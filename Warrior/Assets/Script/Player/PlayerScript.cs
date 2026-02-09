using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;
using UnityEngine.EventSystems;
using System;

public class PlayerScript : MonoBehaviour
{
    //属性
    public float hp;//初始血量
    public float currentPlayerHp;//当前血量
    public int atk;//初始攻击力
    public int currentAtk;//当前攻击力
    public float speed;//初始速度
    public float currentSpeed;//当前速度
    //异兽icon
    public Sprite[] WarriorImg;

    //旋转
    public Vector3 d;
    Vector3 V = new Vector3(0, 1, 0);
    public Vector3 TargetPos;
    Vector3 D = new Vector3(0, 1, 0);
    public GameObject RotationObj;

    public Rigidbody2D rig;
    //血量文本
    public Text PlayerHpText;
    //血条
    public Image PlayerHpImage;
    //减少血量文本预制体
    public GameObject decreaseBloodtxtPrefab;
    //减少血量文本父物体
    public GameObject decreaseBloodtxtParent;

    public GameObject m;
    //结束面板
    public GameObject gameEndPanel;

    public bool isPlayerDead;

    public Button StopBtn;

    public Image BlackBackground;
    public AudioSource audioSourcePlayer;
    public AudioClip[] acilp;
    //设置按钮
    public Button SetBtn;
    //音效面板
    public GameObject MusicPanel;

    public bool IEasy;
    public bool INormal;
    public bool IHard;
    public bool IVeryHard;

    //普通攻击特效
    public GameObject[] normalAtkEffect;
    //技能特效
    public GameObject skillEffect_1;
    public GameObject skillEffect_2;
    public GameObject skillEffect_3;
    public GameObject skillEffect_4;
    public GameObject skillEffect_5;
    public GameObject skillEffect_6;
    //普通攻击按钮
    public Button normalAtkBtn;
    // 连发间隔（秒）
    public float normalAtkInterval = 0.15f;
    private Coroutine firingCoroutine;
    // 按住判定阈值（秒）
    private float holdDelay = 0.25f;
    private Coroutine holdDetectCoroutine;
    private bool isHolding;
    //技能攻击按钮
    public Button skillAtkBtn;
    //摇杆
    public GameObject joyStick;
    private JoyStick joyStickScript;
    //当前选择的角色id
    private int ChooseIndex;
    //技能数据
    private SkillData currentSkillData;
    //子弹发射点
    public GameObject bulletPoint;
    //技能特效
    GameObject skillEffect = null;
    //技能持续时间coroutine;
    private Coroutine skillDurationCoroutine;
    //是否开启护盾（技能6）
    private bool isShield;

    public static PlayerScript Instance;
    private void Awake()
    {
        EventManager.Instance.AddListener(EventName.ChangeSound, ChangeSound);
        EventManager.Instance.AddListener(EventName.InitPlayerState, InitPlayerState);
        EventManager.Instance.AddListener(EventName.ChangeWarrior, ChangeIndex);
        EventManager.Instance.AddListener(EventName.PlayerDamage, PlayerDamage);
        EventManager.Instance.AddListener(EventName.GameEnd, GameEnd);
        EventManager.Instance.AddListener(EventName.ResetPlayerState, ResetPlayerState);
    }
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        joyStickScript = joyStick.GetComponent<JoyStick>();

        rig = GetComponent<Rigidbody2D>();
        //普通攻击
        // 单次点击使用 onClick 回调
        normalAtkBtn.onClick.AddListener(OnNormalAtkClicked);
        // 注册按住检测（PointerDown 开始检测，PointerUp/Exit 停止）
        EventTrigger trigger = normalAtkBtn.gameObject.GetComponent<EventTrigger>();
        if (trigger == null) trigger = normalAtkBtn.gameObject.AddComponent<EventTrigger>();

        var entryDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        entryDown.callback.AddListener((data) => { OnPointerDown(); });
        trigger.triggers.Add(entryDown);

        var entryUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        entryUp.callback.AddListener((data) => { OnPointerUp(); });
        trigger.triggers.Add(entryUp);

