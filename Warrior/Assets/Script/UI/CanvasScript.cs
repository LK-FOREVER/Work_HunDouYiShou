using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class CanvasScript : MonoBehaviour
{
    //资源栏金币
    public Text CoinTxt;
    //资源栏水晶
    // public Text CrystaylTxt;
    //资源栏能量
    public Text EnergyTxt;
    public AudioSource audioSource;
    public AudioClip[] acilp;
    public Text nameTxt;
    public Button sevenDayBtn;
    public GameObject sevenDayPanel;
    public Button dailyTaskBtn;
    public GameObject dailyTaskPanel;
    public Button chooseLevelBtn;
    public GameObject chooseLevelPanel;
    public Sprite[] normalAtkSprite;
    public Sprite[] skillAtkSprite;
    public Image normalAtkImg;
    public Image skillAtkImg;
    public Image skillCooldownMask;
    private Coroutine skillCoolDownCoroutine;
    public static CanvasScript Instance;
    private void Awake()
    {
        EventManager.Instance.AddListener(EventName.ChangeWarrior, ChangeWarriorSkillImg);
        EventManager.Instance.AddListener(EventName.SkillCoolDown, SkillCoolDown);
        EventManager.Instance.AddListener(EventName.ResetPlayerState, ResetSkillState);
    }
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
        EventManager.Instance.RemoveListener(EventName.ChangeWarrior, ChangeWarriorSkillImg);
        EventManager.Instance.RemoveListener(EventName.SkillCoolDown, SkillCoolDown);
        EventManager.Instance.RemoveListener(EventName.ResetPlayerState, ResetSkillState);
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
    private void ChangeWarriorSkillImg(object sender, EventArgs e)
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
    //技能冷却
    private void SkillCoolDown(object sender, EventArgs e)
    {
        CoolDownArgs args = e as CoolDownArgs;
        skillCooldownMask.gameObject.SetActive(true);
        skillCooldownMask.fillAmount = 1;
        skillCooldownMask.transform.parent.GetComponent<Button>().interactable = false;
        if (skillCoolDownCoroutine != null)
            StopCoroutine(skillCoolDownCoroutine);
        skillCoolDownCoroutine = StartCoroutine(SkillCoolDownCoroutine(args.coolDownTime));
    }
    //技能冷却协程
    private IEnumerator SkillCoolDownCoroutine(float coolDownTime)
    {
        float timer = 0;
        while (timer < coolDownTime)
        {
            timer += Time.deltaTime;
            skillCooldownMask.fillAmount = 1 - timer / coolDownTime;
            yield return null;
        }
        ResetSkillCoolDown();
    }
    private void ResetSkillCoolDown()
    {
        skillCooldownMask.fillAmount = 0;
        skillCooldownMask.gameObject.SetActive(false);
        skillCooldownMask.transform.parent.GetComponent<Button>().interactable = true;
    }
    private void ResetSkillState(object sender, EventArgs e)
    {
        ResetSkillCoolDown();
    }
    public void UpdateResource()
    {
        CoinTxt.text = PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0).ToString();
        // CrystaylTxt.text = PlayerPrefs.GetInt(SdkScript.nickname + "Crystal", 0).ToString();
    }
}
