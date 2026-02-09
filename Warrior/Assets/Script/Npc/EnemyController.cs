using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private GameObject Player;
    //属性
    public int enemyHp;
    public int currentEnemyHp;
    public float enemySpeed;
    public float currentEnemySpeed;
    public int enemyAtk = 1;
    public int currentEnemyAtk;
    //移动
    private bool IMoveToPos = true;
    private bool moveToPlayer = true;
    private Vector3 d;
    private Vector3 TargetPos;
    private float desPos;
    private Vector3 newTargetPos;
    //旋转的父物体
    public GameObject NpcRotation;
    private Vector3 V = new Vector3(0, 1, 0);
    //血条
    public Text enemyHpText;
    public Image enemyHpImage;
    //减少血量文本预制体
    public GameObject decreaseBloodtxtPrefab;
    //减少血量文本父物体
    public GameObject decreaseBloodtxtParent;

    //音效
    public AudioSource audioSourceEnemy;
    public AudioClip[] acilp;
    //普通攻击特效
    public GameObject[] normalAtkEffect;
    //技能特效
    public GameObject skillEffect_1;
    public GameObject skillEffect_2;
    public GameObject skillEffect_3;
    public GameObject skillEffect_4;
    public GameObject skillEffect_5;
    public GameObject skillEffect_6;
    //子弹发射点
    public GameObject bulletPoint;
    // 连发间隔（秒）
    private float normalAtkInterval = 0.35f;
    private Coroutine firingCoroutine;
    // 延迟协程，目标切换协程
    private Coroutine delayCoroutine;
    private Coroutine targetChangeCoroutine;
    // 目标切换间隔（秒）
    public float targetChangeInterval = 7f;
    private LevelData levelData;
    //敌人索引
    private int enemyIndex;
    //敌人唯一标记ID,用于判断玩家子弹打中的是哪儿个敌人
    private int enemyID;
    //技能特效
    GameObject skillEffect = null;
    //技能数据
    private SkillData currentSkillData;
    //技能持续时间coroutine;
    private Coroutine skillDurationCoroutine;
    //技能冷却时间coroutine;
    private Coroutine skillCooldownCoroutine;
    //是否处于冷却状态
    private bool isCoolDown;
    //是否开启护盾（技能6）
    private bool isShield;

    //敌人是否死亡
    private bool isEnemyDead;
    //是否转向完成
    private bool isdelay = false;
    //是否可以普通攻击
    public bool canFire = true;

    void Awake()
    {
        EventManager.Instance.AddListener(EventName.EnemyDamage, EnemyDamage);
    }

    void Start()
    {
        Player = GameObject.Find("Player");
        //设置敌人的音量
        audioSourceEnemy.volume = PlayerPrefs.GetFloat(SdkScript.nickname + "Sound", 0.5f);
        enemyHpText.text = currentEnemyHp.ToString();
    }
    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener(EventName.EnemyDamage, EnemyDamage);
        if (firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        if (delayCoroutine != null)
        {
            StopCoroutine(delayCoroutine);
            delayCoroutine = null;
        }
        if (targetChangeCoroutine != null)
        {
            StopCoroutine(targetChangeCoroutine);
            targetChangeCoroutine = null;
        }
    }
    void Update()
    {
        if (!isEnemyDead)
        {
            RotateRotationObject();
            if (moveToPlayer)
            {
                MoveToPlayerPos();
            }

            // 添加状态监控
            if (isdelay && !IMoveToPos && canFire)
            {
                Debug.LogWarning($"Enemy Update: State inconsistency - isdelay={isdelay}, IMoveToPos={IMoveToPos}, canFire={canFire}");
            }

            //延迟0.5秒再开始攻击
            if (!isdelay && delayCoroutine == null)
            {
                delayCoroutine = StartCoroutine(FireContinuouslyDelay());
            }

            if (isdelay)
            {
                if (canFire)
                {
                    if (IMoveToPos && firingCoroutine == null)
                    {
                        StartFiring();
                    }
                }
                if (!isCoolDown) OnSkillAtkClicked();
            }
        }
    }
    private IEnumerator FireContinuouslyDelay()
    {
        yield return new WaitForSeconds(0.5f);
        isdelay = true;
        // 一次性启动每隔若干秒切换目标的位置协程
        if (targetChangeCoroutine == null)
        {
            targetChangeCoroutine = StartCoroutine(CreateRandomTargetPos());
        }
        // 标记完毕，清理引用
        delayCoroutine = null;
    }
    //角色移动
    public void MoveToPlayerPos()
    {
        if (IMoveToPos)
        {
            if (Player == null) Player = GameObject.Find("Player");
            TargetPos = Player.transform.position;
            d = (TargetPos - transform.position).normalized;
            float minDist = 3.0f;
            float maxDist = 7.5f;
            desPos = Vector3.Distance(transform.position, TargetPos);
            // 依据超出最小距离的程度平滑插值后退速度（距离越小，后退越快）
            float t = Mathf.Clamp01((minDist - desPos) / minDist); // 0..1

            // 平滑靠近逻辑：目标保持在 desiredDistance 处，靠近时速度按距离差平滑缩放
            float desiredDistance = (minDist + maxDist) * 0.5f; // 中间安全距离
            if (desPos > desiredDistance)
            {
                float approachFactor = Mathf.Clamp01((desPos - desiredDistance) / (maxDist - desiredDistance));
                float approachSpeed = enemySpeed * Mathf.Lerp(0.5f, 1f, approachFactor); // 接近时逐步加速到 full speed
                Vector3 desiredPos = TargetPos - d * desiredDistance;
                transform.position = Vector3.MoveTowards(transform.position, desiredPos, approachSpeed * Time.deltaTime);
            }

            // 当玩家过于接近时，平滑地后退以避免生硬抖动
            if (desPos < minDist)
            {
                transform.position += (-d) * enemySpeed * t * Time.deltaTime;
            }
        }
    }
    // 旋转
    public void RotateRotationObject()
    {
        float r = Vector3.Angle(V, d);
        if (d.x < 0)
        {
            NpcRotation.transform.rotation = Quaternion.Euler(0, 0, r);
        }
        else
        {
            NpcRotation.transform.rotation = Quaternion.Euler(0, 0, -r);
        }
    }
    //每过一段时间，让敌人向其他位置移动（非阻塞）
    private IEnumerator MoveToOtherPosCoroutine(Vector3 target)
    {
        if (!IMoveToPos) yield break;
        // 在移动到其他位置期间，不再跟随玩家
        moveToPlayer = false;

        // 停止普攻协程
        if (firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        canFire = false;
        IMoveToPos = false;

        // 计算初始距离
        float initialDistance = Vector3.Distance(transform.position, target);

        // 设定到达目标的阈值（更小的值，确保真正到达）
        float arrivalThreshold = 0.1f; // 改为更小的阈值

        // 添加超时保护
        float maxMoveTime = 5f; // 最大移动时间
        float moveStartTime = Time.time;

        // 使用简单的 MoveTowards 移动，确保能真正到达目标
        while (Vector3.Distance(transform.position, target) > arrivalThreshold)
        {
            // 检查是否超时
            if (Time.time - moveStartTime > maxMoveTime)
            {
                transform.position = target;
                break;
            }

            // 计算移动方向
            Vector3 moveDirection = (target - transform.position).normalized;
            d = moveDirection; // 更新方向向量用于旋转

            // 计算当前距离
            float currentDistance = Vector3.Distance(transform.position, target);

            // 根据距离调整速度（越近越慢，避免过冲）
            float speedFactor = Mathf.Clamp01(currentDistance / initialDistance);
            float currentSpeed = enemySpeed * Mathf.Lerp(0.3f, 1f, speedFactor);

            // 直接向目标位置移动
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                currentSpeed * Time.deltaTime
            );

            // 输出调试信息
            if (Time.time - moveStartTime > 5f) // 如果移动超过5秒还没到达
            {
                Debug.Log($"Enemy: Still moving. Distance to target: {currentDistance}, Position: {transform.position}");
            }

            yield return null;
        }

        // 确保最终位置精确到达
        transform.position = target;

        // 到达目标位置，恢复状态
        canFire = true;
        IMoveToPos = true;

        // 立即更新方向朝向玩家
        if (Player == null)
            Player = GameObject.Find("Player");

        if (Player != null)
        {
            Vector3 toPlayer = (Player.transform.position - transform.position);
            // 确保方向向量非零
            if (toPlayer.sqrMagnitude > 0.0001f)
            {
                d = toPlayer.normalized;
            }
            else
            {
                d = new Vector3(0, 1, 0);
            }
            // 强制更新旋转
            RotateRotationObject();
        }
        else
        {
        }

        // 恢复跟随玩家行为
        moveToPlayer = true;

        // 等待一帧确保所有状态更新
        yield return null;

        // 立即开始射击
        if (canFire && IMoveToPos)
        {
            // 确保firingCoroutine为空，避免重复启动
            if (firingCoroutine == null)
            {
                StartFiring();
            }
            else
            {
            }
        }
        else
        {
            // 如果状态不对，强制恢复
            ForceRecovery();
        }
    }
    //每隔 targetChangeInterval 秒随机生成TargetPos并移动过去
    private IEnumerator CreateRandomTargetPos()
    {
        while (true)
        {
            yield return new WaitForSeconds(targetChangeInterval);

            // 确保敌人还活着
            if (isEnemyDead) yield break;

            // 生成随机位置，确保在有效范围内
            newTargetPos = new Vector3(
                UnityEngine.Random.Range(25f, 33f),
                UnityEngine.Random.Range(-42f, -28f),
                0
            );
            // 检查目标位置是否太近
            float distanceToTarget = Vector3.Distance(transform.position, newTargetPos);
            if (distanceToTarget < 1f)
            {
                // 生成一个更远的位置
                newTargetPos = transform.position + new Vector3(
                    UnityEngine.Random.Range(-5f, 5f),
                    UnityEngine.Random.Range(-5f, 5f),
                    0
                ).normalized * 3f; // 至少3个单位距离
            }

            // 开始移动，并等待移动完成
            yield return StartCoroutine(MoveToOtherPosCoroutine(newTargetPos));

            // 移动完成后，再次检查状态并强制恢复
            yield return new WaitForSeconds(0.5f); // 给一点时间让状态稳定

            if (!isEnemyDead && canFire && IMoveToPos && firingCoroutine == null)
            {
                ForceRecovery();
            }
        }
    }
    // 外部可调用的恢复方法
    public void ForceRecovery()
    {
        if (isEnemyDead)
        {
            return;
        }

        //如果正在移动到其他位置，则return
        if (!IMoveToPos)
        {
            return;
        }

        // 确保玩家引用有效
        if (Player == null || !Player.activeInHierarchy)
        {
            Player = GameObject.Find("Player");
        }

        // 更新方向
        if (Player != null && Player.activeInHierarchy)
        {
            Vector3 toPlayer = Player.transform.position - transform.position;
            if (toPlayer.sqrMagnitude > 0.0001f)
            {
                d = toPlayer.normalized;
            }
            else
            {
            }
        }
        else
        {
        }

        // 更新旋转
        RotateRotationObject();

        // 恢复射击
        ForceRestartFiring();
    }
    // 强制重新启动射击的方法
    private void ForceRestartFiring()
    {
        // 确保停止任何现有的射击协程
        if (firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

        // 确保可以发射子弹
        canFire = true;

        // 验证方向是否有效
        if (d.sqrMagnitude < 0.0001f && Player != null && Player.activeInHierarchy)
        {
            d = (Player.transform.position - transform.position).normalized;
            if (d.sqrMagnitude < 0.0001f)
                d = new Vector3(0, 1, 0);
        }

        // 立即更新旋转
        RotateRotationObject();

        // 启动射击协程
        if (canFire && !isEnemyDead)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
    }
    // 普通攻击
    public void StartFiring()
    {
        if (firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else
        {
        }
    }
    private IEnumerator FireContinuously()
    {
        // 等一帧以保证朝向/物理稳定
        yield return null;

        while (true)
        {
            // 验证方向是否有效
            if (d.sqrMagnitude < 0.01f)
            {
                if (Player != null)
                {
                    d = (Player.transform.position - transform.position).normalized;
                }
                else
                {
                    d = new Vector3(0, 1, 0);
                }
            }

            NormalAtk();
            yield return new WaitForSeconds(normalAtkInterval);
        }
    }
    private void NormalAtk()
    {
        // 验证方向
        if (d.sqrMagnitude < 0.01f)
        {
            if (Player != null)
            {
                d = (Player.transform.position - transform.position).normalized;
            }
            else
            {
                return;
            }
        }

        audioSourceEnemy.clip = acilp[(int)SoundType.NormalAtk];
        audioSourceEnemy.Play();

        // 实例化普通攻击特效，从对象池中获取
        GameObject bullet = ObjectPoolManager.Instance.Get(normalAtkEffect[enemyIndex - 1]);
        if (bullet == null)
        {
            // 降级：直接实例化预制体，避免因对象池暂时空而不发射
            bullet = Instantiate(normalAtkEffect[enemyIndex - 1]);
            if (bullet == null) return;
        }
        //设置是否是玩家子弹
        bullet.GetComponent<BulletController>().SetIsPlayer(false);
        //设置伤害
        bullet.GetComponent<BulletController>().SetDamage(currentEnemyAtk);
        // Debug.Log("敌人普通攻击伤害:" + enemyAtk);
        //设置父物体
        bullet.transform.SetParent(bulletPoint.transform, false);

        //旋转子弹，使其指向发射的方向
        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, d) * Quaternion.Euler(0, 0, 90);
        //获取子弹的刚体
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // 禁用重力，防止子弹下落
            rb.gravityScale = 0f;
            // 重置速度以避免池内残留速度影响
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.AddForce(d * 10f, ForceMode2D.Impulse);
        }
        // 添加延迟回收，让子弹完成其功能
        StartCoroutine(DelayReturnEffect(bullet));
    }
    private IEnumerator DelayReturnEffect(GameObject bullet)
    {
        yield return new WaitForSeconds(2f); // 等待2秒
        ObjectPoolManager.Instance.Return(normalAtkEffect[enemyIndex - 1], bullet);
    }
    //释放技能
    private void OnSkillAtkClicked()
    {
        if (enemyIndex == 1)
        {
            // 实例化技能特效
            skillEffect = Instantiate(skillEffect_1);
            audioSourceEnemy.clip = acilp[(int)SoundType.SkillEffect_1];
        }
        else if (enemyIndex == 2)
        {
            skillEffect = Instantiate(skillEffect_2);
            audioSourceEnemy.clip = acilp[(int)SoundType.SkillEffect_2];
        }
        else if (enemyIndex == 3)
        {
            skillEffect = Instantiate(skillEffect_3);
            audioSourceEnemy.clip = acilp[(int)SoundType.SkillEffect_3];
        }
        else if (enemyIndex == 4)
        {
            skillEffect_4.SetActive(true);
            skillEffect = skillEffect_4;
            audioSourceEnemy.clip = acilp[(int)SoundType.SkillEffect_4];
        }
        else if (enemyIndex == 5)
        {
            skillEffect_5.SetActive(true);
            skillEffect = skillEffect_5;
            audioSourceEnemy.clip = acilp[(int)SoundType.SkillEffect_5];
        }
        else if (enemyIndex == 6)
        {
            skillEffect_6.SetActive(true);
            skillEffect = skillEffect_6;
            audioSourceEnemy.clip = acilp[(int)SoundType.SkillEffect_6];
        }
        if (skillEffect == null) return;
        // 获取当前技能数据
        currentSkillData = PlayerData.Instance.skillData[enemyIndex - 1];

        if (enemyIndex != 3)
        {
            if (enemyIndex == 1 || enemyIndex == 2)
            {
                // 设置技能特效的父物体
                skillEffect.transform.SetParent(bulletPoint.transform, false);
                //设置是否是玩家技能
                skillEffect.GetComponent<SkillController>().SetIsPlayerSkill(false);
                // 设置技能的伤害值
                skillEffect.GetComponent<SkillController>().SetSkillDamage(currentSkillData.skill_damage);
                //设置技能增加的属性值
                SetCurrentEnemyState(0, currentSkillData.add_atk, currentSkillData.add_speed, true);
                //旋转技能效果，使其指向发射的方向
                skillEffect.transform.rotation = Quaternion.LookRotation(Vector3.forward, d) * Quaternion.Euler(0, 0, 90);
                //获取技能特效的刚体
                Rigidbody2D rb = skillEffect.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 0f;
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                    rb.AddForce(d * 6f, ForceMode2D.Impulse);
                }
            }
            if (enemyIndex == 4 || enemyIndex == 5)
            {
                //设置技能增加的属性值
                SetCurrentEnemyState(0, currentSkillData.add_atk, currentSkillData.add_speed, true);
            }
            if (enemyIndex == 6)
            {
                //开启护盾，免疫所有敌人伤害
                isShield = true;
            }
        }
        else
        {
            //羽毛技能
            // 设置技能特效的父物体
            skillEffect.transform.SetParent(bulletPoint.transform, false);
            //遍历skillEffect的所有子物体
            for (int i = 0; i < skillEffect.transform.childCount; i++)
            {
                skillEffect.transform.GetChild(i).GetComponent<SkillController>().SetIsPlayerSkill(false);
                skillEffect.transform.GetChild(i).GetComponent<SkillController>().SetSkillDamage(currentSkillData.skill_damage);
                // skillEffect.transform.GetChild(i).transform.rotation = Quaternion.LookRotation(Vector3.forward, d) * Quaternion.Euler(0, 0, 90);
                Rigidbody2D rb = skillEffect.transform.GetChild(i).GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 0f;
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                    rb.AddForce(d * 6f, ForceMode2D.Impulse);
                }
            }
            //过5秒后销毁羽毛技能的父物体
            StartCoroutine(DestroyParentAfterDelay(5f));
        }
        audioSourceEnemy.Play();
        SkillCooldown(currentSkillData.skill_cooldown);
        SkillDuration(currentSkillData.continue_time);
    }
    //技能冷却
    private void SkillCooldown(float coolDownTime)
    {
        if (skillCooldownCoroutine != null)
        {
            StopCoroutine(skillCooldownCoroutine);
        }
        skillCooldownCoroutine = StartCoroutine(SkillCooldownCoroutine(coolDownTime));
    }
    //技能冷却协程
    private IEnumerator SkillCooldownCoroutine(float coolDownTime)
    {
        isCoolDown = true;
        float timer = 0;
        while (timer < coolDownTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        // 技能冷却结束后，再次释放技能
        isCoolDown = false;
    }

    //技能持续时间
    private void SkillDuration(int durationTime)
    {
        if (skillDurationCoroutine != null)
        {
            StopCoroutine(skillDurationCoroutine);
        }
        skillDurationCoroutine = StartCoroutine(SkillDurationCoroutine(durationTime));
    }
    //技能持续时间协程
    private IEnumerator SkillDurationCoroutine(float durationTime)
    {
        float timer = 0;
        while (timer < durationTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        // 技能持续时间结束后，重置玩家状态
        SetCurrentEnemyState(0, -currentSkillData.add_atk, -currentSkillData.add_speed, false);
        if (skillEffect != null && enemyIndex == 4 || enemyIndex == 5 || enemyIndex == 6)
        {
            skillEffect.SetActive(false);
            skillEffect = null;
            //关闭护盾
            isShield = false;
        }
    }
    //过5秒后销毁羽毛技能的父物体
    private IEnumerator DestroyParentAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(skillEffect);
    }
    /// <summary>
    /// 设置当前玩家状态
    /// </summary>
    /// <param name="addHp">添加的血量</param>
    /// <param name="addAtk">添加的攻击力</param>
    /// <param name="addSpeed">添加的移动速度</param>
    /// <param name="isAdd">是否添加属性，true为添加，false为重置</param>
    private void SetCurrentEnemyState(int addHp, int addAtk, float addSpeed, bool isAdd)
    {
        if (isAdd)
        {
            currentEnemyHp += addHp;
            currentEnemyAtk += addAtk;
            currentEnemySpeed = (1 + addSpeed) * currentEnemySpeed;
        }
        else
        {
            // currentEnemyHp = currentEnemyHp;
            currentEnemyAtk = enemyAtk;
            currentEnemySpeed = enemySpeed;
        }
        // Debug.Log($"当前敌人状态：CurrentHP={currentEnemyHp}, CurrentATK={currentEnemyAtk}, CurrentSpeed={currentEnemySpeed}");
    }
    //碰到障碍物
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // // 添加超时保护
            // float maxTouchTime = 2.5f; // 最大碰到障碍物时间
            // float touchStartTime = Time.time;
            // while (collision.gameObject.CompareTag("Obstacle"))
            // {
            //     // 检查是否超时
            //     if (Time.time - touchStartTime > maxTouchTime)
            //     {
            //         if (newTargetPos != Vector3.zero)
            //             transform.position = newTargetPos;
            //     }
            // }
        }
    }
    //敌人受到攻击
    private void EnemyDamage(object sender, EventArgs e)
    {
        DamageArgs args = e as DamageArgs;
        if (args.enemyID != enemyID) return;//玩家子弹打中的不是该敌人
        if (isEnemyDead) return;
        if (isShield) return;
        // 创建减少血量的文字
        GameObject decreaseBloodtxt = Instantiate(decreaseBloodtxtPrefab);
        decreaseBloodtxt.GetComponent<Text>().text = "-" + args.damage.ToString();
        decreaseBloodtxt.transform.SetParent(decreaseBloodtxtParent.transform, false);
        StartCoroutine(DelayReturnTxt(decreaseBloodtxt));
        //减少敌人血量
        currentEnemyHp -= args.damage;
        if (currentEnemyHp <= 0)
        {
            currentEnemyHp = 0;
            EnemyDead();
        }
        enemyHpText.text = currentEnemyHp.ToString();
        enemyHpImage.fillAmount = (float)currentEnemyHp / enemyHp;
    }
    private IEnumerator DelayReturnTxt(GameObject bloodTxt)
    {
        yield return new WaitForSeconds(2f); // 等待2秒
        Destroy(bloodTxt);
    }
    //敌人死亡
    private void EnemyDead()
    {
        isEnemyDead = true;
        Destroy(gameObject);
        if (!PlayerData.Instance.isBattle)
        {
            PlayerData.Instance.enemyAliveCount--;
            if (PlayerData.Instance.enemyAliveCount <= 0)
            {
                //游戏结束
                EventManager.Instance.TriggerEvent(EventName.GameEnd, this, new GameEndArgs() { isWin = true });
            }
        }
        else
        {
            EventManager.Instance.TriggerEvent(EventName.GameEnd, this, new GameEndArgs() { isWin = true });
        }

        //每日任务
        PlayerData.Instance.dailyTaskProgress[6]++;
        //成就任务
        PlayerData.Instance.achievementTaskProgress[6]++;
        PlayerData.Instance.achievementTaskProgress[7]++;
        PlayerData.Instance.achievementTaskProgress[8]++;
        PlayerData.Instance.SaveData();
    }
    public void setEnemyIndex(int index)
    {
        enemyIndex = index;
    }
    public void setEnemyID(int id)
    {
        enemyID = id;
    }
    public int getEnemyID()
    {
        return enemyID;
    }
}


