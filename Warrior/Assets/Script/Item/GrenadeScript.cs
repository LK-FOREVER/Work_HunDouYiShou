using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{

    GameObject GrenadeBoomEff;
    bool IBoom = true;
    void Start()
    {
        //Invoke("ActiveBoomRange", 1f);
    }

    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Npc" || collision.gameObject.name == "Player")&& collision.gameObject.transform != this.transform.parent)
        {
            if (IBoom)
            {
                print("手雷掉血");
                this.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
                GrenadeBoomEff = (GameObject)Resources.Load("Prefabs/GrenadeBoomEff");
                // GameObject Obj = Instantiate(GrenadeBoomEff, collision.transform.position, collision.transform.rotation);
                GameObject Obj = Instantiate(GrenadeBoomEff, this.transform.position, this.transform.rotation);
                Obj.transform.parent = this.transform;
                Destroy(this.gameObject, 0.5f);

                Destroy(Obj, 0.75f);
                IBoom = false;
            }

        }
    }
    //public void ActiveBoomRange()
    //{
    //    BoomRange.SetActive(true);
    //    this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    //}
}
