using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W2btnScript : MonoBehaviour
{
    public StartSceneScript s;
    public Canvas c;
    public Text LockBtnTxt;
    public bool ILock;
    public bool IPress;

    public Button LockBtn;             //������ʹ�ð�ť
    public Text LockTxt;               //ʹ�����ı�
    public Image Lock;                 //未解锁��Ӱ
    public Image LockImg;//��ͼƬ
    public GameObject[] ChooseArrow;//ѡ���ͷ
    public int PlayerPrefsLock2 = 0;
    public PlayerScript p;
    void Start()
    {
        PlayerPrefsLock2 = PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock2", 0);
    }


    void Update()
    {
        //print(PlayerPrefsLock2);
        //if (PlayerPrefsLock2 == 0)
        //{
        //    ILock = false;
        //    Lock.gameObject.SetActive(true);
        //}
        //print(PlayerPrefsLock2);
        if (PlayerPrefsLock2 == 1)
        {
            ILock = true;
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }

        if (ILock && IPress)
        {
            // s.UseImg[1].gameObject.SetActive(true);
            // foreach (var item in s.UseImg)                         //�ر�����Сʹ����
            // {
            //     if (item != s.UseImg[1])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }
            s.SkillBtn[1].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)                      //�ر����༼��
            {
                if (item != s.SkillBtn[1])
                {
                    item.gameObject.SetActive(false);
                }
            }
            c.GetComponent<CanvasScript>().SkillIndex = 1;
        }
    }

    public void UpdateSkillImg()
    {
        // s.UseImg[1].gameObject.SetActive(true);
        // foreach (var item in s.UseImg)                         //�ر�����Сʹ����
        // {
        //     if (item != s.UseImg[1])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.SkillBtn[1].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)                      //�ر����༼��
        {
            if (item != s.SkillBtn[1])
            {
                item.gameObject.SetActive(false);
            }
        }
        c.GetComponent<CanvasScript>().SkillIndex = 1;
    }
    public void W2()
    {
        UpdateSkillImg();
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(true);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 2;
        s.ChooseIndex = 2;
        // s.ChooseWarrior = 2;
        // s.ChooseBackground[1].gameObject.SetActive(true);
        // foreach (var item in s.ChooseBackground)                     //�ر���������
        // {
        //     if (item != s.ChooseBackground[1])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[1].gameObject.SetActive(true);
        foreach (var item in s.Background)                             //�ر�����ͷ��
        {
            if (item != s.Background[1])
            {
                item.gameObject.SetActive(false);
            }
        }

        s.monsterName.text = "白泽";
        s.HpTxt.text = ":300";
        s.SpTxt.text = ":80";
        s.AkTxt.text = ":20";
        s.TellTxt.text = "获得50%生命值上限的护盾，持续5秒，冷却20秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[1];


        //�����Ƿ񱻰�ѹ����ʾ��ť���ı�
        //����жϰ�ť��ʾ�ı�
        if (ILock && IPress)
        {
            LockBtnTxt.text = "出战中";
            LockBtn.interactable = false;
        }
        else if (ILock && !IPress)
        {
            LockBtnTxt.text = "出战";
            LockBtn.interactable = true;
        }
        else if (!ILock)
        {
            LockBtnTxt.text = "未解锁";
            LockBtn.interactable = false;
        }
    }
}
