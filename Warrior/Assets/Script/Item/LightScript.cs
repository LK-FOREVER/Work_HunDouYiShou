using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc"||collision.gameObject.name=="Player")
        {
            //命中减速
            if(collision.gameObject.name == "Player")
            {
                collision.GetComponent<PlayerScript>().speed *= 0.7f;
            }
            if (collision.gameObject.name == "Warrior1(Clone)")
            {
                collision.GetComponent<Warrior1Script>().Speed *= 0.7f;
            }
            if (collision.gameObject.name == "Warrior2(Clone)")
            {
                collision.GetComponent<Warrior2Script>().Speed *= 0.7f;
            }
            if (collision.gameObject.name == "Warrior3(Clone)")
            {
                collision.GetComponent<Warrior3Script>().Speed *= 0.7f;
            }
            if (collision.gameObject.name == "Warrior4(Clone)")
            {
                collision.GetComponent<Warrior4Script>().Speed *= 0.7f;
            }
            if (collision.gameObject.name == "Warrior5(Clone)")
            {
                collision.GetComponent<Warrior5Script>().Speed *= 0.7f;
            }
            if (collision.gameObject.name == "Warrior6(Clone)")
            {
                collision.GetComponent<Warrior6Script>().Speed *= 0.7f;
            }
        }
        //命中掉血
        if (collision.gameObject.name == "Player")
        {
            collision.GetComponent<PlayerScript>().DecreasePlayerHp(50);

            collision.GetComponentInParent<PlayerScript>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            collision.GetComponentInParent<PlayerScript>().BloodTxt.text = "-" + "50";
            collision.GetComponentInParent<PlayerScript>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            collision.GetComponentInParent<PlayerScript>().InvokeFalseBloodTxt();
        }
        if (collision.gameObject.name == "Warrior1(Clone)")
        {
            collision.GetComponent<Warrior1Script>().DecreaseWarrior1Hp(50);

            collision.GetComponentInParent<Warrior1Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            collision.GetComponentInParent<Warrior1Script>().BloodTxt.text = "-" + "50";
            collision.GetComponentInParent<Warrior1Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            collision.GetComponentInParent<Warrior1Script>().InvokeFalseBloodTxt();
        }
        if (collision.gameObject.name == "Warrior2(Clone)")
        {
            collision.GetComponent<Warrior2Script>().DecreaseWarrior2Hp(50);

            collision.GetComponentInParent<Warrior2Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            collision.GetComponentInParent<Warrior2Script>().BloodTxt.text = "-" + "50";
            collision.GetComponentInParent<Warrior2Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            collision.GetComponentInParent<Warrior2Script>().InvokeFalseBloodTxt();
        }
        if (collision.gameObject.name == "Warrior3(Clone)")
        {
            collision.GetComponent<Warrior3Script>().DecreaseWarrior3Hp(50);

            collision.GetComponentInParent<Warrior3Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            collision.GetComponentInParent<Warrior3Script>().BloodTxt.text = "-" + "50";
            collision.GetComponentInParent<Warrior3Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            collision.GetComponentInParent<Warrior3Script>().InvokeFalseBloodTxt();
        }
        if (collision.gameObject.name == "Warrior4(Clone)")
        {
            collision.GetComponent<Warrior4Script>().DecreaseWarrior4Hp(50);

            collision.GetComponentInParent<Warrior4Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            collision.GetComponentInParent<Warrior4Script>().BloodTxt.text = "-" + "50";
            collision.GetComponentInParent<Warrior4Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            collision.GetComponentInParent<Warrior4Script>().InvokeFalseBloodTxt();
        }
        if (collision.gameObject.name == "Warrior5(Clone)")
        {
            collision.GetComponent<Warrior5Script>().DecreaseWarrior5Hp(50);

            collision.GetComponentInParent<Warrior5Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
            collision.GetComponentInParent<Warrior5Script>().BloodTxt.text = "-" + "50";
            collision.GetComponentInParent<Warrior5Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
            collision.GetComponentInParent<Warrior5Script>().InvokeFalseBloodTxt();
            if (collision.gameObject.name == "Warrior6(Clone)")
            {
                collision.GetComponent<Warrior6Script>().DecreaseWarrior6Hp(50);

                collision.GetComponentInParent<Warrior6Script>().BloodTxt.gameObject.SetActive(true);      //掉血文本特效
                collision.GetComponentInParent<Warrior6Script>().BloodTxt.text = "-" + "50";
                collision.GetComponentInParent<Warrior6Script>().BloodTxt.color = new Color(0.812f, 0.235f, 0.235f);
                collision.GetComponentInParent<Warrior6Script>().InvokeFalseBloodTxt();
            }
        }
        //命中加分
        if (this.transform.parent.name == "Player")
        {
            GetComponentInParent<PlayerScript>().m.GetComponent<MapScript>().dic["玩家"] += 50;
        }
        if (this.transform.parent.name == "Warrior1(Clone)")
        {
           this.transform.parent.GetComponentInParent<Warrior1Script>().m.GetComponent<MapScript>().dic[transform.parent.parent.GetComponent<Warrior1Script>().Name] += 50;
        }
        if (this.transform.parent.name == "Warrior2(Clone)")
        {
            this.transform.parent.GetComponentInParent<Warrior2Script>().m.GetComponent<MapScript>().dic[transform.parent.parent.GetComponent<Warrior2Script>().Name] += 50;
        }
        if (this.transform.parent.name == "Warrior3(Clone)")
        {
            this.transform.parent.GetComponentInParent<Warrior3Script>().m.GetComponent<MapScript>().dic[transform.parent.parent.GetComponent<Warrior3Script>().Name] += 50;
        }
        if (this.transform.parent.name == "Warrior4(Clone)")
        {
            this.transform.parent.GetComponentInParent<Warrior4Script>().m.GetComponent<MapScript>().dic[transform.parent.parent.GetComponent<Warrior4Script>().Name] += 50;
        }
        if (this.transform.parent.name == "Warrior5(Clone)")
        {
            this.transform.parent.GetComponentInParent<Warrior5Script>().m.GetComponent<MapScript>().dic[transform.parent.parent.GetComponent<Warrior5Script>().Name] += 50;
        }
        if (this.transform.parent.name == "Warrior6(Clone)")
        {
            this.transform.parent.GetComponentInParent<Warrior6Script>().m.GetComponent<MapScript>().dic[transform.parent.parent.GetComponent<Warrior6Script>().Name] += 50;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc" || collision.gameObject.name == "Player")
        {
            //print("激光命中");
            if (collision.gameObject.name == "Player")
            {
                collision.GetComponent<PlayerScript>().speed /= 0.7f;
            }
            if (collision.gameObject.name == "Warrior1(Clone)")
            {
                collision.GetComponent<Warrior1Script>().Speed /= 0.7f;
            }
            if (collision.gameObject.name == "Warrior2(Clone)")
            {
                collision.GetComponent<Warrior2Script>().Speed /= 0.7f;
            }
            if (collision.gameObject.name == "Warrior3(Clone)")
            {
                collision.GetComponent<Warrior3Script>().Speed /= 0.7f;
            }
            if (collision.gameObject.name == "Warrior4(Clone)")
            {
                collision.GetComponent<Warrior4Script>().Speed /= 0.7f;
            }
            if (collision.gameObject.name == "Warrior5(Clone)")
            {
                collision.GetComponent<Warrior5Script>().Speed /= 0.7f;
            }
            if (collision.gameObject.name == "Warrior6(Clone)")
            {
                collision.GetComponent<Warrior6Script>().Speed /= 0.7f;
            }
        }
    }
}
