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
    //技能数据
    private TextAsset skillTextAsset;
    private List<SkillData> skills_data;
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
        LoadLevelResource(); //加载技能数据
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

    private void LoadLevelResource()
    {
        skillTextAsset = Resources.Load<TextAsset>("Data/skill_data");
        string skill_jsonStr = skillTextAsset.text;
        SkillDataList skillDataList = JsonUtility.FromJson<SkillDataList>(skill_jsonStr);
        skills_data = skillDataList.skills;
        PlayerData.Instance.skillData = skills_data.ToArray();
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
                EventManager.Instance.TriggerEvent(EventName.InitPlayerState, this, new InitPlayerStateArgs() { hp = 200f, atk = 2, speed = 100 / 30f });
                break;
            case 2:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock2", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[1];
                    WarriorBtn[1].GetComponent<W2btnScript>().W2();
                    EventManager.Instance.TriggerEvent(EventName.InitPlayerState, this, new InitPlayerStateArgs() { hp = 300f, atk = 2, speed = 120 / 30f });
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock3", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[2];
                    WarriorBtn[2].GetComponent<W3btnScript>().W3();
                    EventManager.Instance.TriggerEvent(EventName.InitPlayerState, this, new InitPlayerStateArgs() { hp = 150f, atk = 3, speed = 100 / 30f });
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock4", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[3];
                    WarriorBtn[3].GetComponent<W4btnScript>().W4();
                    EventManager.Instance.TriggerEvent(EventName.InitPlayerState, this, new InitPlayerStateArgs() { hp = 250f, atk = 4, speed = 150 / 30f });
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock5", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[4];
                    WarriorBtn[4].GetComponent<W5btnScript>().W5();
                    EventManager.Instance.TriggerEvent(EventName.InitPlayerState, this, new InitPlayerStateArgs() { hp = 250f, atk = 4, speed = 180 / 30f });
                }
                break;
            case 6:
                if (PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock6", 0) == 1)
                {
                    p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[5];
                    WarriorBtn[5].GetComponent<W6btnScript>().W6();
                    EventManager.Instance.TriggerEvent(EventName.InitPlayerState, this, new InitPlayerStateArgs() { hp = 350f, atk = 1, speed = 80 / 30f });
                }
                break;
        }
    }
}
