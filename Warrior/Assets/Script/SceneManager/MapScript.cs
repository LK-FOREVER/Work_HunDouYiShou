using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MapScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Scrol;
    public GameObject AddBlood;
    public GameObject Trap;
    public GameObject[] Warriors;
    public List<GameObject> Others = new List<GameObject>();
    public List<GameObject> AddBloodList = new List<GameObject>();
    public List<GameObject> TrapList = new List<GameObject>();
    public List<GameObject> ObstacleList = new List<GameObject>();
    public List<GameObject> NpcList = new List<GameObject>();
    public List<GameObject> NpcArrow = new List<GameObject>();
    public GameObject obstacleT;
    public GameObject obstacleV;
    public GameObject obstacleW;
    //List<int> AddBloodList = new List<int>();
    //List<int> TrapList = new List<int>();

    public Tilemap map1;
    public Tilemap map2;
    public Tilemap map3;
    public Tilemap map4;
    public Tilemap map5;
    float x0;
    float y0;
    float x1;
    float y1;
    float x2;
    float y2;

    Vector2 Vpos;
    Vector2 Tpos;
    Vector2 Wpos;

    bool IRotate = false;

    //bool ICreateNpc;
    public bool ISingle;
    public bool IPoints;
    public Text TimeTxt;
    public float lateTime;
    public float currentTime;

    public bool ICreateNpcAfter = true;
    public bool ICreateAddBloodAfter = true;
    public bool ICreateTrapAfter = true;

    public List<string> Warriorname = new List<string>();
    public List<int> Warriorpoint = new List<int>();

    public int Index;
    public int index;
    //public List<int> PointIndex = new List<int>();                   

    public Text[] WarriornameTxt;
    public Text[] WarriorpointTxt;

    public bool Icoin = true;
    public GameObject SortPanel;

    public bool IFreezeSkill;

    public List<GameObject> WarriorArrow = new List<GameObject>();

    public Dictionary<string, int> dic = new Dictionary<string, int>();

    public int Count;
    public int Warrior3Count;

    public GameObject[] Item;
    public List<GameObject> ItemList = new List<GameObject>();
    public Sprite[] ItemSprite = new Sprite[10];

    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public GameObject Arrow4;
    public GameObject Arrow5;
    public GameObject Arrow6;
    public GameObject Light;
    public GameObject Bullet;
    public GameObject Hammer;
    public GameObject Grenade;
    public GameObject Hook;

    void Awake()
    {
        Arrow1 = (GameObject)Resources.Load("Prefabs/Warrior1Arrow");
        Arrow2 = (GameObject)Resources.Load("Prefabs/Warrior2Arrow");
        Arrow3 = (GameObject)Resources.Load("Prefabs/Warrior3Arrow");
        Arrow4 = (GameObject)Resources.Load("Prefabs/Warrior4Arrow");
        Arrow5 = (GameObject)Resources.Load("Prefabs/Warrior5Arrow");
        Arrow6 = (GameObject)Resources.Load("Prefabs/Warrior6Arrow");
        Light = (GameObject)Resources.Load("Prefabs/LightObj");
        Bullet = (GameObject)Resources.Load("Prefabs/BulletObj");
        Hammer = (GameObject)Resources.Load("Prefabs/PlayerHammerItem");
        Grenade = (GameObject)Resources.Load("Prefabs/PlayerGrenade");
        Hook = (GameObject)Resources.Load("Prefabs/PlayerHookItemObj");
    }
    void Start()
    {
        Player = GameObject.Find("Player");
        Scrol = GameObject.Find("StartCanvas");
        //Warriorname.Add(Player.GetComponent<PlayerScript>().Name);
        //Warriorpoint.Add(Player.GetComponent<PlayerScript>().point);
        //PointIndex.Add(0);

        //Warriorname[index] = Player.GetComponent<PlayerScript>().Name;
        //Warriorpoint[index] = Player.GetComponent<PlayerScript>().point;
        dic.Add("玩家", 0);

        Others.Add(Player);

        ActiveMap();
        CreateMap();
        CreateAddBlood();
        Invoke("CreateAddBloodAfter", 30f);
        CreateTrap();
        InvokeRepeating("CreateTrapAfter", 30f, 30f);
        CreateObstacle();
        CreateNpc();
        CreateItem();
        InvokeRepeating("CreateItemAfter", 30f, 30f);
        StartCoroutine("Fun");

        lateTime = Time.time;
    }

    void Update()
    {
        SetDiff();

        SingleFun();
        PointsFun();


        //print(Warrior3Count);
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
    public void CreateObstacle()
    {
        for (int i = 0; i < 15; i++)
        {
            x0 = Random.Range(-4f, 28f);
            y0 = Random.Range(-42f, 6f);
            x1 = Random.Range(-4f, 28f);
            y1 = Random.Range(-42f, 6f);
            x2 = Random.Range(-4f, 28f);
            y2 = Random.Range(-42f, 6f);
            Tpos = new Vector2(x0, y0);
            Vpos = new Vector2(x1, y1);
            Wpos = new Vector2(x2, y2);
            GameObject objT = Instantiate(obstacleT);
            ObstacleList.Add(objT);
            objT.transform.position = Tpos;
            GameObject objV = Instantiate(obstacleV);
            ObstacleList.Add(objV);
            objV.transform.position = Vpos;
            GameObject objW = Instantiate(obstacleW);
            ObstacleList.Add(objW);
            objW.transform.position = Wpos;
            // int rT = Random.Range(0, 26);
            // if (rT >= 0 && rT < 5)
            // {
            //     objT.transform.rotation = Quaternion.Euler(0, 0, 0);
            //     objV.transform.rotation = Quaternion.Euler(0, 0, 0);
            // }
            // else if (rT >= 5 && rT < 10)
            // {
            //     objT.transform.rotation = Quaternion.Euler(0, 0, 90);
            //     objV.transform.rotation = Quaternion.Euler(0, 0, 90);
            // }
            // else if (rT >= 10 && rT < 15)
            // {
            //     objT.transform.rotation = Quaternion.Euler(0, 0, 180);
            //     objV.transform.rotation = Quaternion.Euler(0, 0, 180);
            // }
            // else if (rT >= 15 && rT < 20)
            // {
            //     objT.transform.rotation = Quaternion.Euler(0, 0, 270);
            //     objV.transform.rotation = Quaternion.Euler(0, 0, 270);
            // }
            // else if (rT >= 20 && rT < 25)
            // {
            //     objT.transform.rotation = Quaternion.Euler(0, 0, 360);
            //     objV.transform.rotation = Quaternion.Euler(0, 0, 360);
            // }
        }

    }
    public void CreateNpc()                                                                      //???????Npc
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject obj = GameObject.Instantiate(Warriors[Random.Range(0, 6)]);

            Index++;
            //PointIndex.Add(Index);
            Others.Add(obj);
            NpcList.Add(obj);

            float xW = Random.Range(-4f, 28f);
            float yW = Random.Range(6f, -42f);
            obj.transform.position = new Vector3(xW, yW, 0);
        }
    }
    public void CreateNpcAfter()
    {
        if (IPoints)
        {
            if (ICreateNpcAfter)
            {

                GameObject obj = GameObject.Instantiate(Warriors[Random.Range(0, 6)]);

                Index++;
                //PointIndex.Add(Index);
                Others.Add(obj);
                NpcList.Add(obj);

                float xW = Random.Range(-4f, 28f);
                float yW = Random.Range(6f, -42f);
                obj.transform.position = new Vector3(xW, yW, 0);
            }

        }
    }
    IEnumerator Fun()                                                                            //????????Npc
    {
        yield return new WaitForSeconds(20f);//??

        while (true)
        {
            CreateNpcAfter();
            yield return new WaitForSeconds(20f);//??
        }
    }

    //public void ActiveAddBlood()                        
    //{
    //    foreach(var item in AddBlood)                   
    //    {
    //        item.SetActive(false);
    //    }
    //}
    public void CreateAddBlood()                                            //??????????????
    {
        for (int i = 0; i < Player.GetComponent<PlayerScript>().AddNum; i++)
        {
            GameObject obj = GameObject.Instantiate(AddBlood);
            AddBloodList.Add(obj);
            float x = Random.Range(-4f, 28f);
            float y = Random.Range(-42f, 6f);
            obj.transform.position = new Vector3(x, y, 0);
        }

    }
    public void CreateAddBloodAfter()
    {
        if (ICreateAddBloodAfter)
        {
            for (int i = 0; i < Player.GetComponent<PlayerScript>().AddAfterNum; i++)
            {
                GameObject obj = GameObject.Instantiate(AddBlood);
                AddBloodList.Add(obj);
                float x = Random.Range(2f, 22f);
                float y = Random.Range(-36f, 0f);
                obj.transform.position = new Vector3(x, y, 0);
            }
        }
    }

    public void CreateTrap()                                            //???????????????
    {
        for (int i = 0; i < Player.GetComponent<PlayerScript>().TrapNum; i++)
        {
            GameObject obj = GameObject.Instantiate(Trap);
            TrapList.Add(obj);
            float x = Random.Range(-4f, 28f);
            float y = Random.Range(-42f, 6f);
            obj.transform.position = new Vector3(x, y, 0);
        }
    }
    public void CreateTrapAfter()
    {
        if (ICreateTrapAfter)
        {
            for (int i = 0; i < Player.GetComponent<PlayerScript>().TrapAfterNum; i++)
            {
                GameObject obj = GameObject.Instantiate(Trap);
                TrapList.Add(obj);
                float x = Random.Range(2f, 22f);
                float y = Random.Range(-36f, 0f);
                obj.transform.position = new Vector3(x, y, 0);
            }
        }
    }
    public void CreateItem()
    {
        for (int i = 0; i < 30; i++)
        {
            int ItemID = Random.Range(0, 10);
            GameObject obj = GameObject.Instantiate(Item[ItemID]);
            ItemList.Add(obj);
            float x = Random.Range(-4f, 28f);
            float y = Random.Range(-42f, 6f);
            obj.transform.position = new Vector3(x, y, 0);
        }
    }
    public void CreateItemAfter()
    {
        for (int i = 0; i < 10; i++)
        {
            int ItemID = Random.Range(0, 10);
            GameObject obj = GameObject.Instantiate(Item[ItemID]);
            ItemList.Add(obj);
            float x = Random.Range(-4f, 28f);
            float y = Random.Range(-42f, 6f);
            obj.transform.position = new Vector3(x, y, 0);
        }
    }

    public void SingleFun()
    {
        if (ISingle)
        {
            SortPanel.SetActive(false);
            if (Others.Count == 1)
            {
                Player.GetComponent<PlayerScript>().singlePanel.SetActive(true);         //单人游戏胜利
                // Player.GetComponent<PlayerScript>().EndVictory.gameObject.SetActive(true);
                // Player.GetComponent<PlayerScript>().EndOver.gameObject.SetActive(false);
                Player.GetComponent<PlayerScript>().IFreeze = true;
                ICreateAddBloodAfter = false;
                ICreateNpcAfter = false;
                ICreateTrapAfter = false;
                TimeTxt.text = "剩余玩家人数:" + Others.Count.ToString();
                Debug.Log("Icoin" + Icoin + "easy" + Player.GetComponent<PlayerScript>().IEasy + "normal" + Player.GetComponent<PlayerScript>().INormal + "hard" + Player.GetComponent<PlayerScript>().IHard + "veryhard" + Player.GetComponent<PlayerScript>().IVeryHard);
                if (Icoin)
                {
                    Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[13];
                    Player.GetComponent<PlayerScript>().audio.Play();
                    if (Player.GetComponent<PlayerScript>().IEasy)
                    {
                        int Coin = PlayerPrefs.GetInt("Coin", 0);                                   //加金币
                        Coin += 200;
                        PlayerPrefs.SetInt("Coin", Coin);
                        Icoin = false;
                        Scrol.GetComponent<CanvasScript>().SingleCoinTxt.text = "*200";
                    }
                    if (Player.GetComponent<PlayerScript>().INormal)
                    {
                        int Coin = PlayerPrefs.GetInt("Coin", 0);                                   //加金币
                        Coin += 240;
                        PlayerPrefs.SetInt("Coin", Coin);
                        Icoin = false;
                        Scrol.GetComponent<CanvasScript>().SingleCoinTxt.text = "*240";
                    }
                    if (Player.GetComponent<PlayerScript>().IHard)
                    {
                        int Coin = PlayerPrefs.GetInt("Coin", 0);                                   //加金币
                        Coin += 280;
                        PlayerPrefs.SetInt("Coin", Coin);
                        Icoin = false;
                        Scrol.GetComponent<CanvasScript>().SingleCoinTxt.text = "*280";
                    }
                    if (Player.GetComponent<PlayerScript>().IVeryHard)
                    {
                        int Coin = PlayerPrefs.GetInt("Coin", 0);                                   //加金币
                        Coin += 360;
                        PlayerPrefs.SetInt("Coin", Coin);
                        Icoin = false;
                        Scrol.GetComponent<CanvasScript>().SingleCoinTxt.text = "*280";
                    }
                }
            }
            else if (Others.Count != 1 && Player.GetComponent<PlayerScript>().PlayerHp <= 0)
            {

                Player.GetComponent<PlayerScript>().singlePanel.SetActive(true);         //单人游戏失败
                // Player.GetComponent<PlayerScript>().EndOver.gameObject.SetActive(true);
                // Player.GetComponent<PlayerScript>().EndVictory.gameObject.SetActive(false);
                foreach (var item in Others)
                {
                    if (item.tag == "PLAYER")
                    {
                        item.GetComponent<PlayerScript>().IFreeze = true;
                    }
                    if (item.name == "Warrior1(Clone)")
                    {
                        item.GetComponent<Warrior1Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior2(Clone)")
                    {
                        item.GetComponent<Warrior2Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior3(Clone)")
                    {
                        item.GetComponent<Warrior3Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior4(Clone)")
                    {
                        item.GetComponent<Warrior4Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior5(Clone)")
                    {
                        item.GetComponent<Warrior5Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior6(Clone)")
                    {
                        item.GetComponent<Warrior6Script>().IFreeze = true;
                    }
                }
                ICreateAddBloodAfter = false;
                ICreateNpcAfter = false;
                ICreateTrapAfter = false;
                TimeTxt.text = "剩余玩家人数:" + Others.Count.ToString();
                if (Icoin)
                {
                    Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[14];
                    Player.GetComponent<PlayerScript>().audio.Play();
                    int Coin = PlayerPrefs.GetInt("Coin", 0);
                    Coin += 0;
                    PlayerPrefs.SetInt("Coin", Coin);
                    Icoin = false;
                    Scrol.GetComponent<CanvasScript>().SingleCoinTxt.text = "*0";
                }

            }
            else  //单人游戏继续
            {
                if (!IFreezeSkill)
                {
                    foreach (var item in Others)
                    {
                        if (item.tag == "PLAYER")
                        {
                            item.GetComponent<PlayerScript>().IFreeze = false;
                        }
                        if (item.name == "Warrior1(Clone)")
                        {
                            item.GetComponent<Warrior1Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior2(Clone)")
                        {
                            item.GetComponent<Warrior2Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior3(Clone)")
                        {
                            item.GetComponent<Warrior3Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior4(Clone)")
                        {
                            item.GetComponent<Warrior4Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior5(Clone)")
                        {
                            item.GetComponent<Warrior5Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior6(Clone)")
                        {
                            item.GetComponent<Warrior6Script>().IFreeze = false;
                        }
                    }

                }
                Player.GetComponent<PlayerScript>().singlePanel.SetActive(false);
                //Player.GetComponent<PlayerScript>().IFreeze = false;
                ICreateAddBloodAfter = true;
                ICreateNpcAfter = false;
                ICreateTrapAfter = true;
                TimeTxt.text = "剩余玩家人数:" + " " + (Others.Count + Warrior3Count).ToString();
            }

            TimeTxt.fontSize = 70;
        }

    }
    public void PointsFun()
    {
        if (IPoints)
        {
            SortPanel.SetActive(true);
            if (currentTime < 0 || Player.GetComponent<PlayerScript>().PlayerHp <= 0)
            {
                //SortPoint();
                //ShowSort();
                SortAndShow(0);
                Player.GetComponent<PlayerScript>().pointsPanel.SetActive(true);
                ICreateAddBloodAfter = false;
                ICreateNpcAfter = false;
                ICreateTrapAfter = false;

                foreach (var item in Others)
                {
                    if (item.tag == "PLAYER")
                    {
                        item.GetComponent<PlayerScript>().IFreeze = true;
                    }
                    if (item.name == "Warrior1(Clone)")
                    {
                        item.GetComponent<Warrior1Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior2(Clone)")
                    {
                        item.GetComponent<Warrior2Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior3(Clone)")
                    {
                        item.GetComponent<Warrior3Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior4(Clone)")
                    {
                        item.GetComponent<Warrior4Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior5(Clone)")
                    {
                        item.GetComponent<Warrior5Script>().IFreeze = true;
                    }
                    if (item.name == "Warrior6(Clone)")
                    {
                        item.GetComponent<Warrior6Script>().IFreeze = true;
                    }
                }


                TimeTxt.gameObject.SetActive(false);
                if (Icoin)
                {
                    Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[12];
                    Player.GetComponent<PlayerScript>().audio.Play();
                    int Coin = PlayerPrefs.GetInt("Coin", 0);                                   //判断金币数
                    if (dic["玩家"] < 200)
                    {
                        Coin += 0;
                        PlayerPrefs.SetInt("Coin", Coin);
                        Icoin = false;
                        Scrol.GetComponent<CanvasScript>().PointCoinTxt.text = "*0";
                    }
                    if (dic["玩家"] > 200 && dic["玩家"] <= 500)
                    {
                        Coin += 100;
                        PlayerPrefs.SetInt("Coin", Coin);
                        Icoin = false;
                        Scrol.GetComponent<CanvasScript>().PointCoinTxt.text = "*100";
                    }
                    if (dic["玩家"] >= 500 && dic["玩家"] <= 2000)
                    {
                        Coin += 200;
                        PlayerPrefs.SetInt("Coin", Coin);
                        Icoin = false;
                        Scrol.GetComponent<CanvasScript>().PointCoinTxt.text = "*200";
                    }
                    if (dic["玩家"] > 2000)
                    {
                        Coin += 100;
                        PlayerPrefs.SetInt("Coin", Coin);
                        Icoin = false;
                        Scrol.GetComponent<CanvasScript>().PointCoinTxt.text = "*300";
                    }
                    int P_Point = PlayerPrefs.GetInt("Point", 0);
                    P_Point += dic["玩家"];
                    PlayerPrefs.SetInt("Point", P_Point);
                }
                Player.GetComponent<PlayerScript>().NewText.text = dic["玩家"].ToString();             //?????????
                //int PlayerprefsPoint = PlayerPrefs.GetInt("PlayerprefsPoint", 0);
                if (dic["玩家"] > PlayerPrefs.GetInt("PlayerprefsPoint", 0))
                {
                    print("Histroy");
                    Player.GetComponent<PlayerScript>().Histroytxt.text = "历史最高分:" + " " + dic["玩家"].ToString();
                    PlayerPrefs.SetInt("PlayerprefsPoint", dic["玩家"]);
                    Player.GetComponent<PlayerScript>().NewHistroy.gameObject.SetActive(true);
                }
                else
                {
                    Player.GetComponent<PlayerScript>().Histroytxt.text = "历史最高分:" + " " + PlayerPrefs.GetInt("PlayerprefsPoint", 0).ToString();
                    //Player.GetComponent<PlayerScript>().NewHistroy.gameObject.SetActive(false) ;
                }

            }
            else if (currentTime >= 0)
            {
                SortAndShow(0);
                Player.GetComponent<PlayerScript>().pointsPanel.SetActive(false);
                ICreateAddBloodAfter = true;
                ICreateNpcAfter = true;
                ICreateTrapAfter = true;
                if (!IFreezeSkill)
                {
                    foreach (var item in Others)
                    {
                        if (item.tag == "PLAYER")
                        {
                            item.GetComponent<PlayerScript>().IFreeze = false;
                        }
                        if (item.name == "Warrior1(Clone)")
                        {
                            item.GetComponent<Warrior1Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior2(Clone)")
                        {
                            item.GetComponent<Warrior2Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior3(Clone)")
                        {
                            item.GetComponent<Warrior3Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior4(Clone)")
                        {
                            item.GetComponent<Warrior4Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior5(Clone)")
                        {
                            item.GetComponent<Warrior5Script>().IFreeze = false;
                        }
                        if (item.name == "Warrior6(Clone)")
                        {
                            item.GetComponent<Warrior6Script>().IFreeze = false;
                        }
                    }

                }
                TimeTxt.gameObject.SetActive(true);
            }
            currentTime = 90 - (Time.time - lateTime);

            int minutes = (int)(currentTime / 60);
            int seconds = (int)(currentTime % 60);

            TimeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            //Debug.Log(string.Format("Time Elapsed: {0:00}:{1:00}", minutes, seconds));
        }

    }
    public void SortAndShow(int t)
    {

        var sort = dic.OrderByDescending(p => p.Value);

        foreach (KeyValuePair<string, int> kvp in sort)
        {
            //point.Add(kvp.Value);
            //name.Add(kvp.Key);

            //print(kvp.Key + "：" + kvp.Value);
            WarriornameTxt[t].text = kvp.Key.ToString();
            WarriorpointTxt[t].text = kvp.Value.ToString();
            t++;
            if (t >= 8)
            {
                break;
            }
        }
    }

    public void SetDiff()
    {
        if (Player.GetComponent<PlayerScript>().IEasy)
        {
            foreach (var temp in Others)
            {
                if (temp.name == "Warrior1(Clone)")
                {
                    temp.GetComponent<Warrior1Script>().FreqSkill = 40;
                }
                if (temp.name == "Warrior2(Clone)")
                {
                    temp.GetComponent<Warrior2Script>().FreqSkill = 30;
                }
                if (temp.name == "Warrior3(Clone)")
                {
                    temp.GetComponent<Warrior3Script>().FreqSkill = 40;
                }
                if (temp.name == "Warrior4(Clone)")
                {
                    temp.GetComponent<Warrior4Script>().FreqSkill = 40;
                }
                if (temp.name == "Warrior6(Clone)")
                {
                    temp.GetComponent<Warrior6Script>().FreqSkill = 40;
                }
            }
        }
        if (Player.GetComponent<PlayerScript>().INormal)
        {
            foreach (var temp in Others)
            {
                if (temp.name == "Warrior1(Clone)")
                {
                    temp.GetComponent<Warrior1Script>().FreqSkill = 20;
                }
                if (temp.name == "Warrior2(Clone)")
                {
                    temp.GetComponent<Warrior2Script>().FreqSkill = 20;
                }
                if (temp.name == "Warrior3(Clone)")
                {
                    temp.GetComponent<Warrior3Script>().FreqSkill = 30;
                }
                if (temp.name == "Warrior4(Clone)")
                {
                    temp.GetComponent<Warrior4Script>().FreqSkill = 20;
                }
                if (temp.name == "Warrior6(Clone)")
                {
                    temp.GetComponent<Warrior6Script>().FreqSkill = 20;
                }
            }
        }
        if (Player.GetComponent<PlayerScript>().IHard)
        {
            foreach (var temp in Others)
            {
                if (temp.name == "Warrior1(Clone)")
                {
                    temp.GetComponent<Warrior1Script>().FreqSkill = 15;
                }
                if (temp.name == "Warrior2(Clone)")
                {
                    temp.GetComponent<Warrior2Script>().FreqSkill = 15;
                }
                if (temp.name == "Warrior3(Clone)")
                {
                    temp.GetComponent<Warrior3Script>().FreqSkill = 20;
                }
                if (temp.name == "Warrior4(Clone)")
                {
                    temp.GetComponent<Warrior4Script>().FreqSkill = 10;
                }
                if (temp.name == "Warrior6(Clone)")
                {
                    temp.GetComponent<Warrior6Script>().FreqSkill = 10;
                }
            }
        }
        if (Player.GetComponent<PlayerScript>().IVeryHard)
        {
            foreach (var temp in Others)
            {
                if (temp.name == "Warrior1(Clone)")
                {
                    temp.GetComponent<Warrior1Script>().FreqSkill = 10;
                }
                if (temp.name == "Warrior2(Clone)")
                {
                    temp.GetComponent<Warrior2Script>().FreqSkill = 10;
                }
                if (temp.name == "Warrior3(Clone)")
                {
                    temp.GetComponent<Warrior3Script>().FreqSkill = 15;
                }
                if (temp.name == "Warrior4(Clone)")
                {
                    temp.GetComponent<Warrior4Script>().FreqSkill = 5;

                }
                if (temp.name == "Warrior6(Clone)")
                {
                    temp.GetComponent<Warrior6Script>().FreqSkill = 5;
                }
            }
        }

    }
    public void FlaseIFreezeSkill()
    {
        IFreezeSkill = false;
    }
    public void InvokeFalseFreezeSkill()
    {
        Invoke("FlaseIFreezeSkill", 2f);
    }
}
