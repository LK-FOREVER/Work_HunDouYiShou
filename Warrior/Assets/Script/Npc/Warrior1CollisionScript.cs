using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Warrior1CollisionScript : MonoBehaviour
{
    public bool Ifront;
    public bool Iback;
    private Warrior1Script warrior1Script;

    void Start()
    {
        warrior1Script = GetComponentInParent<Warrior1Script>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    }
    public void FalseColiEff()
    {
        warrior1Script.ColiEff.SetActive(false);
    }
    public void FalseShieldEff()
    {
        // warrior1Script.Player.GetComponent<PlayerScript>().ShieldEff.SetActive(false);
    }
    public void FalseMonsterEff()
    {
    }

}
