using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBoomScript : MonoBehaviour
{
    public GameObject Boomeff;
    GameObject obj;
 
    void Start()
    {
        Boomeff = Resources.Load<GameObject>("Eff/BoomEffObj");
      
      
        Invoke("FalseBomb", 30f);
    }
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player"||collision.gameObject.tag=="Npc")
        {
            if (collision.gameObject.name != "Warrior6(Clone)")
            {
               
                obj = Instantiate(Boomeff);
                obj.transform.position = collision.transform.position;
                Destroy(obj, 0.6f);
            }
           
        }

    }
    public void FalseBomb()
    {
        this.gameObject.SetActive(false);
    }
    public void FalseBoom()
    {
        obj.SetActive(false);
    }
}
