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

    void Update()
    {
        if (!s)
        {
            s = GameObject.Find("Manager").GetComponent<StartSceneScript>();
        }
    }

    public void W5()
    {
        ILock = PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock5", 0) == 1;
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
        ChooseArrow[4].SetActive(true);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 5;
        s.ChooseIndex = 5;
        s.monsterName.text = "鲲鹏";
        s.HpTxt.text = "250";
        s.SpTxt.text = "180";
        s.AkTxt.text = "4";
        s.TellTxt.text = "技能：增加30%移动速度，持续10秒，冷却20秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[4];

        //�����Ƿ񱻰�ѹ����ʾ��ť���ı�
        //����жϰ�ť��ʾ�ı�
        if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 5)
        {
            LockBtnTxt.text = "出战中";
            LockBtn.interactable = false;
        }
        else if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) != 5)
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
