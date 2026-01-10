using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
