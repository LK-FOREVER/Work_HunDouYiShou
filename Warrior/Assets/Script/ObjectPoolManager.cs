using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    // 每种Prefab一个池
    private Dictionary<GameObject, Queue<GameObject>> poolDict = new Dictionary<GameObject, Queue<GameObject>>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // 获取对象
    public GameObject Get(GameObject prefab)
    {
        if (!poolDict.ContainsKey(prefab))
            poolDict[prefab] = new Queue<GameObject>();

        var pool = poolDict[prefab];
        if (pool.Count > 0)
        {
            var obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return Instantiate(prefab);
        }
    }

    // 回收对象
    public void Return(GameObject prefab, GameObject obj)
    {
        obj.SetActive(false);
        if (!poolDict.ContainsKey(prefab))
            poolDict[prefab] = new Queue<GameObject>();
        poolDict[prefab].Enqueue(obj);
    }
    // 清空所有池中的对象
    public void Clear()
    {
        foreach (var kv in poolDict)
        {
            while (kv.Value.Count > 0)
            {
                var obj = kv.Value.Dequeue();
                Destroy(obj);
            }
        }
        poolDict.Clear();
    }
}