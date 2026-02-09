using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    public Text levelTxt;
    public Button levelBtn;
    public GameObject mask;
    private LevelData level_data;
    private PlayerScript p;
    private GameObject MainPanel;
    private GameObject ChooseLevelPanel;
    private GameObject Player;
    private GameObject energyTip;

    void Start()
    {
        levelBtn.onClick.AddListener(() => OnClickLevelBtn(level_data));
    }
    public void Init(LevelData levelData, int currentLevelIndex, GameObject tip)
    {
        if (!p) p = PlayerScript.Instance;
        if (!MainPanel) MainPanel = GameObject.Find("MainPanel");
        if (!Player) Player = GameObject.Find("Player");
        if (!ChooseLevelPanel) ChooseLevelPanel = GameObject.Find("ChooseLevelPanel");
        level_data = levelData;
        levelTxt.text = levelData.level_name;
        energyTip = tip;
        //如果当前关卡索引小于已通过的关卡数，说明该关卡已解锁
        if (currentLevelIndex <= PlayerPrefs.GetInt(SdkScript.nickname + "MaxPassedLevelIndex", 0))
        {
            mask.SetActive(false);
            levelBtn.interactable = true;
        }
        else
        {
            mask.SetActive(true);
            levelBtn.interactable = false;
        }
    }
    public void OnClickLevelBtn(LevelData levelData)
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        if (PlayerPrefs.GetInt(SdkScript.nickname + "Energy", 0) >= 5)
        {
            PlayerPrefs.SetInt(SdkScript.nickname + "Energy", PlayerPrefs.GetInt(SdkScript.nickname + "Energy", 0) - 5);
            //每日任务
            PlayerData.Instance.dailyTaskProgress[4] += 5;
            //成就任务
            PlayerData.Instance.achievementTaskProgress[12] += 5;
            PlayerData.Instance.achievementTaskProgress[13] += 5;
            PlayerData.Instance.achievementTaskProgress[14] += 5;
            PlayerData.Instance.SaveData();

            ChooseLevelPanel.SetActive(false);
            SceneManager.LoadScene("LoadScene");
            MainPanel.SetActive(false);
            Debug.Log("OnClickLevelBtn:" + level_data.level_name);
            PlayerData.Instance.levelData = levelData;
            PlayerData.Instance.isBattle = false;
        }
        else
        {
            //提示体力不足
            energyTip.SetActive(true);
            Invoke("CloseTip", 1.5f);
        }
    }
    //关闭提示
    public void CloseTip()
    {
        energyTip.SetActive(false);
    }
}
