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
        p.audio.clip = p.acilp[0];
        p.audio.Play();
    }
}
