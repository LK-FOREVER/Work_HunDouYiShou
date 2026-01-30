using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // 子弹伤害
    private int damage;
    //子弹是谁发射的
    private bool isPlayer;
    //是否结束
    private bool isOver;
    void Start()
    {
        EventManager.Instance.AddListener(EventName.GameEnd, SetIsOver);
    }
    private void SetIsOver(object sender, EventArgs e)
    {
        isOver = true;
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
        if (isOver)
        {
            gameObject.SetActive(false);
            return;
        }
        if (collision.gameObject.tag == "bullet")
        {
            //子弹碰到子弹
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Npc")
        {
            if(!isPlayer) return;
            //子弹碰到敌人
            EventManager.Instance.TriggerEvent(EventName.EnemyDamage, this, new DamageArgs { damage = damage });
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "PLAYER")
        {
            if(isPlayer) return;
            //子弹碰到玩家
            EventManager.Instance.TriggerEvent(EventName.PlayerDamage, this, new DamageArgs { damage = damage });
            // Debug.Log("玩家受到伤害:" + damage);
            gameObject.SetActive(false);
        }
    }
}
