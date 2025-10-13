using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBtn1Script : MonoBehaviour
{
    public GameObject NotEnoughPop;
    public void OnClickMonsterBtn1()
    {
        int crystal = PlayerPrefs.GetInt(SdkScript.nickname + "Crystal", 0);
        int coin = PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0);
        if (crystal < 10)
        {
            NotEnoughPop.SetActive(true);
            return;
        }
        crystal -= 10;
        coin += 500;
        PlayerPrefs.SetInt(SdkScript.nickname + "Crystal", crystal);
        PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);
    }
}
