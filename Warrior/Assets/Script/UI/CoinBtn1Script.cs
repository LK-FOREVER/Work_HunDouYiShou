using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBtn1Script : MonoBehaviour
{
    public GameObject ChargeWarnPop;
    public GameObject BuyResourcePanel;
    public void OnClickCoinBtn1()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
        if (SdkScript.adult_level == 2 && PlayerPrefs.GetInt(SdkScript.nickname + "ChargeNum", 0) + 6 > 400)
        {
            ChargeWarnPop.SetActive(true);
            return;
        }
        BuyResourcePanel.SetActive(true);
        BuyResourcePanel.GetComponent<BuyResourcePanel>().InitUI(1);
    }
}
