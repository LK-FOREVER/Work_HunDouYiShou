using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior6CollisionScript : MonoBehaviour
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
        GetComponentInParent<Warrior6Script>().ColiEff.SetActive(false);
    }
    public void FalseShieldEff()
    {
        // GetComponentInParent<Warrior6Script>().Player.GetComponent<PlayerScript>().ShieldEff.SetActive(false);
    }
    public void FalseMonsterEff()
    {
    }
}
