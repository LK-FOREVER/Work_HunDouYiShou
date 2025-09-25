using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill6Script : MonoBehaviour
{
    public bool IClick = true;                 //是否可以点击
    public Sprite[] S;
    bool IShowSkill;
    public GameObject Player;
    public GameObject PlayerBoom;
    GameObject obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

       
    }
    public void UseSkill()
    {
        if (IClick)
        {
            Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[6];
            Player.GetComponent<PlayerScript>().audio.Play();
            IClick = false;
            this.GetComponent<Image>().sprite = S[1];
            Invoke("falseSprite", 15f);

             obj = GameObject.Instantiate(PlayerBoom);
            obj.transform.position = Player.transform.position;
           


        }


    }
    public void falseSprite()
    {
        this.GetComponent<Image>().sprite = S[0];
        IClick = true;
    }
    
}
