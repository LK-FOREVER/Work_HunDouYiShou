using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    Rigidbody2D rig;
    public GameObject Player;
    public GameObject m;
    public GameObject HookBackObj;
    bool IMove;
   
    bool ICoil;
    void Start()
    {
        //rig = this.GetComponent<Rigidbody2D>();
        //rig.AddForce(new Vector2(0, 300f));//施加力
        //rig.drag = 1.5f;
        //rig.angularDrag = 1.5f;

        Player = GameObject.Find("Player");
        m = GameObject.Find("MapManager");
        //Destroy(this.gameObject,2f);
       
    }

    void Update()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc"/*||collision.gameObject.name=="Player"*/)
        {
            this.transform.parent.parent.GetComponent<PlayerScript>().HookBack = true;
            print("HookNpc");
            //rig.drag = 10f;
            //rig.angularDrag = 10f;
            ICoil = true; //碰撞后不销毁该物体
            m.GetComponent<MapScript>().IFreezeSkill = true;//关闭持续移动
           //this.GetComponent<MeshRenderer>().material.color=new Color(0, 0, 0, 0);
            //if (collision.gameObject.name == "Player")
            //{
            //    collision.GetComponent<PlayerScript>().IFreeze = true;
            //}
            if (collision.gameObject.name == "Warrior1(Clone)")
            {
                collision.GetComponent<Warrior1Script>().IFreeze = true;//冻结单个移动
            }
            if (collision.gameObject.name == "Warrior2(Clone)")
            {
                collision.GetComponent<Warrior2Script>().IFreeze = true;//冻结单个移动
            }
            if (collision.gameObject.name == "Warrior3(Clone)")
            {
                collision.GetComponent<Warrior3Script>().IFreeze = true;//冻结单个移动
            }
            if (collision.gameObject.name == "Warrior4(Clone)")
            {
                collision.GetComponent<Warrior4Script>().IFreeze = true;//冻结单个移动
            }
            if (collision.gameObject.name == "Warrior5(Clone)")
            {
                collision.GetComponent<Warrior5Script>().IFreeze = true;//冻结单个移动
            }
            if (collision.gameObject.name == "Warrior6(Clone)")
            {
                collision.GetComponent<Warrior6Script>().IFreeze = true;//冻结单个移动
            }
            collision.transform.parent = this.transform.GetChild(0);
            //if (this.transform.parent.parent.name == "Player")
            //{
            //    //print(this.transform.parent.parent.name);
            //    this.transform.parent.parent.GetComponent<PlayerScript>().HookBack=true;
            //    this.transform.parent.parent = null;
            //}
            if (this.transform.parent.parent.name == "Warrior1(Clone)")
            {
                //print(this.transform.parent.parent.name);
                this.transform.parent.parent.GetComponent<Warrior1Script>().HookBack = true;
                this.transform.parent.parent = null;
            }
            if (this.transform.parent.parent.name == "Warrior2(Clone)")
            {
                //print(this.transform.parent.parent.name);
                this.transform.parent.parent.GetComponent<Warrior2Script>().HookBack = true;
                this.transform.parent.parent = null;
            }
            if (this.transform.parent.parent.name == "Warrior3(Clone)")
            {
                //print(this.transform.parent.parent.name);
                this.transform.parent.parent.GetComponent<Warrior3Script>().HookBack = true;
                this.transform.parent.parent = null;
            }
            if (this.transform.parent.parent.name == "Warrior4(Clone)")
            {
                //print(this.transform.parent.parent.name);
                this.transform.parent.parent.GetComponent<Warrior4Script>().HookBack = true;
                this.transform.parent.parent = null;
            }
            if (this.transform.parent.parent.name == "Warrior5(Clone)")
            {
                //print(this.transform.parent.parent.name);
                this.transform.parent.parent.GetComponent<Warrior5Script>().HookBack = true;
                this.transform.parent.parent = null;
            }
            if (this.transform.parent.parent.name == "Warrior6(Clone)")
            {
                //print(this.transform.parent.parent.name);
                this.transform.parent.parent.GetComponent<Warrior6Script>().HookBack = true;
                this.transform.parent.parent = null;
            }
          
            HookBackObj.SetActive(true);//判断钩子回拉

            //命中掉血
            if (collision.gameObject.name == "Player")
            {
                collision.GetComponent<PlayerScript>().DecreasePlayerHp(10);

                collision.GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<PlayerScript>().BloodTxt.text = "-" + "10";
                collision.GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior1(Clone)")
            {
                collision.GetComponent<Warrior1Script>().DecreaseWarrior1Hp(10);

                collision.GetComponentInParent<Warrior1Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.text = "-" + "10";
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior1Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior2(Clone)")
            {
                collision.GetComponent<Warrior2Script>().DecreaseWarrior2Hp(10);

                collision.GetComponentInParent<Warrior2Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior2Script>().BloodTxt.text = "-" + "10";
                collision.GetComponentInParent<Warrior2Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior2Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior3(Clone)")
            {
                collision.GetComponent<Warrior3Script>().DecreaseWarrior3Hp(10);

                collision.GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.text = "-" + "10";
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior4(Clone)")
            {
                collision.GetComponent<Warrior4Script>().DecreaseWarrior4Hp(10);

                collision.GetComponentInParent<Warrior4Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.text = "-" + "10";
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior4Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior5(Clone)")
            {
                collision.GetComponent<Warrior5Script>().DecreaseWarrior5Hp(10);

                collision.GetComponentInParent<Warrior5Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.text = "-" + "10";
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior5Script>().InvokeFalseBloodTxt();
                if (collision.gameObject.name == "Warrior6(Clone)")
                {
                    collision.GetComponent<Warrior6Script>().DecreaseWarrior6Hp(10);

                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.text = "-" + "10";
                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                    collision.GetComponentInParent<Warrior6Script>().InvokeFalseBloodTxt();
                }
            }
            //命中加分
            if (this.transform.parent.name == "Player")
            {
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 100;
            }
            if (this.transform.parent.name == "Warrior1(Clone)")
            {
                GetComponentInParent<Warrior1Script>().m.GetComponent<MapScript>().dic [transform.parent.GetComponent<Warrior1Script>().Name] += 100;
            }
            if (this.transform.parent.name == "Warrior2(Clone)")
            {
                GetComponentInParent<Warrior2Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior2Script>().Name] += 100;
            }
            if (this.transform.parent.name == "Warrior3(Clone)")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior3Script>().Name] += 100;
            }
            if (this.transform.parent.name == "Warrior4(Clone)")
            {
                GetComponentInParent<Warrior4Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior4Script>().Name] += 100;
            }
            if (this.transform.parent.name == "Warrior5(Clone)")
            {
                GetComponentInParent<Warrior5Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior5Script>().Name] += 100;
            }
            if (this.transform.parent.name == "Warrior6(Clone)")
            {
                GetComponentInParent<Warrior6Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior6Script>().Name] += 100;
            }

        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
   
    }

