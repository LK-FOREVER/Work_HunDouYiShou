using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
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
    //是否是对战模式
    private bool isBattle;
    //难度等级
    private bool IEasy;
    private bool INormal;
    private bool IHard;
    private bool IVeryHard;
    //障碍物数量
    private int obstacleNum = 10;
    //障碍物预制体
    public GameObject[] obstaclePrefab;
    private ObjectPoolManager poolManager;
    private LevelData levelData;
    void Awake()
    {
        poolManager = ObjectPoolManager.Instance;
    }
    void Start()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeMusic, this, new ChangeMusicArgs { index_music = 1 });
        isBattle = PlayerData.Instance.isBattle;
        IEasy = PlayerData.Instance.IEasy;
        INormal = PlayerData.Instance.INormal;
        IHard = PlayerData.Instance.IHard;
        IVeryHard = PlayerData.Instance.IVeryHard;
        levelData = PlayerData.Instance.levelData;
        CreateMap();
        CreateObstacle();
        CreateNpc();
    }
    //创建地图
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
    //创建障碍物
    public void CreateObstacle()
    {
        for (int i = 0; i < obstacleNum; i++)
        {
            var obj = poolManager.Get(obstaclePrefab[Random.Range(0, obstaclePrefab.Length)]);
            float x = Random.Range(25f, 33f);
            float y = Random.Range(-42f, -28f);
            obj.transform.position = new Vector3(x, y, 0);
        }
    }
    //创建敌人
    public void CreateNpc()
    {
        Debug.Log("isBattle:" + isBattle);
        PlayerData.Instance.enemyAliveCount = 0;
        EventManager.Instance.TriggerEvent(EventName.GameStart);
        //初始生命值，攻击力，速度
        int hp_1 = 160; int atk_1 = 2; float speed_1 = 100f;//麒麟
        int hp_2 = 240; int atk_2 = 2; float speed_2 = 120f;//白泽
        int hp_3 = 120; int atk_3 = 3; float speed_3 = 100f;//凤凰
        int hp_4 = 200; int atk_4 = 4; float speed_4 = 150f;//九尾
        int hp_5 = 200; int atk_5 = 4; float speed_5 = 180f;//鲲鹏
        int hp_6 = 280; int atk_6 = 1; float speed_6 = 80f;//玄武

        if (!isBattle)
        {
            //闯关模式，每关两个敌人，第一个敌人读取数据中，第二个敌人随机生成
            for (int i = 0; i < levelData.enemy.Count; i++)
            {
                float x_1 = Random.Range(24f, 33f);
                float y_1 = Random.Range(-34f, -28f);
                var obj_1 = poolManager.Get(enemyPrefab);
                obj_1.transform.position = new Vector3(x_1, y_1, 0);
                obj_1.GetComponent<SpriteRenderer>().sprite = enemySprite[levelData.enemy[i].enemy_id - 1];
                obj_1.GetComponent<EnemyController>().enemyHp = levelData.enemy[i].hp;
                obj_1.GetComponent<EnemyController>().currentEnemyHp = levelData.enemy[i].hp;
                obj_1.GetComponent<EnemyController>().currentEnemySpeed = levelData.enemy[i].speed / 30;
                obj_1.GetComponent<EnemyController>().enemyAtk = levelData.enemy[i].attack;
                obj_1.GetComponent<EnemyController>().currentEnemyAtk = levelData.enemy[i].attack;
                obj_1.GetComponent<EnemyController>().setEnemyIndex(levelData.enemy[i].enemy_id);
                obj_1.GetComponent<EnemyController>().setEnemyID(1);
                PlayerData.Instance.enemyAliveCount++;
                // Debug.Log("levelData.enemy[i].hp:" + levelData.enemy[i].hp + "levelData.enemy[i].attack:" + levelData.enemy[i].attack);
            }
            //随机生成第二个敌人
            float x_2 = Random.Range(24f, 33f);
            float y_2 = Random.Range(-34f, -28f);
            var obj_2 = poolManager.Get(enemyPrefab);
            obj_2.transform.position = new Vector3(x_2, y_2, 0);
            //1-6随机生成一个敌人
            int enemy_id = Random.Range(1, 7);
            obj_2.GetComponent<SpriteRenderer>().sprite = enemySprite[enemy_id - 1];
            switch (enemy_id)
            {
                case 1:
                    obj_2.GetComponent<EnemyController>().enemyHp = hp_1;
                    obj_2.GetComponent<EnemyController>().currentEnemyHp = hp_1;
                    obj_2.GetComponent<EnemyController>().enemySpeed = speed_1 / 30;
                    obj_2.GetComponent<EnemyController>().currentEnemySpeed = speed_1 / 30;
                    obj_2.GetComponent<EnemyController>().enemyAtk = atk_1;
                    obj_2.GetComponent<EnemyController>().currentEnemyAtk = atk_1;
                    break;
                case 2:
                    obj_2.GetComponent<EnemyController>().enemyHp = hp_2;
                    obj_2.GetComponent<EnemyController>().currentEnemyHp = hp_2;
                    obj_2.GetComponent<EnemyController>().enemySpeed = speed_2 / 30;
                    obj_2.GetComponent<EnemyController>().currentEnemySpeed = speed_2 / 30;
                    obj_2.GetComponent<EnemyController>().enemyAtk = atk_2;
                    obj_2.GetComponent<EnemyController>().currentEnemyAtk = atk_2;
                    break;
                case 3:
                    obj_2.GetComponent<EnemyController>().enemyHp = hp_3;
                    obj_2.GetComponent<EnemyController>().currentEnemyHp = hp_3;
                    obj_2.GetComponent<EnemyController>().enemySpeed = speed_3 / 30;
                    obj_2.GetComponent<EnemyController>().currentEnemySpeed = speed_3 / 30;
                    obj_2.GetComponent<EnemyController>().enemyAtk = atk_3;
                    obj_2.GetComponent<EnemyController>().currentEnemyAtk = atk_3;
                    break;
                case 4:
                    obj_2.GetComponent<EnemyController>().enemyHp = hp_4;
                    obj_2.GetComponent<EnemyController>().currentEnemyHp = hp_4;
                    obj_2.GetComponent<EnemyController>().enemySpeed = speed_4 / 30;
                    obj_2.GetComponent<EnemyController>().currentEnemySpeed = speed_4 / 30;
                    obj_2.GetComponent<EnemyController>().enemyAtk = atk_4;
                    obj_2.GetComponent<EnemyController>().currentEnemyAtk = atk_4;
                    break;
                case 5:
                    obj_2.GetComponent<EnemyController>().enemyHp = hp_5;
                    obj_2.GetComponent<EnemyController>().currentEnemyHp = hp_5;
                    obj_2.GetComponent<EnemyController>().enemySpeed = speed_5 / 30;
                    obj_2.GetComponent<EnemyController>().currentEnemySpeed = speed_5 / 30;
                    obj_2.GetComponent<EnemyController>().enemyAtk = atk_5;
                    obj_2.GetComponent<EnemyController>().currentEnemyAtk = atk_5;
                    break;
                case 6:
                    obj_2.GetComponent<EnemyController>().enemyHp = hp_6;
                    obj_2.GetComponent<EnemyController>().currentEnemyHp = hp_6;
                    obj_2.GetComponent<EnemyController>().enemySpeed = speed_6 / 30;
                    obj_2.GetComponent<EnemyController>().currentEnemySpeed = speed_6 / 30;
                    obj_2.GetComponent<EnemyController>().enemyAtk = atk_6;
                    obj_2.GetComponent<EnemyController>().currentEnemyAtk = atk_6;
                    break;
                default:
                    break;
            }
            obj_2.GetComponent<EnemyController>().setEnemyIndex(enemy_id);
            obj_2.GetComponent<EnemyController>().setEnemyID(2);
            PlayerData.Instance.enemyAliveCount++;
        }
        else
        {
            //对战模式，只有一个敌人
            float x = Random.Range(24f, 33f);
            float y = Random.Range(-34f, -28f);
            var obj = poolManager.Get(enemyPrefab);
            obj.transform.position = new Vector3(x, y, 0);
            //1-6随机生成一个敌人
            int enemy_id = Random.Range(1, 7);
            obj.GetComponent<SpriteRenderer>().sprite = enemySprite[enemy_id - 1];
            obj.GetComponent<EnemyController>().setEnemyIndex(enemy_id);
            if (IEasy)
            {

                switch (enemy_id)
                {
                    case 1:
                        obj.GetComponent<EnemyController>().enemyHp = hp_1;
                        obj.GetComponent<EnemyController>().currentEnemyHp = hp_1;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_1 / 30;
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_1 / 30;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_1;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_1;
                        break;
                    case 2:
                        obj.GetComponent<EnemyController>().enemyHp = hp_2;
                        obj.GetComponent<EnemyController>().currentEnemyHp = hp_2;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_2 / 30;
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_2 / 30;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_2;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_2;
                        break;
                    case 3:
                        obj.GetComponent<EnemyController>().enemyHp = hp_3;
                        obj.GetComponent<EnemyController>().currentEnemyHp = hp_3;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_3 / 30;
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_3 / 30;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_3;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_3;
                        break;
                    case 4:
                        obj.GetComponent<EnemyController>().enemyHp = hp_4;
                        obj.GetComponent<EnemyController>().currentEnemyHp = hp_4;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_4 / 30;
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_4 / 30;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_4;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_4;
                        break;
                    case 5:
                        obj.GetComponent<EnemyController>().enemyHp = hp_5;
                        obj.GetComponent<EnemyController>().currentEnemyHp = hp_5;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_5 / 30;
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_5 / 30;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_5;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_5;
                        break;
                    case 6:
                        obj.GetComponent<EnemyController>().enemyHp = hp_6;
                        obj.GetComponent<EnemyController>().currentEnemyHp = hp_6;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_6 / 30;
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_6 / 30;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_6;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_6;
                        break;
                    default:
                        break;
                }
            }
            else if (INormal)
            {
                switch (enemy_id)
                {
                    case 1:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_1 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_1 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_1 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_1 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_1;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_1;
                        break;
                    case 2:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_2 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_2 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_2 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_2 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_2;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_2;
                        break;
                    case 3:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_3 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_3 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_3 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_3 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_3;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_3;
                        break;
                    case 4:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_4 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_4 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_4 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_4 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_4;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_4;
                        break;
                    case 5:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_5 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_5 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_5 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_5 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_5;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_5;
                        break;
                    case 6:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_6 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_6 * 1.2f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_6 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_6 / 30 * 1.2f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_6;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_6;
                        break;
                    default:
                        break;
                }
            }
            else if (IHard)
            {
                switch (enemy_id)
                {
                    case 1:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_1 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_1 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_1 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_1 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_1;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_1;
                        break;
                    case 2:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_2 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_2 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_2 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_2 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_2;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_2;
                        break;
                    case 3:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_3 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_3 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_3 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_3 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_3;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_3;
                        break;
                    case 4:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_4 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_4 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_4 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_4 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_4;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_4;
                        break;
                    case 5:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_5 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_5 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_5 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_5 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_5;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_5;
                        break;
                    case 6:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_6 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_6 * 1.3f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_6 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_6 / 30 * 1.3f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_6;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_6;
                        break;
                    default:
                        break;
                }
                //每日任务
                PlayerData.Instance.dailyTaskProgress[2]++;
                PlayerData.Instance.SaveData();
            }
            else if (IVeryHard)
            {
                switch (enemy_id)
                {
                    case 1:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_1 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_1 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_1 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_1 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_1;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_1;
                        break;
                    case 2:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_2 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_2 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_2 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_2 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_2;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_2;
                        break;
                    case 3:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_3 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_3 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_3 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_3 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_3;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_3;
                        break;
                    case 4:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_4 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_4 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_4 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_4 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_4;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_4;
                        break;
                    case 5:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_5 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_5 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_5 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_5 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_5;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_5;
                        break;
                    case 6:
                        obj.GetComponent<EnemyController>().enemyHp = (int)(hp_6 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemyHp = (int)(hp_6 * 1.4f);
                        obj.GetComponent<EnemyController>().currentEnemySpeed = speed_6 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemySpeed = speed_6 / 30 * 1.4f;
                        obj.GetComponent<EnemyController>().enemyAtk = atk_6;
                        obj.GetComponent<EnemyController>().currentEnemyAtk = atk_6;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
