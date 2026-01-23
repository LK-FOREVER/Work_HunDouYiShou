using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntArrayWrapper
{
    public int[] array;
}

[System.Serializable]
public class BoolArrayWrapper
{
    public bool[] array;
}

[System.Serializable]
public class SevenSignInfo
{
    public int day;
    public string rewardType;
    public int rewardNum;
}

[System.Serializable]
public class SevenSignList
{
    public List<SevenSignInfo> signs;
}
[System.Serializable]
public class DailyTaskInfo
{
    public int id;
    public string desc;
    public int num;
    public string rewardType;
    public int rewardNum;
}
[System.Serializable]
public class DailyTaskList
{
    public List<DailyTaskInfo> daily_tasks;
}
[System.Serializable]
public class AchievementTaskInfo
{
    public int id;
    public string desc;
    public int num;
    public string rewardType;
    public int rewardNum;
}
[System.Serializable]
public class AchievementTaskList
{
    public List<AchievementTaskInfo> achievement_tasks;
}
[System.Serializable]
public class PlayTimeData
{
    public string date;          // 记录日期 "yyyy-MM-dd"
    public float totalSeconds;     // 当天累计秒数
    public int savedMinutes;   // 已保存的分钟数
}

