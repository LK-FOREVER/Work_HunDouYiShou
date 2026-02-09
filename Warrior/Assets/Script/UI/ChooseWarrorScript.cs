using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWarrorScript : MonoBehaviour
{
    public PlayerScript p;
    public GameObject changePanel;
    public LockBtnScript _lockBtnScript;
    public void ChooseWarriors()
    {
        changePanel.SetActive(true);
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
    }
}
