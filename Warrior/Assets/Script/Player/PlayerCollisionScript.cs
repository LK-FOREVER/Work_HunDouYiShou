using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class PlayerCollisionScript : MonoBehaviour
{
   public bool Ifront;
   public bool Iback;
    public int Killnum;
    public Text KillTxt;
    void Start()
    {
        
    }

    void Update()
    {
        KillTxt.text="淘汰异兽数："+Killnum.ToString();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            this.GetComponentInParent<PlayerScript>().rig.AddForce(-this.GetComponentInParent<PlayerScript>().d * 20000 * Time.deltaTime);

            this.GetComponentInParent<PlayerScript>().rig.drag = 6f;
            this.GetComponentInParent<PlayerScript>().rig.angularDrag = 6f;
        }
        if (!this.GetComponentInParent<PlayerScript>().IParse)
        {
            if (collision.gameObject.tag == "Obstacle")
            {

                //print("不撞击");
                this.GetComponentInParent<PlayerScript>().rig.AddForce(-this.GetComponentInParent<PlayerScript>().d * 30000 * Time.deltaTime);

                this.GetComponentInParent<PlayerScript>().rig.drag = 6f;
                this.GetComponentInParent<PlayerScript>().rig.angularDrag = 6f;
                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);

            }

            if (collision.gameObject.name == "frontObject1")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[8];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior1Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior1Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior1Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 25;
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 25;
                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);

                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);


            }
            if (collision.gameObject.name == "frontObject2")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[8];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior2Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior2Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior2Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 25;
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 25;
                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);

                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);



            }
            if (collision.gameObject.name == "frontObject3")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[8];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior3Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior3Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior3Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 25;
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 25;
                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);

                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);


            }
            if (collision.gameObject.name == "frontObject4")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[8];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior4Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior4Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior4Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 25;
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 25;
                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);

                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);


            }
            if (collision.gameObject.name == "frontObject5")
            {
                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[8];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior5Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior5Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior5Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 25;
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 25;
                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);

                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);


            }
            if (collision.gameObject.name == "frontObject6")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[8];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior6Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior6Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior6Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 25;
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 25;
                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);
                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);

            }
            if (collision.gameObject.name == "backObject1")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[9];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior1Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior1Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior1Script>().rig.angularDrag = 6f;
                Iback = true;
                collision.GetComponentInParent<Warrior1Script>().DecreaseWarrior1Hp(this.GetComponentInParent<PlayerScript>().Ak);
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.text = "-" + this.GetComponentInParent<PlayerScript>().Ak.ToString();
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior1Script>().InvokeFalseBloodTxt();
                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);
                if (collision.GetComponentInParent<Warrior1Script>().IDead)
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] +=100;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 100;
                    int P_KillNum = PlayerPrefs.GetInt("KillNum", 0);                            //存入击杀数
                    P_KillNum++;
                    PlayerPrefs.SetInt("KillNum", P_KillNum);
                    Killnum++;//记录该局击杀数

                }
                else
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 50;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 50;
                    int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                    P_ColiNum++;
                    PlayerPrefs.SetInt("ColiNum", P_ColiNum);
                }


            }
            if (collision.gameObject.name == "backObject2")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[9];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior2Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior2Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior2Script>().rig.angularDrag = 6f;
                Iback = true;
                if (collision.GetComponentInParent<Warrior2Script>().Ishield == false)
                {
                    collision.GetComponentInParent<Warrior2Script>().DecreaseWarrior2Hp(this.GetComponentInParent<PlayerScript>().Ak);
                    collision.GetComponentInParent<Warrior2Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                    collision.GetComponentInParent<Warrior2Script>().BloodTxt.text = "-" + this.GetComponentInParent<PlayerScript>().Ak.ToString();
                    collision.GetComponentInParent<Warrior2Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                    collision.GetComponentInParent<Warrior2Script>().InvokeFalseBloodTxt();
                }
                if (collision.GetComponentInParent<Warrior2Script>().Ishield == true && collision.GetComponentInParent<Warrior2Script>().ShieldHp != 0)
                {
                    collision.GetComponentInParent<Warrior2Script>().DecreaseShieldHp(this.GetComponentInParent<PlayerScript>().Ak);
                }
                if (collision.GetComponentInParent<Warrior2Script>().Ishield == true && collision.GetComponentInParent<Warrior2Script>().ShieldHp == 0)
                {
                    collision.GetComponentInParent<Warrior2Script>().ShieldEff.SetActive(false);
                }
                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);
                if (collision.GetComponentInParent<Warrior2Script>().IDead)
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] +=100;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 100;
                    int P_KillNum = PlayerPrefs.GetInt("KillNum", 0);                            //存入击杀数
                    P_KillNum++;
                    PlayerPrefs.SetInt("KillNum", P_KillNum);
                    Killnum++;//记录该局击杀数
                }
                else
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 50;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 50;
                    int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                    P_ColiNum++;
                    PlayerPrefs.SetInt("ColiNum", P_ColiNum);
                }


            }
            if (collision.gameObject.name == "backObject3")
            {
                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[9];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior3Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior3Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior3Script>().rig.angularDrag = 6f;
                Iback = true;
                collision.GetComponentInParent<Warrior3Script>().DecreaseWarrior3Hp(this.GetComponentInParent<PlayerScript>().Ak);
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.text = "-" + this.GetComponentInParent<PlayerScript>().Ak.ToString();
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
                collision.GetComponentInParent<Warrior3Script>().GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                collision.GetComponentInParent<Warrior3Script>().Warrior3Rotation.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                collision.GetComponentInParent<Warrior3Script>().Warrior3Canvas.gameObject.SetActive(true);
                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);
                if (collision.GetComponentInParent<Warrior3Script>().IDead)
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 100;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 100;
                    int P_KillNum = PlayerPrefs.GetInt("KillNum", 0);                            //存入击杀数
                    P_KillNum++;
                    PlayerPrefs.SetInt("KillNum", P_KillNum);
                    Killnum++;//记录该局击杀数
                }
                else
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 50;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 50;
                    int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                    P_ColiNum++;
                    PlayerPrefs.SetInt("ColiNum", P_ColiNum);
                }


            }
            if (collision.gameObject.name == "backObject4")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[9];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior4Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior4Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior4Script>().rig.angularDrag = 6f;
                Iback = true;
                collision.GetComponentInParent<Warrior4Script>().DecreaseWarrior4Hp(this.GetComponentInParent<PlayerScript>().Ak);
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.text = "-" + this.GetComponentInParent<PlayerScript>().Ak.ToString();
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior4Script>().InvokeFalseBloodTxt();
                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);

                if (collision.GetComponentInParent<Warrior4Script>().IDead)
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 100;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 100;
                    int P_KillNum = PlayerPrefs.GetInt("KillNum", 0);                            //存入击杀数
                    P_KillNum++;
                    PlayerPrefs.SetInt("KillNum", P_KillNum);
                    Killnum++;//记录该局击杀数
                }
                else
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 50;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 50;
                    int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                    P_ColiNum++;
                    PlayerPrefs.SetInt("ColiNum", P_ColiNum);
                }


            }
            if (collision.gameObject.name == "backObject5")
            {

                collision.GetComponentInParent<Warrior5Script>().audio.clip = collision.GetComponentInParent<Warrior5Script>().acilp[0];
                collision.GetComponentInParent<Warrior5Script>().audio.Play();
                collision.GetComponentInParent<Warrior5Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior5Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior5Script>().rig.angularDrag = 6f;
                Iback = true;
                collision.GetComponentInParent<Warrior5Script>().DecreaseWarrior5Hp(this.GetComponentInParent<PlayerScript>().Ak);
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.text = "-" + this.GetComponentInParent<PlayerScript>().Ak.ToString();
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior5Script>().InvokeFalseBloodTxt();
                collision.GetComponentInParent<Warrior5Script>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);

                if (collision.GetComponentInParent<Warrior5Script>().IDead)
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 100;
                    GetComponentInParent<Warrior5Script>().m.GetComponent<MapScript>().dic["玩家"] += 100;
                    int P_KillNum = PlayerPrefs.GetInt("KillNum", 0);                            //存入击杀数
                    P_KillNum++;
                    PlayerPrefs.SetInt("ColiNum", P_KillNum);
                    Killnum++;//记录该局击杀数
                }
                else
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 50;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 50;
                    int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                    P_ColiNum++;
                    PlayerPrefs.SetInt("ColiNum", P_ColiNum);
                }


            }
            if (collision.gameObject.name == "backObject6")
            {

                this.GetComponentInParent<PlayerScript>().audio.clip = this.GetComponentInParent<PlayerScript>().acilp[9];
                this.GetComponentInParent<PlayerScript>().audio.Play();
                collision.GetComponentInParent<Warrior6Script>().rig.AddForce(this.GetComponentInParent<PlayerScript>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior6Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior6Script>().rig.angularDrag = 6f;
                Iback = true;
                collision.GetComponentInParent<Warrior6Script>().DecreaseWarrior6Hp(this.GetComponentInParent<PlayerScript>().Ak);
                collision.GetComponentInParent<Warrior6Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior6Script>().BloodTxt.text = "-" + this.GetComponentInParent<PlayerScript>().Ak.ToString();
                collision.GetComponentInParent<Warrior6Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior6Script>().InvokeFalseBloodTxt();
                GetComponentInParent<PlayerScript>().ColiEff.SetActive(true);                //撞击特效
                Invoke("FalseColiEff", 0.3f);
                if (collision.GetComponentInParent<Warrior6Script>().IDead)
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 100;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 100;
                    int P_KillNum = PlayerPrefs.GetInt("KillNum", 0);                            //存入击杀数
                    P_KillNum++;
                    PlayerPrefs.SetInt("KillNum", P_KillNum);
                    Killnum++;//记录该局击杀数
                }
                else
                {
                    //GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().index] += 50;
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 50;
                    int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //存入撞击数
                    P_ColiNum++;
                    PlayerPrefs.SetInt("ColiNum", P_ColiNum);
                }

            }
            if (collision.gameObject.name == "PlayerDefendObject" /*&& collision.gameObject != this.gameObject*/)
            {
                Vector3 Defendd = (this.transform.position - collision.transform.position).normalized;
                this.GetComponentInParent<PlayerScript>().rig.AddForce(Defendd * 10000 * Time.deltaTime); //给对方施加力，方向是自身的，防止玩家静止

                this.GetComponentInParent<PlayerScript>().rig.drag = 6f;
                this.GetComponentInParent<PlayerScript>().rig.angularDrag = 6f;

                this.GetComponentInParent<PlayerScript>().DecreasePlayerHp(10);
                this.GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                this.GetComponentInParent<PlayerScript>().BloodTxt.text = "-" + "10";
                this.GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                this.GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
                //被命中对面加分
                if (collision.transform.parent.name == "Player")
                {
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 50;
                }
                if (collision.transform.parent.name == "Warrior1(Clone)")
                {
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior1Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior2(Clone)")
                {
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior2Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior3(Clone)")
                {
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior3Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior4(Clone)")
                {
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior4Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior5(Clone)")
                {
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior5Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior6(Clone)")
                {
                    GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior6Script>().Name] += 50;
                }
            }
            if (collision.gameObject.tag == "PlayerHammerItem" && collision.gameObject.transform.parent != this.transform.parent.parent)
            {

                this.GetComponentInParent<PlayerScript>().IFreeze = true;
                this.GetComponentInParent<PlayerScript>().InvokeFalseFreeze();
                this.GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().IFreezeSkill = true;
                this.GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().InvokeFalseFreezeSkill();

            }
        }

        if (collision.gameObject.tag == "AddBlood" && GetComponentInParent<PlayerScript>().PlayerHp != GetComponentInParent<PlayerScript>().PlayerHP)
        {
            GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            GetComponentInParent<PlayerScript>().BloodTxt.text = "+10";
            GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.427f, 0.980f, 0.302f);
            GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
            GetComponentInParent<PlayerScript>().audio.clip = GetComponentInParent<PlayerScript>().acilp[10];
            GetComponentInParent<PlayerScript>().audio.Play();
            GetComponentInParent<PlayerScript>().AddPlayerHp(10);
            Destroy(collision.gameObject);

            //m.GetComponent<MapScript>().Warriorpoint[m.GetComponent<MapScript>().index] += 5; 
            GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 5;

            GetComponentInParent<PlayerScript>().AddBloodEff.SetActive(true);
            GetComponentInParent<PlayerScript>().InvokeFalseAddBloodEff();
        }
        if (collision.gameObject.tag == "Boom")
        {
            GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            GetComponentInParent<PlayerScript>().BloodTxt.text = "-20";
            GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
            GetComponentInParent<PlayerScript>().audio.clip = GetComponentInParent<PlayerScript>().acilp[7];
            GetComponentInParent<PlayerScript>().audio.Play();
            GetComponentInParent<PlayerScript>().DecreasePlayerHp(20);
            Destroy(collision.gameObject);
            //m.GetComponent<MapScript>().Warriorpoint[m.GetComponent<MapScript>().index] += 5;
            GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 5;
        }
        if (collision.gameObject.tag == "Trap")
        {
            GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            GetComponentInParent<PlayerScript>().BloodTxt.text = "-10";
            GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
            GetComponentInParent<PlayerScript>().audio.clip = GetComponentInParent<PlayerScript>().acilp[11];
            GetComponentInParent<PlayerScript>().audio.Play();
            GetComponentInParent<PlayerScript>().DecreasePlayerHp(10);
            Destroy(collision.gameObject);
            //m.GetComponent<MapScript>().Warriorpoint[m.GetComponent<MapScript>().index] += 5;
            GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 5;
            GetComponentInParent<PlayerScript>().TrapEff.SetActive(true);
            GetComponentInParent<PlayerScript>().InvokeFalseTrapEff();
        }
        if (collision.gameObject.tag == "Defend")
        {
            if( (GetComponentInParent<PlayerScript>().IItem1 == true&& GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 1;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1,1,1,1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[0];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false&& GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 1;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[0];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
        if (collision.gameObject.tag == "Hammer")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 2;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[1];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 2;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[1];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
        if (collision.gameObject.tag == "HandBomb")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 3;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[2];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 3;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[2];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
        if (collision.gameObject.tag == "Hook")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 4;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[3];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 4;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[3];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
      
        if (collision.gameObject.tag == "Knife")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 5;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[4];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 5;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[4];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        } 
        if (collision.gameObject.tag == "Light")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 6;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[5];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 6;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[5];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
        if (collision.gameObject.tag == "Magnet")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 7;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[6];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 7;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[6];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
        if (collision.gameObject.tag == "Matrix")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 8;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[7];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 8;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[7];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
        if (collision.gameObject.tag == "PMove")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 9;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[8];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 9;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[8];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
        if (collision.gameObject.tag == "Shoot")
        {
            if ((GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == true) || (GetComponentInParent<PlayerScript>().IItem1 == true && GetComponentInParent<PlayerScript>().IItem2 == false))
            {
                GetComponentInParent<PlayerScript>().Item1Id = 10;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem1 = false;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn1.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[9];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;

            }
            else if ((GetComponentInParent<PlayerScript>().IItem1 == false && GetComponentInParent<PlayerScript>().IItem2 == true))
            {
                GetComponentInParent<PlayerScript>().Item2Id = 10;
                collision.gameObject.SetActive(false);
                GetComponentInParent<PlayerScript>().IItem2 = false;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().raycastTarget = true;
                GetComponentInParent<PlayerScript>().ItemBtn2.GetComponent<Image>().sprite = GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().ItemSprite[9];
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 20;
            }
        }
        //以上10个全部为道具
       
        if (collision.gameObject.name == "HookBackObj"&&collision.gameObject.transform.parent!=this.transform.parent)
        {
            print("Hook");
            //print(collision.transform.GetChild(0));
            //this.GetComponentInParent<Warrior1Script>().IFreeze = false;
            this.GetComponentInParent<PlayerScript>().HookBack = false;
            this.GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().IFreezeSkill = false;

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
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "frontObject1")
        {
            Ifront = false;
            collision.GetComponentInParent<Warrior1Script>().RandomR();
           
        }
        if (collision.gameObject.name == "frontObject2")
        {
            Ifront = false;
            collision.GetComponentInParent<Warrior2Script>().RandomR();
        }
        if (collision.gameObject.name == "frontObject3")
        {
            Ifront = false;
            collision.GetComponentInParent<Warrior3Script>().RandomR();
        }
        if (collision.gameObject.name == "frontObject4")
        {
            Ifront = false;
            collision.GetComponentInParent<Warrior4Script>().RandomR();
        }
        if (collision.gameObject.name == "frontObject5")
        {
            Ifront = false;
            collision.GetComponentInParent<Warrior5Script>().RandomR();
        }
        if (collision.gameObject.name == "frontObject6")
        {
            Ifront = false;
            collision.GetComponentInParent<Warrior6Script>().RandomR();
        }
        if (collision.gameObject.name == "backObject1")
        {
            Iback = false;
            collision.GetComponentInParent<Warrior1Script>().RandomR();
        }
        if (collision.gameObject.name == "backObject2")
        {
            Iback = false;
            collision.GetComponentInParent<Warrior2Script>().RandomR();
        }
        if (collision.gameObject.name == "backObject3")
        {
            Iback = false;
            collision.GetComponentInParent<Warrior3Script>().RandomR();
        }
        if (collision.gameObject.name == "backObject4")
        {
            Iback = false;
            collision.GetComponentInParent<Warrior4Script>().RandomR();
        }
        if (collision.gameObject.name == "backObject5")
        {
            Iback = false;
            collision.GetComponentInParent<Warrior5Script>().RandomR();
        }
        if (collision.gameObject.name == "backObject6")
        {
            Iback = false;
            collision.GetComponentInParent<Warrior6Script>().RandomR();
        }
    }

    public void FalseColiEff()
    {
        GetComponentInParent<PlayerScript>().ColiEff.SetActive(false);
    }
    
}
