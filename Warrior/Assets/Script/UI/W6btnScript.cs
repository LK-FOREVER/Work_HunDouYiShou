using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class W6btnScript : MonoBehaviour
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
    public int PlayerPrefsLock6 = 0;
    public PlayerScript p;
    void Start()
    {
       
        PlayerPrefsLock6 = PlayerPrefs.GetInt("PlayerPrefsLock6", 0);
    }

    
    void Update()
    {

        //if (PlayerPrefsLock6 == 0)
        //{
        //    ILock = false;
        //    Lock.gameObject.SetActive(true);
        //}
        if (PlayerPrefsLock6 == 1)
        {
            ILock = true;
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }

        if (ILock && IPress)
        {
            // s.UseImg[5].gameObject.SetActive(true);
            // foreach (var item in s.UseImg)                         //关闭其余小使用中
            // {
            //     if (item != s.UseImg[5])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }
            s.SkillBtn[5].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)
            {
                if (item != s.SkillBtn[5])
                {
                    item.gameObject.SetActive(false);
                }
            }
            c.GetComponent<CanvasScript>().SkillIndex = 5;
        }
    }

    private void UpdateSkillImg()
    {
        // s.UseImg[5].gameObject.SetActive(true);
        // foreach (var item in s.UseImg)                         //关闭其余小使用中
        // {
        //     if (item != s.UseImg[5])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.SkillBtn[5].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)
        {
            if (item != s.SkillBtn[5])
            {
                item.gameObject.SetActive(false);
            }
        }
        c.GetComponent<CanvasScript>().SkillIndex = 5;
    }
    public void W6()
    {
        UpdateSkillImg();
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(true);
        StartSceneScript.W = 6;
        s.ChooseIndex = 6;
        // s.ChooseWarrior = 6;
        // s.ChooseBackground[5].gameObject.SetActive(true);
        // foreach (var item in s.ChooseBackground)
        // {
        //     if (item != s.ChooseBackground[5])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[5].gameObject.SetActive(true);
        foreach (var item in s.Background)
        {
            if (item != s.Background[5])
            {
                item.gameObject.SetActive(false);
            }
        }
        s.monsterName.text = "玄武";
        s.HpTxt.text = ":200";
        s.SpTxt.text = ":160";
        s.AkTxt.text = ":20";
        s.TellTxt.text = "技能：原地放置一枚地雷，对接触到的敌人造成20点伤害，冷却15秒，地雷持续30秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[5];

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
