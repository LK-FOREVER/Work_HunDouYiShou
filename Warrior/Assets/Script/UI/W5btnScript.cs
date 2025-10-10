using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class W5btnScript : MonoBehaviour
{
    public StartSceneScript s;
    public Canvas c;
    public Text LockBtnTxt;
    public bool ILock;
    public bool IPress;

    public Button LockBtn;             //������ʹ�ð�ť
    public Text LockTxt;               //ʹ�����ı�
    public Image Lock;                 //未解锁��Ӱ
    public Image LockImg;//��ͼƬ
    public GameObject[] ChooseArrow;//ѡ���ͷ
    public int PlayerPrefsLock5 = 0;
    public PlayerScript p;
    void Start()
    {
      
        PlayerPrefsLock5 = PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock5",0);
    }


    void Update()
    {
        //if (PlayerPrefsLock5 == 0)
        //{
        //    ILock = false;
        //    Lock.gameObject.SetActive(true);
        //}
         if (PlayerPrefsLock5 == 1)
        {
            ILock = true;
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }

        if (ILock && IPress)
        {
            // s.Player.GetComponent<PlayerScript>().IWarrior5 = true;
            // s.UseImg[4].gameObject.SetActive(true);
            // foreach (var item in s.UseImg)                         //�ر�����Сʹ����
            // {
            //     if (item != s.UseImg[4])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }
            s.SkillBtn[4].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)
            {
                if (item != s.SkillBtn[4])
                {
                    item.gameObject.SetActive(false);
                }
            }
            c.GetComponent<CanvasScript>().SkillIndex = 4;

        }
    }

    private void UpdateSkillImg()
    {
        // s.Player.GetComponent<PlayerScript>().IWarrior5 = true;
        // s.UseImg[4].gameObject.SetActive(true);
        // foreach (var item in s.UseImg)                         //�ر�����Сʹ����
        // {
        //     if (item != s.UseImg[4])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.SkillBtn[4].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)
        {
            if (item != s.SkillBtn[4])
            {
                item.gameObject.SetActive(false);
            }
        }
        c.GetComponent<CanvasScript>().SkillIndex = 4;
    }
    public void W5()
    {
        UpdateSkillImg();
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(true);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 5;
        s.ChooseIndex = 5;
        // s.ChooseWarrior = 5;
        // s.ChooseBackground[4].gameObject.SetActive(true);
        // foreach (var item in s.ChooseBackground)
        // {
        //     if (item != s.ChooseBackground[4])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[4].gameObject.SetActive(true);
        foreach (var item in s.Background)
        {
            if (item != s.Background[4])
            {
                item.gameObject.SetActive(false);
            }
        }
        s.monsterName.text = "鲲鹏";
        s.HpTxt.text = ":500";
        s.SpTxt.text = ":100";
        s.AkTxt.text = ":10";
        s.TellTxt.text = "被动技能，生命值越低，攻击力越高。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[4];

        //�����Ƿ񱻰�ѹ����ʾ��ť���ı�
        //����жϰ�ť��ʾ�ı�
        if (ILock && IPress)
        {
            LockBtnTxt.text = "出战中";
            LockBtn.interactable = false;
        }
        else if (ILock && !IPress)
        {
            LockBtnTxt.text = "出战";
            LockBtn.interactable = true;
        }
        else if (!ILock)
        {
            LockBtnTxt.text = "未解锁";
            LockBtn.interactable = false;
        }
    }
}
