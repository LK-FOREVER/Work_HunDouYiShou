using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RePointsScript : MonoBehaviour
{
    public GameObject Player;
    public Canvas StartCanvas;
    public GameObject m;
    public GameObject PointsPanel;
    public Button[] SkillBtn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ReGame()
    {
        Player.GetComponent<PlayerScript>().audio.clip = Player.GetComponent<PlayerScript>().acilp[0];
        Player.GetComponent<PlayerScript>().audio.Play();
        m = GameObject.Find("MapManager");
        m.GetComponent<MapScript>().Icoin = true; //可多次加钱
        foreach (var item in m.GetComponent<MapScript>().ObstacleList)
        {
            Destroy(item);
        }
        foreach (var item in m.GetComponent<MapScript>().AddBloodList)
        {
            Destroy(item);
        }
        foreach (var item in m.GetComponent<MapScript>().TrapList)
        {
            Destroy(item);
        }
        foreach (var item in m.GetComponent<MapScript>().NpcList)
        {
            Destroy(item);
        }
        foreach (var item in m.GetComponent<MapScript>().ItemList)
        {
            Destroy(item);
        }
        foreach (var item in Player.GetComponent<PlayerScript>().ItemObject)
        {
            item.SetActive(false);
        }
        Player.GetComponent<PlayerScript>().ItemBtn1.GetComponent<Item1BtnScript>().IShoot = false;  //重开关闭子弹发射
        Player.GetComponent<PlayerScript>().ItemBtn2.GetComponent<Item2BtnScript>().IShoot = false;
        m.GetComponent<MapScript>().ObstacleList.Clear();
        m.GetComponent<MapScript>().AddBloodList.Clear();
        m.GetComponent<MapScript>().TrapList.Clear();
        m.GetComponent<MapScript>().NpcList.Clear();
        m.GetComponent <MapScript>().ItemList.Clear();
        //foreach (var item in m.GetComponent<MapScript>().Others) { Destroy(item); }
        m.GetComponent<MapScript>().Others.Clear();
        foreach (var item in m.GetComponent<MapScript>().WarriorArrow) { Destroy(item); }
        m.GetComponent<MapScript>().WarriorArrow.Clear();
      
            m.GetComponent<MapScript>().Others.Add(Player);
            m.GetComponent<MapScript>().ActiveMap();
            m.GetComponent<MapScript>().CreateMap();
            m.GetComponent<MapScript>().CreateObstacle();
            m.GetComponent<MapScript>().CreateAddBlood();

        m.GetComponent<MapScript>().CreateItem();
        Player.GetComponent<PlayerScript>().IItem1 = true;
        Player.GetComponent<PlayerScript>().IItem2 = true;
        Player.GetComponent<PlayerScript>().ItemBtn1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Player.GetComponent<PlayerScript>().ItemBtn2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        m.GetComponent<MapScript>().CreateTrap();

        //m.GetComponent<MapScript>().PointIndex.Clear();      //清空排行榜属性
        //m.GetComponent<MapScript>().PointIndex.Add(0);
        m.GetComponent<MapScript>().dic.Clear();
        m.GetComponent<MapScript>().dic.Add("玩家", 0);
        //m.GetComponent<MapScript>().Warriorpoint.Clear();
        // m.GetComponent<MapScript>().Warriorpoint.Add(0);
        // m.GetComponent<MapScript>().Warriorname.Clear();
        // m.GetComponent<MapScript>().Warriorname.Add("玩家");
        // m.GetComponent<MapScript>().Index = 0;
        m.GetComponent<MapScript>().CreateNpc();




        m.GetComponent<MapScript>().lateTime = Time.time;

          
            Player.GetComponent<PlayerScript>().PlayerHp = Player.GetComponent<PlayerScript>().PlayerHP;
            Player.transform.position = new Vector3(12, -20, 0);

          

            Player.GetComponent<PlayerScript>().IPoints = true;
            Player.GetComponent<PlayerScript>().ISingle = false;
          
           for (int i = 0; i < m.GetComponent<MapScript>().Warriorpoint.Count; i++)        //积分重制
            {
                m.GetComponent<MapScript>().Warriorpoint[i] = 0;
            }
           
        foreach(var temp in SkillBtn)
        {
            if (temp.name == "Skill1btn")
            {
                temp.GetComponent<Skill1Script>().IClick= true;
                temp.GetComponent<Skill1Script>().GetComponent<Image>().sprite = temp.GetComponent<Skill1Script>().S[0];
            }
            if (temp.name == "Skill2btn")
            {
                temp.GetComponent<Skill2Script>().IClick = true;
                temp.GetComponent<Skill2Script>().GetComponent<Image>().sprite = temp.GetComponent<Skill2Script>().S[0];
            }
            if (temp.name == "Skill3btn")
            {
                temp.GetComponent<Skill3Script>().IClick = true;
                temp.GetComponent<Skill3Script>().GetComponent<Image>().sprite = temp.GetComponent<Skill3Script>().S[0];
            }
            if (temp.name == "Skill4btn")
            {
                temp.GetComponent<Skill4Script>().IClick = true;
                temp.GetComponent<Skill4Script>().GetComponent<Image>().sprite = temp.GetComponent<Skill4Script>().S[0];
            }
            
            if (temp.name == "Skill6btn")
            {
                temp.GetComponent<Skill6Script>().IClick = true;
                temp.GetComponent<Skill6Script>().GetComponent<Image>().sprite = temp.GetComponent<Skill6Script>().S[0];
            }
        }
          



    }
}
