using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill3Script : MonoBehaviour
{
    public bool IClick = true;                 //是否可以点击
    public Sprite[] S;
    public GameObject Player;
    public GameObject PlayerRotation;
    public GameObject m;
    public Image PlayerBackground;
    public Image PlayerBlood;
    public Text PlayerBloodTxt;
    // Update is called once per frame
    void Update()
    {
      
    }
    public void UseSkill()
    {
        if (IClick)
        {
            Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[3];
            Player.GetComponent<PlayerScript>().audio.Play();
            IClick = false;
            this.GetComponent<Image>().sprite = S[1];
            Invoke("falseSprite", 20f);                             //技能冷却
            m = GameObject.Find("MapManager");
            foreach(var temp in Player.GetComponent<PlayerScript>().ItemObject)
            {
                temp.SetActive(false);
            }
        }
        m.GetComponent<MapScript>().Others.Remove(Player);
        Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        PlayerRotation.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        PlayerBackground.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        PlayerBlood.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        PlayerBloodTxt.GetComponent<Text>().color = new Color(1, 1, 1, 0.5f);
        Player.GetComponent<PlayerScript>().Ak = 40;
        Invoke("fasleSkill", 10f);                                 //技能持续

    }
    public void falseSprite()
    {
        this.GetComponent<Image>().sprite = S[0];
        IClick = true;

    }

    public void fasleSkill()
    {
        m.GetComponent<MapScript>().Others.Add(Player);
        Player.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        PlayerRotation.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        PlayerBackground.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        PlayerBlood.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        PlayerBloodTxt.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        Player.GetComponent<PlayerScript>().Ak = 30;
    }
}
