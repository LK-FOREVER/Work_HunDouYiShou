using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterPanelScript : MonoBehaviour
{
    public GameObject[] btnImg;
    public GameObject[] btnTxt;
    public Button[] btn;
    public void InitUI()
    {
        btnImg[0].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock2", 0) == 0);
        btnTxt[0].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock2", 0) == 1);
        btnImg[1].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock3", 0) == 0);
        btnTxt[1].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock3", 0) == 1);
        btnImg[2].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock4", 0) == 0);
        btnTxt[2].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock4", 0) == 1);
        btnImg[3].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock5", 0) == 0);
        btnTxt[3].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock5", 0) == 1);
        btnImg[4].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock6", 0) == 0);
        btnTxt[4].SetActive(PlayerPrefs.GetInt("PlayerPrefsLock6", 0) == 1);
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = PlayerPrefs.GetInt("PlayerPrefsLock" + (i + 1), 0) == 0;
        }
    }
}
