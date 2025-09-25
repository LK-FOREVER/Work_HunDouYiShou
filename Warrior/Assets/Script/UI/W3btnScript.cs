using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class W3btnScript : MonoBehaviour
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
    public int PlayerPrefsLock3 = 0;
    public PlayerScript p;
    void Start()
    {
       
        PlayerPrefsLock3 = PlayerPrefs.GetInt("PlayerPrefsLock3",0);
    }

   
    void Update()
    {
        //if (PlayerPrefsLock3 == 0)
        //{
        //    ILock = false;
        //    Lock.gameObject.SetActive(true);
        //}
        if (PlayerPrefsLock3 == 1)
        {
            ILock = true;
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }
        if (ILock && IPress)
        {
            // s.UseImg[2].gameObject.SetActive(true);
            // foreach (var item in s.UseImg)                         //�ر�����Сʹ����
            // {
            //     if (item != s.UseImg[2])
            //     {
            //         item.gameObject.SetActive(false);
            //     }
            // }
            s.SkillBtn[2].gameObject.SetActive(true);
            foreach (var item in s.SkillBtn)
            {
                if (item != s.SkillBtn[2])
                {
                    item.gameObject.SetActive(false);
                }
            }
            c.GetComponent<CanvasScript>().SkillIndex = 2;
        }
        
    }
    
    public void UpdateSkillImg()
    {
        // s.UseImg[2].gameObject.SetActive(true);
        // foreach (var item in s.UseImg)                         //�ر�����Сʹ����
        // {
        //     if (item != s.UseImg[2])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.SkillBtn[2].gameObject.SetActive(true);
        foreach (var item in s.SkillBtn)
        {
            if (item != s.SkillBtn[2])
            {
                item.gameObject.SetActive(false);
            }
        }
        c.GetComponent<CanvasScript>().SkillIndex = 2;
    }
    public void W3()
    {
        UpdateSkillImg();
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(true);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 3;
        s.ChooseIndex = 3;
        // s.ChooseWarrior = 3;
        // s.ChooseBackground[2].gameObject.SetActive(true);
        // foreach (var item in s.ChooseBackground)
        // {
        //     if (item != s.ChooseBackground[2])
        //     {
        //         item.gameObject.SetActive(false);
        //     }
        // }
        s.Background[2].gameObject.SetActive(true);
        foreach (var item in s.Background)
        {
            if (item != s.Background[2])
            {
                item.gameObject.SetActive(false);
            }
        }
       
        s.monsterName.text = "���";
        s.HpTxt.text = ":150";
        s.SpTxt.text = ":180";
        s.AkTxt.text = ":30";
        s.TellTxt.text = "���ܣ��������״̬������10�룬�����ڼ���ײ���˶������10���˺�����ǰ�������״̬����ȴ20�롣";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[2];

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
