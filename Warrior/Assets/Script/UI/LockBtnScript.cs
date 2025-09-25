using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockBtnScript : MonoBehaviour
{
    public GameObject Manager;
    public Button [] WarriorBtn;
    public GameObject BugPanel;
    public Image WarningImg;
    public PlayerScript p;
    public Text CoinTxt;
    public Text AskTxt;

    void Start()
    {
       
    }
    void Update()
    {
        //print(WarriorBtn[1].GetComponent<W2btnScript>().IPress);
    }
    public void PressLockBtn(bool isFirst)
    {
        
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        int index = isFirst? PlayerPrefs.GetInt("CurrentPlayer") : Manager.GetComponent<StartSceneScript>().ChooseIndex;
        switch (index)
        {
            case 1:
                if (WarriorBtn[0].GetComponent<W1btnScript>().ILock)           //已解锁情况下点击
                {
                    WarriorBtn[0].GetComponent<W1btnScript>().IPress = true;
                    WarriorBtn[1].GetComponent<W2btnScript>().IPress = false;  //重置其余按压
                    WarriorBtn[2].GetComponent<W3btnScript>().IPress = false;
                    WarriorBtn[3].GetComponent<W4btnScript>().IPress = false;
                    WarriorBtn[4].GetComponent<W5btnScript>().IPress = false;
                    WarriorBtn[5].GetComponent<W6btnScript>().IPress = false;
                    WarriorBtn[0].GetComponent<W1btnScript>().W1();
                    PlayerPrefs.SetInt("CurrentPlayer", 1);
                }
                else 
                {
                    //BugPanel.SetActive(true); //弹出是否购买界面
                    //CoinTxt.text = "*5000";
                    //AskTxt.text = "是否花费5000金币解锁该勇者";
                    //WarningImg.GetComponent<Image>().sprite = p.WarriorImg[0];

                }
                break;
            case 2:
                if (WarriorBtn[1].GetComponent<W2btnScript>().ILock)
                {
                    WarriorBtn[0].GetComponent<W1btnScript>().IPress = false;
                    WarriorBtn[1].GetComponent<W2btnScript>().IPress = true;  //重置其余按压
                    WarriorBtn[2].GetComponent<W3btnScript>().IPress = false;
                    WarriorBtn[3].GetComponent<W4btnScript>().IPress = false;
                    WarriorBtn[4].GetComponent<W5btnScript>().IPress = false;
                    WarriorBtn[5].GetComponent<W6btnScript>().IPress = false;
                    WarriorBtn[1].GetComponent<W2btnScript>().W2();
                    PlayerPrefs.SetInt("CurrentPlayer", 2);
                }
                else /*if (!WarriorBtn[1].GetComponent<W1btnScript>().ILock)*/
                {
                    // BugPanel.SetActive(true); //弹出是否购买界面
                    // CoinTxt.text = "*5000";
                    // AskTxt.text = "是否花费5000金币解锁该异兽？";
                    // WarningImg.GetComponent<Image>().sprite = p.WarriorImg[1];
                }
                break;
            case 3:
                if (WarriorBtn[2].GetComponent<W3btnScript>().ILock)
                {
                    WarriorBtn[0].GetComponent<W1btnScript>().IPress = false;
                    WarriorBtn[1].GetComponent<W2btnScript>().IPress = false;  //重置其余按压
                    WarriorBtn[2].GetComponent<W3btnScript>().IPress = true;
                    WarriorBtn[3].GetComponent<W4btnScript>().IPress = false;
                    WarriorBtn[4].GetComponent<W5btnScript>().IPress = false;
                    WarriorBtn[5].GetComponent<W6btnScript>().IPress = false;
                    WarriorBtn[2].GetComponent<W3btnScript>().W3();
                    PlayerPrefs.SetInt("CurrentPlayer", 3);
                }
                else 
                {
                    // BugPanel.SetActive(true); //弹出是否购买界面
                    // CoinTxt.text = "*20000";
                    // AskTxt.text = "是否花费20000金币解锁该异兽？";
                    // WarningImg.GetComponent<Image>().sprite = p.WarriorImg[2];
                }
                break;
            case 4:
                if (WarriorBtn[3].GetComponent<W4btnScript>().ILock)
                {
                    WarriorBtn[0].GetComponent<W1btnScript>().IPress = false;
                    WarriorBtn[1].GetComponent<W2btnScript>().IPress = false;  //重置其余按压
                    WarriorBtn[2].GetComponent<W3btnScript>().IPress = false;
                    WarriorBtn[3].GetComponent<W4btnScript>().IPress = true;
                    WarriorBtn[4].GetComponent<W5btnScript>().IPress = false;
                    WarriorBtn[5].GetComponent<W6btnScript>().IPress = false;
                    WarriorBtn[3].GetComponent<W4btnScript>().W4();
                    PlayerPrefs.SetInt("CurrentPlayer", 4);
                }
                else 
                {
                    // BugPanel.SetActive(true);//弹出是否购买界面
                    // CoinTxt.text = "*50000";
                    // AskTxt.text = "是否花费50000钻石解锁该异兽？";
                    // WarningImg.GetComponent<Image>().sprite = p.WarriorImg[3];
                }
                break;
            case 5:
                if (WarriorBtn[4].GetComponent<W5btnScript>().ILock)
                {
                    WarriorBtn[0].GetComponent<W1btnScript>().IPress = false;
                    WarriorBtn[1].GetComponent<W2btnScript>().IPress = false;  //重置其余按压
                    WarriorBtn[2].GetComponent<W3btnScript>().IPress = false;
                    WarriorBtn[3].GetComponent<W4btnScript>().IPress = false;
                    WarriorBtn[4].GetComponent<W5btnScript>().IPress = true;
                    WarriorBtn[5].GetComponent<W6btnScript>().IPress = false;
                    WarriorBtn[4].GetComponent<W5btnScript>().W5();
                    PlayerPrefs.SetInt("CurrentPlayer", 5);
                }
                else 
                {
                    // BugPanel.SetActive(true); //弹出是否购买界面
                    // CoinTxt.text = "*300";
                    // AskTxt.text = "是否花费300钻石解锁该异兽？";
                    // WarningImg.GetComponent<Image>().sprite = p.WarriorImg[4];
                }
                break;
            case 6:
                if (WarriorBtn[5].GetComponent<W6btnScript>().ILock)
                {
                    WarriorBtn[0].GetComponent<W1btnScript>().IPress = false;
                    WarriorBtn[1].GetComponent<W2btnScript>().IPress = false;  //重置其余按压
                    WarriorBtn[2].GetComponent<W3btnScript>().IPress = false;
                    WarriorBtn[3].GetComponent<W4btnScript>().IPress = false;
                    WarriorBtn[4].GetComponent<W5btnScript>().IPress = false;
                    WarriorBtn[5].GetComponent<W6btnScript>().IPress = true;
                    WarriorBtn[5].GetComponent<W6btnScript>().W6();
                    PlayerPrefs.SetInt("CurrentPlayer", 6);
                }
                else 
                {
                    // BugPanel.SetActive(true);//弹出是否购买界面
                    // CoinTxt.text = "*500";
                    // AskTxt.text = "是否花费500钻石解锁该异兽？";
                    // WarningImg.GetComponent<Image>().sprite = p.WarriorImg[5];
                }
                break;
        }
    }
}
