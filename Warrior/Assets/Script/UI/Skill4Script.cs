using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Skill4Script : MonoBehaviour
{
    public bool IClick = true;                 //是否可以点击
    public Sprite[] S;
    public GameObject m;
    float desNpc;
    public GameObject Player;
    GameObject obj;//ShowFreeze
    GameObject Obj;//IdleFreeze
    GameObject obj1;//ShowFreeze
    GameObject Obj1;//IdleFreeze
    GameObject obj2;//ShowFreeze
    GameObject Obj2;//IdleFreeze
    GameObject obj3;//ShowFreeze
    GameObject Obj3;//IdleFreeze
    GameObject obj4;//ShowFreeze
    GameObject Obj4;//IdleFreeze
    GameObject obj5;//ShowFreeze
    GameObject Obj5;//IdleFreeze
    // Update is called once per frame
    void Start()
    {
       
    }
    void Update()
    {
        

    }
    public void UseSkill()
    {
        if (IClick)
        {
            IClick = false;
            m = GameObject.Find("MapManager");
            m.GetComponent<MapScript>().IFreezeSkill= true; //使用冻结关闭判定结束的移动与否 冻结也被用于游戏重开
            Invoke("FalseSkill",2f);  //恢复判定
            this.GetComponent<Image>().sprite = S[1];
            Invoke("falseSprite", 30f);

           
            for (int i = 0; i < m.GetComponent<MapScript>().Others.Count; i++)
            {
                desNpc = Vector3.Distance(Player.transform.position, m.GetComponent<MapScript>().Others[i].transform.position);
                if (desNpc < 3f && (m.GetComponent<MapScript>().Others[i] != Player))
                {
                    if (m.GetComponent<MapScript>().Others[i].name == "Warrior1(Clone)")
                    {
                        Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[5];
                        Player.GetComponent<PlayerScript>().audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior1Script>().IFreeze = true;
                        Invoke("flaseWarrior1Freeze", 2f);
                        obj=Instantiate(Player.GetComponent<PlayerScript>().ShowFreezeEff);               //释放冻结
                        obj.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Obj = Instantiate(Player.GetComponent<PlayerScript>().IdleFreezeEff);
                        Obj.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreezeEff", 0.8f);
                        Invoke("FalseIdleFreezeEff", 2f);

                    }
                    else if (m.GetComponent<MapScript>().Others[i].name == "Warrior2(Clone)")
                    {
                        Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[5];
                        Player.GetComponent<PlayerScript>().audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior2Script>().IFreeze = true;
                        Invoke("flaseWarrior2Freeze", 2f);
                         obj1= Instantiate(Player.GetComponent<PlayerScript>().ShowFreezeEff);               //释放冻结
                        obj1.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj1.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Obj1 = Instantiate(Player.GetComponent<PlayerScript>().IdleFreezeEff);
                        Obj1.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj1.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze1Eff", 0.8f);
                        Invoke("FalseIdleFreeze1Eff", 2f);
                    }
                    else if (m.GetComponent<MapScript>().Others[i].name == "Warrior3(Clone)")
                    {
                        Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[5];
                        Player.GetComponent<PlayerScript>().audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior3Script>().IFreeze = true;
                        Invoke("flaseWarrior3Freeze", 2f);
                         obj2 = Instantiate(Player.GetComponent<PlayerScript>().ShowFreezeEff);               //释放冻结
                        obj2.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj2.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Obj2 = Instantiate(Player.GetComponent<PlayerScript>().IdleFreezeEff);
                        Obj2.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj2.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze2Eff", 0.8f);
                        Invoke("FalseIdleFreeze2Eff", 2f);
                    }
                    else if (m.GetComponent<MapScript>().Others[i].name == "Warrior4(Clone)")
                    {
                        Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[5];
                        Player.GetComponent<PlayerScript>().audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior4Script>().IFreeze = true;
                        Invoke("flaseWarrior4Freeze", 2f);
                        obj3 = Instantiate(Player.GetComponent<PlayerScript>().ShowFreezeEff);               //释放冻结
                        obj3.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj3.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Obj3 = Instantiate(Player.GetComponent<PlayerScript>().IdleFreezeEff);
                        Obj3.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj3.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze3Eff", 0.8f);
                        Invoke("FalseIdleFreeze3Eff", 2f);
                    }
                    else if (m.GetComponent<MapScript>().Others[i].name == "Warrior5(Clone)")
                    {
                        Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[5];
                        Player.GetComponent<PlayerScript>().audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior5Script>().IFreeze = true;
                        Invoke("flaseWarrior5Freeze", 2f);
                         obj4 = Instantiate(Player.GetComponent<PlayerScript>().ShowFreezeEff);               //释放冻结
                        obj4.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj4.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Obj4 = Instantiate(Player.GetComponent<PlayerScript>().IdleFreezeEff);
                        Obj4.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj4.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze4Eff", 0.8f);
                        Invoke("FalseIdleFreeze4Eff", 2f);
                    }
                    else if (m.GetComponent<MapScript>().Others[i].name == "Warrior6(Clone)")
                    {
                        Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[5];
                        Player.GetComponent<PlayerScript>().audio.Play();
                        m.GetComponent<MapScript>().Others[i].GetComponent<Warrior6Script>().IFreeze = true;
                        Invoke("flaseWarrior6Freeze", 2f);
                        obj5 = Instantiate(Player.GetComponent<PlayerScript>().ShowFreezeEff);               //释放冻结
                        obj5.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        obj5.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Obj5 = Instantiate(Player.GetComponent<PlayerScript>().IdleFreezeEff);
                        Obj5.transform.position = m.GetComponent<MapScript>().Others[i].transform.position;
                        Obj5.transform.parent = m.GetComponent<MapScript>().Others[i].transform;
                        Invoke("FalseShowFreeze5Eff", 0.8f);
                        Invoke("FalseIdleFreeze5Eff", 2f);
                    }
                }

            }
        }
       
    }
    public void falseSprite()
    {
        this.GetComponent<Image>().sprite = S[0];
        IClick = true;
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
        obj2.SetActive(false);
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
    public void FalseSkill()
    {
        m.GetComponent<MapScript>().IFreezeSkill = false;
    }
}
