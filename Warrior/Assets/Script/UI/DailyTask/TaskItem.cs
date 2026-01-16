using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void InitDailyTask(DailyTaskInfo info)
    {
        Debug.Log("Init Daily Task: " + info);
    }
    public void InitAchievementTask(AchievementTaskInfo info)
    {
        Debug.Log("Init Achievement Task: " + info);
    }
}
