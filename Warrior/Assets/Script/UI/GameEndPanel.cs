using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndPanel : MonoBehaviour
{
    public Image titleImage;
    public Image bottomImage;
    public Text iconText;
    public Button againBtn;
    public Button sureBtn;
    public Sprite[] titleSprite;
    public Sprite[] bottomSprite;
    public PlayerScript Player;
    public GameObject mainPanel;
    public GameObject energyTip;

    private ObjectPoolManager poolManager;
    private LevelData levelData;

    void Awake()
    {
        poolManager = ObjectPoolManager.Instance;
    }
    void Start()
    {
        againBtn.onClick.AddListener(OnAgainBtnClick);
        sureBtn.onClick.AddListener(OnSureBtnClick);
    }
    public void Init(bool isWin, float remainingHpPercentage)
    {
        if (PlayerData.Instance != null)
            levelData = PlayerData.Instance.levelData;
        if (titleImage == null || bottomImage == null || iconText == null)
        {
            Debug.LogError("组件为空");
            return;
        }

        int idx = isWin ? 0 : 1;
        if (titleSprite != null && titleSprite.Length > idx)
            titleImage.sprite = titleSprite[idx];
        else
            Debug.LogWarning("titleSprite为空或索引超出范围");

        if (bottomSprite != null && bottomSprite.Length > idx)
            bottomImage.sprite = bottomSprite[idx];
        else
            Debug.LogWarning("bottomSprite为空或索引超出范围");

        if (levelData == null && PlayerData.Instance != null)
            levelData = PlayerData.Instance.levelData;

        int reward = 0;
        if (!isWin)
        {
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.Defeat });
            reward = 0;
        }
        else
        {
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.Victory });

            if (!PlayerData.Instance.isBattle)
            {
                try
                {
                    if (levelData != null)
                        reward = levelData.rewardNum;
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning("读取levelData.rewardNum失败: " + ex.Message);
                }
                if(levelData.level_id > PlayerPrefs.GetInt(SdkScript.nickname + "MaxPassedLevelIndex", 0))
                    PlayerPrefs.SetInt(SdkScript.nickname + "MaxPassedLevelIndex", levelData.level_id);
            }
            else
            {
                //如果是对战模式，根据玩家剩余血量百分比计算奖励
                if (remainingHpPercentage >= 0.8f)
                    reward = 200;
                else if (remainingHpPercentage >= 0.5f && remainingHpPercentage < 0.8f)
                    reward = 150;
                else if (remainingHpPercentage < 0.5f)
                    reward = 100;
            }
        }

        iconText.text = isWin ? reward.ToString() : "0";
        PlayerPrefs.SetInt(SdkScript.nickname + "Coin", reward + PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0));
    }
    private void OnAgainBtnClick()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        if (PlayerPrefs.GetInt(SdkScript.nickname + "Energy", 0) >= 5)
        {
            PlayerPrefs.SetInt(SdkScript.nickname + "Energy", PlayerPrefs.GetInt(SdkScript.nickname + "Energy", 0) - 5);
            //每日任务
            PlayerData.Instance.dailyTaskProgress[4] += 5;
            //成就任务
            PlayerData.Instance.achievementTaskProgress[12] += 5;
            PlayerData.Instance.achievementTaskProgress[13] += 5;
            PlayerData.Instance.achievementTaskProgress[14] += 5;
            PlayerData.Instance.SaveData();

            Destroy(GameObject.FindWithTag("Npc"));
            poolManager.Clear();
            gameObject.SetActive(false);
            SceneManager.LoadScene("LoadScene");
            EventManager.Instance.TriggerEvent(EventName.ResetPlayerState, this);
            Time.timeScale = 1.0f;
        }
        else
        {
            //提示体力不足
            energyTip.SetActive(true);
        }
    }
    private void OnSureBtnClick()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        Destroy(GameObject.FindWithTag("Npc"));
        poolManager.Clear();
        gameObject.SetActive(false);
        SceneManager.LoadScene("StartScene");
        EventManager.Instance.TriggerEvent(EventName.ChangeMusic, this, new ChangeMusicArgs { index_music = 0 });
        EventManager.Instance.TriggerEvent(EventName.ResetPlayerState, this);
        mainPanel.SetActive(true);
        Time.timeScale = 1.0f;
        energyTip.SetActive(false);
    }
}
