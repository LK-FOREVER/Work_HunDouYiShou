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
        if (PlayerPrefs.GetInt("ExitGagme",0)==0)
        {
            WarningImg.gameObject.SetActive(true);
            Invoke("FalseWarning", 7f);
        }
        PlayerPrefs.SetInt("ExitGagme",0);
        

        //Invoke("falseWarning", 3f);
        //v = GetComponent<VideoPlayer>();
        //v.Play();
        startBtn.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
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
        PlayerPrefs.SetInt("CurrentPlayerAge",Convert.ToInt32(data.adult_level) );
        string str = "y73163550,4;c73163563,4;c73163569,4:f73163582:e73163829,4:l73163973,4:g73164057,4:x73163914,4:x73164019,4:k73164075,4:i73163591,3:w73163597,3:x73163605,3:a73163624,3" +
            "v73163894,3:f73164000,3:u73164064,3:b73163920,3:g73164024,3:d73164080,3:u73163632,2:a73163637,2:q73163643,2:v73163648,2:d73163908,2:s73164005,2:d73164069,2:w73163927,2:p73164029,2:t73164085,2" +
            "d73163700,1:i73163705,1:v73163708,1:x73163712,1";
        string[] list = str.Split(';');
        for (int i = 0; i < list.Length; i++) 
        {
            string[] temp = list[i].Split(',');    //多次生成temp
            if (data.nickname == temp[0] && temp[1] == "4")
            {
                PlayerPrefs.SetInt("PlayerPrefsLock1", 1);
                PlayerPrefs.SetInt("PlayerPrefsLock2", 1);
                PlayerPrefs.SetInt("PlayerPrefsLock3", 1);
                PlayerPrefs.SetInt("PlayerPrefsLock4", 1);
                PlayerPrefs.SetInt("PlayerPrefsLock5", 1);
                PlayerPrefs.SetInt("PlayerPrefsLock6", 1);
            }
            if (data.nickname == temp[0] && temp[1] == "3")
            {
                PlayerPrefs.SetInt("PlayerPrefsLock1", 1);
                PlayerPrefs.SetInt("PlayerPrefsLock2", 1);
                PlayerPrefs.SetInt("PlayerPrefsLock3", 1);
            }
        }
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