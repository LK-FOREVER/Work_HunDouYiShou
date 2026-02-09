using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeryHardScript : MonoBehaviour
{
    public Text DifTxt;
    public Button DifBtn;
    public PlayerScript p;
    public void ClickVeryHardBtn()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        DifTxt.text = "难度：极难";
        DifBtn.GetComponent<DifBtnScript>().FalseDifBtn();
        DifBtn.GetComponent<DifBtnScript>().IClick = !DifBtn.GetComponent<DifBtnScript>().IClick;
        DifBtn.GetComponent<Image>().sprite = DifBtn.GetComponent<DifBtnScript>().sprite[0];
        
        PlayerData.Instance.IEasy = false;
        PlayerData.Instance.INormal = false;
        PlayerData.Instance.IHard = false;
        PlayerData.Instance.IVeryHard = true;
    }
}
