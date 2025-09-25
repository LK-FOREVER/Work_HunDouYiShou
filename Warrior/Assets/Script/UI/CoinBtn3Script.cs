using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBtn3Script : MonoBehaviour
{
    public GameObject NotEnoughPop;
    public GameObject BuyResourcePanel;

    public void OnClickCoinBtn3()
    {
        int crystal = PlayerPrefs.GetInt("Crystal", 0);
        int coin = PlayerPrefs.GetInt("Coin", 0);
        if (crystal < 10)
        {
            NotEnoughPop.SetActive(true);
            return;
        }
        BuyResourcePanel.SetActive(true);
        BuyResourcePanel.GetComponent<BuyResourcePanel>().InitUI(3);
    }
}
