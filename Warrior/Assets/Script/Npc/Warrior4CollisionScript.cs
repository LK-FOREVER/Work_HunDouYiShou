using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior4CollisionScript : MonoBehaviour
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
    public void FalseColiEff()
    {
        GetComponentInParent<Warrior4Script>().ColiEff.SetActive(false);
    }
    public void FalseShieldEff()
    {
        // GetComponentInParent<Warrior4Script>().Player.GetComponent<PlayerScript>().ShieldEff.SetActive(false);
    }
    public void FalseMonsterEff()
    {
    }
}
