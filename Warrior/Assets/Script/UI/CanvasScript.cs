using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System;
using Unity.VisualScripting;

public class CanvasScript : MonoBehaviour
{
    public Image Background;
    public Image Simg;
    public Image SkillBackground;
    public Button[] Skillbtn;
    public int SkillIndex;
    public Text CoinTxt;
    public Text CrystaylTxt;
    public Text PointCoinTxt;
    public Text SingleCoinTxt;
    public AudioSource audioSource;
    public AudioClip[] acilp;

    public Image headImg;
    public Text nameTxt;
    int coin;
    public Button sevenDayBtn;
    public GameObject sevenDayPanel;
    public Button dailyTaskBtn;
    public GameObject dailyTaskPanel;
    public static CanvasScript Instance;

    public Button chooseLevelBtn;
    public GameObject chooseLevelPanel;

    public Sprite[] normalAtkSprite;
    public Sprite[] skillAtkSprite;
    public Image normalAtkImg;
    public Image skillAtkImg;
    void Start()
    {
        EventManager.Instance.AddListener(EventName.ChangeWarrior, ChangeWarrior);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        //PlayerPrefs.SetInt(SdkScript.nickname + "Coin", 0);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = acilp[0];
        audioSource.Play();
        // Background.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        // Simg.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        nameTxt.text = PlayerPrefs.GetString(SdkScript.nickname + "PlayerName", "昵称");
        sevenDayBtn.onClick.AddListener(() => sevenDayPanel.SetActive(true));
        dailyTaskBtn.onClick.AddListener(() =>
        {
            dailyTaskPanel.SetActive(true);
            dailyTaskPanel.GetComponent<DailyTaskScript>().UpdateUI();
        });
        chooseLevelBtn.onClick.AddListener(() =>
        {
            chooseLevelPanel.SetActive(true);
            chooseLevelPanel.GetComponent<ChooseLevelPanel>().Init();
        });
    }
    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener(EventName.ChangeWarrior, ChangeWarrior);
    }

    void Update()
    {
        // Vector3 V = Input.mousePosition;

        // if (Input.GetKeyDown(KeyCode.Mouse0))
        // {
        //     Background.transform.position = V;
        // }

        // if (SceneManager.GetSceneByName("LoadScene").isLoaded)
        // {
        //     SkillBackground.gameObject.SetActive(false);
        //     Skillbtn[SkillIndex].gameObject.SetActive(false);
        // }
        if (SceneManager.GetSceneByName("GameScene").isLoaded)
        {
            // SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            audioSource.Stop();
        }
        UpdateResource();
    }
    private void ChangeWarrior(object sender, EventArgs e)
    {
        ChangeWarriorArgs args = e as ChangeWarriorArgs;
        Debug.Log("ChangeWarrior:" + args.index_monster);
        RefreshSkillImg(args.index_monster);
    }
    //更换技能图标
    private void RefreshSkillImg(int index_monster)
    {
        normalAtkImg.sprite = normalAtkSprite[index_monster - 1];
        skillAtkImg.sprite = skillAtkSprite[index_monster - 1];
    }
    public void UpdateResource()
    {
        CoinTxt.text = PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0).ToString();
        CrystaylTxt.text = PlayerPrefs.GetInt(SdkScript.nickname + "Crystal", 0).ToString();
    }
}
