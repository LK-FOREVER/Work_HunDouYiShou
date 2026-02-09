using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class W6btnScript : MonoBehaviour
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
    public int PlayerPrefsLock6 = 0;
    public PlayerScript p;

    void Update()
    {
        if (!s)
        {
            s = GameObject.Find("Manager").GetComponent<StartSceneScript>();
        }
    }

    public void W6()
    {
        ILock = PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock6", 0) == 1;
        if (ILock)
        {
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(true);
        StartSceneScript.W = 6;
        s.ChooseIndex = 6;
        s.monsterName.text = "玄武";
        s.HpTxt.text = "350";
        s.SpTxt.text = "80";
        s.AkTxt.text = "1";
        s.TellTxt.text = "技能：获得护盾，免疫所有伤害，持续5秒，冷却20秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[5];

        if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 6)
        {
            LockBtnTxt.text = "出战中";
            LockBtn.interactable = false;
        }
        else if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) != 6)
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
