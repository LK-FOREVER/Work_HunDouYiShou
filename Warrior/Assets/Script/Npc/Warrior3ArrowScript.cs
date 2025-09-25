using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior3ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCamera")
        {
            this.gameObject.SetActive(false);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCamera")
        {
            this.gameObject.SetActive(true);
        }
    }
}
