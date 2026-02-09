using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBtnScript : MonoBehaviour
{
    public GameObject StopPanel;
    public PlayerScript p;
    public void ClickStopBtn()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        Time.timeScale = 0f;
        StopPanel.SetActive(true);
    }
}
