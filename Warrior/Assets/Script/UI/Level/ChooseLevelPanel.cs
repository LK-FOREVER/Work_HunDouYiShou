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

    void Awake()
    {
        LoadLevelResource();
    }
    private void LoadLevelResource()
    {
        levelTextAsset = Resources.Load<TextAsset>("Data/level_data");
        string level_jsonStr = levelTextAsset.text;
        LevelDataList levelDataList = JsonUtility.FromJson<LevelDataList>(level_jsonStr);
        levels_data = levelDataList.levels;
    }
    public void Init()
    {
        //清除content下的所有子物体
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
        //根据关卡数据生成关卡项
        for (int i = 0; i < levels_data.Count; i++)
        {
            GameObject obj = Instantiate(levelItemPrefab, content.transform);
            LevelItem levelItem = obj.GetComponent<LevelItem>();
            levelItem.Init(levels_data[i]);
        }
    }
}
