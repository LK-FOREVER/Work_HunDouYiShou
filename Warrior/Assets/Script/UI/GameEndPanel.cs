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
    public void Init(bool isWin)
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
        try
        {
            if (levelData != null)
                reward = levelData.rewardNum;
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning("读取levelData.rewardNum失败: " + ex.Message);
        }

        iconText.text = isWin ? reward.ToString() : "0";
    }
    private void OnAgainBtnClick()
    {
        Player.audio.clip = Player.acilp[0];
        Player.audio.Play();
        Destroy(GameObject.FindWithTag("Npc"));
        poolManager.Clear();
        gameObject.SetActive(false);
        SceneManager.LoadScene("LoadScene");
        EventManager.Instance.TriggerEvent(EventName.ResetPlayerState, this);
        Time.timeScale = 1.0f;
    }
    private void OnSureBtnClick()
    {
        Player.audio.clip = Player.acilp[0];
        Player.audio.Play();
        Destroy(GameObject.FindWithTag("Npc"));
        poolManager.Clear();
        gameObject.SetActive(false);
        SceneManager.LoadScene("StartScene");
        EventManager.Instance.TriggerEvent(EventName.ResetPlayerState, this);
        mainPanel.SetActive(true);
        Time.timeScale = 1.0f;
    }
    private void reset()
    {
        Player.audio.clip = Player.acilp[0];
        Player.audio.Play();
        Destroy(GameObject.FindWithTag("Npc"));
        poolManager.Clear();
        gameObject.SetActive(false);
        EventManager.Instance.TriggerEvent(EventName.ResetPlayerState, this);
        Time.timeScale = 1.0f;
    }
}
