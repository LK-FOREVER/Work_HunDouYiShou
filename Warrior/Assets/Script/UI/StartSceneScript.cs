using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{
    public static int W;
    public int ChooseWarrior;//选择购买的异兽
    public int ChooseResource;//选择购买的资源
    public int ChooseIndex = 1; //选择出战的异兽
    public Button[] WarriorBtn; //判断每个英雄按钮是否解锁
    public PlayerScript p;
    public Image[] Background;
    public Text HpTxt;
    public Text SpTxt;
    public Text AkTxt;
    public TextMeshProUGUI TellTxt;
    public GameObject changePanel;
    public Button[] SkillBtn;
    public Image SkillBackground;

    public Text monsterName; //异兽名称
    // public Button LockBtn;             //解锁或使用按钮
    // public Text LockTxt;               //使用中文本
    // public Image[] UseImg;             //显示小使用中

    public Sprite[] BigWarriorImg;
    public Image ShowWarriorImg;

    public GameObject CreateNamePanel;
    private int currentMonsterIndex;
    public static StartSceneScript Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Application.targetFrameRate = 240;    //帧数
        currentMonsterIndex = PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1);
        foreach (var item in Background)
        {
            if (item != Background[currentMonsterIndex - 1])
            {
                item.gameObject.SetActive(false);
            }
            else
            {
                item.gameObject.SetActive(true);
            }

        }

        //创建昵称界面
        if (PlayerPrefs.GetString(SdkScript.nickname + "PlayerName") == "") CreateNamePanel.SetActive(true);
        //选择出战的角色
        ChooseWarriors();
    }

    void Update()
    {
        if (SceneManager.GetSceneByName("GameScene").isLoaded)
        {
            // SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
    }

    public void ChooseWarriors()
    {
        int currentMonsterIndex = PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1);
        Debug.Log("currentMonsterIndex：" + currentMonsterIndex);
        EventManager.Instance.TriggerEvent(EventName.ChangeWarrior, this, new ChangeWarriorArgs() { index_monster = currentMonsterIndex });
        switch (currentMonsterIndex)
        {
            case 1:
                p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[0];            //更换英雄图片  
                WarriorBtn[0].GetComponent<W1btnScript>().W1();
                p.speed = 100/30f;                                                              ///更改英雄属性
                p.PlayerHp = 200f;
                p.PlayerHP = 200f;
                p.atk = 2;
                break;
            case 2:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock2", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[1];
                    WarriorBtn[1].GetComponent<W2btnScript>().W2();

                    p.speed = 120/30f;
                    p.PlayerHp = 300f;
                    p.PlayerHP = 300f;
                    p.atk = 2;
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock3", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[2];
                    WarriorBtn[2].GetComponent<W3btnScript>().W3();

                    p.speed = 100/30f;
                    p.PlayerHp = 150f;
                    p.PlayerHP = 150f;
                    p.atk = 3;
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock4", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[3];
                    WarriorBtn[3].GetComponent<W4btnScript>().W4();

                    p.speed = 150/30f;
                    p.PlayerHp = 250f;
                    p.PlayerHP = 250f;
                    p.atk = 4;
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock5", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[4];
                    WarriorBtn[4].GetComponent<W5btnScript>().W5();

                    p.speed = 180/30f;
                    p.PlayerHp = 250f;
                    p.PlayerHP = 250f;
                    p.atk = 4;
                }
                break;
            case 6:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock6", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[5];
                    WarriorBtn[5].GetComponent<W6btnScript>().W6();

                    p.speed = 80/30f;
                    p.PlayerHp = 350f;
                    p.PlayerHP = 350f;
                    p.atk = 1;
                }
                break;
        }
    }
}
