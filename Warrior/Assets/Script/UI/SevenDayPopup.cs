using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SevenDayPopup : MonoBehaviour
{
    public const string SignNumPrefs = "SignNum";
    public const string SignDataPrefs = "SignData";
    public Button closeBtn;
    private TextAsset sevenSignTextAsset;
    private List<SevenSignInfo> sevenSignList;

    public GameObject[] alreadyHave;
    int signCount;
    DateTime today;
    DateTime lastSignDate;

    void Start()
    {
        closeBtn.onClick.AddListener(() =>
        {
            EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
            gameObject.SetActive(false);
        });
        UpdateUI();
        sevenSignTextAsset = Resources.Load<TextAsset>("Data/seven_days_sign_reward");
        string jsonStr = sevenSignTextAsset.text;
        SevenSignList signList = JsonUtility.FromJson<SevenSignList>(jsonStr);
        sevenSignList = signList.signs;
    }
    void OnEnable()
    {
        UpdateUI();
    }

    public void OnSignClicked()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        if (!IsSameDay(lastSignDate, today))
        {
            signCount++;
            lastSignDate = today;

            PlayerPrefs.SetInt(SdkScript.nickname + SignNumPrefs, signCount);
            PlayerPrefs.SetString(SdkScript.nickname + SignDataPrefs, lastSignDate.ToString());

            GiveReward(signCount);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // 初始化数据
        today = DateTime.Now;
        signCount = PlayerPrefs.GetInt(SdkScript.nickname + SignNumPrefs, 0);
        lastSignDate = DateTime.Parse(PlayerPrefs.GetString(SdkScript.nickname + SignDataPrefs, DateTime.MinValue.ToString()));

        // 检查是否需要重置
        if (NeedReset())
        {
            PlayerPrefs.DeleteKey(SdkScript.nickname + SignNumPrefs);
            PlayerPrefs.DeleteKey(SdkScript.nickname + SignDataPrefs);
            signCount = 0;
        }
        for (int i = 0; i < alreadyHave.Length; i++)
        {
            alreadyHave[i].SetActive(i < PlayerPrefs.GetInt(SdkScript.nickname + SignNumPrefs, 0));
            //前六天和第七天节点的button组件挂载的节点不同，需要分别获取
            if (i <= alreadyHave.Length - 2)
                alreadyHave[i].transform.parent.GetComponent<Button>().interactable = i >= signCount && !IsSameDay(lastSignDate, today) && signCount == i; //设置按钮是否可点击
            else
                alreadyHave[i].transform.parent.GetChild(0).GetComponent<Button>().interactable = i >= signCount && !IsSameDay(lastSignDate, today) && signCount == i;
        }
    }

    bool IsSameDay(DateTime date1, DateTime date2)
    {
        return date1.Year == date2.Year &&
               date1.Month == date2.Month &&
               date1.Day == date2.Day;
    }

    bool NeedReset()
    {
        // 超过7天或跨周重置
        if (signCount >= 7) return true;

        TimeSpan span = today - lastSignDate;
        return span.Days > 1 || GetWeekOfYear(today) != GetWeekOfYear(lastSignDate);
    }

    int GetWeekOfYear(DateTime date)
    {
        return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
            date,
            System.Globalization.CalendarWeekRule.FirstDay,
            DayOfWeek.Monday);
    }

    void GiveReward(int day)
    {
        //从列表中获取指定天数的签到奖励信息
        SevenSignInfo signInfo = sevenSignList.Find(x => x.day == day);
        if (signInfo != null)
        {
            if (signInfo.rewardType == "Coin")
            {
                PlayerPrefs.SetInt(SdkScript.nickname + "Coin", PlayerPrefs.GetInt(SdkScript.nickname + "Coin", 0) + signInfo.rewardNum);
            }
            else if (signInfo.rewardType == "Crystal")
            {
                PlayerPrefs.SetInt(SdkScript.nickname + "Crystal", PlayerPrefs.GetInt(SdkScript.nickname + "Crystal", 0) + signInfo.rewardNum);
            }
        }
    }
}