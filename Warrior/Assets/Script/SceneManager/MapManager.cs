using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Sprite[] enemySprite;
    public Tilemap map1;
    public Tilemap map2;
    public Tilemap map3;
    public Tilemap map4;
    public Tilemap map5;

    private ObjectPoolManager poolManager;
    private LevelData levelData;
    void Awake()
    {
        poolManager = ObjectPoolManager.Instance;
    }
    void Start()
    {
        levelData = PlayerData.Instance.levelData;
        ActiveMap();
        CreateMap();
        CreateNpc();
    }

    public void ActiveMap()
    {
        map1.gameObject.SetActive(false);
        map2.gameObject.SetActive(false);
        map3.gameObject.SetActive(false);
        map4.gameObject.SetActive(false);
        map5.gameObject.SetActive(false);
    }
    public void CreateMap()
    {
        int x = Random.Range(0, 26);
        if (x >= 0 && x <= 5)
        {
            map1.gameObject.SetActive(true);
            map2.gameObject.SetActive(false);
            map3.gameObject.SetActive(false);
            map4.gameObject.SetActive(false);
            map5.gameObject.SetActive(false);
        }
        if (x >= 6 && x <= 10)
        {
            map1.gameObject.SetActive(false);
            map2.gameObject.SetActive(true);
            map3.gameObject.SetActive(false);
            map4.gameObject.SetActive(false);
            map5.gameObject.SetActive(false);
        }
        if (x >= 11 && x <= 15)
        {
            map1.gameObject.SetActive(false);
            map2.gameObject.SetActive(false);
            map3.gameObject.SetActive(true);
            map4.gameObject.SetActive(false);
            map5.gameObject.SetActive(false);
        }
        if (x >= 16 && x <= 20)
        {
            map1.gameObject.SetActive(false);
            map2.gameObject.SetActive(false);
            map3.gameObject.SetActive(false);
            map4.gameObject.SetActive(true);
            map5.gameObject.SetActive(false);
        }
        if (x >= 21 && x <= 25)
        {
            map1.gameObject.SetActive(false);
            map2.gameObject.SetActive(false);
            map3.gameObject.SetActive(false);
            map4.gameObject.SetActive(false);
            map5.gameObject.SetActive(true);
        }
    }
    public void CreateNpc()                                                                      //???????Npc
    {
        for (int i = 0; i < levelData.enemy.Count; i++)
        {
            var obj = poolManager.Get(enemyPrefab);
            obj.GetComponent<SpriteRenderer>().sprite = enemySprite[levelData.enemy[i].enemy_id - 1];

            float x = Random.Range(24f, 33f);
            float y = Random.Range(-34f, -28f);
            obj.transform.position = new Vector3(x, y, 0);
            
            obj.GetComponent<EnemyController>().enemyHp = levelData.enemy[i].hp;
            obj.GetComponent<EnemyController>().enemyAtk = levelData.enemy[i].attack;
            Debug.Log("levelData.enemy[i].hp:" + levelData.enemy[i].hp+"levelData.enemy[i].attack:" + levelData.enemy[i].attack);
        }
    }
}
