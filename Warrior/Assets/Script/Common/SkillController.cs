using System;
using UnityEngine;
public class SkillController : MonoBehaviour
{
    // 技能伤害
    private int skillDamage;
    // 技能是谁发射的
    private bool isPlayerSkill;
    //是否结束
    private bool isOver;
    void Awake()
    {
        EventManager.Instance.AddListener(EventName.GameEnd, SetIsOver);
    }
    private void SetIsOver(object sender, EventArgs e)
    {
        isOver = true;
    }
    //设置是否是玩家技能
    public void SetIsPlayerSkill(bool isPlayerSkill)
    {
        this.isPlayerSkill = isPlayerSkill;
    }
    //设置技能伤害
    public void SetSkillDamage(int skillDamage)
    {
        this.skillDamage = skillDamage;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOver)
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.tag == "Npc")
        {
            if (!isPlayerSkill) return;
            //技能碰到敌人
            EventManager.Instance.TriggerEvent(EventName.EnemyDamage, this, new DamageArgs { damage = skillDamage });
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PLAYER")
        {
            if (isPlayerSkill) return;
            //技能碰到玩家
            EventManager.Instance.TriggerEvent(EventName.PlayerDamage, this, new DamageArgs { damage = skillDamage });
            // Debug.Log("玩家受到伤害:" + skillDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}