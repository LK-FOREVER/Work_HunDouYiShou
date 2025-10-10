using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoomScript : MonoBehaviour
{
    public GameObject Boomeff;
    GameObject obj;
  
    void Start()
    {
        Invoke("FalseBomb", 30f);
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Npc")
        {
            obj = Instantiate(Boomeff);
            obj.transform.position = collision.transform.position;
            Invoke("FalseBoom", 1f);
            Destroy(obj,0.6f);
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
