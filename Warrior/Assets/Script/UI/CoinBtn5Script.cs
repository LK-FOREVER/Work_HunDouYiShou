using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBtn5Script : MonoBehaviour
{
    public GameObject NotEnoughPop;
    public GameObject BuyResourcePanel;
    public void OnClickCoinBtn5()
    {
        int crystal = PlayerPrefs.GetInt("Crystal", 0);
        int coin = PlayerPrefs.GetInt("Coin", 0);
        if (crystal < 100)
        {
            NotEnoughPop.SetActive(true);
            return;
        }
        BuyResourcePanel.SetActive(true);
        BuyResourcePanel.GetComponent<BuyResourcePanel>().InitUI(5);
    }
}
