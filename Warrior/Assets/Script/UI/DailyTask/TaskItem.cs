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

    void Start()
    {

    }
    public void InitDailyTask(DailyTaskInfo info)
    {
        taskNameTxt.text = info.desc;
        taskIcon.sprite = info.rewardType == "Coin" ? taskIcons[0] : taskIcons[1];
        rewardNumTxt.text = info.rewardNum.ToString();
        taskNum = info.num;
        if (PlayerData.Instance != null && PlayerData.Instance.dailyTaskProgress[info.id - 1] >= taskNum)
        {
            if (PlayerData.Instance.dailyTaskGeted[info.id - 1])
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
    public void InitAchievementTask(AchievementTaskInfo info)
    {
        taskNameTxt.text = info.desc;
        taskIcon.sprite = info.rewardType == "Crystal" ? taskIcons[1] : taskIcons[0];
        rewardNumTxt.text = info.rewardNum.ToString();
        taskNum = info.num;
        if (PlayerData.Instance != null && PlayerData.Instance.achievementTaskProgress[info.id - 1] >= taskNum)
        {
            if (PlayerData.Instance.achievementTaskGeted[info.id - 1])
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
