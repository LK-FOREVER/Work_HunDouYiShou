using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private GameObject Player;
    //属性
    public float enemyHp;
    public float currentEnemyHp;
    public float enemySpeed;
    public int enemyAtk = 1;
    //移动
    private bool IMoveToPos = true;
    private bool IFreeze;

    private Vector3 d;
    private Vector3 TargetPos;
    private float desPos;
    //旋转的父物体
    public GameObject NpcRotation;
    private Vector3 V = new Vector3(0, 1, 0);
    //血条
    public Text EnemyHpText;
    public Image EnemyHpImage;
    public Canvas PlayerCanvas;
    //音效
    public AudioSource audioSource;
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
    public float normalAtkInterval = 0.15f;
    private Coroutine firingCoroutine;
    private LevelData levelData;
    private int enemyIndex;

    //敌人是否死亡
    private bool isDead;

    void Awake()
    {
        EventManager.Instance.AddListener(EventName.EnemyDamage, EnemyDamage);
    }

    void Start()
    {
        Player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
        levelData = PlayerData.Instance.levelData;
        enemyIndex = levelData.enemy[0].enemy_id - 1;
        currentEnemyHp = enemyHp;
        EnemyHpText.text = currentEnemyHp.ToString();
    }
    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener(EventName.EnemyDamage, EnemyDamage);
        firingCoroutine = null;
    }
    void Update()
    {
        RotateRotationObject();
        if (!IFreeze)
        {
            MoveToTargetPos();
        }
        StartFiring();
    }
    //角色移动
    public void MoveToTargetPos()
    {
        if (IMoveToPos)
        {
            if(Player==null) Player = GameObject.Find("Player");
            TargetPos = Player.transform.position;
            d = (TargetPos - transform.position).normalized;
            desPos = Vector3.Distance(transform.position, TargetPos);
            if (desPos > 4.5f)
            {
                transform.position += d * enemySpeed * Time.deltaTime;
            }
            if (desPos < 2.0f)
            {
                transform.position -= d * enemySpeed * Time.deltaTime;
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
    // 开始连续发射
    public void StartFiring()
    {
        if (firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireContinuously());
    }
    private IEnumerator FireContinuously()
    {
        while (true)
        {
            NormalAtk();
            yield return new WaitForSeconds(normalAtkInterval);
        }
    }
    private void NormalAtk()
    {
        audioSource.clip = acilp[0];
        audioSource.Play();

        // 实例化普通攻击特效，从对象池中获取
        GameObject bullet = ObjectPoolManager.Instance.Get(normalAtkEffect[enemyIndex]);
        if (bullet == null) return;
        //设置是否是玩家子弹
        bullet.GetComponent<BulletController>().SetIsPlayer(false);
        //设置伤害
        bullet.GetComponent<BulletController>().SetDamage(enemyAtk);
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
        ObjectPoolManager.Instance.Return(normalAtkEffect[enemyIndex], bullet);
    }
    //敌人受到攻击
    private void EnemyDamage(object sender, EventArgs e)
    {
        DamageArgs args = e as DamageArgs;
        currentEnemyHp -= args.damage;
        if (currentEnemyHp <= 0)
        {
            currentEnemyHp = 0;
            EnemyDead();
        }
        EnemyHpText.text = currentEnemyHp.ToString();
        EnemyHpImage.fillAmount = currentEnemyHp / enemyHp;
    }
    //敌人死亡
    private void EnemyDead()
    {
        if (isDead) return;
        isDead = true;
        EventManager.Instance.TriggerEvent(EventName.GameEnd, this, new GameEndArgs() { isWin = true });
    }
}


