using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CertainResourceScript : MonoBehaviour
{
    public StartSceneScript s;
    public Text NoCoinTxt;
    public GameObject BuyResourcePanel;

    void Start()
    {
        NoCoinTxt.gameObject.SetActive(false);
    }
    public void Certain()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
        int coin = PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0);
        switch (s.ChooseResource)
        {
            case 1:
                BuyResourcePanel.SetActive(false);
                coin += 600;
                PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);
                PlayerPrefs.SetInt(SdkScript.nickname + "ChargeNum", PlayerPrefs.GetInt(SdkScript.nickname + "ChargeNum", 0) + 6);//增加充值金额
                break;
            case 2:
                BuyResourcePanel.SetActive(false);
                coin += 1800;
                PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);
                PlayerPrefs.SetInt(SdkScript.nickname + "ChargeNum", PlayerPrefs.GetInt(SdkScript.nickname + "ChargeNum", 0) + 18);//增加充值金额
                break;
            case 3:
                BuyResourcePanel.SetActive(false);
                coin += 3000;
                PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);
                PlayerPrefs.SetInt(SdkScript.nickname + "ChargeNum", PlayerPrefs.GetInt(SdkScript.nickname + "ChargeNum", 0) + 30);//增加充值金额
                break;
            case 4:
                BuyResourcePanel.SetActive(false);
                coin += 6800;
                PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);
                PlayerPrefs.SetInt(SdkScript.nickname + "ChargeNum", PlayerPrefs.GetInt(SdkScript.nickname + "ChargeNum", 0) + 68);//增加充值金额
                break;
            case 5:
                BuyResourcePanel.SetActive(false);
                coin += 12800;
                PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);
                break;
            default:
                break;
        }
    }
    public void falseNoCoinTxt()
    {
        NoCoinTxt.gameObject.SetActive(false);
    }
}
