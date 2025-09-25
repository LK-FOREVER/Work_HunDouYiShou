using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActiveScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //print("CollisionSucceed");
            this.gameObject.SetActive(false);
        }
    }
}
