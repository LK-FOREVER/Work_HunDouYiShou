using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class DailyPlayTimeTracker : MonoBehaviour
{
    private const int TARGET_MINUTES = 2; // 目标30分钟
    private const string SAVE_KEY = "DailyPlayTimeData";
    private PlayTimeData currentData;
    private float updateTimer = 0f;
    private const float UPDATE_INTERVAL = 1f; // 每1秒更新一次
    public static DailyPlayTimeTracker Instance;

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
        LoadData();
        StartTracking();
    }

    void Update()
    {
        //判断场景是否为登录界面，登录界面不累计在线时间
        if (SceneManager.GetActiveScene().name == "LoadStartScene") return;

        // 每帧更新计时器
        updateTimer += Time.unscaledDeltaTime;
        if (updateTimer >= UPDATE_INTERVAL)
        {
            updateTimer = 0f;
            UpdatePlayTime();
        }
        if (HasReachedDailyGoal() && PlayerData.Instance.dailyTaskProgress[3] == 0)
        {
            PlayerData.Instance.dailyTaskProgress[3]++;
            PlayerData.Instance.SaveData();
        }
    }


    // 开始追踪
    private void StartTracking()
    {
        CheckAndResetDailyData();
    }

    // 更新游戏时间
    private void UpdatePlayTime()
    {
        if (currentData == null) return;

        // 直接使用每帧的未缩放时间增量
        currentData.totalSeconds += UPDATE_INTERVAL;

        if (currentData.totalSeconds >= 1)
        {
            // Debug.Log($"今日累计游戏时间: {currentData.totalSeconds} 秒");
        }
        // 自动保存（每1分钟保存一次）
        if (currentData.totalSeconds >= 60 * (currentData.savedMinutes + 1))
        {
            currentData.savedMinutes = Mathf.FloorToInt(currentData.totalSeconds / 60);
            SaveData();
        }
    }

    // 检查并重置每日数据
    private void CheckAndResetDailyData()
    {
        string today = DateTime.Now.ToString("yyyy-MM-dd");

        if (currentData == null || currentData.date != today)
        {
            // 新的一天，重置数据
            currentData = new PlayTimeData
            {
                date = today,
                totalSeconds = 0,
                savedMinutes = 0,
            };
            SaveData();
        }
    }

    // 检查是否达到30分钟
    public bool HasReachedDailyGoal()
    {
        if (currentData == null) return false;

        CheckAndResetDailyData(); // 先检查日期
        return currentData.totalSeconds >= TARGET_MINUTES * 60;
    }

    // 获取今日累计时间（分钟）
    public float GetTodayPlayTimeMinutes()
    {
        if (currentData == null) return 0f;
        CheckAndResetDailyData();
        return currentData.totalSeconds / 60f;
    }

    // 获取剩余时间（分钟）
    public float GetRemainingTimeMinutes()
    {
        float played = GetTodayPlayTimeMinutes();
        return Mathf.Max(0, TARGET_MINUTES - played);
    }

    // 获取进度（0-1）
    public float GetProgress()
    {
        float played = GetTodayPlayTimeMinutes();
        return Mathf.Clamp01(played / TARGET_MINUTES);
    }

    // 保存数据
    private void SaveData()
    {
        if (currentData == null) return;

        string json = JsonUtility.ToJson(currentData);
        PlayerPrefs.SetString(SdkScript.nickname + SAVE_KEY, json);
        PlayerPrefs.Save();

#if UNITY_EDITOR
        Debug.Log($"保存数据: {json}");
#endif
    }

    // 加载数据
    private void LoadData()
    {
        if (PlayerPrefs.HasKey(SdkScript.nickname + SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SdkScript.nickname + SAVE_KEY);
            currentData = JsonUtility.FromJson<PlayTimeData>(json);

#if UNITY_EDITOR
            Debug.Log($"加载数据: {json}");
#endif
        }
    }
}