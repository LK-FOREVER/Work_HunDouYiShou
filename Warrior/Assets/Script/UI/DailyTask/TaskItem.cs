using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{
    public Text taskNameTxt; //任务名称
    public Image taskIcon; //任务图标
    public Text rewardNumTxt; //奖励数量
    public Text isDoneTxt; //是否完成
    public Button getBtn; //获取任务按钮
    public Sprite[] taskIcons; //任务图标数组

    private int taskNum; //任务要求数量

    private DailyTaskInfo dailyTaskInfo; //任务信息
    private AchievementTaskInfo achievementInfo; //成就任务信息
    private bool isDailyTask;

    void Start()
    {
        getBtn.onClick.AddListener(OnGetRewardClick);
    }

    public void InitDailyTask(DailyTaskInfo info)
    {
        dailyTaskInfo = info;
        isDailyTask = true;
        taskNameTxt.text = info.desc;
        taskIcon.sprite = info.rewardType == "Coin" ? taskIcons[0] : taskIcons[1];
        rewardNumTxt.text = info.rewardNum.ToString();
        taskNum = info.num;
        UpdateTask();
    }
    public void InitAchievementTask(AchievementTaskInfo info)
    {
        achievementInfo = info;
        isDailyTask = false;
        taskNameTxt.text = info.desc;
        taskIcon.sprite = info.rewardType == "Crystal" ? taskIcons[1] : taskIcons[0];
        rewardNumTxt.text = info.rewardNum.ToString();
        taskNum = info.num;
        UpdateTask();
    }

    //更新任务状态
    public void UpdateTask()
    {
        if (isDailyTask)
        {
            if (PlayerData.Instance != null && PlayerData.Instance.dailyTaskProgress[dailyTaskInfo.id - 1] >= taskNum)
            {
                if (PlayerData.Instance.dailyTaskGeted[dailyTaskInfo.id - 1])
                {
                    isDoneTxt.gameObject.SetActive(true);
                    isDoneTxt.text = "已领取";
                    getBtn.gameObject.SetActive(false);
                }
                else
                {
                    isDoneTxt.gameObject.SetActive(false);
                    getBtn.gameObject.SetActive(true);
                }
            }
            else
            {
                isDoneTxt.gameObject.SetActive(true);
                isDoneTxt.text = "未完成";
                getBtn.gameObject.SetActive(false);
            }
        }
        else
        {
            if (PlayerData.Instance != null && PlayerData.Instance.achievementTaskProgress[achievementInfo.id - 1] >= taskNum)
            {
                if (PlayerData.Instance.achievementTaskGeted[achievementInfo.id - 1])
                {
                    isDoneTxt.gameObject.SetActive(true);
                    isDoneTxt.text = "已领取";
                    getBtn.gameObject.SetActive(false);
                }
                else
                {
                    isDoneTxt.gameObject.SetActive(false);
                    getBtn.gameObject.SetActive(true);
                }
            }
            else
            {
                isDoneTxt.gameObject.SetActive(true);
                isDoneTxt.text = "未完成";
                getBtn.gameObject.SetActive(false);
            }
        }
    }

    public void OnGetRewardClick()
    {
        isDoneTxt.gameObject.SetActive(true);
        isDoneTxt.text = "已领取";
        getBtn.gameObject.SetActive(false);
        //领取奖励
        Debug.Log("任务奖励已领取");

        if (isDailyTask)
        {
            //更新资源栏中资源数量
            if (dailyTaskInfo.rewardType == "Coin")
            {
                PlayerPrefs.SetInt(SdkScript.nickname + "Coin", PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0) + dailyTaskInfo.rewardNum);
            }
            else if (dailyTaskInfo.rewardType == "Crystal")
            {
                PlayerPrefs.SetInt(SdkScript.nickname + "Crystal", PlayerPrefs.GetInt(SdkScript.nickname + "Crystal", 0) + dailyTaskInfo.rewardNum);
            }
            PlayerData.Instance.dailyTaskGeted[dailyTaskInfo.id - 1] = true;
        }
        else
        {
            //更新资源栏中资源数量
            if (achievementInfo.rewardType == "Coin")
            {
                PlayerPrefs.SetInt(SdkScript.nickname + "Coin", PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0) + achievementInfo.rewardNum);
            }
            else if (achievementInfo.rewardType == "Crystal")
            {
                PlayerPrefs.SetInt(SdkScript.nickname + "Crystal", PlayerPrefs.GetInt(SdkScript.nickname + "Crystal", 0) + achievementInfo.rewardNum);
            }
            PlayerData.Instance.achievementTaskGeted[achievementInfo.id - 1] = true;
        }
        PlayerData.Instance.SaveData();
        UpdateTask();
    }
}
