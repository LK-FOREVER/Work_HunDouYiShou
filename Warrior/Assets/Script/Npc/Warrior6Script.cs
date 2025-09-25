using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Warrior6Script : MonoBehaviour
{
    public GameObject Player;
   public float Warrior6Hp = 200;
   public float Speed = 3.8f;
    public float Ak = 20f;

    bool IMoveToPos = true;
    bool IMoveToOthers = false;
    Vector3 D;
    public Vector3 d;
    public Vector3 TargetPos;
    float desPos;

    public GameObject NpcRotationIcon;
    Vector3 V = new Vector3(0, 1, 0);

    bool INpcColli;
  public  Rigidbody2D rig;

  public  GameObject m;
    float desNpc;

    int r;
    public Text Warrior6HpText;
    public Image Warrior6HpImage;
    bool Ifront;
    bool Iback;

    public GameObject Boom;

    public bool IFreeze;
    public bool IDead;
    public string Name;
    public int point;
    //public int index;
    public int R1;        //ѡ���Ѷ�
    public int R2;

    public GameObject ColiEff;
    public GameObject DeadEff;
   
    public GameObject BombEff;
    public GameObject hammerEff;

    GameObject obj;
    public Canvas PlayerCanvas;
    public GameObject Rotation;
    public AudioSource audio;
    public AudioClip[] acilp;

    public GameObject Arrow6;
     GameObject ObjA;
    public float FreqSkill=20;

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
    void Start()
    {
      
        audio = GetComponent<AudioSource>();
        RandomR();
        rig = GetComponent<Rigidbody2D>();
        m = GameObject.Find("MapManager");
        Player = GameObject.Find("Player");
        Arrow6 = (GameObject)Resources.Load("Prefabs/Warrior6Arrow");
        ObjA = Instantiate(Arrow6);
        ObjA.transform.position = Player.transform.position;
        m.GetComponent<MapScript>().WarriorArrow.Add(ObjA);
       
        StartCoroutine("ShowWarrior6Hp");
        StartCoroutine("Skill");

        int n = Random.Range(0, 101);
        Name = "异兽" + n.ToString();
        //m.GetComponent<MapScript>().Warriorname.Add(Name);
        //m.GetComponent<MapScript>().Warriorpoint.Add(point);
        m.GetComponent<MapScript>().dic.Add(Name, 0);
        //for (int i = 0; i < m.GetComponent<MapScript>().PointIndex.Count; i++)              //ÿһ���ű�����Ψһ�±�
        //{
        //    if (m.GetComponent<MapScript>().PointIndex[i] != 0)
        //    {
        //        index = i;
        //        m.GetComponent<MapScript>().Warriorname[i] = Name;

        //        m.GetComponent<MapScript>().PointIndex[i] = 0;
        //        break;
        //    }
        //}

        StartCoroutine("UseItem");
       
        Bullet = (GameObject)Resources.Load("Prefabs/BulletObj");
        Light = (GameObject)Resources.Load("Prefabs/LightObj");
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
        /* index = m.GetComponent<MapScript>().SortIndex[index];*/                //ʵʱ���½�������±�
        Warrior6HpText.text = Warrior6Hp.ToString();
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
                for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
                {
                    desNpc = Vector3.Distance(this.transform.position, m.GetComponent<MapScript>().Others[i].transform.position);
                    if (desNpc < 2f && (m.GetComponent<MapScript>().Others[i] != this.gameObject) && (r >= 0 && r <= 10))
                    {
                        IMoveToPos = false;
                        D = m.GetComponent<MapScript>().Others[i].transform.position - this.transform.position;
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
    public void Warrior6Skill()
    {
        audio.clip = acilp[0];
        audio.Play();
        GameObject obj1 = GameObject.Instantiate(BombEff);
        obj1.transform.position = this.transform.position;
       
    }
    
    IEnumerator Skill()
    {
        yield return new WaitForSeconds(Random.Range(1f,5f));
        while (true)
        {
            Warrior6Skill();
            yield return new WaitForSeconds(FreqSkill);
        }
    }
    public void AddWarrior6Hp(float value)
    {
        Warrior6Hp += value;
        Warrior6Hp = Mathf.Clamp(Warrior6Hp, 0, 200);
    }
    public void DecreaseWarrior6Hp(float value)
    {
        Warrior6Hp -= value;
        if (Warrior6Hp <= 0)
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
        Warrior6Hp = Mathf.Clamp(Warrior6Hp, 0, 200);
    }
    IEnumerator ShowWarrior6Hp()
    {
        yield return new WaitForSeconds(0.1f);
        float Health = Warrior6Hp;
        while (true)
        {
            if (Health < Warrior6Hp)
            {
                Health += 1f;
            }
            else
            {
                Health -= 1f;
            }
            Warrior6HpImage.fillAmount = (int)Health / 200f;
          
            yield return new WaitForSeconds(0.000001f);
        }
    }
   public IEnumerable DecreaseMatrix()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            DecreaseWarrior6Hp(5);
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
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 10;
                break;
            case 2:
                Hammer = (GameObject)Resources.Load("Prefabs/PlayerHammerItem");
                GameObject obj0 = Instantiate(Hammer, ItemPointObj.transform.position, this.transform.GetChild(0).transform.rotation);
                obj0.transform.parent = this.transform;
                //obj0.transform.localPosition = new Vector3(0, 0, 0);
                //obj0.transform.localRotation = Quaternion.identity;
                rig0 = obj0.GetComponent<Rigidbody2D>();
                rig0.AddForce(ItemD * 750f);//ʩ����
                rig0.drag = 1.5f;
                rig0.angularDrag = 1.5f;
                Destroy(obj0, 1f);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 10;
                break;
            case 3:
                Grenade = (GameObject)Resources.Load("Prefabs/PlayerGrenade");
                GameObject obj = Instantiate(Grenade, ItemPointObj.transform.position, this.transform.GetChild(0).transform.rotation);
                obj.transform.parent = Player.transform;
                //obj.transform.localPosition = new Vector3(0, 0, 0);
                //obj.transform.localRotation = Quaternion.identity;
                rig3 = obj.GetComponent<Rigidbody2D>();
                rig3.AddForce(d * 600f);//ʩ����
                rig3.drag = 1.5f;
                rig3.angularDrag = 1.5f;
                Destroy(obj, 0.75f);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 10;
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
            //m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 10;
            //    break;
            case 5:
                foreach (var item in Knife)
                {
                    item.gameObject.SetActive(true);
                }
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 10;
                break;
            case 6:
                //Light.SetActive(true);
                //Invoke("FalseLignt", 1f);
                light = Instantiate(Light, ItemPointObj.transform.position, this.transform.GetChild(0).transform.rotation);
                light.transform.parent = this.transform.GetChild(0).transform;
                Destroy(light, 1f);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 10;
                break;
            case 7:
                MagneticObj.SetActive(true);
                Invoke("FalseMagnetic", 10f);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 50;
                break;
            case 8:
                MatrixObj.SetActive(true);
                Invoke("FalseMatrix", 5f);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 20;
                break;
            case 9:
                Iparse=true;
                //transform.GetChild(0).GetChild(1).GetComponent<PolygonCollider2D>().enabled = false;
                //transform.GetChild(0).GetChild(2).GetComponent<PolygonCollider2D>().enabled = false;
                foreach (var temp in Player.GetComponent<PlayerScript>().m.GetComponent<MapScript>().ObstacleList)
                {
                    temp.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
                    temp.transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = true;
                }
                Invoke("FalsePhase", 3f);
                PMoveEff.SetActive(true);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 50;
                break;
            case 10:
                // IShoot = true;
                // Gun.SetActive(true);
                // Invoke("FalseGun", 8f);
                // m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior6Script>().Name] += 10;
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
        //transform.GetChild(0).GetChild(1).GetComponent<PolygonCollider2D>().enabled = true;
        //transform.GetChild(0).GetChild(2).GetComponent<PolygonCollider2D>().enabled = true;
        Iparse=false;
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
        m.GetComponent<MapScript>().Others.Remove(this.gameObject);
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
