using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc"||collision.gameObject.name=="Player")
        {
            this.gameObject.SetActive(false);
            //���е�Ѫ
            if (collision.gameObject.name == "Player")
            {
                collision.GetComponent<PlayerScript>().DecreasePlayerHp(20);

                collision.GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<PlayerScript>().BloodTxt.text = "-" + "20";
                collision.GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior1(Clone)")
            {
                collision.GetComponent<Warrior1Script>().DecreaseWarrior1Hp(20);

                collision.GetComponentInParent<Warrior1Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.text = "-" + "20";
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior1Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior2(Clone)")
            {
                collision.GetComponent<Warrior2Script>().DecreaseWarrior2Hp(20);

                collision.GetComponentInParent<Warrior2Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior2Script>().BloodTxt.text = "-" + "20";
                collision.GetComponentInParent<Warrior2Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior2Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior3(Clone)")
            {
                collision.GetComponent<Warrior3Script>().DecreaseWarrior3Hp(20);

                collision.GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.text = "-" + "20";
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior4(Clone)")
            {
                collision.GetComponent<Warrior4Script>().DecreaseWarrior4Hp(20);

                collision.GetComponentInParent<Warrior4Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.text = "-" + "20";
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior4Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior5(Clone)")
            {
                collision.GetComponent<Warrior5Script>().DecreaseWarrior5Hp(20);

                collision.GetComponentInParent<Warrior5Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.text = "-" + "20";
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior5Script>().InvokeFalseBloodTxt();
                if (collision.gameObject.name == "Warrior6(Clone)")
                {
                    collision.GetComponent<Warrior6Script>().DecreaseWarrior6Hp(20);

                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.text = "-" + "20";
                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                    collision.GetComponentInParent<Warrior6Script>().InvokeFalseBloodTxt();
                }
            }
            //���мӷ�
            if (this.transform.parent.parent.name == "Player")
            {
                this.transform.parent.GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["���"] += 100;
            }
            if (this.transform.parent.parent.name == "Warrior1(Clone)")
            {
                this.transform.parent.GetComponentInParent<Warrior1Script>().m.GetComponent<MapScript>().dic[this.transform.parent.parent.GetComponent<Warrior1Script>().Name] += 10;
            }
            if (this.transform.parent.parent.name == "Warrior2(Clone)")
            {
                this.transform.parent.GetComponentInParent<Warrior2Script>().m.GetComponent<MapScript>().dic[this.transform.parent.parent.GetComponent<Warrior2Script>().Name] += 10;
            }
            if (this.transform.parent.parent.name == "Warrior3(Clone)")
            {
                this.transform.parent.GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[this.transform.parent.parent.GetComponent<Warrior3Script>().Name] += 10;
            }
            if (this.transform.parent.parent.name == "Warrior4(Clone)")
            {
                this.transform.parent.GetComponentInParent<Warrior4Script>().m.GetComponent<MapScript>().dic[this.transform.parent.parent.GetComponent<Warrior4Script>().Name] += 10;
            }
            if (this.transform.parent.parent.name == "Warrior5(Clone)")
            {
                this.transform.parent.GetComponentInParent<Warrior5Script>().m.GetComponent<MapScript>().dic[this.transform.parent.parent.GetComponent<Warrior5Script>().Name] += 10;
            }
            if (this.transform.parent.parent.name == "Warrior6(Clone)")
            {
                this.transform.parent.GetComponentInParent<Warrior6Script>().m.GetComponent<MapScript>().dic[this.transform.parent.parent.GetComponent<Warrior6Script>().Name] += 10;
            }
        }
    }
}
