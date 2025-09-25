using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Warrior1Script : MonoBehaviour
{
    public GameObject Player;
    public float Warrior1Hp = 200;
    public float Speed = 3f;
    public float Ak = 30f;

    public bool IMoveToPos = true;
    bool IMoveToOthers = false;
    Vector3 D;
    public Vector3 d;
    public Vector3 TargetPos;
    float desPos;

    public GameObject NpcRotationIcon;
    public GameObject Warrior1Collision;
    Vector3 V = new Vector3(0, 1, 0);

    bool INpcColli;
    public Rigidbody2D rig;

    public GameObject m;
    float desNpc;

    public int r;
    public Text Warrior1HpText;
    public Image Warrior1HpImage;

    public bool IFreeze;

    public bool IDead;
    public string Name;
    public int point;
    //public int index;

    public GameObject ColiEff;
    public GameObject DeadEff;
    public GameObject SpeedEff;
    public GameObject hammerEff;

    GameObject obj;

    public Canvas PlayerCanvas;
    public GameObject Rotation;

    public AudioSource audio;
    public AudioClip[] acilp;

    public GameObject Arrow1;
    GameObject ObjA;
    public float FreqSkill = 20;

    public Text BloodTxt;

    //����Ϊ����
    public GameObject ItemPointObj;
    public GameObject DefendObj;
    GameObject Hammer;
    GameObject Grenade;
    GameObject Hook;
    Vector3 ItemD;
    Rigidbody2D rig0;
    Rigidbody2D rig3;
    Rigidbody2D rig4;
    GameObject obj4;
    public bool HookBack;
    Vector3 HookD;
    public GameObject[] Knife;
    GameObject Light;
    GameObject light;
    public GameObject MagneticObj;
    public GameObject MatrixObj;

    bool IShoot;
    GameObject Bullet;
    public GameObject Gun;
    public GameObject PMoveEff;
    public bool Iparse;
    // ...existing code...
    private MapScript mapScript;

    void Awake()
    {
    }
    // ...existing code...
    void Start()
    {
        audio = GetComponent<AudioSource>();

        m = GameObject.Find("MapManager");
        mapScript = m.GetComponent<MapScript>();
        Player = GameObject.Find("Player");
        Arrow1 = mapScript.Arrow1;
        Light = mapScript.Light;
        ObjA = Instantiate(Arrow1);
        ObjA.transform.position = Player.transform.position;
        mapScript.WarriorArrow.Add(ObjA);
        int n = Random.Range(0, 101);
        Name = "异兽" + n.ToString();
        //mapScript.Warriorname.Add(Name);
        //mapScript.Warriorpoint.Add(point);
        mapScript.dic.Add(Name, 0);

        RandomR();
        rig = GetComponent<Rigidbody2D>();


        StartCoroutine("ShowWarrior1Hp");
        StartCoroutine("Skill");
        //for (int i = 0; i < mapScript.PointIndex.Count; i++)              //ÿһ���ű�����Ψһ�±�
        //{
        //    if (mapScript.PointIndex[i] != 0)
        //    {
        //        index = i;
        //        mapScript.Warriorname[i] = Name;                          //ƥ�����������һ��

        //        print(index);
        //        mapScript.PointIndex[i] = 0;
        //        break;
        //    }
        //}

        StartCoroutine("UseItem");

        Bullet = mapScript.Bullet;
        Hammer = mapScript.Hammer;
        Grenade = mapScript.Grenade;

        InvokeRepeating("CreateBullet", 0.5f, 0.5f);

    }


    void Update()
    {
        ItemD = (ItemPointObj.transform.position - this.transform.position).normalized;
        if (HookBack && obj4 != null)
        {
            //print("HookBack");
            rig4.drag = 10f;
            rig4.angularDrag = 10f;
            HookD = (this.transform.position - obj4.transform.position).normalized;
            obj4.transform.position += HookD * 8f * Time.deltaTime;
        }

        if (Player != null)
        {
            Vector3 D = this.transform.position - ObjA.transform.position;
            Vector3 d = D.normalized;
            float angle = Vector3.Angle(V, d);
            if (d.x < 0)
            {
                ObjA.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                ObjA.transform.rotation = Quaternion.Euler(0, 0, -angle);
            }
            ObjA.transform.position += d * 10f * Time.deltaTime;
            if (ObjA.transform.position.x > Player.transform.position.x + 2.05f && (ObjA.transform.position.y < Player.transform.position.y + 4.85f || ObjA.transform.position.y > Player.transform.position.y - 4.85f))
            {
                ObjA.transform.position = new Vector3(Player.transform.position.x + 2.05f, ObjA.transform.position.y, 0);
            }
            if (ObjA.transform.position.x < Player.transform.position.x - 2.05f && (ObjA.transform.position.y < Player.transform.position.y + 4.85f || ObjA.transform.position.y > Player.transform.position.y - 4.85f))
            {
                ObjA.transform.position = new Vector3(Player.transform.position.x - 2.05f, ObjA.transform.position.y, 0);
            }
            if (ObjA.transform.position.y > Player.transform.position.y + 4.85f && (ObjA.transform.position.x < Player.transform.position.x + 2.05f || ObjA.transform.position.x > Player.transform.position.x - 2.05f))
            {
                ObjA.transform.position = new Vector3(ObjA.transform.position.x, Player.transform.position.y + 4.85f);
            }
            if (ObjA.transform.position.y < Player.transform.position.y - 4.85f && (ObjA.transform.position.x < Player.transform.position.x + 2.05f || ObjA.transform.position.x > Player.transform.position.x - 2.05f))
            {
                ObjA.transform.position = new Vector3(ObjA.transform.position.x, Player.transform.position.y - 4.85f);
            }
            //����ͼ��
            if ((ObjA.transform.position.x < Player.transform.position.x + 2.05f && ObjA.transform.position.x > Player.transform.position.x - 2.05f && ObjA.transform.position.y < Player.transform.position.y + 4.8f && ObjA.transform.position.y > Player.transform.position.y - 4.8f) || IDead)
            {
                ObjA.SetActive(false);
            }
            else
            {
                ObjA.SetActive(true);
            }

        }
        /*index=mapScript.SortIndex[index];     */           //ʵʱ���½�������±�
        Warrior1HpText.text = Warrior1Hp.ToString();
        RotateRotationObject();
        if (!IFreeze)
        {
            RemoveToTargetPos();
            RemoveToOthers();
        }
        if (rig.velocity.magnitude < 1f * Time.deltaTime)
        {
            INpcColli = false;
        }


    }
    public void RemoveToTargetPos()
    {

        if (IMoveToPos)
        {
            if (!INpcColli)
            {

                D = TargetPos - this.transform.position;
                d = D.normalized;
                desPos = Vector3.Distance(this.transform.position, TargetPos);
                if (desPos > 0.5f)
                {
                    this.transform.position += d * Speed * Time.deltaTime;
                }
                else
                {
                    float x = Random.Range(0f, 24f);
                    float y = Random.Range(-38f, 2f);
                    TargetPos = new Vector3(x, y, 0);
                }
            }
        }
    }
    public void RemoveToOthers()
    {
        if (r > Player.GetComponent<PlayerScript>().R1 && r < Player.GetComponent<PlayerScript>().R2)
        {
            if (!INpcColli)
            {
                for (int i = 0; i < mapScript.Others.Count; i++)
                {
                    desNpc = Vector3.Distance(this.transform.position, mapScript.Others[i].transform.position);
                    if (desNpc < 2f && (mapScript.Others[i] != this.gameObject) && (r >= 0 && r <= 10))
                    {
                        IMoveToPos = false;
                        D = mapScript.Others[i].transform.position - this.transform.position;
                        d = D.normalized;
                        this.transform.position += d * Speed * Time.deltaTime;
                    }
                    else
                    {
                        IMoveToPos = true;
                    }
                }
            }
        }
    }
    public void RotateRotationObject()
    {
        float r = Vector3.Angle(V, d);
        if (d.x < 0)
        {
            NpcRotationIcon.transform.rotation = Quaternion.Euler(0, 0, r);
        }
        else
        {
            NpcRotationIcon.transform.rotation = Quaternion.Euler(0, 0, -r);
        }
    }
    public void RandomR()
    {
        r = Random.Range(0, 21);
    }
    public void WarriorSkill()
    {
        audio.clip = acilp[0];
        Speed = 5f;
        Invoke("falseSkill", 10);
        SpeedEff.SetActive(true);
        Invoke("FalseSpeedEff", 10f);
    }
    public void falseSkill()
    {
        Speed = 3f;
    }
    IEnumerator Skill()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        while (true)
        {
            WarriorSkill();
            yield return new WaitForSeconds(FreqSkill);
        }
    }
    public void AddWarrior1Hp(float value)
    {
        Warrior1Hp += value;
        Warrior1Hp = Mathf.Clamp(Warrior1Hp, 0, 200);
    }
    public void DecreaseWarrior1Hp(float value)
    {
        Warrior1Hp -= value;
        if (Warrior1Hp <= 0)
        {
            ObjA.SetActive(false);
            audio.clip = acilp[6];
            audio.Play();
            print("Dead");
            IDead = true;
            DeadEff.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            PlayerCanvas.gameObject.SetActive(false);
            Rotation.SetActive(false);
            Invoke("FalseDeadEff", 0.5f);
        }
        Warrior1Hp = Mathf.Clamp(Warrior1Hp, 0, 200);
    }
    IEnumerator ShowWarrior1Hp()
    {
        yield return new WaitForSeconds(0.1f);
        float Health = Warrior1Hp;
        while (true)
        {
            if (Health < Warrior1Hp)
            {
                Health += 1f;
            }
            else
            {
                Health -= 1f;
            }
            Warrior1HpImage.fillAmount = (int)Health / 200f;

            yield return new WaitForSeconds(0.000001f);
        }
    }
    public IEnumerable DecreaseMatrix()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            DecreaseWarrior1Hp(5);
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator UseItem()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            NpcUseItem();

            yield return new WaitForSeconds(Random.Range(8f, 20f));

        }
    }
    public void NpcUseItem()
    {
        int r = Random.Range(1, 11);
        switch (r)
        {
            case 1:
                DefendObj.SetActive(true);
                Invoke("FalseItem1", 0.75f);
                mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 10;
                break;
            case 2:
                GameObject obj0 = Instantiate(Hammer, ItemPointObj.transform.position, this.transform.GetChild(0).transform.rotation);
                obj0.transform.parent = this.transform;
                //obj0.transform.localPosition = new Vector3(0, 0, 0);
                //obj0.transform.localRotation = Quaternion.identity;
                rig0 = obj0.GetComponent<Rigidbody2D>();
                rig0.AddForce(ItemD * 750f);//ʩ����
                rig0.drag = 1.5f;
                rig0.angularDrag = 1.5f;
                Destroy(obj0, 1f);
                mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 10;
                break;
            case 3:
                GameObject obj = Instantiate(Grenade, ItemPointObj.transform.position, this.transform.GetChild(0).transform.rotation);
                obj.transform.parent = Player.transform;
                //obj.transform.localPosition = new Vector3(0, 0, 0);
                //obj.transform.localRotation = Quaternion.identity;
                rig3 = obj.GetComponent<Rigidbody2D>();
                rig3.AddForce(d * 600f);//ʩ����
                rig3.drag = 1.5f;
                rig3.angularDrag = 1.5f;
                Destroy(obj, 0.75f);
                mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 10;
                break;
            //case 4:
            //    Invoke("PreventHookBug", 1.4f);
            //    Hook = (GameObject)Resources.Load("Prefabs/PlayerHookItemObj");
            //    obj4 = Instantiate(Hook, ItemPointObj.transform.position, this.transform.GetChild(0).transform.rotation);
            //    obj4.transform.parent = this.transform;
            //obj4.transform.localPosition = new Vector3(0, 0, 0);
            //obj4.transform.localRotation = Quaternion.identity;
            //    rig4 = obj4.GetComponent<Rigidbody2D>();
            //    rig4.AddForce(d * 300f);//ʩ����
            //    rig4.drag = 1.5f;
            //    rig4.angularDrag = 1.5f;
            //    Destroy(obj4, 1.5f);
            //mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 10;
            //    break;
            case 5:
                foreach (var item in Knife)
                {
                    item.gameObject.SetActive(true);
                }
                mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 10;
                break;
            case 6:
                //Light.SetActive(true);
                light = Instantiate(Light, ItemPointObj.transform.position, this.transform.GetChild(0).transform.rotation);
                light.transform.parent = this.transform.GetChild(0).transform;
                Destroy(light, 1f);
                //Invoke("FalseLignt", 1f);
                mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 10;
                break;
            case 7:
                MagneticObj.SetActive(true);
                Invoke("FalseMagnetic", 10f);
                mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 50;
                break;
            case 8:
                MatrixObj.SetActive(true);
                Invoke("FalseMatrix", 5f);
                mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 20;
                break;
            case 9:
                //transform.GetChild(0).GetChild(1).GetComponent<PolygonCollider2D>().enabled = false;
                //transform.GetChild(0).GetChild(2).GetComponent<PolygonCollider2D>().enabled = false;
                Iparse = true;
                foreach (var temp in Player.GetComponent<PlayerScript>().m.GetComponent<MapScript>().ObstacleList)
                {
                    temp.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
                    temp.transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = true;
                }
                Invoke("FalsePhase", 3f);
                mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 50;
                PMoveEff.SetActive(true);
                break;
            case 10:

                // IShoot = true;
                // Gun.SetActive(true);
                // Invoke("FalseGun", 8f);
                // mapScript.dic[GetComponentInParent<Warrior1Script>().Name] += 10;
                break;
        }
    }
    public void NpcAttackItem()
    {

    }
    public void NpcBeAttackItem()
    {

    }
    public void PreventHookBug()
    {
        Player.GetComponent<PlayerScript>().m.GetComponent<MapScript>().IFreezeSkill = false;//�رճ����ƶ�
        foreach (var temp in Player.GetComponent<PlayerScript>().m.GetComponent<MapScript>().Others)
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
    public void FalseLignt()
    {
        Light.SetActive(false);

    }
    public void FalseMagnetic()
    {
        MagneticObj.SetActive(false);
    }
    public void FalseMatrix()
    {
        MatrixObj.SetActive(false);
    }
    public void FalsePhase()
    {

        PMoveEff.SetActive(false);
        foreach (var temp in Player.GetComponent<PlayerScript>().m.GetComponent<MapScript>().ObstacleList)
        {
            temp.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
            temp.transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = false;
        }
        Iparse = false;
        //transform.GetChild(0).GetChild(1).GetComponent<PolygonCollider2D>().enabled = true;
        // transform.GetChild(0).GetChild(2).GetComponent<PolygonCollider2D>().enabled = true;
    }
    public void CreateBullet()
    {
        if (IShoot)
        {
            GameObject obj2 = Instantiate(Bullet, Gun.transform.position, this.transform.GetChild(0).transform.rotation);
            obj2.transform.parent = this.transform;
            obj2.transform.localPosition = new Vector3(0, 0, 0);
            //obj2.transform.localRotation = Quaternion.identity;
            Destroy(obj2, 1.5f);
        }

    }
    public void FalseGun()
    {
        Gun.SetActive(false);
        IShoot = false;
    }
    public void FalseDeadEff()
    {
        DeadEff.SetActive(false);
        Destroy(this.gameObject);
        mapScript.Others.Remove(this.gameObject);
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            RemoveToTargetPos();
        }
    }
    //����Ϊ�رյ���
    public void FalseItem1()
    {
        DefendObj.SetActive(false);
    }
}