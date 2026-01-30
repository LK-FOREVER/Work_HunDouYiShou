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
        // GetComponentInParent<Warrior3Script>().Player.GetComponent<PlayerScript>().ShieldEff.SetActive(false);
    }
    public void FalseMonsterEff()
    {
    }
}
