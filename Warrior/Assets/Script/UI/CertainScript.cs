using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CertainScript : MonoBehaviour
{
    public StartSceneScript s;
    public monsterPanelScript monsterPanelScript;
    public GameObject BuyPanel;

    public Text NoCoinTxt;
    public bool ICertainBuy;
    int coin;
    void Start()
    {
        NoCoinTxt.gameObject.SetActive(false);
    }
    public void Certain()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
        coin = PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0);
        switch (s.ChooseWarrior)
        {
            case 2:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock2", 0) == 0 && coin >= 5000)                //�ڽ��������
                {
                    s.WarriorBtn[1].GetComponent<W2btnScript>().Lock.gameObject.SetActive(false); //�ر���

                    coin -= 5000;
                    PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);              //Ǯ�����
                    s.WarriorBtn[1].GetComponent<W2btnScript>().LockBtnTxt.text = "出战";
                    PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock2", 1);     //��������ô洢
                    BuyPanel.SetActive(false);

                    int WorkNum = PlayerPrefs.GetInt(SdkScript.nickname + "WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt(SdkScript.nickname + "WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt(SdkScript.nickname + "NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt(SdkScript.nickname + "NewHero", P_NewHero);
                    PlayerPrefs.Save();

                    //成就任务进度更新
                    PlayerData.Instance.achievementTaskProgress[1] += 1;
                }
                else if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock2", 0) == 0 && coin < 5000/*&&ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock3", 0) == 0 && coin >= 8000)                //�ڽ��������
                {
                    s.WarriorBtn[2].GetComponent<W3btnScript>().Lock.gameObject.SetActive(false); //�ر���
                    coin -= 8000;
                    PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);              //Ǯ�����
                    s.WarriorBtn[2].GetComponent<W3btnScript>().LockBtnTxt.text = "出战";
                    PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock3", 1);
                    BuyPanel.SetActive(false);
                    int WorkNum = PlayerPrefs.GetInt(SdkScript.nickname + "WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt(SdkScript.nickname + "WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt(SdkScript.nickname + "NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt(SdkScript.nickname + "NewHero", P_NewHero);
                    PlayerPrefs.Save();
                    //成就任务进度更新
                    PlayerData.Instance.achievementTaskProgress[2] += 1;
                }
                else if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock3", 0) == 0 && coin < 8000 /*&& ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock4", 0) == 0 && coin >= 8000)                //�ڽ��������
                {
                    s.WarriorBtn[3].GetComponent<W4btnScript>().Lock.gameObject.SetActive(false); //�ر���
                    coin -= 8000;
                    PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);              //Ǯ�����
                    s.WarriorBtn[3].GetComponent<W4btnScript>().LockBtnTxt.text = "出战";
                    PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock4", 1);
                    BuyPanel.SetActive(false);
                    int WorkNum = PlayerPrefs.GetInt(SdkScript.nickname + "WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt(SdkScript.nickname + "WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt(SdkScript.nickname + "NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt(SdkScript.nickname + "NewHero", P_NewHero);
                    PlayerPrefs.Save();
                    //成就任务进度更新
                    PlayerData.Instance.achievementTaskProgress[3] += 1;
                }
                else if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock4", 0) == 0 && coin < 8000/* && ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock5", 0) == 0 && coin >= 15000)                //�ڽ��������
                {
                    s.WarriorBtn[4].GetComponent<W5btnScript>().Lock.gameObject.SetActive(false); //�ر���
                    coin -= 15000;
                    PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);              //Ǯ�����
                    s.WarriorBtn[4].GetComponent<W5btnScript>().LockBtnTxt.text = "出战";
                    PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock5", 1);
                    BuyPanel.SetActive(false);
                    int WorkNum = PlayerPrefs.GetInt(SdkScript.nickname + "WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt(SdkScript.nickname + "WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt(SdkScript.nickname + "NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt(SdkScript.nickname + "NewHero", P_NewHero);
                    PlayerPrefs.Save();
                    //成就任务进度更新
                    PlayerData.Instance.achievementTaskProgress[4] += 1;
                }
                else if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock5", 0) == 0 && coin < 15000 /*&& ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
            case 6:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock6", 0) == 0 && coin >= 15000)                //�ڽ��������
                {
                    s.WarriorBtn[5].GetComponent<W6btnScript>().Lock.gameObject.SetActive(false); //�ر���
                    coin -= 15000;
                    PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);              //Ǯ�����
                    s.WarriorBtn[5].GetComponent<W6btnScript>().LockBtnTxt.text = "出战";
                    PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock6", 1);
                    BuyPanel.SetActive(false);
                    int WorkNum = PlayerPrefs.GetInt(SdkScript.nickname + "WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt(SdkScript.nickname + "WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt(SdkScript.nickname + "NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt(SdkScript.nickname + "NewHero", P_NewHero);
                    PlayerPrefs.Save();
                    //成就任务进度更新
                    PlayerData.Instance.achievementTaskProgress[5] += 1;
                }
                else if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock6", 0) == 0 && coin < 15000 /*&& ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
        }
        monsterPanelScript.InitUI();
        PlayerData.Instance.SaveData();
    }
    public void falseNoCoinTxt()
    {
        NoCoinTxt.gameObject.SetActive(false);
    }
}
