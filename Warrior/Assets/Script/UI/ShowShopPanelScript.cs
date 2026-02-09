using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShopPanelScript : MonoBehaviour
{
    public PlayerScript p;
    public GameObject shopPanel;
    public void ShowShop()
    {
        shopPanel.SetActive(true);
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

    }
}
