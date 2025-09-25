using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class W4btnScript : MonoBehaviour
{
    public StartSceneScript s;
    public Canvas c;
    public Text LockBtnTxt;
    public bool ILock;
    public bool IPress;

    public Button LockBtn;             //������ʹ�ð�ť
    public Text LockTxt;               //ʹ�����ı�
    public Image Lock;                 //δ������Ӱ
    public Image LockImg;//��ͼƬ
    public GameObject[] ChooseArrow;//ѡ���ͷ
    public int PlayerPrefsLock4 = 0;
    public PlayerScript p;
  
    void Start()
    {
       
        PlayerPrefsLock4 = PlayerPrefs.GetInt("PlayerPrefsLock4",0);
    }

 
    void Update()
    {
        //if (PlayerPrefsLock4 == 0)
        //{
        //    ILock = false;
        //    Lock.gameObject.SetActive(true);
        //}
        if (PlayerPrefsLock4 == 1)
        {
            ILock = true;
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }


        if (ILock && IPress)
        {
            // s.UseImg[3].gameObject.SetActive(true);
            // foreach (var item in s.UseImg)                         //�ر�����Сʹ����
            // {
            //     if (item != s.UseImg[3])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }
            s.SkillBtn[3].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)
            {
                if (item != s.SkillBtn[3])
                {
                    item.gameObject.SetActive(false);
                }
            }
            c.GetComponent<CanvasScript>().SkillIndex = 3;
        }
    }
    
    public void UpdateSkillImg()
    {
        // s.UseImg[3].gameObject.SetActive(true);
        // foreach (var item in s.UseImg)                         //�ر�����Сʹ����
        // {
        //     if (item != s.UseImg[3])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.SkillBtn[3].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)
        {
            if (item != s.SkillBtn[3])
            {
                item.gameObject.SetActive(false);
            }
        }
        c.GetComponent<CanvasScript>().SkillIndex = 3;
    }
    public void W4()
    {
        UpdateSkillImg();
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(true);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 4;
        s.ChooseIndex = 4;
        // s.ChooseWarrior = 4;
        // s.ChooseBackground[3].gameObject.SetActive(true);
        // foreach (var item in s.ChooseBackground)
        // {
        //     if (item != s.ChooseBackground[3])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[3].gameObject.SetActive(true);
        foreach (var item in s.Background)
        {
            if (item != s.Background[3])
            {
                item.gameObject.SetActive(false);
            }
        }
        s.monsterName.text = "��β";
        s.HpTxt.text = ":250";
        s.SpTxt.text = ":150";
        s.AkTxt.text = ":25";
        s.TellTxt.text = "���ܣ�����Ӣ�ۣ�����2�룬��ȴ30�롣";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[3];

        //�����Ƿ񱻰�ѹ����ʾ��ť���ı�
        //����жϰ�ť��ʾ�ı�
        if (ILock && IPress)
        {
            LockBtnTxt.text = "��ս��";
            LockBtn.interactable = false;
        }
        else if (ILock && !IPress)
        {
            LockBtnTxt.text = "��ս";
            LockBtn.interactable = true;
        }
        else if (!ILock)
        {
            LockBtnTxt.text = "δ����";
            LockBtn.interactable = false;
        }
    }
}
