using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // 子弹伤害
    private int damage;
    //子弹是谁发射的
    private bool isPlayer;
    //是否结束
    private bool isOver;
    void Awake()
    {
        EventManager.Instance.AddListener(EventName.GameEnd, SetIsOver);
        EventManager.Instance.AddListener(EventName.GameStart, SetIsStart);
    }
    void OnDestroy()
    {
        EventManager.Instance.RemoveListener(EventName.GameEnd, SetIsOver);
        EventManager.Instance.RemoveListener(EventName.GameStart, SetIsStart);
    }
    private void SetIsOver(object sender, EventArgs e)
    {
        isOver = true;
    }
    private void SetIsStart(object sender, EventArgs e)
    {
        isOver = false;
    }
    //设置是否是玩家子弹
    public void SetIsPlayer(bool isPlayer)
    {
        this.isPlayer = isPlayer;
    }
    //设置子弹伤害
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("isOver:" + isOver + "collision.gameObject.tag:" + collision.gameObject.tag + "isPlayer:" + isPlayer);
        if (isOver)
        {
            gameObject.SetActive(false);
            return;
        }
        if (collision.gameObject.tag == "bullet" && gameObject.tag == "bullet")
        {
            //子弹碰到子弹
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Npc")
        {
            if (!isPlayer) return;
            //子弹碰到敌人
            EventManager.Instance.TriggerEvent(EventName.EnemyDamage, this, new DamageArgs { damage = damage, enemyID = collision.GetComponent<EnemyController>().getEnemyID() });
            gameObject.SetActive(false);
            // 触发敌人的恢复机制
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.ForceRecovery();
            }
        }
        else if (collision.gameObject.tag == "PLAYER")
        {
            if (isPlayer) return;
            //子弹碰到玩家
            EventManager.Instance.TriggerEvent(EventName.PlayerDamage, this, new DamageArgs { damage = damage });
            // Debug.Log("玩家受到伤害:" + damage);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
