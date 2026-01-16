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
    public Image Lock;                 //未解锁��Ӱ
    public Image LockImg;//��ͼƬ
    public GameObject[] ChooseArrow;//ѡ���ͷ
    public PlayerScript p;

    void Update()
    {
        if (!s)
        {
            s = GameObject.Find("Manager").GetComponent<StartSceneScript>();
        }
    }

    public void W4()
    {
        ILock = PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock4", 0) == 1;
        if (ILock)
        {
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }

        if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 4)
        {
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
        s.monsterName.text = "九尾";
        s.HpTxt.text = ":250";
        s.SpTxt.text = ":150";
        s.AkTxt.text = ":4";
        s.TellTxt.text = "技能：周围生成火圈，普通攻击增加2点攻击力，持续10秒，冷却30秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[3];

        if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 4)
        {
            LockBtnTxt.text = "出战中";
            LockBtn.interactable = false;
        }
        else if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) != 4)
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
