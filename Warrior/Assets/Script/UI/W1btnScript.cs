using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W1btnScript : MonoBehaviour
{
    public StartSceneScript s;
    public Canvas c;
    public bool ILock = true;
    public int PlayerPrefsLock1 = 1;
    public bool IPress;                  //是否按压选择 默认一号位选中
    public Text LockBtnTxt;                   //按钮内部文本

    public Button LockBtn;             //解锁或使用按钮
    public Text LockTxt;               //使用中文本
    public Image Lock;                 //未解锁阴影
    public Image LockImg;//锁图片
    public GameObject[] ChooseArrow;//选择箭头
    public PlayerScript p;
    void Start()
    {

        //PlayerPrefsLock1 = PlayerPrefs.GetInt("PlayerPrefsLock1",0);
    }


    void Update()
    {
        //if(PlayerPrefsLock1 == 0)
        //{
        //    ILock = false;
        //    Lock.gameObject.SetActive(true);
        //}
        //else if(PlayerPrefsLock1 == 1)
        //{
        //    ILock = true;
        //    Lock.gameObject.SetActive(false);
        //}

        if (ILock && IPress)              //实时判断是否使用，否则需多点一次头像按钮
        {
            // s.UseImg[0].gameObject.SetActive(true);
            // foreach (var item in s.UseImg)                         //关闭其余小使用中
            // {
            //     if (item != s.UseImg[0])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }

            s.SkillBtn[0].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)                        //关闭其余技能图标
            {
                if (item != s.SkillBtn[0])
                {
                    item.gameObject.SetActive(false);
                }
            }
            c.GetComponent<CanvasScript>().SkillIndex = 0;              //切换技能图标  
        }
    }

    public void UpdateSkillImg()
    {
        // s.UseImg[0].gameObject.SetActive(true);
        // foreach (var item in s.UseImg)                         //关闭其余小使用中
        // {
        //     if (item != s.UseImg[0])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }

        s.SkillBtn[0].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)                        //关闭其余技能图标
        {
            if (item != s.SkillBtn[0])
            {
                item.gameObject.SetActive(false);
            }
        }
        c.GetComponent<CanvasScript>().SkillIndex = 0;              //切换技能图标 
    }
    public void W1()
    {
        UpdateSkillImg();
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseArrow[0].SetActive(true);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 1;
        s.ChooseIndex = 1;
        // s.ChooseWarrior = 1;                                  //更改英雄属性
        // s.ChooseBackground[0].gameObject.SetActive(true);     //高亮显示
        // foreach (var item in s.ChooseBackground)               //关闭其余高亮
        // {
        //     if (item != s.ChooseBackground[0])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[0].gameObject.SetActive(true);
        foreach (var item in s.Background)                     //关闭其余英雄头像
        {
            if (item != s.Background[0])
            {
                item.gameObject.SetActive(false);
            }
        }
        s.monsterName.text = "麒麟";
        s.HpTxt.text = ":200";
        s.SpTxt.text = ":120";
        s.AkTxt.text = ":30";
        s.TellTxt.text = "技能：增加50%移动速度，持续10秒，冷却20秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[0];

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
