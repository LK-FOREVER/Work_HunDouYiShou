using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill5Script : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    void Update()
    {
      Player.GetComponent<PlayerScript>(). Ak = (int)(10 + (500 - Player.GetComponent<PlayerScript>().PlayerHp) * 0.2f);
    }
}
