using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Skill2Script : MonoBehaviour
{
    public bool IClick = true;                 //是否可以点击

    public Sprite[] S;
    public GameObject Player;
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
            Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[2];
            Player.GetComponent<PlayerScript>().audio.Play();
            IClick = false;
            this.GetComponent<Image>().sprite = S[1];
            Invoke("falseSprite", 20f);

            Player.GetComponent<PlayerScript>().Ishield = true;
            Player.GetComponent<PlayerScript>().ShieldHp = 150f;
            Invoke("falseSkill", 5f);

            Player.GetComponent<PlayerScript>().ShieldEff.SetActive(true);
            Invoke("FalseShieldEff", 5f);
        }

    }
    public void falseSprite()
    {
        this.GetComponent<Image>().sprite = S[0];
        IClick = true;
    }
    public void falseSkill()
    {
        Player.GetComponent<PlayerScript>().Ishield = false;
        Player.GetComponent<PlayerScript>().ShieldHp = 0;
    }
    public void FalseShieldEff()
    {
        Player.GetComponent<PlayerScript>().ShieldEff.SetActive(false);
    }
}
