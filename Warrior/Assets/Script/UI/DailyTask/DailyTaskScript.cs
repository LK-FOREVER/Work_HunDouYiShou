using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyTaskScript : MonoBehaviour
{
    public GameObject content;
    public Text titleTxt;
    public Button closeBtn;
    [SerializeField] private ToggleGroup toggleGroup;
    [SerializeField] private Toggle toggle1;
    [SerializeField] private Toggle toggle2;
    public GameObject itemPrefab;

    private TextAsset dailyTaskTextAsset;//每日任务
    private List<DailyTaskInfo> dailyTaskList;
    private TextAsset achievementTextAsset;//成就任务
    private List<AchievementTaskInfo> achievementList;
    void Start()
    {
        closeBtn.onClick.AddListener(() => gameObject.SetActive(false));
        if (toggle1 != null)
        {
            toggle1.onValueChanged.AddListener(OnToggle1ValueChanged);
        }

        if (toggle2 != null)
        {
            toggle2.onValueChanged.AddListener(OnToggle2ValueChanged);
        }
        toggle1.isOn = true; // 默认选中第一个Toggle
        LoadDailyTasks();
        UpdateUI();

    }
    private void LoadDailyTasks()
    {
        dailyTaskTextAsset = Resources.Load<TextAsset>("Data/daily_task_data");
        string daily_jsonStr = dailyTaskTextAsset.text;
        DailyTaskList dailyTask = JsonUtility.FromJson<DailyTaskList>(daily_jsonStr);
        dailyTaskList = dailyTask.daily_tasks;

        achievementTextAsset = Resources.Load<TextAsset>("Data/achievement_task_data");
        string achievement_jsonStr = achievementTextAsset.text;
        AchievementTaskList achievementTask = JsonUtility.FromJson<AchievementTaskList>(achievement_jsonStr);
        achievementList = achievementTask.achievement_tasks;
    }
    private void UpdateUI()
    {
        if (toggle1.isOn)
        {
            titleTxt.text = "每日任务";
            // 清空现有内容
            for (int i = content.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(content.transform.GetChild(i).gameObject);
            }

            foreach (var item in dailyTaskList)
            {
                var daily_task_item = Instantiate(itemPrefab, content.transform);
                daily_task_item.GetComponent<TaskItem>().InitDailyTask(item);
            }
        }
        else
        {
            titleTxt.text = "成就任务";
            // 清空现有内容
            for (int i = content.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(content.transform.GetChild(i).gameObject);
            }
            foreach (var item in achievementList)
            {
                var achievement_task_item = Instantiate(itemPrefab, content.transform);
                achievement_task_item.GetComponent<TaskItem>().InitAchievementTask(item);
            }
        }

    }
    private void OnToggle1ValueChanged(bool isOn)
    {
        Debug.Log($"Toggle 1 changed to: {isOn}");
        // 你的逻辑代码
    }

    private void OnToggle2ValueChanged(bool isOn)
    {
        Debug.Log($"Toggle 2 changed to: {isOn}");
        // 你的逻辑代码
    }

    void OnDestroy()
    {
        // 清理监听，防止内存泄漏
        if (toggle1 != null)
            toggle1.onValueChanged.RemoveListener(OnToggle1ValueChanged);
        if (toggle2 != null)
            toggle2.onValueChanged.RemoveListener(OnToggle2ValueChanged);
    }
}
