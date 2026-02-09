using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalScript : MonoBehaviour
{
    public Text DifTxt;
    public Button DifBtn;
    public PlayerScript p;
    public void ClickNormalBtn()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        DifTxt.text = "难度：正常";
        DifBtn.GetComponent<DifBtnScript>().FalseDifBtn();
        DifBtn.GetComponent<DifBtnScript>().IClick = !DifBtn.GetComponent<DifBtnScript>().IClick;
        DifBtn.GetComponent<Image>().sprite = DifBtn.GetComponent<DifBtnScript>().sprite[0];
        
        PlayerData.Instance.IEasy = false;
        PlayerData.Instance.INormal = true;
        PlayerData.Instance.IHard = false;
        PlayerData.Instance.IVeryHard = false;
    }
}
