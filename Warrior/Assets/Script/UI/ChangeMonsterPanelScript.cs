using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMonsterPanelScript : MonoBehaviour
{
    public GameObject[] lockObj;//锁
    public GameObject[] lockMaskObj;//遮罩
    public Button[] WarriorBtn;
    public GameObject[] arrowObj;//箭头
    public Text buttonText;//出战按钮文字

    void OnEnable()
    {
        InitUI();
    }
    public void InitUI()
    {
        PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock1", 1);//默认解锁第一个异兽
        for (int i = 1; i < lockObj.Length; i++)
        {
            if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock" + (i + 1), 0) == 0)
            {
                lockObj[i].SetActive(true);
                lockMaskObj[i].SetActive(true);
            }
            else
            {
                lockObj[i].SetActive(false);
                lockMaskObj[i].SetActive(false);
            }
        }
        
        int currentPlayer = PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1);
        switch (currentPlayer)
        {
            case 1:
                WarriorBtn[0].GetComponent<W1btnScript>().W1();
                break;
            case 2:
                WarriorBtn[1].GetComponent<W2btnScript>().W2();
                break;
            case 3:
                WarriorBtn[2].GetComponent<W3btnScript>().W3();
                break;
            case 4:
                WarriorBtn[3].GetComponent<W4btnScript>().W4();
                break;
            case 5:
                WarriorBtn[4].GetComponent<W5btnScript>().W5();
                break;
            case 6:
                WarriorBtn[5].GetComponent<W6btnScript>().W6();
                break;
            default:
                break;
        }
        // for (int i = 0; i < arrowObj.Length; i++)
        // {
        //     if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock" + (i + 1), 0) == 1 && arrowObj[i].activeSelf && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 0) == i + 1)
        //     {
        //         buttonText.text = "出战中";
        //     }
        //     else if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock" + (i + 1), 0) == 1 && arrowObj[i].activeSelf)
        //     {
        //         buttonText.text = "出战";
        //     }
        // }
    }
}
