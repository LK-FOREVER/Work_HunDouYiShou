using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class W3btnScript : MonoBehaviour
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
    public int PlayerPrefsLock3 = 0;
    public PlayerScript p;
    void Start()
    {
       
        PlayerPrefsLock3 = PlayerPrefs.GetInt("PlayerPrefsLock3",0);
    }

   
    void Update()
    {
        //if (PlayerPrefsLock3 == 0)
        //{
        //    ILock = false;
        //    Lock.gameObject.SetActive(true);
        //}
        if (PlayerPrefsLock3 == 1)
        {
            ILock = true;
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }
        if (ILock && IPress)
        {
            // s.UseImg[2].gameObject.SetActive(true);
            // foreach (var item in s.UseImg)                         //关闭其余小使用中
            // {
            //     if (item != s.UseImg[2])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }
            s.SkillBtn[2].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)
            {
                if (item != s.SkillBtn[2])
                {
                    item.gameObject.SetActive(false);
                }
            }
            c.GetComponent<CanvasScript>().SkillIndex = 2;
        }
        
    }
    
    public void UpdateSkillImg()
    {
        // s.UseImg[2].gameObject.SetActive(true);
        // foreach (var item in s.UseImg)                         //关闭其余小使用中
        // {
        //     if (item != s.UseImg[2])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.SkillBtn[2].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)
        {
            if (item != s.SkillBtn[2])
            {
                item.gameObject.SetActive(false);
            }
        }
        c.GetComponent<CanvasScript>().SkillIndex = 2;
    }
    public void W3()
    {
        UpdateSkillImg();
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(true);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 3;
        s.ChooseIndex = 3;
        // s.ChooseWarrior = 3;
        // s.ChooseBackground[2].gameObject.SetActive(true);
        // foreach (var item in s.ChooseBackground)
        // {
        //     if (item != s.ChooseBackground[2])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[2].gameObject.SetActive(true);
        foreach (var item in s.Background)
        {
            if (item != s.Background[2])
            {
                item.gameObject.SetActive(false);
            }
        }
       
        s.monsterName.text = "凤凰";
        s.HpTxt.text = ":150";
        s.SpTxt.text = ":180";
        s.AkTxt.text = ":30";
        s.TellTxt.text = "技能：获得隐身状态，持续10秒，隐身期间碰撞敌人额外造成10点伤害并提前解除隐身状态，冷却20秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[2];

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
