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
[System.Serializable]
public class EnemyData
{
    public int enemy_id;
    public string enemy_name;
    public int hp;
    public int attack;
}
[System.Serializable]
public class LevelData
{
    public int level_id;
    public string level_name;
    public List<EnemyData> enemy;
    public string rewardType;
    public int rewardNum;
}
[System.Serializable]
public class LevelDataList
{
    public List<LevelData> levels;
}
[System.Serializable]
public class SkillData
{
    public int skill_id;
    public string skill_desc;
    public int skill_damage;
    public int add_atk;
    public float add_speed;
    public int continue_time;
    public int skill_cooldown;
}
[System.Serializable]
public class SkillDataList
{
    public List<SkillData> skills;
}
