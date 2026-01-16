using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBtn4Script : MonoBehaviour
{
    public GameObject ChargeWarnPop;
    public GameObject BuyResourcePanel;
    public void OnClickCoinBtn4()
    {
        if (SdkScript.adult_level == 2 && PlayerPrefs.GetInt(SdkScript.nickname + "ChargeNum", 0) + 68 > 400)
        {
            ChargeWarnPop.SetActive(true);
            return;
        }
        BuyResourcePanel.SetActive(true);
        BuyResourcePanel.GetComponent<BuyResourcePanel>().InitUI(4);
    }
}
