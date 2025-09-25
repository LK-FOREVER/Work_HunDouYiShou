using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SdkScript : MonoBehaviour
{

    public static string nickname;//玩家ID编号
    public static int adult_level;//玩家年龄字段

    public GameObject TimeTips;//游戏时长温馨提示
    public GameObject ExitTips;//退出游戏提示

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    
    public void ExitGame(string str)
    {
        DateTime epoch =new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc);
        DateTime utcDateTime =epoch.AddSeconds(int.Parse(str));
        DateTime localDateTime=utcDateTime.ToLocalTime();
        int delayTime =(21-localDateTime.Hour)*60*60+(0-localDateTime.Minute)*60+(0-localDateTime.Second)*60;
        // 检查当前时间是否处于20:45到21:00之间
        int delayTime2 =(20-localDateTime.Hour)*60*60+(45-localDateTime.Minute)*60+(0-localDateTime.Second)*60;
        if (delayTime2>=0)
        {
            StartCoroutine(ShowTimeTips(delayTime2));
        }
        else
        {
            StartCoroutine(ShowTimeTips(0));
        }
        StartCoroutine(ShowExitTips(delayTime));
        
    }

    //到21.00显示退出游戏提示
    public IEnumerator ShowExitTips(int time)
    {
        yield return new WaitForSeconds(time);
        GameObject obj = Instantiate(ExitTips, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(GameObject.Find("TipsPanel").transform);
        obj.transform.localPosition = new Vector3(0, 0, 0);
        obj.transform.Find("Confirm").GetComponent<Button>().onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("ExitGagme",1);
            SceneManager.LoadScene("LoadStartScene");
        });
    }
    //如果是20.45-21.00之间的时间段，则显示温馨提示
    public IEnumerator ShowTimeTips(int time)
    {
        yield return new WaitForSeconds(time);
        GameObject obj = Instantiate(TimeTips, Vector3.zero, Quaternion.identity);
        obj.transform.SetParent(GameObject.Find("TipsPanel").transform);
        obj.transform.localPosition = new Vector3(0, 0, 0);
    }
    // public IEnumerator Exit(int time)
    // {
    //     yield return new WaitForSeconds(time);
    //     PlayerPrefs.SetInt("ExitGagme",1);
    //     SceneManager.LoadScene("LoadStartScene");
    // }

}

public class LoginPram
{
    public string adult_level;
    public string timestamp;
    public string nickname;
}