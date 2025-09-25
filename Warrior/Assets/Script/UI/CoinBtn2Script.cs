using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBtn2Script : MonoBehaviour
{
    public GameObject ChargeWarnPop;
    public GameObject BuyResourcePanel;
    public void OnClickCoinBtn2()
    {
        if (SdkScript.adult_level == 2 && PlayerPrefs.GetInt(SdkScript.nickname+"ChargeNum",0)+25>=400)
        {
            ChargeWarnPop.SetActive(true);
            return;
        }
        BuyResourcePanel.SetActive(true);
        BuyResourcePanel.GetComponent<BuyResourcePanel>().InitUI(2);
    }
}
