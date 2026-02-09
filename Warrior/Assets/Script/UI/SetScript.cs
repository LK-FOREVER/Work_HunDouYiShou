using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScript : MonoBehaviour
{
    public GameObject MusicPanel;
    public PlayerScript p;
    
    public void SetMusicBtn()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        MusicPanel.SetActive(true);
    }
}
