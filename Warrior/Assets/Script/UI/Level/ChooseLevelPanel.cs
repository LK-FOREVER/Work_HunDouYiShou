using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelPanel : MonoBehaviour
{
    public GameObject content;
    public GameObject levelItemPrefab;
    //关卡数据
    private TextAsset levelTextAsset;
    private List<LevelData> levels_data;

    void Start()
    {
        LoadLevelResource();
        Init();
    }
    private void LoadLevelResource()
    {
        levelTextAsset = Resources.Load<TextAsset>("LevelData");
        string level_jsonStr = levelTextAsset.text;
        LevelDataList levelDataList = JsonUtility.FromJson<LevelDataList>(level_jsonStr); //解析json
        levels_data = levelDataList.levels;
    }
    public void Init()
    {
        for (int i = 0; i < levels_data.Count; i++)
        {
            GameObject obj = Instantiate(levelItemPrefab, content.transform);
            LevelItem levelItem = obj.GetComponent<LevelItem>();
            levelItem.Init(levels_data[i]);
        }
    }
}
