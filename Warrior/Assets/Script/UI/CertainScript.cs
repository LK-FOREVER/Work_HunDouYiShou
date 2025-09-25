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
    int crystal;
    void Start()
    {
        NoCoinTxt.gameObject.SetActive(false);
       //coin=  PlayerPrefs.GetInt("Coin", 0);
       
    }
    public void Certain()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        crystal = PlayerPrefs.GetInt("Crystal", 0);

        switch (s.ChooseWarrior)
        {
            //case 1:
            //    if (!s.WarriorBtn[0].GetComponent<W1btnScript>().ILock && coin >= Value)                //�ڽ��������
            //    {
            //        coin-=Value;
            //        PlayerPrefs.SetInt("Coin",coin);              //Ǯ�����
            //        s.WarriorBtn[0].GetComponent<W1btnScript>().ILock = true;
            //        //s.WarriorBtn[0].GetComponent<W1btnScript>().Lock.gameObject.SetActive(false);
            //        PlayerPrefs.SetInt("PlayerPrefsLock1", 1);

            //        BuyPanel.SetActive(false);
            //    }
            //    break;
            case 2:
                if (!s.WarriorBtn[1].GetComponent<W2btnScript>().ILock && coin >= 5000)                //�ڽ��������
                {
                    s.WarriorBtn[1].GetComponent<W2btnScript>().Lock.gameObject.SetActive(false); //�ر���

                    coin -= 5000;
                    PlayerPrefs.SetInt("Coin", coin);              //Ǯ�����
                    s.WarriorBtn[1].GetComponent<W2btnScript>().ILock = true;
                    s.WarriorBtn[1].GetComponent<W2btnScript>().LockBtnTxt.text = "�ѽ���";
                    PlayerPrefs.SetInt("PlayerPrefsLock2", 1);     //��������ô洢
                    BuyPanel.SetActive(false);

                    int WorkNum = PlayerPrefs.GetInt("WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt("WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt("NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt("NewHero", P_NewHero);
                    PlayerPrefs.Save();
                }
                else if (!s.WarriorBtn[1].GetComponent<W2btnScript>().ILock && coin < 5000/*&&ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
            case 3:
                if (!s.WarriorBtn[2].GetComponent<W3btnScript>().ILock && coin >= 20000)                //�ڽ��������
                {
                    s.WarriorBtn[2].GetComponent<W3btnScript>().Lock.gameObject.SetActive(false); //�ر���
                    coin -= 20000;
                    PlayerPrefs.SetInt("Coin", coin);              //Ǯ�����
                    s.WarriorBtn[2].GetComponent<W3btnScript>().ILock = true;
                    s.WarriorBtn[2].GetComponent<W3btnScript>().LockBtnTxt.text = "�ѽ���";
                    PlayerPrefs.SetInt("PlayerPrefsLock3", 1);
                    BuyPanel.SetActive(false);
                    int WorkNum = PlayerPrefs.GetInt("WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt("WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt("NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt("NewHero", P_NewHero);
                    PlayerPrefs.Save();
                }
                else if (!s.WarriorBtn[2].GetComponent<W3btnScript>().ILock && coin < 20000 /*&& ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
            case 4:
                if (!s.WarriorBtn[3].GetComponent<W4btnScript>().ILock && crystal >= 50000)                //�ڽ��������
                {
                    s.WarriorBtn[3].GetComponent<W4btnScript>().Lock.gameObject.SetActive(false); //�ر���
                    crystal -= 50000;
                    PlayerPrefs.SetInt("Crystal", crystal);              //Ǯ�����
                    s.WarriorBtn[3].GetComponent<W4btnScript>().ILock = true;
                    s.WarriorBtn[3].GetComponent<W4btnScript>().LockBtnTxt.text = "�ѽ���";
                    PlayerPrefs.SetInt("PlayerPrefsLock4", 1);
                    BuyPanel.SetActive(false);
                    int WorkNum = PlayerPrefs.GetInt("WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt("WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt("NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt("NewHero", P_NewHero);
                    PlayerPrefs.Save();
                }
                else if (!s.WarriorBtn[3].GetComponent<W4btnScript>().ILock && crystal < 50000/* && ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
            case 5:
                if (!s.WarriorBtn[4].GetComponent<W5btnScript>().ILock && crystal >= 300)                //�ڽ��������
                {
                    s.WarriorBtn[4].GetComponent<W5btnScript>().Lock.gameObject.SetActive(false); //�ر���
                    crystal -= 300;
                    PlayerPrefs.SetInt("Crystal", crystal);              //Ǯ�����
                    s.WarriorBtn[4].GetComponent<W5btnScript>().ILock = true;
                    s.WarriorBtn[4].GetComponent<W5btnScript>().LockBtnTxt.text = "�ѽ���";
                    PlayerPrefs.SetInt("PlayerPrefsLock5", 1);
                    BuyPanel.SetActive(false);
                    int WorkNum = PlayerPrefs.GetInt("WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt("WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt("NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt("NewHero", P_NewHero);
                    PlayerPrefs.Save();
                }
                else if (!s.WarriorBtn[4].GetComponent<W5btnScript>().ILock && crystal < 300 /*&& ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
            case 6:
                if (!s.WarriorBtn[5].GetComponent<W6btnScript>().ILock && crystal >= 500)                //�ڽ��������
                {
                    s.WarriorBtn[5].GetComponent<W6btnScript>().Lock.gameObject.SetActive(false); //�ر���
                    crystal -= 500;
                    PlayerPrefs.SetInt("Crystal", crystal);              //Ǯ�����
                    s.WarriorBtn[5].GetComponent<W6btnScript>().ILock = true;
                    s.WarriorBtn[5].GetComponent<W6btnScript>().LockBtnTxt.text = "�ѽ���";
                    PlayerPrefs.SetInt("PlayerPrefsLock6", 1);
                    BuyPanel.SetActive(false);
                    int WorkNum = PlayerPrefs.GetInt("WorkNum", 0);  //���������
                    WorkNum++;
                    PlayerPrefs.SetInt("WorkNum", WorkNum);
                    int P_NewHero = PlayerPrefs.GetInt("NewHero", 0);       //��Ӣ�۳ɾ�
                    P_NewHero += 1;
                    PlayerPrefs.SetInt("NewHero", P_NewHero);
                    PlayerPrefs.Save();
                }
                else if (!s.WarriorBtn[5].GetComponent<W6btnScript>().ILock && crystal < 500 /*&& ICertainBuy*/)
                {
                    NoCoinTxt.gameObject.SetActive(true);
                    Invoke("falseNoCoinTxt", 1.3f);
                }
                break;
        }
        monsterPanelScript.InitUI();
    }
    public void falseNoCoinTxt()
    {
        NoCoinTxt.gameObject.SetActive(false);
    }
}
