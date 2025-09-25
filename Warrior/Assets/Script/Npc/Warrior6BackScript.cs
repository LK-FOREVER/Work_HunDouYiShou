using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior6BackScript : MonoBehaviour
{
    // Start is called before the first frame update
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
            this.GetComponentInParent<Warrior6Script>().rig.AddForce(this.GetComponentInParent<Warrior6Script>().d * 20000 * Time.deltaTime);

            this.GetComponentInParent<Warrior6Script>().rig.drag = 6f;
            this.GetComponentInParent<Warrior6Script>().rig.angularDrag = 6f;
        }
        if (!this.GetComponentInParent<Warrior6Script>().Iparse)
        {
            if (collision.gameObject.tag == "Obstacle")
            {

                //print("��ײ��");
                try
                {
                    this.GetComponentInParent<Warrior6Script>().rig.AddForce(this.GetComponentInParent<Warrior6Script>().d * 30000 * Time.deltaTime);

                    this.GetComponentInParent<Warrior6Script>().rig.drag = 6f;
                    this.GetComponentInParent<Warrior6Script>().rig.angularDrag = 6f;
                }
                catch (System.Exception)
                {

                    throw;
                }

                int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);                            //����ײ����
                P_ColiNum++;
                PlayerPrefs.SetInt("ColiNum", P_ColiNum);

            }
            if (collision.gameObject.name == "PlayerDefendObject")
            {
                Vector3 Defendd = (this.transform.position - collision.transform.position).normalized;
                this.GetComponentInParent<Warrior6Script>().rig.AddForce(Defendd * 10000 * Time.deltaTime); //���Է�ʩ�����������������ģ���ֹ��Ҿ�ֹ

                this.GetComponentInParent<Warrior6Script>().rig.drag = 6f;
                this.GetComponentInParent<Warrior6Script>().rig.angularDrag = 6f;

                this.GetComponentInParent<Warrior6Script>().DecreaseWarrior6Hp(10);
                this.GetComponentInParent<Warrior6Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                this.GetComponentInParent<Warrior6Script>().BloodTxt.text = "-" + "10";
                this.GetComponentInParent<Warrior6Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                this.GetComponentInParent<Warrior6Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.tag == "PlayerHammerItem" && collision.gameObject.transform.parent != this.transform.parent)
            {

                this.GetComponentInParent<Warrior6Script>().IFreeze = true;
                this.GetComponentInParent<Warrior6Script>().InvokeFalseFreeze();
                this.GetComponentInParent<Warrior6Script>().m.GetComponent<MapScript>().IFreezeSkill = true;
                this.GetComponentInParent<Warrior6Script>().m.GetComponent<MapScript>().InvokeFalseFreezeSkill();
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
            this.GetComponentInParent<Warrior6Script>().HookBack = false;
            this.GetComponentInParent<Warrior6Script>().m.GetComponent<MapScript>().IFreezeSkill = false;
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
}
