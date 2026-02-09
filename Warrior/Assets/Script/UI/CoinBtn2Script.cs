using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBtn2Script : MonoBehaviour
{
    public GameObject ChargeWarnPop;
    public GameObject BuyResourcePanel;
    public void OnClickCoinBtn2()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
        if (SdkScript.adult_level == 2 && PlayerPrefs.GetInt(SdkScript.nickname + "ChargeNum", 0) + 18 > 400)
        {
            ChargeWarnPop.SetActive(true);
            return;
        }
        BuyResourcePanel.SetActive(true);
        BuyResourcePanel.GetComponent<BuyResourcePanel>().InitUI(2);
    }
}
