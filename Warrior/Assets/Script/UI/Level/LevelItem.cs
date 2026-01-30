using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    public Text levelTxt;
    public Button levelBtn;
    private LevelData level_data;
    private PlayerScript p;
    private GameObject MainPanel;
    private GameObject ChooseLevelPanel;
    private GameObject Player;

    void Start()
    {
        levelBtn.onClick.AddListener(() => OnClickLevelBtn(level_data));
    }
    public void Init(LevelData levelData)
    {
        if(!p) p = PlayerScript.Instance;
        if(!MainPanel) MainPanel = GameObject.Find("MainPanel");
        if(!Player) Player = GameObject.Find("Player");
        if(!ChooseLevelPanel) ChooseLevelPanel = GameObject.Find("ChooseLevelPanel");
        level_data = levelData;
        levelTxt.text = levelData.level_name;
    }
    public void OnClickLevelBtn(LevelData levelData)
    {
        Debug.Log("OnClickLevelBtn:" + level_data.level_name);
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseLevelPanel.SetActive(false);
        SceneManager.LoadScene("LoadScene");
        MainPanel.SetActive(false);
        PlayerData.Instance.levelData = levelData;
    }
}
