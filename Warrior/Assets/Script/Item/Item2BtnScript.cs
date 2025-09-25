using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item2BtnScript : MonoBehaviour
{
    Rigidbody2D rig4;
    Rigidbody2D rig;
    Vector3 d;
    Vector3 HookD;
    GameObject Hammer;
    GameObject Grenade;
    GameObject Hook;
    GameObject Bullet;
    GameObject Light;
    GameObject light;
    public bool IShoot;
    public GameObject Player;
    public GameObject[] Knife;

    public GameObject MagneticObj;
    public GameObject MatrixObj;

    public GameObject Gun;
    public GameObject ItemPointObj;//?????????
    GameObject obj4;
    public GameObject PMoveEff;
    private PlayerScript playerScript;
    void Start()
    {
        playerScript = Player.GetComponent<PlayerScript>();
        this.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }


    void Update()
    {
        if (playerScript.m != null)
        {
            // Bullet = (GameObject)Resources.Load("Prefabs/BulletObj");
            Hook = playerScript.m.GetComponent<MapScript>().Hook;
            Light = playerScript.m.GetComponent<MapScript>().Light;
            Hammer = playerScript.m.GetComponent<MapScript>().Hammer;
            Grenade = playerScript.m.GetComponent<MapScript>().Grenade;

            // InvokeRepeating("CreateBullet", 0.5f, 0.5f);
        }
        d = (ItemPointObj.transform.position - Player.transform.position).normalized;
        if (playerScript.HookBack && obj4 != null)
        {
            //print("HookBack");
            rig4.drag = 10f;
            rig4.angularDrag = 10f;

            HookD = (Player.transform.position - obj4.transform.position).normalized;
            obj4.transform.position += HookD * 10f * Time.deltaTime;
        }
    }
    public void ClickItem2()
    {
        playerScript.IItem2 = true;
        //this.gameObject.SetActive(false);
        this.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        this.GetComponent<Image>().raycastTarget = false;
        switch (playerScript.Item2Id)
        {
            case 1:
                if (!playerScript.IItem[0])
                {
                    playerScript.IItem[0] = true;
                    playerScript.PlayerDefendObject.SetActive(true);
                    playerScript.InvokeItem1Skill();
                }
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 10;
                break;
            case 2:
                GameObject obj0 = Instantiate(Hammer, ItemPointObj.transform.position, Player.transform.GetChild(0).transform.rotation);
                obj0.transform.parent = Player.transform;
                //obj0.transform.localPosition = new Vector3(0, 0, 0);
                //obj0.transform.localRotation = Quaternion.identity;

                rig = obj0.GetComponent<Rigidbody2D>();
                rig.AddForce(d * 500f);//?????
                rig.drag = 1.5f;
                rig.angularDrag = 1.5f;
                Destroy(obj0, 1f);
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 10;
                break;
            case 3:
                GameObject obj = Instantiate(Grenade, ItemPointObj.transform.position, Player.transform.GetChild(0).transform.rotation);
                obj.transform.parent = Player.transform;
                //obj.transform.localPosition = new Vector3(0, 0, 0);
                //obj.transform.localRotation = Quaternion.identity;
                rig = obj.GetComponent<Rigidbody2D>();
                rig.AddForce(d * 300f);//?????
                rig.drag = 1.5f;
                rig.angularDrag = 1.5f;
                Destroy(obj, 0.75f);
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 10;
                break;
            case 4:
                Invoke("PreventHookBug", 0f);
                obj4 = Instantiate(Hook, ItemPointObj.transform.position, Player.transform.GetChild(0).transform.rotation);
                obj4.transform.parent = Player.transform;
                //obj4.transform.localPosition = new Vector3(0, 0, 0);
                //obj4.transform.localRotation = Quaternion.identity;
                rig4 = obj4.GetComponent<Rigidbody2D>();
                rig4.AddForce(d * 400f);//?????
                rig4.drag = 1.5f;
                rig4.angularDrag = 1.5f;
                Destroy(obj4, 1.5f);
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 10;
                break;
            case 5:
                foreach (var item in Knife)
                {
                    item.gameObject.SetActive(true);
                }
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 10;
                break;
            case 6:
                if (!playerScript.IItem[5])
                {
                    light = Instantiate(Light, ItemPointObj.transform.position, Player.transform.GetChild(0).transform.rotation);
                    Debug.Log(Player.transform.GetChild(0).transform.rotation.eulerAngles);
                    light.transform.parent = Player.transform.GetChild(0).transform;
                    Destroy(light, 1f);
                    playerScript.IItem[5] = true;
                    Invoke("FalseLight", 1f);
                }
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 10;
                break;
            case 7:
                if (!playerScript.IItem[6])
                {
                    playerScript.IItem[6] = true;
                    MagneticObj.SetActive(true);
                    Invoke("FalseMagnetic", 10f);
                }
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 50;
                break;
            case 8:
                if (!playerScript.IItem[7])
                {
                    playerScript.IItem[7] = true;
                    MatrixObj.SetActive(true);
                    Invoke("FalseMatrix", 5f);
                }
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 20;
                break;
            case 9:
                if (!playerScript.IItem[8])
                {
                    playerScript.IItem[8] = true;
                    playerScript.IParse = true;
                    foreach (var temp in playerScript.m.GetComponent<MapScript>().ObstacleList)
                    {
                        temp.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
                        temp.transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = true;
                    }
                    //Player.transform.GetChild(0).GetChild(1).GetComponent<PolygonCollider2D>().enabled = false;
                    //Player.transform.GetChild(0).GetChild(2).GetComponent<PolygonCollider2D>().enabled = false;
                    Invoke("FalsePhase", 3f);
                    PMoveEff.SetActive(true);
                }
                playerScript.m.GetComponent<MapScript>().dic["玩家"] += 50;
                break;
            case 10:
                // if (!playerScript.IItem[9])
                // {
                //     playerScript.IItem[9] = true;
                //     IShoot = true;
                //     Gun.SetActive(true);
                //     Invoke("FalseGun", 8f);



                // }
                // playerScript.m.GetComponent<MapScript>().dic["玩家"] += 10;
                break;
        }
    }
    public void FalseLight()
    {
        //Light.SetActive(false);
        playerScript.IItem[5] = false;
    }
    public void FalseMagnetic()
    {
        MagneticObj.SetActive(false);
        playerScript.IItem[6] = false;
    }
    public void FalseMatrix()
    {
        MatrixObj.SetActive(false);
        playerScript.IItem[7] = false;
    }
    public void FalsePhase()
    {
        playerScript.IParse = false;
        playerScript.IItem[8] = false;
        foreach (var temp in playerScript.m.GetComponent<MapScript>().Others)
        {
            temp.GetComponent<CircleCollider2D>().isTrigger = false;
        }
        //Player.transform.GetChild(0).GetChild(1).GetComponent<PolygonCollider2D>().enabled = true;
        //Player.transform.GetChild(0).GetChild(2).GetComponent<PolygonCollider2D>().enabled = true;
        PMoveEff.SetActive(false);
    }
    public void FalseGun()
    {
        playerScript.IItem[9] = false;
        Gun.SetActive(false);
        IShoot = false;
    }
    public void CreateBullet()
    {
        if (IShoot)
        {
            GameObject obj2 = Instantiate(Bullet, Gun.transform.position, Player.transform.GetChild(0).transform.rotation);
            obj2.transform.parent = Player.transform;
            obj2.transform.localPosition = new Vector3(0, 0, 0);
            //obj2.transform.localRotation = Quaternion.identity;
            Destroy(obj2, 1.5f);
        }

    }
    public void PreventHookBug()
    {
        //obj4.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        //Destroy(obj4.GetComponent<Rigidbody2D>());
        //Destroy(obj4.GetComponent<BoxCollider2D>());
        //Destroy(obj4.transform.GetChild(0).GetComponent<BoxCollider2D>());
        playerScript.m.GetComponent<MapScript>().IFreezeSkill = false;//?????????
        foreach (var temp in playerScript.m.GetComponent<MapScript>().Others)
        {
            if (temp.gameObject.name == "Player")
            {
                temp.GetComponent<PlayerScript>().IFreeze = false;
                temp.transform.parent = null;
            }
            if (temp.gameObject.name == "Warrior1(Clone)")
            {
                temp.GetComponent<Warrior1Script>().IFreeze = false;
                temp.transform.parent = null;
            }
            if (temp.gameObject.name == "Warrior2(Clone)")
            {
                temp.GetComponent<Warrior2Script>().IFreeze = false;
                temp.transform.parent = null;
            }
            if (temp.gameObject.name == "Warrior3(Clone)")
            {
                temp.GetComponent<Warrior3Script>().IFreeze = false;
                temp.transform.parent = null;
            }
            if (temp.gameObject.name == "Warrior4(Clone)")
            {
                temp.GetComponent<Warrior4Script>().IFreeze = false;
                temp.transform.parent = null;
            }
            if (temp.gameObject.name == "Warrior5(Clone)")
            {
                temp.GetComponent<Warrior5Script>().IFreeze = false;
                temp.transform.parent = null;
            }
            if (temp.gameObject.name == "Warrior6(Clone)")
            {
                temp.GetComponent<Warrior6Script>().IFreeze = false;
                temp.transform.parent = null;
            }
        }
    }
}
