using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class W4btnScript : MonoBehaviour
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
    public int PlayerPrefsLock4 = 0;
    public PlayerScript p;
  
    void Start()
    {
       
        PlayerPrefsLock4 = PlayerPrefs.GetInt("PlayerPrefsLock4",0);
    }

 
    void Update()
    {
        //if (PlayerPrefsLock4 == 0)
        //{
        //    ILock = false;
        //    Lock.gameObject.SetActive(true);
        //}
        if (PlayerPrefsLock4 == 1)
        {
            ILock = true;
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }


        if (ILock && IPress)
        {
            // s.UseImg[3].gameObject.SetActive(true);
            // foreach (var item in s.UseImg)                         //关闭其余小使用中
            // {
            //     if (item != s.UseImg[3])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }
            s.SkillBtn[3].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)
            {
                if (item != s.SkillBtn[3])
                {
                    item.gameObject.SetActive(false);
                }
            }
            c.GetComponent<CanvasScript>().SkillIndex = 3;
        }
    }
    
    public void UpdateSkillImg()
    {
        // s.UseImg[3].gameObject.SetActive(true);
        // foreach (var item in s.UseImg)                         //关闭其余小使用中
        // {
        //     if (item != s.UseImg[3])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.SkillBtn[3].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)
        {
            if (item != s.SkillBtn[3])
            {
                item.gameObject.SetActive(false);
            }
        }
        c.GetComponent<CanvasScript>().SkillIndex = 3;
    }
    public void W4()
    {
        UpdateSkillImg();
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(true);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 4;
        s.ChooseIndex = 4;
        // s.ChooseWarrior = 4;
        // s.ChooseBackground[3].gameObject.SetActive(true);
        // foreach (var item in s.ChooseBackground)
        // {
        //     if (item != s.ChooseBackground[3])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[3].gameObject.SetActive(true);
        foreach (var item in s.Background)
        {
            if (item != s.Background[3])
            {
                item.gameObject.SetActive(false);
            }
        }
        s.monsterName.text = "九尾";
        s.HpTxt.text = ":250";
        s.SpTxt.text = ":150";
        s.AkTxt.text = ":25";
        s.TellTxt.text = "技能：冻结英雄，持续2秒，冷却30秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[3];

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
