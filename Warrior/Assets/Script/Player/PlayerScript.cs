using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class PlayerScript : MonoBehaviour
{
    public float PlayerHp = 200;
    public float PlayerHP = 200;
    public float ShieldHp;
    public float speed = 3f;
    public float Ak = 30;
    public Sprite[] WarriorImg;
    Vector2 dir;
    public Vector3 d;
    Vector3 D = new Vector3(0, 1, 0);

    public bool IColl;
    public Rigidbody2D rig;
    public GameObject RotationIcon;
    public GameObject BackGround;
    public GameObject PlayerCollision;
    public Text PlayerHpText;
    public Image PlayerHpImage;

    public bool IFreeze;
    public bool Ishield;

    public GameObject m;
    public MapScript mapScript;
    public bool ISingle;
    public bool IPoints;
    public GameObject singlePanel;
    public GameObject pointsPanel;
    public Image SingleWarriorImage;
    public Image PointsWarriorImage;
    public Image EndVictory;
    public Image EndOver;
    public bool IRegame;

    public bool IDead;
    public string Name;
    public int point;
    public int index;

    //public int coin;              //金币系统记录每局游戏金币�?
    public Text Histroytxt;
    public Text NewText;
    public GameObject NewHistroy;

    public Button StopBtn;

    public GameObject AddBloodEff;
    public GameObject TrapEff;
    public GameObject DeadEff;
    public GameObject SpeedEff;
    public GameObject ColiEff;
    public GameObject ShieldEff;
    public GameObject ShowFreezeEff;
    public GameObject IdleFreezeEff;
    public GameObject MonsterEff;
    public GameObject BoomEff;
    public GameObject hammerEff;
    GameObject obj;

    public bool IWarrior5; //�?否使用英�?5
    public Image BlackBackground;
    bool ILoad;
    public AudioSource audio;
    public AudioClip[] acilp;
    public Button SetBtn;
    public GameObject MusicPanel;

    public int R1 = 0;        //选择难度
    public int R2 = 20;
    public int T1 = 1;          //吃陷阱随机�?�率
    public int T2 = 21;
    public int B1 = 1;          //吃�?�包随机�?�率
    public int B2 = 21;

    public int TrapNum = 30;   //地图道具
    public int TrapAfterNum = 10;
    public int AddNum = 50;
    public int AddAfterNum = 10;

    public bool IEasy;           //难度�?间控�?
    public bool INormal;
    public bool IHard;
    public bool IVeryHard;

    public Text BloodTxt;

    public Button ItemBtn1;
    public Button ItemBtn2;
    public bool IItem1 = true;
    public bool IItem2 = true;
    public int Item1Id;
    public int Item2Id;

    public GameObject PlayerDefendObject;

    public GameObject[] ItemObject;
    public bool[] IItem = new bool[10];
    public bool HookBack;

    public bool IParse;
    public bool IMove = true;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Name = "玩家";
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine("ShowPlayerHp");
        //PlayerPrefs.SetInt("PlayerPrefsLock2", 0);
        //PlayerPrefs.SetInt("PlayerPrefsLock3", 0);
        //PlayerPrefs.SetInt("PlayerPrefsLock4", 0);
        //PlayerPrefs.SetInt("PlayerPrefsLock5", 0);

        //int   coin = PlayerPrefs.GetInt("Coin", 0);
        //   coin += 50000;
        //   PlayerPrefs.SetInt("Coin", coin);
    }

    void Update()
    {
        if(mapScript==null && SceneManager.GetActiveScene().name=="GameScene")
        {
            m = GameObject.Find("MapManager");
            mapScript = m.GetComponent<MapScript>();
        }
        //print(IPhase);
        //print(T1 + "  " + T2);
        PlayerHpText.text = PlayerHp.ToString();

        if (!IFreeze)
        {
            if (!IColl)
            {
                if (!ILoad)
                {
                    if (IMove) //摇杆停�??
                    {
                        this.transform.position += d * speed * Time.deltaTime;
                    }

                }

            }
        }


        if (rig.velocity.magnitude < 0.1f)
        {
            IColl = false;
        }
        float r = Vector3.Angle(D, d);

        if (BackGround.GetComponent<ScrolScript>().content.anchoredPosition.x < 0)
        {
            RotationIcon.transform.rotation = Quaternion.Euler(0, 0, r);
        }
        else
        {
            RotationIcon.transform.rotation = Quaternion.Euler(0, 0, -r);
        }
        //RotationIcon.transform.Rotate(this.transform.forward,r);
        //if (this.transform.position.x > -3.435f && this.transform.position.x < 27.435f&&this.transform.position.y < 5.435f && this.transform.position.y > -41.435f)
        //{
        //    this.transform.position += d * speed * Time.deltaTime;
        //}
        Scene activeScene = SceneManager.GetActiveScene();
        //if (SceneManager.GetSceneByName("StartScene").isLoaded)
        //{
        //    SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        //}
        if (SceneManager.GetSceneByName("LoadScene").isLoaded)
        {
            pointsPanel.gameObject.SetActive(false);
            singlePanel.gameObject.SetActive(false);
            BlackBackground.gameObject.SetActive(false);
            SetBtn.gameObject.SetActive(false);
            MusicPanel.SetActive(false);
            ILoad = true;
        }

        if (SceneManager.GetSceneByName("GameScene").isLoaded)
        {
            ILoad = false;
            SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());

            StopBtn.gameObject.SetActive(true);                          //显示暂停按钮
                                                                         //pointsPanel = GameObject.Find("PointsPanel");
                                                                         //singlePanel = GameObject.Find("SinglePanel");

            if (PlayerHp <= 0)
            {
                //canvas = GameObject.Find("Canvas");
                if (IPoints)
                {
                    pointsPanel.gameObject.SetActive(true);
                    //Time.timeScale = 0;
                }

                if (ISingle)
                {
                    singlePanel.gameObject.SetActive(true);                   //单人游戏失败
                                                                              //    EndOver.gameObject.SetActive(true);
                                                                              //Time.timeScale = 0;
                }

            }

        }

        if (IPoints)
        {
            if (m != null)
            {
                mapScript.IPoints = true;         //切换模式
                mapScript.ISingle = false;
            }
        }
        if (ISingle)
        {
            if (m != null)
            {
                mapScript.ISingle = true;
                mapScript.IPoints = false;
            }
        }

    }
    public void SetDir(Vector2 _d)
    {
        dir = new Vector2(_d.x, _d.y);
        d = dir.normalized;
    }
    public void AddPlayerHp(float value)
    {

        PlayerHp += value;
        PlayerHp = Mathf.Clamp(PlayerHp, 0, PlayerHP);
    }
    public void DecreasePlayerHp(float value)
    {
        PlayerHp -= value;

        if (PlayerHp <= 0)
        {
            IDead = true;
            DeadEff.SetActive(true);
            Invoke("FalseDeadEff", 1f);
        }
        PlayerHp = Mathf.Clamp(PlayerHp, 0, PlayerHP);
    }
    public void DecreaseShieldHp(float value)
    {
        ShieldHp -= value;

        ShieldHp = Mathf.Clamp(ShieldHp, 0, 150);
    }
    public IEnumerable DecreaseMatrix()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            DecreasePlayerHp(5);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator ShowPlayerHp()
    {
        yield return new WaitForSeconds(0.1f);
        float Health = PlayerHp;
        while (true)
        {
            if (Health < PlayerHp)
            {
                Health += 1f;
            }
            else
            {
                Health -= 1f;
            }
            PlayerHpImage.fillAmount = (int)Health / PlayerHP;
            yield return new WaitForSeconds(0.000001f);
        }
    }
    IEnumerator ShowShieldHp()
    {
        yield return new WaitForSeconds(0.1f);
        float Health = ShieldHp;
        while (true)
        {
            if (Health > ShieldHp)
            {
                Health -= 0.1f;
            }

            //Warrior2HpImage.fillAmount = (int)Health / 150f;

            yield return new WaitForSeconds(0.001f);
        }
    }
    public void FalseAddBloodEff()
    {
        AddBloodEff.SetActive(false);
    }
    public void InvokeFalseAddBloodEff()
    {
        Invoke("FalseAddBloodEff", 1f);
    }
    public void FalseTrapEff()
    {
        TrapEff.SetActive(false);
    }
    public void InvokeFalseTrapEff()
    {
        Invoke("FalseTrapEff", 1f);
    }
    public void FalseDeadEff()
    {
        DeadEff.SetActive(false);
    }
    public void FalseSpeedEff()
    {
        SpeedEff.SetActive(false);
    }
    public void FalseBoomEff()
    {
        obj.SetActive(false);
    }
    public void FalseBloodTxt()
    {
        BloodTxt.gameObject.SetActive(false);
    }
    public void InvokeFalseBloodTxt()
    {
        Invoke("FalseBloodTxt", 1f);
    }
    public void FalseItem1Skill()
    {
        PlayerDefendObject.SetActive(false);
        IItem[0] = false;
    }
    public void InvokeItem1Skill()
    {
        Invoke("FalseItem1Skill", 0.75f);
    }
    public void FalseFreeze()
    {
        IFreeze = false;
    }
    public void InvokeFalseFreeze()
    {
        hammerEff.SetActive(true);
        Invoke("FalseFreeze", 2f);
        hammerEff.SetActive(false);
    }
}
