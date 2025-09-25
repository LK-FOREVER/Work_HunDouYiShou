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
        p.audio.clip = p.acilp[0];
        p.audio.Play();
    }
}
