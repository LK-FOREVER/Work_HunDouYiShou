using UnityEditor.U2D.Aseprite;

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
    public int[] dailyTaskProgress = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    //成就任务进度
    public int[] achievementTaskProgress = new int[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    //每日领取状态
    public bool[] dailyTaskGeted = new bool[8] { false, false, false, false, false, false, false, false };
    //成就领取状态
    public bool[] achievementTaskGeted = new bool[15] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
}