using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBloodScript : MonoBehaviour
{
    //bool Iscale = false;
    bool Ilarge = true;
    float s = 0.5f;
    Vector3 d;

    void Start()
    {
        
    }


    void Update()
    {
        //if (Iscale)
        //{
            if (Ilarge) //是否放大                
            {
                s += 0.0005f;
                if (s > 0.6f) //控制大小            
                {
                    Ilarge = false;
                }
            }
            else
            {
                s -= 0.025f;
                if (s < 0.5f)
                {
                    Ilarge = true;
                }
            }

            this.transform.localScale = new Vector3(s, s, 0);

        //}
        this.transform.position += d * 40f * Time.deltaTime;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MagneticObj")
        {

            if (collision.transform.parent.name == "Player")
            {
                if (collision.transform.parent.GetComponent<PlayerScript>().PlayerHp < collision.transform.parent.GetComponent<PlayerScript>().PlayerHP)
                {
                    d = (collision.transform.parent.transform.position - this.transform.position).normalized;
                }
                else
                {
                    d = new Vector3(0,0,0);
                }
            }
            if (collision.transform.parent.name == "Warrior1(Clone)")
            {
                if (collision.transform.parent.GetComponent<Warrior1Script>().Warrior1Hp < 200f)
                {
                    d = (collision.transform.parent.transform.position - this.transform.position).normalized;
                }
                else
                {
                    d = new Vector3(0,0,0);
                }
            }
            if (collision.transform.parent.name == "Warrior2(Clone)")
            {
                if (collision.transform.parent.GetComponent<Warrior2Script>().Warrior2Hp < 300f)
                {
                    d = (collision.transform.parent.transform.position - this.transform.position).normalized;
                }
                else
                {
                    d = new Vector3(0, 0, 0);
                }
            }
            if (collision.transform.parent.name == "Warrior3(Clone)")
            {
                if (collision.transform.parent.GetComponent<Warrior3Script>().Warrior3Hp < 150f)
                {
                    d = (collision.transform.parent.transform.position - this.transform.position).normalized;
                }
                else
                {
                    d = new Vector3(0, 0, 0);
                }
            }
            if (collision.transform.parent.name == "Warrior4(Clone)")
            {
                if (collision.transform.parent.GetComponent<Warrior4Script>().Warrior4Hp < 250f)
                {
                    d = (collision.transform.parent.transform.position - this.transform.position).normalized;
                }
                else
                {
                    d = new Vector3(0, 0, 0);
                }
            }
            if (collision.transform.parent.name == "Warrior5(Clone)")
            {
                if (collision.transform.parent.GetComponent<Warrior5Script>().Warrior5Hp < 500f)
                {
                    d = (collision.transform.parent.transform.position - this.transform.position).normalized;
                }
                else
                {
                    d = new Vector3(0, 0, 0);
                }
            }
            if (collision.transform.parent.name == "Warrior6(Clone)")
            {
                if (collision.transform.parent.GetComponent<Warrior6Script>().Warrior6Hp < 200f)
                {
                    d = (collision.transform.parent.transform.position - this.transform.position).normalized;
                }
                else
                {
                    d = new Vector3(0, 0, 0);
                }
            }
        }

    }
}
