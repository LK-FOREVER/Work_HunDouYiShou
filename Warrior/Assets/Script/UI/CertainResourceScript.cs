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
        int crystal = PlayerPrefs.GetInt("Crystal", 0);
        int coin = PlayerPrefs.GetInt("Coin", 0);
        switch (s.ChooseResource)
        {
            case 1:
                BuyResourcePanel.SetActive(false);
                crystal += 100;
                PlayerPrefs.SetInt("Crystal", crystal);
                break;
            case 2:
                BuyResourcePanel.SetActive(false);
                crystal += 500;
                PlayerPrefs.SetInt("Crystal", crystal);
                break;
            case 3:
                if (crystal < 10)
                {
                    NoCoinTxt.text = "水晶不足";
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                    return;
                }
                BuyResourcePanel.SetActive(false);
                crystal -= 10;
                coin += 500;
                PlayerPrefs.SetInt("Crystal", crystal);
                PlayerPrefs.SetInt("Coin", coin);
                break;
            case 4:
                if (crystal < 40)
                {
                    NoCoinTxt.text = "水晶不足";
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                    return;
                }
                BuyResourcePanel.SetActive(false);
                crystal -= 40;
                coin += 2000;
                PlayerPrefs.SetInt("Crystal", crystal);
                PlayerPrefs.SetInt("Coin", coin);
                break;
            case 5:
                if (crystal < 100)
                {
                    NoCoinTxt.text = "水晶不足";
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                    return;
                }
                BuyResourcePanel.SetActive(false);
                crystal -= 100;
                coin += 5000;
                PlayerPrefs.SetInt("Crystal", crystal);
                PlayerPrefs.SetInt("Coin", coin);
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
