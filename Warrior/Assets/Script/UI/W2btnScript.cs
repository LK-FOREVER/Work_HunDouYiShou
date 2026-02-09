using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W2btnScript : MonoBehaviour
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

    public void W2()
    {
        ILock = PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock2", 0) == 1;
        if (ILock)
        {
            Lock.gameObject.SetActive(false);
            LockImg.gameObject.SetActive(false);
        }

        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        ChooseArrow[0].SetActive(false);
        ChooseArrow[1].SetActive(true);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 2;
        s.ChooseIndex = 2;

        s.monsterName.text = "白泽";
        s.HpTxt.text = "300";
        s.SpTxt.text = "120";
        s.AkTxt.text = "2";
        s.TellTxt.text = "技能：向正前方发射一道扇形水波，造成30点伤害，冷却20秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[1];

        if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 2)
        {
            LockBtnTxt.text = "出战中";
            LockBtn.interactable = false;
        }
        else if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) != 2)
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
