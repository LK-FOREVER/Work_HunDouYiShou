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

    public Button LockBtn;             //解锁或使用按钮
    public Text LockTxt;               //使用中文本
    public Image Lock;                 //未解锁阴影
    public Image LockImg;//锁图片
    public GameObject[] ChooseArrow;//选择箭头
    public int PlayerPrefsLock2 = 0;
    public PlayerScript p;
    void Start()
    {
        PlayerPrefsLock2 = PlayerPrefs.GetInt("PlayerPrefsLock2", 0);
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
            // foreach (var item in s.UseImg)                         //关闭其余小使用中
            // {
            //     if (item != s.UseImg[1])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }
            s.SkillBtn[1].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)                      //关闭其余技能
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
        // foreach (var item in s.UseImg)                         //关闭其余小使用中
        // {
        //     if (item != s.UseImg[1])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.SkillBtn[1].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)                      //关闭其余技能
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
        // foreach (var item in s.ChooseBackground)                     //关闭其他高亮
        // {
        //     if (item != s.ChooseBackground[1])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[1].gameObject.SetActive(true);
        foreach (var item in s.Background)                             //关闭其他头像
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
        s.TellTxt.text = "技能：获得50%生命值上限的护盾，持续5秒，冷却20秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[1];


        //根据是否被按压过显示按钮或文本
        //点击判断按钮显示文本
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
