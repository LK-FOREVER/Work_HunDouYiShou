using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NpcScript : MonoBehaviour
{
    public GameObject NpcRotationIcon;
     GameObject m;
    public bool INpcColli=false;
    Rigidbody2D rig;
    Vector3 V=new Vector3(0,1,0);

    GameObject Player;

    Vector3 TargetPos;
    float desPos;
    float desPlayer;
    float desNpc;
    float Speed =1f;
    Vector3 D;
    public  Vector3 d;
    bool IMoveToPos = true;
    bool IMoveToPlayer;
    void Start()
    {
        Player = GameObject.Find("Player");
        m = GameObject.Find("MapManager");
        rig =GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //desPlayer = Vector3.Distance(this.transform.position, Player.transform.position);
        //if (desPlayer < 5f)
        //{
        //    IMoveToPlayer = true;
        //    IMoveToPos = false;
        //}
        //else
        //{
        //    IMoveToPlayer = false;
        //    IMoveToPos = true;
        //}
        RemoveToTargetPos();
        RemoveToOthers();
        //RemoveToPlayer();




        float r=Vector3.Angle(V,d);
        if (d.x < 0)
        {
          
                NpcRotationIcon.transform.rotation = Quaternion.Euler(0, 0, r);
           
           
        }
        else
        {
           
                NpcRotationIcon.transform.rotation = Quaternion.Euler(0, 0, -r);
           
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DontMove")
        {
            INpcColli = true;
            rig.AddForce(-d * 20000 * Time.deltaTime);
            d = -d;
            rig.drag = 6f;
            rig.angularDrag = 6f;
            float x = Random.Range(-4f, 28f);
            float y = Random.Range(-42f, 6f);
            TargetPos = new Vector3(x, y, 0);
            IMoveToPlayer = false;
            IMoveToPos = true;
        }
        if (collision.gameObject.tag == "PLAYER")
        {
            INpcColli = true;
            rig.AddForce(Player.GetComponent<PlayerScript>().d * 30000 * Time.deltaTime);
            //d = -d;
            rig.drag = 6f;
            rig.angularDrag = 6f;
            IMoveToPlayer=true;
            IMoveToPos=false;
        }
        if (collision.gameObject.tag == "Npc")
        {
            INpcColli = true;
            rig.AddForce(collision.GetComponent<NpcScript>().d * 30000 * Time.deltaTime);
            d = -d;
            rig.drag = 6f;
            rig.angularDrag = 6f;
            float x = Random.Range(-4f, 28f);
            float y = Random.Range(-42f, 6f);
            TargetPos = new Vector3(x, y, 0);
        }
    }
    
        public void RemoveToTargetPos()
       {
        if (IMoveToPos)
        {
            D = TargetPos - this.transform.position;
            d = D.normalized;
            desPos = Vector3.Distance(this.transform.position, TargetPos);
            if (desPos > 0.5f)
            {
                this.transform.position += d * Speed * Time.deltaTime;
            }
            else  
            {
                float x = Random.Range(-4f, 28f);
                float y = Random.Range(-42f, 6f);
                TargetPos = new Vector3(x, y, 0);
            }
        }
       
       }
    public void RemoveToPlayer()
    {
       
        if (IMoveToPlayer)
        {
            
            
                D = Player.transform.position - this.transform.position;
                d = D.normalized;
                this.transform.position += d * Speed * Time.deltaTime;
            
        }
    }
    public void RemoveToOthers()
    { 
        
            for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
            {
            desNpc = Vector3.Distance(this.transform.position, m.GetComponent<MapScript>().Others[i].transform.position);
      
                if (desNpc <= 5f && (m.GetComponent<MapScript>().Others[i] != this.gameObject))
                {
                    IMoveToPos = false;
                    IMoveToPlayer = false; 
                    D = m.GetComponent<MapScript>().Others[i].transform.position - this.transform.position;
                    d = D.normalized;
                    this.transform.position += d * Speed * Time.deltaTime;
                }
            else
            {
                IMoveToPos = true;
            }
        }

    }

}
