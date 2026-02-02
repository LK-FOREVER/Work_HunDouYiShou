using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockBtnScript : MonoBehaviour
{
    public GameObject Manager;
    public Button[] WarriorBtn;
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
    }
    public void PressUnlockBtn()
    {

        p.audio.clip = p.acilp[0];
        p.audio.Play();
        int index = Manager.GetComponent<StartSceneScript>().ChooseIndex;
        // Debug.Log("index：" + index);
        EventManager.Instance.TriggerEvent(EventName.ChangeWarrior, this, new ChangeWarriorArgs() { index_monster = index });
        switch (index)
        {
            case 1:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock1", 1) == 1)           //�ѽ�������µ��
                {
                    PlayerPrefs.SetInt(SdkScript.nickname + "CurrentPlayer", 1);
                    WarriorBtn[0].GetComponent<W1btnScript>().W1();
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock2", 0) == 1)
                {
                    PlayerPrefs.SetInt(SdkScript.nickname + "CurrentPlayer", 2);
                    WarriorBtn[1].GetComponent<W2btnScript>().W2();
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock3", 0) == 1)
                {
                    PlayerPrefs.SetInt(SdkScript.nickname + "CurrentPlayer", 3);
                    WarriorBtn[2].GetComponent<W3btnScript>().W3();
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock4", 0) == 1)
                {
                    PlayerPrefs.SetInt(SdkScript.nickname + "CurrentPlayer", 4);
                    WarriorBtn[3].GetComponent<W4btnScript>().W4();
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock5", 0) == 1)
                {
                    PlayerPrefs.SetInt(SdkScript.nickname + "CurrentPlayer", 5);
                    WarriorBtn[4].GetComponent<W5btnScript>().W5();
                }
                break;
            case 6:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock6", 0) == 1)
                {
                    PlayerPrefs.SetInt(SdkScript.nickname + "CurrentPlayer", 6);
                    WarriorBtn[5].GetComponent<W6btnScript>().W6();
                }
                break;
        }
    }
}
