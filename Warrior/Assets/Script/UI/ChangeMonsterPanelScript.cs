using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMonsterPanelScript : MonoBehaviour
{
    public GameObject[] lockObj;//锁
    public GameObject[] lockMaskObj;//遮罩
    public GameObject[] arrowObj;//箭头
    public Text buttonText;//出战按钮文字

    void OnEnable()
    {
        InitUI();
    }
    public void InitUI()
    {
        Debug.Log("CurrentPlayer：" + PlayerPrefs.GetInt("CurrentPlayer"));
        PlayerPrefs.SetInt("PlayerPrefsLock1", 1);//默认解锁第一个异兽
        for (int i = 1; i < lockObj.Length; i++)
        {
            if (PlayerPrefs.GetInt("PlayerPrefsLock" + (i + 1), 0) == 0)
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
        // for (int i = 0; i < arrowObj.Length; i++)
        // {
        //     if (PlayerPrefs.GetInt("PlayerPrefsLock" + (i + 1), 0) == 1 && arrowObj[i].activeSelf && PlayerPrefs.GetInt("CurrentPlayer", 0) == i + 1)
        //     {
        //         buttonText.text = "出战中";
        //     }
        //     else if (PlayerPrefs.GetInt("PlayerPrefsLock" + (i + 1), 0) == 1 && arrowObj[i].activeSelf)
        //     {
        //         buttonText.text = "出战";
        //     }
        // }
    }
}
