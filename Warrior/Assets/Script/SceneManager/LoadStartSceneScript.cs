using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class LoadStartSceneScript : MonoBehaviour
{
    public Image load;

    AsyncOperation async;

    float Realloadvalue = 0;

    float loadvalue = 0;

    public Image WarningImg;

    public SdkScript sdkScript;

    public Text LoadTxt;

    public Button startBtn;
    public GameObject ExitTips;//防沉迷踢出弹窗
    void Start()
    {
        if (PlayerPrefs.GetInt(SdkScript.nickname + "ExitGagme", 0) == 0)
        {
            WarningImg.gameObject.SetActive(true);
            Invoke("FalseWarning", 7f);
        }
        PlayerPrefs.SetInt(SdkScript.nickname + "ExitGagme", 0);


        //Invoke("falseWarning", 3f);
        //v = GetComponent<VideoPlayer>();
        //v.Play();
        startBtn.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            LoginPram loginPram = new LoginPram { nickname = "n7653447411111", adult_level = "2", timestamp = "1700000000" };
            SdkScript.nickname = loginPram.nickname;
            SdkScript.adult_level = Convert.ToInt32(loginPram.adult_level);
            ID(loginPram);
            StartCoroutine("AsyncLoadScene");
#elif UNITY_ANDROID
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        unityActivity.Call("login");
#endif
        });

    }
    void Update()
    {
        if (async == null)                                //预错
        {
            return;
        }

        if (async.progress < 0.9f)
        {
            Realloadvalue = (int)(async.progress * 100);
        }
        else
        {
            Realloadvalue = 100;
        }
        if (loadvalue <= Realloadvalue)
        {
            loadvalue += 1f;
            //showload.text = ((int)loadvalue).ToString() + "%";
            load.fillAmount = loadvalue / 100.0f;
        }
        if (loadvalue >= 100)
        {

            LoadTxt.gameObject.SetActive(false);
            //async.allowSceneActivation = true;

        }
    }
    IEnumerator AsyncLoadScene()
    {
        yield return new WaitForSeconds(0.1f);
        async = SceneManager.LoadSceneAsync("StartScene");
        async.allowSceneActivation = true;
        yield return async;


    }
    public void LoginCallBack(string str)
    {
        Debug.Log(str);
        LoginPram param = JsonUtility.FromJson<LoginPram>(str);
        if (Convert.ToInt32(param.adult_level) == 0 || Convert.ToInt32(param.adult_level) == 1)
        {
            return;
        }
        else if (Convert.ToInt32(param.adult_level) == 2)
        {
            sdkScript.ExitGame(param.timestamp);       //启动防沉迷记录时间
        }

        SdkScript.nickname = param.nickname;
        SdkScript.adult_level = Convert.ToInt32(param.adult_level);
        ID(param);
        StartCoroutine("AsyncLoadScene");
        startBtn.gameObject.SetActive(false);
        LoadTxt.gameObject.SetActive(true);
    }
    public void FalseWarning()
    {
        WarningImg.gameObject.SetActive(false);
    }
    private void ID(LoginPram data)
    {
        PlayerPrefs.SetInt(SdkScript.nickname + "CurrentPlayerAge", Convert.ToInt32(data.adult_level));
        //3表示中级账号，4表示高级账号
        string str = "y75999322,4;f75999326,4;m75999331,4;g75999347,4;r75999384,4;k75999398,4;z76534483,4;q76534487,4;j75999307,3;s75999313,3;u75999318,3;d75999342,3;e75999379,3;a75999393,3;s76534469,3;n76534474,3;";
        string[] list = str.Split(';');
        for (int i = 0; i < list.Length; i++)
        {
            string[] temp = list[i].Split(',');    //多次生成temp
            if (data.nickname == temp[0] && temp[1] == "4")
            {
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock1", 1);
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock2", 1);
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock3", 1);
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock4", 1);
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock5", 1);
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock6", 1);
            }
            if (data.nickname == temp[0] && temp[1] == "3")
            {
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock1", 1);
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock2", 1);
                PlayerPrefs.SetInt(SdkScript.nickname + "PlayerPrefsLock3", 1);
            }
        }
        if (PlayerPrefs.GetString(SdkScript.nickname + "PlayerName") == "")
            SdkScript.is_new_user = true;
    }
}








//AsyncOperation operation = SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Single);
//operation.allowSceneActivation = false;
//float progress = 0;
//while (progress < 1f)
//{
//    progress = operation.progress;

//    if (progress >= 0.9f)
//    {
//        progress = 1.0f;
//        LoadTxt.gameObject.SetActive(false);
//        operation.allowSceneActivation = true;
//    }

//    load.fillAmount = progress; // 更新进度条
//    yield return null;
//}