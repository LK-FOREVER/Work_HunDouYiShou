using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior5BackScript : MonoBehaviour
{
    void Start()
    {
        
    }
   
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            this.GetComponentInParent<Warrior5Script>().rig.AddForce(this.GetComponentInParent<Warrior5Script>().d * 20000 * Time.deltaTime);

            this.GetComponentInParent<Warrior5Script>().rig.drag = 6f;
            this.GetComponentInParent<Warrior5Script>().rig.angularDrag = 6f;
        }
        if (!this.GetComponentInParent<Warrior5Script>().Iparse)
        {
            if (collision.gameObject.tag == "Obstacle")
            {

                //print("不撞击");
                this.GetComponentInParent<Warrior5Script>().rig.AddForce(this.GetComponentInParent<Warrior5Script>().d * 30000 * Time.deltaTime);

                this.GetComponentInParent<Warrior5Script>().rig.drag = 6f;
                this.GetComponentInParent<Warrior5Script>().rig.angularDrag = 6f;
                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);

            }
            if (collision.gameObject.tag == "frontObject")
            {
                GetComponentInParent<Warrior5Script>().MonsterEff.SetActive(true);
                Invoke("FalseMonsterEff", 0.5f);
            }
            if (collision.gameObject.name == "PlayerDefendObject")
            {

                Vector3 Defendd = (this.transform.position - collision.transform.position).normalized;
                this.GetComponentInParent<Warrior5Script>().rig.AddForce(Defendd * 10000 * Time.deltaTime); //给对方施加力，方向是自身的，防止玩家静止

                this.GetComponentInParent<Warrior5Script>().rig.drag = 6f;
                this.GetComponentInParent<Warrior5Script>().rig.angularDrag = 6f;

                this.GetComponentInParent<Warrior5Script>().DecreaseWarrior5Hp(10);
                this.GetComponentInParent<Warrior5Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                this.GetComponentInParent<Warrior5Script>().BloodTxt.text = "-" + "10";
                this.GetComponentInParent<Warrior5Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                this.GetComponentInParent<Warrior5Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.tag == "PlayerHammerItem" && collision.gameObject.transform.parent != this.transform.parent)
            {

                this.GetComponentInParent<Warrior5Script>().IFreeze = true;
                this.GetComponentInParent<Warrior5Script>().InvokeFalseFreeze();
                this.GetComponentInParent<Warrior5Script>().m.GetComponent<MapScript>().IFreezeSkill = true;
                this.GetComponentInParent<Warrior5Script>().m.GetComponent<MapScript>().InvokeFalseFreezeSkill();
            }
        }
       
        //if (collision.gameObject.tag == "Obstacle")
        //{
        //    this.transform.parent.parent = null;
        //}
        if (collision.gameObject.name == "HookBackObj")
        {
            print("Hook");
            //print(collision.transform.GetChild(0));
            //this.GetComponentInParent<Warrior1Script>().IFreeze = false;
            this.GetComponentInParent<Warrior5Script>().HookBack = false;
            this.GetComponentInParent<Warrior5Script>().m.GetComponent<MapScript>().IFreezeSkill = false;
            if (collision.transform.GetChild(0).name == "Player")
            {
                print(0);
                collision.transform.GetChild(0).GetComponent<PlayerScript>().IFreeze = false;
            }

            if (collision.transform.GetChild(0).name == "Warrior1(Clone)")
            {
                print(1);
                collision.transform.GetChild(0).GetComponent<Warrior1Script>().IFreeze = false;
            }
            if (collision.transform.GetChild(0).name == "Warrior2(Clone)")
            {
                print(2);
                collision.transform.GetChild(0).GetComponent<Warrior2Script>().IFreeze = false;
            }
            if (collision.transform.GetChild(0).name == "Warrior3(Clone)")
            {
                print(3);
                collision.transform.GetChild(0).GetComponent<Warrior3Script>().IFreeze = false;
            }
            if (collision.transform.GetChild(0).name == "Warrior4(Clone)")
            {
                print(4);
                collision.transform.GetChild(0).GetComponent<Warrior4Script>().IFreeze = false;
            }
            if (collision.transform.GetChild(0).name == "Warrior5(Clone)")
            {
                print(5);
                collision.transform.GetChild(0).GetComponent<Warrior5Script>().IFreeze = false;
            }
            if (collision.transform.GetChild(0).name == "Warrior6(Clone)")
            {
                print(6);
                collision.transform.GetChild(0).GetComponent<Warrior6Script>().IFreeze = false;
            }
            collision.transform.DetachChildren();
            Destroy(collision.gameObject.transform.parent);
        }
    }
    public void FalseMonsterEff()
    {
        GetComponentInParent<Warrior5Script>().MonsterEff.SetActive(false);
    }
  

}
