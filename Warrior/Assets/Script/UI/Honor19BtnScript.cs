using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Honor19BtnScript : MonoBehaviour
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
    public void GetCoin19()
    {
        p.audio.clip = p.acilp[12];
        p.audio.Play();

        int coin = PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0);
        coin += 1000;
        PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);
       
        P_Get = PlayerPrefs.GetInt(SdkScript.nickname + "Get19", 0);          //�ж��Ƿ���ȡ������
        P_Get = 2;
        PlayerPrefs.SetInt(SdkScript.nickname + "get19", 1);
        PlayerPrefs.SetInt(SdkScript.nickname + "Get19", P_Get);
        h.getnum--;
        PlayerPrefs.SetInt(SdkScript.nickname + "Getnum", h.getnum);
        
    }
}
