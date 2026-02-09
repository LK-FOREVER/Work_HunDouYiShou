using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelScript : MonoBehaviour
{
    public GameObject BugPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CancelBuy()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
        BugPanel.SetActive(false);
    }
}
