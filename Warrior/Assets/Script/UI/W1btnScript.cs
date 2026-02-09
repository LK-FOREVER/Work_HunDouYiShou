using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W1btnScript : MonoBehaviour
{
    public StartSceneScript s;
    public Canvas c;
    public bool ILock = true;
    public int PlayerPrefsLock1 = 1;
    public bool IPress;                  //是否按压选择 默认一号位选中
    public Text LockBtnTxt;                   //按钮内部文本

    public Button LockBtn;             //解锁或使用按钮
    public Text LockTxt;               //使用中文本
    public Image Lock;                 //未解锁阴影
    public Image LockImg;//锁图片
    public GameObject[] ChooseArrow;//选择箭头
    public PlayerScript p;
    void Update()
    {
        if (!s)
        {
            s = GameObject.Find("Manager").GetComponent<StartSceneScript>();
        }
    }

    public void W1()
    {
        ILock = PlayerPrefs.GetInt(SdkScript.nickname + "PlayerPrefsLock1", 1) == 1;
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        ChooseArrow[0].SetActive(true);
        ChooseArrow[1].SetActive(false);
        ChooseArrow[2].SetActive(false);
        ChooseArrow[3].SetActive(false);
        ChooseArrow[4].SetActive(false);
        ChooseArrow[5].SetActive(false);
        StartSceneScript.W = 1;
        s.ChooseIndex = 1;
        s.monsterName.text = "麒麟";
        s.HpTxt.text = "200";
        s.SpTxt.text = "100";
        s.AkTxt.text = "2";
        s.TellTxt.text = "技能：向正前方发射一道闪电，造成50点伤害，冷却20秒。";
        s.ShowWarriorImg.GetComponent<Image>().sprite = s.BigWarriorImg[0];

        //根据是否被按压过显示按钮或文本
        //点击判断按钮显示文本
        if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 1)
        {
            LockBtnTxt.text = "出战中";
            LockBtn.interactable = false;
        }
        else if (ILock && PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) != 1)
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
