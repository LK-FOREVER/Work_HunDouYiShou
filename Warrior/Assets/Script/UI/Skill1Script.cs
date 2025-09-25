using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Skill1Script : MonoBehaviour
{
  public  bool IClick=true;                 //是否可以点击
    public Sprite[] S;
    public GameObject Player;
   

    void Start()
    {
       
    }

    void Update()
    {
       
    }
    public void UseSkill()
    {
       
        
        if (IClick)
        {
            Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[1];
            Player.GetComponent<PlayerScript>().audio.Play();
            IClick = false;
            this.GetComponent<Image>().sprite = S[1];
            Invoke("falseSprite", 20f);

            Player.GetComponent<PlayerScript>().speed = 5f;
            Invoke("falseSkill", 10f);
            Player.GetComponent <PlayerScript>().SpeedEff.SetActive(true);
            Invoke("FalseEff", 10f);
        }
       
        
    }
    public void falseSprite()
    {
        this.GetComponent<Image>().sprite = S[0];
        IClick = true;
    }
    public void falseSkill()
    {
        Player.GetComponent<PlayerScript>().speed = 3f;
    }
    public void FalseEff()
    {
        Player.GetComponent<PlayerScript>().SpeedEff.SetActive(false);
    }
}
