using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Warrior4Script : MonoBehaviour
{
    public GameObject Player;
   public float Warrior4Hp = 250;
   public float Speed = 3.5f;
    public float Ak = 25f;

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

   public GameObject m;
    float desNpc;

    int r;
    public Text Warrior4HpText;
    public Image Warrior4HpImage;
    bool Ifront;
    bool Iback;
    float lateTime;

    public bool IFreeze;
    public bool IDead;
    public string Name;
    public int point;
    //public int index;
    public int R1;        //ѡ���Ѷ�
    public int R2;

    public GameObject ColiEff;
    public GameObject DeadEff;
    public GameObject ShowFreezeEff;
    public GameObject IdleFreezeEff;
    public GameObject hammerEff;

  
    GameObject obj;
    GameObject Obj;
    GameObject obj1;
    GameObject Obj1;
    GameObject obj22;
    GameObject Obj2;
    GameObject obj3;
    GameObject Obj3;
    GameObject obj4;
    GameObject Obj4;
    GameObject obj5;
    GameObject Obj5;
    GameObject obj6;
    GameObject Obj6;
    GameObject obj2; //���ڿ��Ʊ�ը
    public Canvas PlayerCanvas;
    public GameObject Rotation;
    public AudioSource audio;
    public AudioClip[] acilp;
    public GameObject Arrow4;
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
    GameObject obj44;
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
        Arrow4 = (GameObject)Resources.Load("Prefabs/Warrior4Arrow");
        ObjA = Instantiate(Arrow4);
        ObjA.transform.position = Player.transform.position;
        m.GetComponent<MapScript>().WarriorArrow.Add(ObjA);
        
        StartCoroutine("ShowWarrior4Hp");
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
        //         m.GetComponent<MapScript>().Warriorname[i] = Name;

        //        print(index);
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
        if (HookBack && obj44 != null)
        {
            //print("HookBack");
            rig4.drag = 10f;
            rig4.angularDrag = 10f;
            HookD = (this.transform.position - obj44.transform.position).normalized;
            obj44.transform.position += HookD * 8f * Time.deltaTime;
        }
        if (Player != null && ObjA != null && ObjA.activeInHierarchy)
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
                ObjA.transform.rotation = Quaternion.Euler(0, 0, -angle );
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
        /* index = m.GetComponent<MapScript>().SortIndex[index];  */              //ʵʱ���½�������±�
        Warrior4HpText.text = Warrior4Hp.ToString();
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
    public void Warrior4Skill()
    {
        m.GetComponent<MapScript>().IFreezeSkill = true; //ʹ�ö���ر��ж��������ƶ����
        Invoke("FalseSkill", 2f);  //�ָ��ж�
        if (!INpcColli)
            {
                for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
                {
                    desNpc = Vector3.Distance(this.transform.position, m.GetComponent<MapScript>().Others[i].transform.position);
                    if (desNpc < 2f && (m.GetComponent<MapScript>().Others[i] != this.gameObject))
                    {
                        if (m.GetComponent<MapScript>().Others[i].name == "Player")
                        {
                        audio.clip = acilp[0];
                        audio.Play();
                            Player.GetComponent<PlayerScript>().IFreeze = true;
                            Invoke("falsePlayerFreeze", 2f);
                        obj = Instantiate(ShowFreezeEff);               //�ͷŶ���
                        obj.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Obj = Instantiate(IdleFreezeEff);
                        Obj.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreezeEff", 0.8f);
                        Invoke("FalseIdleFreezeEff", 2f);
                    }
                        else if (m.GetComponent<MapScript>().Others[i].name == "Warrior1(Clone)")
                        {
                        audio.clip = acilp[0];
                        audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior1Script>().IFreeze = true;
                            Invoke("flaseWarrior1Freeze", 2f);
                        obj1 = Instantiate(ShowFreezeEff);               //�ͷŶ���
                        obj1.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj1.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                 
                        Obj1 = Instantiate(IdleFreezeEff);
                        Obj1.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj1.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze1Eff", 0.8f);
                        Invoke("FalseIdleFreeze1Eff", 2f);
                    }
                        else if (m.GetComponent<MapScript>().Others[i].name == "Warrior2(Clone)")
                        {
                        audio.clip = acilp[0];
                        audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior2Script>().IFreeze = true;
                            Invoke("flaseWarrior2Freeze", 2f);
                        obj22 = Instantiate(ShowFreezeEff);               //�ͷŶ���
                        obj22.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj22.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                       
                        Obj2 = Instantiate(IdleFreezeEff);
                        Obj2.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj2.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze2Eff", 0.8f);
                        Invoke("FalseIdleFreeze2Eff", 2f);
                    }
                        else if (m.GetComponent<MapScript>().Others[i].name == "Warrior3(Clone)")
                        {
                        audio.clip = acilp[0];
                        audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior3Script>().IFreeze = true;
                            Invoke("flaseWarrior3Freeze", 2f);
                        obj3 = Instantiate(ShowFreezeEff);               //�ͷŶ���
                        obj3.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                         obj3.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                      
                        Obj3 = Instantiate(IdleFreezeEff);
                        Obj3.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj3.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze3Eff", 0.8f);
                        Invoke("FalseIdleFreeze3Eff", 2f);
                    }
                        else if (m.GetComponent<MapScript>().Others[i].name == "Warrior4(Clone)")
                        {
                        audio.clip = acilp[0];
                        audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior4Script>().IFreeze = true;
                            Invoke("flaseWarrior4Freeze", 2f);
                        obj4 = Instantiate(ShowFreezeEff);               //�ͷŶ���
                        obj4.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj4.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        
                        Obj4 = Instantiate(IdleFreezeEff);
                        Obj4.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj4.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze4Eff", 0.8f);
                        Invoke("FalseIdleFreeze4Eff", 2f);
                    }
                        else if (m.GetComponent<MapScript>().Others[i].name == "Warrior5(Clone)")
                        {
                        audio.clip = acilp[0];
                        audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior5Script>().IFreeze = true;
                            Invoke("flaseWarrior5Freeze", 2f);
                        obj5 = Instantiate(ShowFreezeEff);               //�ͷŶ���
                        obj5.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj5.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                       
                        Obj5 = Instantiate(IdleFreezeEff);
                        Obj5.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj5.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze5Eff", 0.8f);
                        Invoke("FalseIdleFreeze5Eff", 2f);
                    }
                        else if (m.GetComponent<MapScript>().Others[i].name == "Warrior6(Clone)")
                        {
                        audio.clip = acilp[0];
                        audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior6Script>().IFreeze = true;
                            Invoke("flaseWarrior6Freeze", 2f);
                        obj6 = Instantiate(ShowFreezeEff);               //�ͷŶ���
                        obj6.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj6.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Obj6 = Instantiate(IdleFreezeEff);
                        Obj6.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj6.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze6Eff", 0.8f);
                        Invoke("FalseIdleFreeze6Eff", 2f);
                    }
                    }
                    else
                    {
                        IMoveToPos = true;
                    }
                }
            }
        

    }
    public void falsePlayerFreeze()
    {
        Player.GetComponent<PlayerScript>().IFreeze = false;
    }
    public void flaseWarrior1Freeze()
    {
        for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
        {

            if (m.GetComponent<MapScript>().Others[i].name == "Warrior1(Clone)" && (m.GetComponent<MapScript>().Others[i] != this.gameObject))
            {
                m.GetComponent<MapScript>().Others[i].GetComponent<Warrior1Script>().IFreeze = false;
            }
        }
    }
    public void flaseWarrior2Freeze()
    {
        for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
        {

            if (m.GetComponent<MapScript>().Others[i].name == "Warrior2(Clone)" && (m.GetComponent<MapScript>().Others[i] != this.gameObject))
            {
                m.GetComponent<MapScript>().Others[i].GetComponent<Warrior2Script>().IFreeze = false;
            }
        }
    }
    public void flaseWarrior3Freeze()
    {
        for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
        {

            if (m.GetComponent<MapScript>().Others[i].name == "Warrior3(Clone)" && (m.GetComponent<MapScript>().Others[i] != this.gameObject))
            {
                m.GetComponent<MapScript>().Others[i].GetComponent<Warrior3Script>().IFreeze = false;
            }
        }
    }
    public void flaseWarrior4Freeze()
    {
        for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
        {

            if (m.GetComponent<MapScript>().Others[i].name == "Warrior4(Clone)" && (m.GetComponent<MapScript>().Others[i] != this.gameObject))
            {
                m.GetComponent<MapScript>().Others[i].GetComponent<Warrior4Script>().IFreeze = false;
            }
        }
    }
    public void flaseWarrior5Freeze()
    {
        for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
        {

            if (m.GetComponent<MapScript>().Others[i].name == "Warrior5(Clone)" && (m.GetComponent<MapScript>().Others[i] != this.gameObject))
            {
                m.GetComponent<MapScript>().Others[i].GetComponent<Warrior5Script>().IFreeze = false;
            }
        }
    }
    public void flaseWarrior6Freeze()
    {
        for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
        {

            if (m.GetComponent<MapScript>().Others[i].name == "Warrior6(Clone)" && (m.GetComponent<MapScript>().Others[i] != this.gameObject))
            {
                m.GetComponent<MapScript>().Others[i].GetComponent<Warrior6Script>().IFreeze = false;
            }
        }
    }
    IEnumerator Skill()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        while (true)
        {
            Warrior4Skill();
            yield return new WaitForSeconds(FreqSkill);
        }
    }
    public void AddWarrior4Hp(float value)
    {
        Warrior4Hp += value;
        
        Warrior4Hp = Mathf.Clamp(Warrior4Hp, 0, 250);
    }
    public void DecreaseWarrior4Hp(float value)
    {
        Warrior4Hp -= value;
        if (Warrior4Hp <= 0)
        {
            Destroy(ObjA);
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
        Warrior4Hp = Mathf.Clamp(Warrior4Hp, 0, 250);
    }
    IEnumerator ShowWarrior4Hp()
    {
        yield return new WaitForSeconds(0.1f);
        float Health = Warrior4Hp;
        while (true)
        {
            if (Health < Warrior4Hp)
            {
                Health += 1f;
            }
            else
            {
                Health -= 1f;
            }
            Warrior4HpImage.fillAmount = (int)Health / 250f;
         
            yield return new WaitForSeconds(0.000001f);
        }
    }
   public  IEnumerable DecreaseMatrix()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            DecreaseWarrior4Hp(5);
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
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 10;
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
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 10;
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
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 10;
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
            //m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 10;
            //    break;
            case 5:
                foreach (var item in Knife)
                {
                    item.gameObject.SetActive(true);
                }
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 10;
                break;
            case 6:
                //Light.SetActive(true);
                //Invoke("FalseLignt", 1f);
                light = Instantiate(Light, ItemPointObj.transform.position, this.transform.GetChild(0).transform.rotation);
                light.transform.parent = this.transform.GetChild(0).transform;
                Destroy(light, 1f);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 10;
                break;
            case 7:
                MagneticObj.SetActive(true);
                Invoke("FalseMagnetic", 10f);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 50;
                break;
            case 8:
                MatrixObj.SetActive(true);
                Invoke("FalseMatrix", 5f);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 20;
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
                PMoveEff.SetActive(true);
                m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 50;
                break;
            case 10:
                // IShoot = true;
                // Gun.SetActive(true);
                // Invoke("FalseGun", 8f);
                // m.GetComponent<MapScript>().dic[GetComponentInParent<Warrior4Script>().Name] += 10;
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
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "wall")
        {
            RemoveToTargetPos();
        }
    }
    public void FalsePhase()
    {
        Iparse = false;
        PMoveEff.SetActive(false);
        foreach (var temp in Player.GetComponent<PlayerScript>().m.GetComponent<MapScript>().ObstacleList)
        {

            temp.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
            temp.transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = false;

        }
        //    transform.GetChild(0).GetChild(1).GetComponent<PolygonCollider2D>().enabled = true;
        //    transform.GetChild(0).GetChild(2).GetComponent<PolygonCollider2D>().enabled = true;
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
    public void FalseShowFreezeEff()
    {
        obj.SetActive(false);
    }
    public void FalseShowFreeze1Eff()
    {
        obj1.SetActive(false);
    }
    public void FalseShowFreeze2Eff()
    {
        obj22.SetActive(false);
    }
    public void FalseShowFreeze3Eff()
    {
        obj3.SetActive(false);
    }
    public void FalseShowFreeze4Eff()
    {
        obj4.SetActive(false);
    }
    public void FalseShowFreeze5Eff()
    {
        obj5.SetActive(false);
    }
    public void FalseShowFreeze6Eff()
    {
        obj6.SetActive(false);
    }
    public void FalseIdleFreezeEff()
    {
        Obj.SetActive(false);
    }
    public void FalseIdleFreeze1Eff()
    {
        Obj1.SetActive(false);
    }
    public void FalseIdleFreeze2Eff()
    {
        Obj2.SetActive(false);
    }
    public void FalseIdleFreeze3Eff()
    {
        Obj3.SetActive(false);
    }
    public void FalseIdleFreeze4Eff()
    {
        Obj4.SetActive(false);
    }
    public void FalseIdleFreeze5Eff()
    {
        Obj5.SetActive(false);
    }
    public void FalseIdleFreeze6Eff()
    {
        Obj6.SetActive(false);
    }

    public void FalseBoomEff()
    {
        obj2.SetActive(false);
    }
    public void FalseSkill()
    {
        m.GetComponent<MapScript>().IFreezeSkill= false;
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
    //����Ϊ�رյ���
    public void FalseItem1()
    {
        DefendObj.SetActive(false);
    }
}
