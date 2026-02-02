using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
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
    public GameObject RotationIcon;

    public Rigidbody2D rig;
    public Text PlayerHpText;//血量文本
    public Image PlayerHpImage;//血条

    public GameObject m;
    public GameObject gameEndPanel;//结束面板

    public bool isPlayerDead;

    public Button StopBtn;

    public Image BlackBackground;
    public AudioSource audio;
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

    public static PlayerScript Instance;
    private void Awake()
    {
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

        audio = GetComponent<AudioSource>();
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
        EventManager.Instance.RemoveListener(EventName.InitPlayerState, InitPlayerState);
        EventManager.Instance.RemoveListener(EventName.ChangeWarrior, ChangeIndex);
        EventManager.Instance.RemoveListener(EventName.PlayerDamage, PlayerDamage);
        EventManager.Instance.RemoveListener(EventName.GameEnd, GameEnd);
        EventManager.Instance.RemoveListener(EventName.ResetPlayerState, ResetPlayerState);
    }
    void Update()
    {
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
        TargetPos = GameObject.FindWithTag("Npc").transform.position;

        D = TargetPos - transform.position;
        d = D.normalized;

        if (d.x < 0)
        {
            RotationIcon.transform.rotation = Quaternion.Euler(0, 0, r);
        }
        else
        {
            RotationIcon.transform.rotation = Quaternion.Euler(0, 0, -r);
        }
    }
    private void InitPlayerState(object sender, EventArgs e)
    {
        InitPlayerStateArgs args = e as InitPlayerStateArgs;
        hp = args.hp;
        atk = args.atk;
        speed = args.speed;
        PlayerHpText.text = currentPlayerHp.ToString();
        currentPlayerHp = 0;
        currentAtk = 0;
        currentSpeed = 0;
        SetCurrentPlayerState(hp, atk, speed);
    }
    private void SetCurrentPlayerState(float addHp, int addAtk, float addSpeed)
    {
        currentPlayerHp += addHp;
        currentAtk += addAtk;
        currentSpeed += addSpeed;
        Debug.Log($"当前玩家状态：CurrentHP={currentPlayerHp}, CurrentATK={currentAtk}, CurrentSpeed={currentSpeed}");
    }
    private void NormalAtk()
    {
        audio.clip = acilp[0];
        audio.Play();

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
        audio.clip = acilp[1];
        audio.Play();
        if (ChooseIndex == 1)
        {
            // 实例化技能特效
            skillEffect = Instantiate(skillEffect_1);
        }
        else if (ChooseIndex == 2)
        {
            skillEffect = Instantiate(skillEffect_2);
        }
        else if (ChooseIndex == 3)
        {
            skillEffect = Instantiate(skillEffect_3);
        }
        else if (ChooseIndex == 4)
        {
            skillEffect_4.SetActive(true);
            skillEffect = skillEffect_4;
        }
        else if (ChooseIndex == 5)
        {
            skillEffect_5.SetActive(true);
            skillEffect = skillEffect_5;
        }
        else if (ChooseIndex == 6)
        {
            skillEffect_6.SetActive(true);
            skillEffect = skillEffect_6;
        }
        if (skillEffect == null) return;
        // 获取当前技能数据
        currentSkillData = PlayerData.Instance.skillData[ChooseIndex - 1];
        // 设置技能特效的父物体
        skillEffect.transform.SetParent(bulletPoint.transform, false);
        if (ChooseIndex != 3)
        {
            //设置是否是玩家技能
            skillEffect.GetComponent<SkillController>().SetIsPlayerSkill(true);
            // 设置技能的伤害值
            skillEffect.GetComponent<SkillController>().SetSkillDamage(currentSkillData.skill_damage);
            //设置技能增加的属性值
            SetCurrentPlayerState(0, currentSkillData.add_atk, currentSkillData.add_speed);
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
        else
        {
            //羽毛技能
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
        SetCurrentPlayerState(0, -currentSkillData.add_atk, -currentSkillData.add_speed);
        if (skillEffect != null && ChooseIndex == 4 || ChooseIndex == 5 || ChooseIndex == 6)
        {
            skillEffect.SetActive(false);
            skillEffect = null;
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
        DecreasePlayerHp(args.damage);
    }
    public void DecreasePlayerHp(float value)
    {
        currentPlayerHp -= value;
        if (currentPlayerHp <= 0)
        {
            currentPlayerHp = 0;
            if (isPlayerDead) return;
            isPlayerDead = true;
            EventManager.Instance.TriggerEvent(EventName.GameEnd, this, new GameEndArgs { isWin = false });
        }

        PlayerHpImage.fillAmount = currentPlayerHp / hp;
        // Debug.Log("EnemyDamage: " + value + "currentPlayerHp: " + currentPlayerHp + "hp: " + hp + "PlayerHpImage.fillAmount: " + PlayerHpImage.fillAmount);

        PlayerHpText.text = currentPlayerHp.ToString();
    }
    private void GameEnd(object sender, EventArgs e)
    {
        GameEndArgs args = e as GameEndArgs;
        gameEndPanel.gameObject.SetActive(true);
        gameEndPanel.GetComponent<GameEndPanel>().Init(args.isWin);
        Time.timeScale = 0.0f;
    }
    //结束游戏时，重新开始游戏，重置玩家状态
    public void ResetPlayerState(object sender, EventArgs e)
    {
        isPlayerDead = false;
        currentPlayerHp = hp;
        PlayerHpImage.fillAmount = currentPlayerHp / hp;
        PlayerHpText.text = currentPlayerHp.ToString();
        holdDetectCoroutine = null;
    }
    private void ChangeIndex(object sender, EventArgs e)
    {
        ChangeWarriorArgs args = e as ChangeWarriorArgs;
        ChooseIndex = args.index_monster;
        Debug.Log("ChooseIndex:" + ChooseIndex);
    }
}
