using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Honor11BtnScript : MonoBehaviour
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
    public void GetCoin11()
    {
        p.audio.clip = p.acilp[12];
        p.audio.Play();

        int coin = PlayerPrefs.GetInt("Coin", 0);
        coin += 36;
        PlayerPrefs.SetInt("Coin", coin);
      
        P_Get = PlayerPrefs.GetInt("Get11", 0);          //�ж��Ƿ���ȡ������
        P_Get = 2;
        PlayerPrefs.SetInt("get11", 1);
        PlayerPrefs.SetInt("Get11", P_Get);
        h.getnum--;
        PlayerPrefs.SetInt("Getnum", h.getnum);
       
    }
}
