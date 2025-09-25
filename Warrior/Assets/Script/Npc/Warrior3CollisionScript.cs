using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior3CollisionScript : MonoBehaviour
{
    public bool Ifront;
    public bool Iback;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            this.GetComponentInParent<Warrior3Script>().rig.AddForce(-this.GetComponentInParent<Warrior3Script>().d * 20000 * Time.deltaTime);

            this.GetComponentInParent<Warrior3Script>().rig.drag = 6f;
            this.GetComponentInParent<Warrior3Script>().rig.angularDrag = 6f;
        }
        if (!this.GetComponentInParent<Warrior3Script>().Iparse)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                //this.transform.parent.parent = null;
                this.GetComponentInParent<Warrior3Script>().rig.AddForce(-this.GetComponentInParent<Warrior3Script>().d * 30000 * Time.deltaTime);

                this.GetComponentInParent<Warrior3Script>().rig.drag = 6f;
                this.GetComponentInParent<Warrior3Script>().rig.angularDrag = 6f;
                float x = Random.Range(-4f, 28f);
                float y = Random.Range(-42f, 6f);
                this.GetComponentInParent<Warrior3Script>().TargetPos = new Vector3(x, y, 0);
            }

            if (collision.gameObject.name == "frontObject")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[2];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<PlayerScript>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime); //���Է�ʩ�����������������ģ���ֹ��Ҿ�ֹ

                collision.GetComponentInParent<PlayerScript>().rig.drag = 6f;
                collision.GetComponentInParent<PlayerScript>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 25;
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 25;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
            }
            if (collision.gameObject.name == "frontObject1")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[2];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior1Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior1Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior1Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 25;
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 25;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
            }
            if (collision.gameObject.name == "frontObject2")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[2];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior2Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior2Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior2Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 25;
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 25;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
            }
            if (collision.gameObject.name == "frontObject3")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[2];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior3Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior3Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior3Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 25;
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 25;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
            }
            if (collision.gameObject.name == "frontObject4")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[2];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior4Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior4Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior4Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 25;
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 25;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
            }
            if (collision.gameObject.name == "frontObject5")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[2];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior5Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior5Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior5Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 25;
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 25;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
            }
            if (collision.gameObject.name == "frontObject6")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[2];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior6Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior6Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior6Script>().rig.angularDrag = 6f;
                Ifront = true;
                //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 25;
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 25;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
            }
            if (collision.gameObject.name == "backObject")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[3];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<PlayerScript>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<PlayerScript>().rig.drag = 6f;
                collision.GetComponentInParent<PlayerScript>().rig.angularDrag = 6f;
                Iback = true;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
                if (collision.GetComponentInParent<PlayerScript>().Ishield == false)
                {
                    collision.GetComponentInParent<PlayerScript>().DecreasePlayerHp(GetComponentInParent<Warrior3Script>().Ak);
                    collision.GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                    collision.GetComponentInParent<PlayerScript>().BloodTxt.text = GetComponentInParent<Warrior3Script>().Ak.ToString();
                    collision.GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                    collision.GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
                }
                if (collision.GetComponentInParent<PlayerScript>().Ishield == true && collision.GetComponentInParent<PlayerScript>().ShieldHp != 0)
                {
                    collision.GetComponentInParent<PlayerScript>().DecreaseShieldHp(GetComponentInParent<Warrior5Script>().Ak);
                }
                if (collision.GetComponentInParent<PlayerScript>().Ishield == true && collision.GetComponentInParent<PlayerScript>().ShieldHp == 0)//�ƶ�
                {
                    collision.GetComponentInParent<PlayerScript>().ShieldEff.SetActive(false);
                }
                if (collision.GetComponentInParent<PlayerScript>().IDead)
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 100;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 100;
                }
                else
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 50;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 50;
                }
                if (collision.GetComponentInParent<PlayerScript>().IWarrior5) //�Ƿ�ѡ��Ӣ��5
                {
                    collision.GetComponentInParent<PlayerScript>().audio.clip = collision.GetComponentInParent<PlayerScript>().acilp[4];
                    collision.GetComponentInParent<PlayerScript>().audio.Play();
                    collision.GetComponentInParent<PlayerScript>().MonsterEff.SetActive(true);
                    Invoke("FalseMonsterEff", 0.5f);
                }
            }
            if (collision.gameObject.name == "backObject1")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[3];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior1Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior1Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior1Script>().rig.angularDrag = 6f;
                Iback = true;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
                collision.GetComponentInParent<Warrior1Script>().DecreaseWarrior1Hp(GetComponentInParent<Warrior3Script>().Ak);
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.text = "-" + GetComponentInParent<Warrior3Script>().Ak.ToString();
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior1Script>().InvokeFalseBloodTxt();
                if (collision.GetComponentInParent<Warrior1Script>().IDead)
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 100;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 100;
                }
                else
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 50;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 50;
                }
            }
            if (collision.gameObject.name == "backObject2")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[3];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior2Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior2Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior2Script>().rig.angularDrag = 6f;
                Iback = true;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
                if (collision.GetComponentInParent<Warrior2Script>().Ishield == false)
                {
                    collision.GetComponentInParent<Warrior2Script>().DecreaseWarrior2Hp(GetComponentInParent<Warrior3Script>().Ak);
                    collision.GetComponentInParent<Warrior2Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                    collision.GetComponentInParent<Warrior2Script>().BloodTxt.text = "-" + GetComponentInParent<Warrior3Script>().Ak.ToString();
                    collision.GetComponentInParent<Warrior2Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                    collision.GetComponentInParent<Warrior2Script>().InvokeFalseBloodTxt();
                }
                if (collision.GetComponentInParent<Warrior2Script>().Ishield == true && collision.GetComponentInParent<Warrior2Script>().ShieldHp != 0)
                {
                    collision.GetComponentInParent<Warrior2Script>().DecreaseShieldHp(GetComponentInParent<Warrior3Script>().Ak);
                }
                if (collision.GetComponentInParent<Warrior2Script>().IDead)
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 100;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 100;
                }
                else
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 50;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 50;
                }
            }
            if (collision.gameObject.name == "backObject3")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[3];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior3Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior3Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior3Script>().rig.angularDrag = 6f;
                Iback = true;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
                collision.GetComponentInParent<Warrior3Script>().DecreaseWarrior3Hp(GetComponentInParent<Warrior3Script>().Ak);
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.text = "-" + GetComponentInParent<Warrior3Script>().Ak.ToString();
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
                if (collision.GetComponentInParent<Warrior3Script>().IDead)
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 100;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 100;
                }
                else
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 50;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 50;
                }
            }
            if (collision.gameObject.name == "backObject4")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[3];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior4Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior4Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior4Script>().rig.angularDrag = 6f;
                Iback = true;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
                collision.GetComponentInParent<Warrior4Script>().DecreaseWarrior4Hp(GetComponentInParent<Warrior3Script>().Ak);
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.text = "-" + GetComponentInParent<Warrior3Script>().Ak.ToString();
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior4Script>().InvokeFalseBloodTxt();
                if (collision.GetComponentInParent<Warrior4Script>().IDead)
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 100;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 100;
                }
                else
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 50;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 50;
                }
            }
            if (collision.gameObject.name == "backObject5")
            {

                collision.GetComponentInParent<Warrior5Script>().audio.clip = collision.GetComponentInParent<Warrior5Script>().acilp[0];
                collision.GetComponentInParent<Warrior5Script>().audio.Play();
                collision.GetComponentInParent<Warrior5Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior5Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior5Script>().rig.angularDrag = 6f;
                Iback = true;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
                collision.GetComponentInParent<Warrior5Script>().DecreaseWarrior5Hp(GetComponentInParent<Warrior3Script>().Ak);
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.text = "-" + GetComponentInParent<Warrior3Script>().Ak.ToString();
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior5Script>().InvokeFalseBloodTxt();
                if (collision.GetComponentInParent<Warrior5Script>().IDead)
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 100;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 100;
                }
                else
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 50;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 50;
                }
            }
            if (collision.gameObject.name == "backObject6")
            {
                GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[3];
                GetComponentInParent<Warrior3Script>().audio.Play();
                collision.GetComponentInParent<Warrior6Script>().rig.AddForce(this.GetComponentInParent<Warrior3Script>().d * 15000 * Time.deltaTime);

                collision.GetComponentInParent<Warrior6Script>().rig.drag = 6f;
                collision.GetComponentInParent<Warrior6Script>().rig.angularDrag = 6f;
                Iback = true;
                GetComponentInParent<Warrior3Script>().ColiEff.SetActive(true);                //ײ����Ч
                Invoke("FalseColiEff", 0.3f);
                collision.GetComponentInParent<Warrior6Script>().DecreaseWarrior6Hp(GetComponentInParent<Warrior3Script>().Ak);
                collision.GetComponentInParent<Warrior6Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior6Script>().BloodTxt.text = "-" + GetComponentInParent<Warrior3Script>().Ak.ToString();
                collision.GetComponentInParent<Warrior6Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior6Script>().InvokeFalseBloodTxt();
                if (collision.GetComponentInParent<Warrior6Script>().IDead)
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 100;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 100;
                }
                else
                {
                    //GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().Warriorpoint[GetComponentInParent<Warrior3Script>().index] += 50;
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 50;
                }
            }
            if (collision.gameObject.name == "PlayerDefendObject")
            {

                Vector3 Defendd = (this.transform.position - collision.transform.position).normalized;
                this.GetComponentInParent<Warrior3Script>().rig.AddForce(Defendd * 10000 * Time.deltaTime); //���Է�ʩ�����������������ģ���ֹ��Ҿ�ֹ

                this.GetComponentInParent<Warrior3Script>().rig.drag = 6f;
                this.GetComponentInParent<Warrior3Script>().rig.angularDrag = 6f;

                this.GetComponentInParent<Warrior3Script>().DecreaseWarrior3Hp(10);
                //this.GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 50;
                this.GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                this.GetComponentInParent<Warrior3Script>().BloodTxt.text = "-" + "10";
                this.GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                this.GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();

                //�����ж���ӷ�
                if (collision.transform.parent.name == "Player")
                {
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic["���"] += 50;
                }
                if (collision.transform.parent.name == "Warrior1(Clone)")
                {
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior1Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior2(Clone)")
                {
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior2Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior3(Clone)")
                {
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior3Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior4(Clone)")
                {
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior4Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior5(Clone)")
                {
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior5Script>().Name] += 50;
                }
                if (collision.transform.parent.name == "Warrior6(Clone)")
                {
                    GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[collision.transform.parent.GetComponent<Warrior6Script>().Name] += 50;
                }
            }
            if (collision.gameObject.tag == "PlayerHammerItem")
            {

                this.GetComponentInParent<Warrior3Script>().IFreeze = true;
                this.GetComponentInParent<Warrior3Script>().InvokeFalseFreeze();
                this.GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().IFreezeSkill = true;
                this.GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().InvokeFalseFreezeSkill();

            }
        }
       
        if (collision.gameObject.tag == "AddBlood" && GetComponentInParent<Warrior3Script>().Warrior3Hp != 200f)
        {
            int r = Random.Range(1, 21);
            if (r >transform.parent.GetComponentInParent<Warrior3Script>(). Player.GetComponent<PlayerScript>().B1 && r < transform.parent.GetComponentInParent<Warrior3Script>().Player.GetComponent<PlayerScript>().B2)
            {
                GetComponentInParent<Warrior3Script>().AddWarrior3Hp(10);
                GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                GetComponentInParent<Warrior3Script>().BloodTxt.text = "+10";
                GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.427f, 0.980f, 0.302f);
                GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
                Destroy(collision.gameObject);
                //m.GetComponent<MapScript>().Warriorpoint[index] += 5;
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 5;
            }

        }
        if (collision.gameObject.tag == "Boom")
        {
            GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[1];
            GetComponentInParent<Warrior3Script>().audio.Play();
            GetComponentInParent<Warrior3Script>().DecreaseWarrior3Hp(20);
            GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
            GetComponentInParent<Warrior3Script>().BloodTxt.text = "-20";
            GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
            Destroy(collision.gameObject);
            //m.GetComponent<MapScript>().Warriorpoint[index] += 5;
            GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 5;
        }
        if (collision.gameObject.tag == "PlayBoom")
        {
            GetComponentInParent<Warrior3Script>().audio.clip = GetComponentInParent<Warrior3Script>().acilp[1];
            GetComponentInParent<Warrior3Script>().audio.Play();
            GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                GetComponentInParent<Warrior3Script>().BloodTxt.text = "-20";
            GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
            GetComponentInParent<Warrior3Script>().DecreaseWarrior3Hp(20);
            Destroy(collision.gameObject);
            //m.GetComponent<MapScript>().Warriorpoint[index] += 5;
            GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 5;
        }
        if (collision.gameObject.tag == "Trap")
        {
            int r = Random.Range(1, 21);
            if (r > GetComponentInParent<Warrior3Script>().Player.GetComponent<PlayerScript>().T1 && r < GetComponentInParent<Warrior3Script>().Player.GetComponent<PlayerScript>().T2)
            {
                GetComponentInParent<Warrior3Script>().DecreaseWarrior3Hp(10);
                GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                GetComponentInParent<Warrior3Script>().BloodTxt.text = "-10";
                GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
                Destroy(collision.gameObject);
                //m.GetComponent<MapScript>().Warriorpoint[index] += 5; 
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 5;
            }
        }
       
        if (collision.gameObject.name == "HookBackObj" && collision.gameObject.transform.parent != this.transform.parent)
        {
            print("Hook");
            //print(collision.transform.GetChild(0));
            //this.GetComponentInParent<Warrior1Script>().IFreeze = false;
            this.GetComponentInParent<Warrior3Script>().HookBack = false;
            this.GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().IFreezeSkill = false;
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
        if (collision.gameObject.tag == "Defend" || collision.gameObject.tag == "Hammer" || collision.gameObject.tag == "HandBomb" || collision.gameObject.tag == "Hook" || collision.gameObject.tag == "Knife" || collision.gameObject.tag == "Light" || collision.gameObject.tag == "Magnet" || collision.gameObject.tag == "Matrix" || collision.gameObject.tag == "PMove" || collision.gameObject.tag == "Shoot")
        {
            collision.gameObject.SetActive(false);
            if (collision.gameObject.tag == "Defend")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "HandBomb")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "Defend")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "Hook")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "Knife")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "Light")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "Magnet")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "Matrix")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "PMove")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
            if (collision.gameObject.tag == "Shoot")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior3Script>().Name] += 20;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "frontObject")
        {
            Ifront = false;
           
        }
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
        if (collision.gameObject.name == "backObject")
        {
            Iback = false;
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
        GetComponentInParent<Warrior3Script>().ColiEff.SetActive(false);
    }
    public void FalseShieldEff()
    {
        GetComponentInParent<Warrior3Script>().Player.GetComponent<PlayerScript>().ShieldEff.SetActive(false);
    }
    public void FalseMonsterEff()
    {
        GetComponentInParent<Warrior3Script>().Player.GetComponent<PlayerScript>().MonsterEff.SetActive(false);
    }
}
