using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Honor15BtnScript : MonoBehaviour
{
    public HonorbtnScriot h;
    public int P_Get;
    public PlayerScript p;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetCoin15()
    {
        p.audio.clip = p.acilp[12];
        p.audio.Play();

        int coin = PlayerPrefs.GetInt("Coin", 0);
        coin += 1200;
        PlayerPrefs.SetInt("Coin", coin);
      
        P_Get = PlayerPrefs.GetInt("Get15", 0);          //判断是否领取过奖励
        P_Get = 2;
        PlayerPrefs.SetInt("get15", 1);
        PlayerPrefs.SetInt("Get15", P_Get);
        h.getnum--;
        PlayerPrefs.SetInt("Getnum", h.getnum);
       
    }
}
