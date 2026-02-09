using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBtn5Script : MonoBehaviour
{
    public GameObject ChargeWarnPop;
    public GameObject BuyResourcePanel;
    public void OnClickCoinBtn5()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
        if (SdkScript.adult_level == 2)
        {
            ChargeWarnPop.SetActive(true);
            return;
        }
        BuyResourcePanel.SetActive(true);
        BuyResourcePanel.GetComponent<BuyResourcePanel>().InitUI(5);
    }
}
