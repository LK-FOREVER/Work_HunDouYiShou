using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    public Text levelTxt;
    public Button levelBtn;
    private LevelData level_data;
    void Start()
    {
        levelBtn.onClick.AddListener(() => OnClickLevelBtn(level_data));
    }
    public void Init(LevelData levelData)
    {
        level_data = levelData;
        levelTxt.text = levelData.level_name;
    }
    public void OnClickLevelBtn(LevelData levelData)
    {
        // ChooseLevelPanel.Instance.SelectLevel(level_data);
    }
}
