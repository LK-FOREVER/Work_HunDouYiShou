using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class StartSceneScript : MonoBehaviour
{
    public static int W;
    public int ChooseWarrior;//选择购买的异兽
    public int ChooseResource;//选择购买的资源
    public int ChooseIndex; //选择出战的异兽
    public Button[] WarriorBtn; //判断每个英雄按钮是否解锁
    public PlayerScript p;
    public GameObject Player;
    public Canvas Scrol;
    // public Image[] ChooseBackground;
    public Image[] Background;
    public Text HpTxt;
    public Text SpTxt;
    public Text AkTxt;
    public TextMeshProUGUI TellTxt;
    public GameObject changePanel;
    public Button[]SkillBtn;
    public Image SkillBackground;

    public Text monsterName; //异兽名称
    // public Button LockBtn;             //解锁或使用按钮
    // public Text LockTxt;               //使用中文本
    // public Image[] UseImg;             //显示小使用中

    public bool IClose;
    public Sprite[] BigWarriorImg;
    public Image ShowWarriorImg;
    
    private SdkScript sdkScript;

    void Start()
    {
        Application.targetFrameRate = 240;    //帧数
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(Scrol);
        // foreach (var item in ChooseBackground)
        // {
        //     item.gameObject.SetActive(false);
        // }
        foreach (var item in Background)
        {
            if (item != Background[0])
            {
                item.gameObject.SetActive(false);
            }
            
        }
        
        //WarriorPanel.SetActive(false);
  
        foreach (var item in SkillBtn)
        {
            if (item != SkillBtn[0])
            {
                item.gameObject.SetActive(false);
            }
        }

        ChooseWarriors();
        //PlayerPrefs.SetInt("PlayerPrefsLock2", 0);  //重置英雄解锁
        //PlayerPrefs.SetInt("PlayerPrefsLock3", 0);
        //PlayerPrefs.SetInt("PlayerPrefsLock4", 0);
        //PlayerPrefs.SetInt("PlayerPrefsLock5", 0);
        //PlayerPrefs.SetInt("PlayerPrefsLock6", 0);
    }

    void Update()
    {
        // ChooseWarrior = PlayerPrefs.GetInt("CurrentPlayer");
        // switch (W)
        // {
        //     case 1: 
        //         WarriorBtn[0].GetComponent<W1btnScript>().W1();
        //         break;
        //     case 2:
        //         WarriorBtn[1].GetComponent<W2btnScript>().W2();
        //         break;
        //     case 3:
        //         WarriorBtn[2].GetComponent<W3btnScript>().W3();
        //         break;
        //     case 4:
        //         WarriorBtn[3].GetComponent<W4btnScript>().W4();
        //         break;
        //     case 5:
        //         WarriorBtn[4].GetComponent<W5btnScript>().W5();
        //         break;
        //     case 6:
        //         WarriorBtn[5].GetComponent<W6btnScript>().W6();
        //         break;
        //     
        // }
        // print(ChooseWarrior);
        
    }

    public void ChooseWarriors()
    {
        switch (PlayerPrefs.GetInt("CurrentPlayer"))
        {
            case 1:
                p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[0];            //更换英雄图片  
                p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[0];
                p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[0];
                WarriorBtn[0].GetComponent<W1btnScript>().W1();
                   
                p.speed = 3f;                                                              ///更改英雄属性
                p.PlayerHp = 200f; 
                p.PlayerHP = 200f;
                p.Ak = 30f;

                // if (WarriorBtn[0].GetComponent<W1btnScript>().IPress)          //根据是否按压判断显示按钮或文本,判断按压的前提是解锁
                // {
                //     LockBtn.gameObject.SetActive(false);
                //     LockTxt.gameObject.SetActive(true);
                // }
                // else if (!WarriorBtn[0].GetComponent<W1btnScript>().IPress)
                // {
                //     LockBtn.gameObject.SetActive(true);
                //     LockTxt.gameObject.SetActive(false);
                // }
                break;
            case 2:
                if (PlayerPrefs.GetInt("PlayerPrefsLock2",0)==1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[1];
                    p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[1];
                    p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[1];
                    WarriorBtn[1].GetComponent<W2btnScript>().W2();
                   
                    p.speed = 2f;
                    p.PlayerHp = 300f;
                    p.PlayerHP = 300f;
                    p.Ak = 20f;
                    // if (WarriorBtn[1].GetComponent<W2btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(false);
                    //     LockTxt.gameObject.SetActive(true);
                    // }
                    // else if (!WarriorBtn[1].GetComponent<W2btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(true);
                    //     LockTxt.gameObject.SetActive(false);
                    // }
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("PlayerPrefsLock3",0)==1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[2];
                    p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[2];
                    p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[2];
                    WarriorBtn[2].GetComponent<W3btnScript>().W3();
                    
                    p.speed = 3.8f;
                    p.PlayerHp = 150f;
                    p.PlayerHP = 150f;
                    p.Ak = 30f;
                    // if (WarriorBtn[2].GetComponent<W3btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(false);
                    //     LockTxt.gameObject.SetActive(true);
                    // }
                    // else if (!WarriorBtn[2].GetComponent<W3btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(true);
                    //     LockTxt.gameObject.SetActive(false);
                    // }
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("PlayerPrefsLock4",0)==1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[3];
                    p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[3];
                    p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[3];
                    WarriorBtn[3].GetComponent<W4btnScript>().W4();
                   
                    p.speed = 3.2f;
                    p.PlayerHp = 250f;
                    p.PlayerHP = 250f;
                    p.Ak = 25f;
                    // if (WarriorBtn[3].GetComponent<W4btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(false);
                    //     LockTxt.gameObject.SetActive(true);
                    // }
                    // else if (!WarriorBtn[3].GetComponent<W4btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(true);
                    //     LockTxt.gameObject.SetActive(false);
                    // }
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("PlayerPrefsLock5",0)==1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[4];
                    p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[4];
                    p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[4];
                    WarriorBtn[4].GetComponent<W5btnScript>().W5();
                    
                    p.speed = 2.5f;
                    p.PlayerHp = 500f;
                    p.PlayerHP = 500f;
                    p.Ak = 10f;
                    // if (WarriorBtn[4].GetComponent<W5btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(false);
                    //     LockTxt.gameObject.SetActive(true);
                    // }
                    // else if (!WarriorBtn[4].GetComponent<W5btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(true);
                    //     LockTxt.gameObject.SetActive(false);
                    // }
                }
                break;
            case 6:
                if (PlayerPrefs.GetInt("PlayerPrefsLock6",0)==1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[5];
                    p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[5];
                    p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[5];
                    WarriorBtn[5].GetComponent<W6btnScript>().W6();
                   
                    p.speed = 3.5f;
                    p.PlayerHp = 200f;
                    p.PlayerHP = 200f;
                    p.Ak = 20f;
                    // if (WarriorBtn[5].GetComponent<W6btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(false);
                    //     LockTxt.gameObject.SetActive(true);
                    // }
                    // else if (!WarriorBtn[5].GetComponent<W6btnScript>().IPress)
                    // {
                    //     LockBtn.gameObject.SetActive(true);
                    //     LockTxt.gameObject.SetActive(false);
                    // }
                }
                break;
        }
        
    }
   
   
}