        var entryExit = new EventTrigger.Entry { eventID = EventTriggerType.PointerExit };
        entryExit.callback.AddListener((data) => { OnPointerUp(); });
        trigger.triggers.Add(entryExit);
        //技能攻击
        skillAtkBtn.onClick.AddListener(OnSkillAtkClicked);
    }
    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener(EventName.ChangeSound, ChangeSound);
        EventManager.Instance.RemoveListener(EventName.InitPlayerState, InitPlayerState);
        EventManager.Instance.RemoveListener(EventName.ChangeWarrior, ChangeIndex);
        EventManager.Instance.RemoveListener(EventName.PlayerDamage, PlayerDamage);
        EventManager.Instance.RemoveListener(EventName.GameEnd, GameEnd);
        EventManager.Instance.RemoveListener(EventName.ResetPlayerState, ResetPlayerState);
    }
    void Update()
    {
        if (isPlayerDead) return;
        Vector2 joystickInput = joyStickScript.GetInputDirection();
        Vector3 joystickInput_3 = new Vector3(joystickInput.x, joystickInput.y, 0);
        transform.position += joystickInput_3.normalized * speed * Time.deltaTime;
        RotateRotationObject();
        //以前的代码
        if (SceneManager.GetSceneByName("LoadScene").isLoaded)
        {
            BlackBackground.gameObject.SetActive(false);
            SetBtn.gameObject.SetActive(false);
            MusicPanel.SetActive(false);
        }

        if (SceneManager.GetSceneByName("GameScene").isLoaded)
        {
            // SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            StopBtn.gameObject.SetActive(true);//显示暂停按钮
        }
        if (SceneManager.GetSceneByName("StartScene").isLoaded)
        {
            BlackBackground.gameObject.SetActive(true);
            SetBtn.gameObject.SetActive(true);//
            StopBtn.gameObject.SetActive(false);
        }
    }
    //旋转方向
    public void RotateRotationObject()
    {
        if (SceneManager.GetActiveScene().name != "GameScene") return;

        float r = Vector3.Angle(V, d);
        //场景中有多个Npc，找到那个距离自己最近的Npc作为TargetPos
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("Npc");
        float minDistance = float.MaxValue;
        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                TargetPos = npc.transform.position;
            }
        }

        D = TargetPos - transform.position;
        d = D.normalized;

        if (d.x < 0)
        {
            RotationObj.transform.rotation = Quaternion.Euler(0, 0, r);
        }
        else
        {
            RotationObj.transform.rotation = Quaternion.Euler(0, 0, -r);
        }
    }
    private void InitPlayerState(object sender, EventArgs e)
    {
        InitPlayerStateArgs args = e as InitPlayerStateArgs;
        hp = args.hp;
        atk = args.atk;
        speed = args.speed;
        PlayerHpText.text = currentPlayerHp.ToString();
        currentPlayerHp = hp;
        currentAtk = atk;
        currentSpeed = speed;
    }
    /// <summary>
    /// 设置当前玩家状态
    /// </summary>
    /// <param name="addHp">添加的血量</param>
    /// <param name="addAtk">添加的攻击力</param>
    /// <param name="addSpeed">添加的移动速度</param>
    /// <param name="isAdd">是否添加属性，true为添加，false为重置</param>
    private void SetCurrentPlayerState(float addHp, int addAtk, float addSpeed, bool isAdd)
    {
        if (isAdd)
        {
            currentPlayerHp += addHp;
            currentAtk += addAtk;
            currentSpeed = (1 + addSpeed) * currentSpeed;
        }
        else
        {
            // currentPlayerHp = currentPlayerHp;
            currentAtk = atk;
            currentSpeed = speed;
        }
        // Debug.Log($"当前玩家状态：CurrentHP={currentPlayerHp}, CurrentATK={currentAtk}, CurrentSpeed={currentSpeed}");
    }
    private void NormalAtk()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.NormalAtk });
        // 实例化普通攻击特效，从对象池中获取
        GameObject bullet = ObjectPoolManager.Instance.Get(normalAtkEffect[ChooseIndex - 1]);
        if (bullet == null) return;
        //设置是否是玩家子弹
        bullet.GetComponent<BulletController>().SetIsPlayer(true);
        // 设置子弹的伤害值
        bullet.GetComponent<BulletController>().SetDamage(currentAtk);
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
        ObjectPoolManager.Instance.Return(normalAtkEffect[ChooseIndex - 1], bullet);
    }
    // 开始连续发射
    public void StartFiring()
    {
        if (firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireContinuously());
    }

    // 停止连续发射
    public void StopFiring()
    {
        if (firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            NormalAtk();
            yield return new WaitForSeconds(normalAtkInterval);
        }
    }

    // 按住检测与回调
    private void OnPointerDown()
    {
        if (holdDetectCoroutine == null)
            holdDetectCoroutine = StartCoroutine(HoldDetect());
    }

    private void OnPointerUp()
    {
        // 取消未触发的 hold 检测
        if (holdDetectCoroutine != null)
        {
            StopCoroutine(holdDetectCoroutine);
            holdDetectCoroutine = null;
        }

        // 若正在长按模式，则停止连发
        if (isHolding)
        {
            StopFiring();
            isHolding = false;
        }
    }

    private IEnumerator HoldDetect()
    {
        yield return new WaitForSeconds(holdDelay);
        holdDetectCoroutine = null;
        isHolding = true;
        StartFiring();
    }

    // 单次点击回调（只在非长按时触发）
    private void OnNormalAtkClicked()
    {
        if (!isHolding)
            NormalAtk();
    }
    // 技能攻击
    private void OnSkillAtkClicked()
    {
        //每日任务
        PlayerData.Instance.dailyTaskProgress[5]++;
        //成就任务
        PlayerData.Instance.achievementTaskProgress[9]++;
        PlayerData.Instance.achievementTaskProgress[10]++;
        PlayerData.Instance.achievementTaskProgress[11]++;
        PlayerData.Instance.SaveData();
        // 实例化技能特效
        if (ChooseIndex == 1)
        {
            skillEffect = Instantiate(skillEffect_1);
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.SkillEffect_1 });
        }
        else if (ChooseIndex == 2)
        {
            skillEffect = Instantiate(skillEffect_2);
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.SkillEffect_2 });
        }
        else if (ChooseIndex == 3)
        {
            skillEffect = Instantiate(skillEffect_3);
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.SkillEffect_3 });
        }
        else if (ChooseIndex == 4)
        {
            skillEffect_4.SetActive(true);
            skillEffect = skillEffect_4;
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.SkillEffect_4 });
        }
        else if (ChooseIndex == 5)
        {
            skillEffect_5.SetActive(true);
            skillEffect = skillEffect_5;
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.SkillEffect_5 });
        }
        else if (ChooseIndex == 6)
        {
            skillEffect_6.SetActive(true);
            skillEffect = skillEffect_6;
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.SkillEffect_6 });
        }
        if (skillEffect == null) return;
        // 获取当前技能数据
        currentSkillData = PlayerData.Instance.skillData[ChooseIndex - 1];

        if (ChooseIndex != 3)
        {
            if (ChooseIndex == 1 || ChooseIndex == 2)
            {
                // 设置技能特效的父物体
                skillEffect.transform.SetParent(bulletPoint.transform, false);
                //设置是否是玩家技能
                skillEffect.GetComponent<SkillController>().SetIsPlayerSkill(true);
                // 设置技能的伤害值
                skillEffect.GetComponent<SkillController>().SetSkillDamage(currentSkillData.skill_damage);
                //设置技能增加的属性值
                SetCurrentPlayerState(0, currentSkillData.add_atk, currentSkillData.add_speed, true);
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
            if (ChooseIndex == 4 || ChooseIndex == 5)
            {
                //设置技能增加的属性值
                SetCurrentPlayerState(0, currentSkillData.add_atk, currentSkillData.add_speed, true);
            }
            if (ChooseIndex == 6)
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
                skillEffect.transform.GetChild(i).GetComponent<SkillController>().SetIsPlayerSkill(true);
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

        SkillCooldown(currentSkillData.skill_cooldown);
        SkillDuration(currentSkillData.continue_time);
    }
    //技能冷却
    private void SkillCooldown(float coolDownTime)
    {
        EventManager.Instance.TriggerEvent(EventName.SkillCoolDown, this, new CoolDownArgs { coolDownTime = coolDownTime });
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
        SetCurrentPlayerState(0, -currentSkillData.add_atk, -currentSkillData.add_speed, false);
        if (skillEffect != null && (ChooseIndex == 4 || ChooseIndex == 5 || ChooseIndex == 6))
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

    private void PlayerDamage(object sender, EventArgs e)
    {
        DamageArgs args = e as DamageArgs;
        if (isShield) return;
        DecreasePlayerHp(args.damage);
    }
    public void DecreasePlayerHp(float value)
    {
        if (isPlayerDead) return;
        // 创建减少血量的文字
        GameObject decreaseBloodtxt = Instantiate(decreaseBloodtxtPrefab);
        decreaseBloodtxt.GetComponent<Text>().text = "-" + value.ToString();
        decreaseBloodtxt.transform.SetParent(decreaseBloodtxtParent.transform, false);
        StartCoroutine(DelayReturnTxt(decreaseBloodtxt));
        //减少玩家血量
        currentPlayerHp -= value;
        if (currentPlayerHp <= 0)
        {
            currentPlayerHp = 0;
            isPlayerDead = true;
            EventManager.Instance.TriggerEvent(EventName.GameEnd, this, new GameEndArgs { isWin = false });
        }

        PlayerHpImage.fillAmount = currentPlayerHp / hp;
        PlayerHpText.text = ((int)currentPlayerHp).ToString();
    }
    private IEnumerator DelayReturnTxt(GameObject bloodTxt)
    {
        yield return new WaitForSeconds(2f); // 等待1秒
        Destroy(bloodTxt);
    }
    private void GameEnd(object sender, EventArgs e)
    {
        GameEndArgs args = e as GameEndArgs;
        //查找场景中的DecreaseBloodtxt(clone)预制体
        GameObject[] decreaseBloodtxts = GameObject.FindGameObjectsWithTag("bloodTxt");
        //隐藏所有DecreaseBloodtxt(clone)预制体
        if (decreaseBloodtxts.Length != 0)
        {
            foreach (GameObject txt in decreaseBloodtxts)
            {
                txt.SetActive(false);
            }
        }
        //计算玩家剩余血量百分比
        float remainingHpPercentage = currentPlayerHp / hp;
        //结束弹窗
        gameEndPanel.gameObject.SetActive(true);
        gameEndPanel.GetComponent<GameEndPanel>().Init(args.isWin, remainingHpPercentage);
        Time.timeScale = 0.0f;
    }
    //结束游戏时，重新开始游戏，重置玩家状态
    public void ResetPlayerState(object sender, EventArgs e)
    {
        isPlayerDead = false;
        currentPlayerHp = hp;
        currentAtk = atk;
        currentSpeed = speed;
        PlayerHpImage.fillAmount = currentPlayerHp / hp;
        PlayerHpText.text = currentPlayerHp.ToString();
        // 停止并清理正在运行的协程，避免旧协程在重置后继续生效
        if (firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        if (holdDetectCoroutine != null)
        {
            StopCoroutine(holdDetectCoroutine);
            holdDetectCoroutine = null;
        }
        if (skillDurationCoroutine != null)
        {
            StopCoroutine(skillDurationCoroutine);
            skillDurationCoroutine = null;
        }

        ClearPlayerBullets();

        // 如果有当前技能实例，先关闭并清除引用
        if (skillEffect != null)
        {
            try { skillEffect.SetActive(false); } catch { }
            skillEffect = null;
        }

        // 关闭可能的技能预制物（兜底）
        skillEffect_4.SetActive(false);
        skillEffect_5.SetActive(false);
        skillEffect_6.SetActive(false);
        // 关闭护盾状态
        isShield = false;
    }
    //清除玩家子弹
    private void ClearPlayerBullets()
    {
        Transform t = bulletPoint.transform;
        for (int i = t.childCount - 1; i >= 0; i--)
        {
            var child = t.GetChild(i).gameObject;
            if (child != null)
                Destroy(child);
        }
    }
    private void ChangeIndex(object sender, EventArgs e)
    {
        ChangeWarriorArgs args = e as ChangeWarriorArgs;
        ChooseIndex = args.index_monster;
        // Debug.Log("ChooseIndex:" + ChooseIndex);
    }
    private void ChangeSound(object sender, EventArgs e)
    {
        ChangeSoundArgs args = e as ChangeSoundArgs;
        audioSourcePlayer.clip = acilp[args.index_sound];
        audioSourcePlayer.Play();
    }
}
