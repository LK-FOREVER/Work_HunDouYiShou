using System;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerData
{
    private static PlayerData _instance;
    public static PlayerData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerData();
            }
            return _instance;
        }
    }

    //每日任务进度
    public int[] dailyTaskProgress = new int[8] { 1, 0, 0, 0, 0, 0, 0, 0 };
    //成就任务进度
    public int[] achievementTaskProgress = new int[15] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    //每日领取状态
    public bool[] dailyTaskGeted = new bool[8] { false, false, false, false, false, false, false, false };
    //成就领取状态
    public bool[] achievementTaskGeted = new bool[15] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    //战斗数据
    public LevelData levelData; //玩家选中的某一关卡的临时数据
    //技能数据
    public SkillData[] skillData;//全部的技能临时数据

    //保存数据
    public void SaveData()
    {
        //任务
        PlayerPrefs.SetString(SdkScript.nickname + "DailyTaskProgress", JsonUtility.ToJson(new IntArrayWrapper { array = dailyTaskProgress }));
        PlayerPrefs.SetString(SdkScript.nickname + "AchievementTaskProgress", JsonUtility.ToJson(new IntArrayWrapper { array = achievementTaskProgress }));
        PlayerPrefs.SetString(SdkScript.nickname + "DailyTaskGeted", JsonUtility.ToJson(new BoolArrayWrapper { array = dailyTaskGeted }));
        PlayerPrefs.SetString(SdkScript.nickname + "AchievementTaskGeted", JsonUtility.ToJson(new BoolArrayWrapper { array = achievementTaskGeted }));
    }
    //加载数据
    public void LoadData()
    {
        //任务
        var dailyProgressWrapper = JsonUtility.FromJson<IntArrayWrapper>(PlayerPrefs.GetString(SdkScript.nickname + "DailyTaskProgress", "{\"array\":[1,0,0,0,0,0,0,0]}"));
        if (dailyProgressWrapper != null && dailyProgressWrapper.array != null)
            dailyTaskProgress = dailyProgressWrapper.array;

        var achievementProgressWrapper = JsonUtility.FromJson<IntArrayWrapper>(PlayerPrefs.GetString(SdkScript.nickname + "AchievementTaskProgress", "{\"array\":[1,0,0,0,0,0,0,0,0,0,0,0,0,0,0]}"));
        if (achievementProgressWrapper != null && achievementProgressWrapper.array != null)
            achievementTaskProgress = achievementProgressWrapper.array;

        var dailyGetedWrapper = JsonUtility.FromJson<BoolArrayWrapper>(PlayerPrefs.GetString(SdkScript.nickname + "DailyTaskGeted", "{\"array\":[false,false,false,false,false,false,false,false]}"));
        if (dailyGetedWrapper != null && dailyGetedWrapper.array != null)
            dailyTaskGeted = dailyGetedWrapper.array;

        var achievementGetedWrapper = JsonUtility.FromJson<BoolArrayWrapper>(PlayerPrefs.GetString(SdkScript.nickname + "AchievementTaskGeted", "{\"array\":[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]}"));
        if (achievementGetedWrapper != null && achievementGetedWrapper.array != null)
            achievementTaskGeted = achievementGetedWrapper.array;
        //如果是新的一天登录，重置每日任务进度
        if (DateTime.Now.Day != DateTime.Parse(PlayerPrefs.GetString(SdkScript.nickname + "LastLoginDate", DateTime.MinValue.ToString())).Day)
        {
            //更新登录日期
            PlayerPrefs.SetString(SdkScript.nickname + "LastLoginDate", DateTime.Now.ToString());
            //重置每日任务进度
            dailyTaskProgress = new int[8] { 1, 0, 0, 0, 0, 0, 0, 0 };
            dailyTaskGeted = new bool[8] { false, false, false, false, false, false, false, false };
        }
    }

}