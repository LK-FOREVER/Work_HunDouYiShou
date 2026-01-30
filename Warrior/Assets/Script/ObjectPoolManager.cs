using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : SingletonAutoMonoBase<ObjectPoolManager>
{
    // 每种Prefab一个池
    private Dictionary<GameObject, Queue<GameObject>> poolDict = new Dictionary<GameObject, Queue<GameObject>>();

    void Awake()
    {

        // DontDestroyOnLoad(gameObject);
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
            // 恢复为 prefab 的原始缩放，防止复用时出现缩放累乘或异常
            if (prefab != null)
                obj.transform.localScale = prefab.transform.localScale;
            return obj;
        }
        else
        {
            var obj = Instantiate(prefab);
            // 确保新实例的缩放与 prefab 一致
            if (prefab != null)
                obj.transform.localScale = prefab.transform.localScale;
            return obj;
        }
    }

    // 回收对象
    public void Return(GameObject prefab, GameObject obj)
    {
        if (obj == null) return;
        obj.SetActive(false);
        // 恢复为 prefab 的原始缩放，避免被之前父物体或操作改变
        if (prefab != null)
            obj.transform.localScale = prefab.transform.localScale;
        // 重置物理状态
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
        // 重置变换
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        if (!poolDict.ContainsKey(prefab))
            poolDict[prefab] = new Queue<GameObject>();

        //限制数量
        if (poolDict[prefab].Count >= 40)
        {
            Destroy(obj);
            return;
        }
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