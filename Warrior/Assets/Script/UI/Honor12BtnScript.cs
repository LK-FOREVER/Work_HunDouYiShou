using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Honor12BtnScript : MonoBehaviour
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
    public void GetCoin12()
    {
        p.audio.clip = p.acilp[12];
        p.audio.Play();

        int coin = PlayerPrefs.GetInt("Coin", 0);
        coin += 360;
        PlayerPrefs.SetInt("Coin", coin);
       
        P_Get = PlayerPrefs.GetInt("Get12", 0);          //判断是否领取过奖励
        P_Get = 2;
        PlayerPrefs.SetInt("get12", 1);
        PlayerPrefs.SetInt("Get12", P_Get);
        h.getnum--;
        PlayerPrefs.SetInt("Getnum", h.getnum);
        
    }
}
