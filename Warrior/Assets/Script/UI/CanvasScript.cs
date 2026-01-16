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


    public GameObject m;
    //public List<string> Warriorname = new List<string>();
    //public List<int> Warriorpoint = new List<int>();
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
    void Start()
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
        //PlayerPrefs.SetInt(SdkScript.nickname + "Coin", 0);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = acilp[0];
        audioSource.Play();
        Background.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Simg.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        nameTxt.text = PlayerPrefs.GetString(SdkScript.nickname + "PlayerName", "昵称");
        sevenDayBtn.onClick.AddListener(() =>sevenDayPanel.SetActive(true));
        dailyTaskBtn.onClick.AddListener(() =>dailyTaskPanel.SetActive(true));
    }

    void Update()
    {
        // coin = PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0);
        //if (coin != 999999)
        //{
        //    coin = 999999;
        //    PlayerPrefs.SetInt(SdkScript.nickname + "Coin", coin);
        //}

        Vector3 V = Input.mousePosition;
        //Vector3 screenpos = Camera.main.ScreenToViewportPoint(V);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Background.transform.position = V;
        }

        Scene activeScene = SceneManager.GetActiveScene();
        //if (SceneManager.GetSceneByName("StartScene").isLoaded)
        //{
        //    SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        //}
        if (SceneManager.GetSceneByName("LoadScene").isLoaded)
        {
            SkillBackground.gameObject.SetActive(false);
            Skillbtn[SkillIndex].gameObject.SetActive(false);
        }
        if (SceneManager.GetSceneByName("GameScene").isLoaded)
        {
            SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
            audioSource.Stop();
            SkillBackground.gameObject.SetActive(true);
            Skillbtn[SkillIndex].gameObject.SetActive(true);

            m = GameObject.Find("MapManager");

        }
        UpdateResource();
    }

    public void UpdateResource()
    {
        CoinTxt.text = PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0).ToString();
        CrystaylTxt.text = PlayerPrefs.GetInt(SdkScript.nickname + "Crystal", 0).ToString();
    }
}
