using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBtn1Script : MonoBehaviour
{
    public GameObject NotEnoughPop;
    public void OnClickMonsterBtn1()
    {
        int crystal = PlayerPrefs.GetInt("Crystal", 0);
        int coin = PlayerPrefs.GetInt("Coin", 0);
        if (crystal < 10)
        {
            NotEnoughPop.SetActive(true);
            return;
        }
        crystal -= 10;
        coin += 500;
        PlayerPrefs.SetInt("Crystal", crystal);
        PlayerPrefs.SetInt("Coin", coin);
    }
}
