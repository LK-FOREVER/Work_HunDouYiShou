using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public PlayerScript p;
    public Button battleBtn;
    public GameObject mainPanel;

    void Start()
    {
        battleBtn.onClick.AddListener(OnClickLevelBtn);
    }
    public void OnClickLevelBtn()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        SceneManager.LoadScene("LoadScene");
        mainPanel.SetActive(false);
        PlayerData.Instance.isBattle = true;
        //每日任务
        PlayerData.Instance.dailyTaskProgress[1]++;
        PlayerData.Instance.SaveData();
    }
}
