using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(Vector3.right* 10f * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc" || collision.gameObject.name == "Player")
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

           
            //���е�Ѫ
            if (collision.gameObject.name == "Player")
            {
                collision.GetComponent<PlayerScript>().DecreasePlayerHp(3);

                collision.GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<PlayerScript>().BloodTxt.text = "-" + "3";
                collision.GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior1(Clone)")
            {
                collision.GetComponent<Warrior1Script>().DecreaseWarrior1Hp(3);

                collision.GetComponentInParent<Warrior1Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.text = "-" + "3";
                collision.GetComponentInParent<Warrior1Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior1Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior2(Clone)")
            {
                collision.GetComponent<Warrior2Script>().DecreaseWarrior2Hp(3);

                collision.GetComponentInParent<Warrior2Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior2Script>().BloodTxt.text = "-" + "3";
                collision.GetComponentInParent<Warrior2Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior2Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior3(Clone)")
            {
                collision.GetComponent<Warrior3Script>().DecreaseWarrior3Hp(3);

                collision.GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.text = "-" + "3";
                collision.GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior4(Clone)")
            {
                collision.GetComponent<Warrior4Script>().DecreaseWarrior4Hp(3);

                collision.GetComponentInParent<Warrior4Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.text = "-" + "3";
                collision.GetComponentInParent<Warrior4Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior4Script>().InvokeFalseBloodTxt();
            }
            if (collision.gameObject.name == "Warrior5(Clone)")
            {
                collision.GetComponent<Warrior5Script>().DecreaseWarrior5Hp(3);

                collision.GetComponentInParent<Warrior5Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.text = "-" + "3";
                collision.GetComponentInParent<Warrior5Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior5Script>().InvokeFalseBloodTxt();
                if (collision.gameObject.name == "Warrior6(Clone)")
                {
                    collision.GetComponent<Warrior6Script>().DecreaseWarrior6Hp(3);

                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.gameObject.SetActive(true);      //��Ѫ�ı���Ч
                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.text = "-" + "3";
                    collision.GetComponentInParent<Warrior6Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                    collision.GetComponentInParent<Warrior6Script>().InvokeFalseBloodTxt();
                }
            }
            //���мӷ�
            if (this.transform.parent.name == "Player")
            {
                GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["���"] += 2;
            }
            if (this.transform.parent.name == "Warrior1(Clone)")
            {
                GetComponentInParent<Warrior1Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior1Script>().Name] += 2;
            }
            if (this.transform.parent.name == "Warrior2(Clone)")
            {
                GetComponentInParent<Warrior2Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior2Script>().Name] += 2;
            }
            if (this.transform.parent.name == "Warrior3(Clone)")
            {
                GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior3Script>().Name] += 2;
            }
            if (this.transform.parent.name == "Warrior4(Clone)")
            {
                GetComponentInParent<Warrior4Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior4Script>().Name] += 2;
            }
            if (this.transform.parent.name == "Warrior5(Clone)")
            {
                GetComponentInParent<Warrior5Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior5Script>().Name] += 2;
            }
            if (this.transform.parent.name == "Warrior6(Clone)")
            {
                GetComponentInParent<Warrior6Script>().m.GetComponent<MapScript>().dic[transform.parent.GetComponent<Warrior6Script>().Name] += 2;
            }
        }
      
    }
}
