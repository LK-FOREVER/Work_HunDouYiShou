using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBtnScript : MonoBehaviour
{
    public GameObject StopPanel;
    public PlayerScript p;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ClickStopBtn()
    {
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        Time.timeScale = 0f;
        StopPanel.SetActive(true);
    }
}
