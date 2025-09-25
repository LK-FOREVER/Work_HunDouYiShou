using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScript : MonoBehaviour
{
    public GameObject StopPanel;
    public PlayerScript p;
    void Start()
    {
      
        
    }

    
    void Update()
    {
        
    }
    public void ClickContinueBtn()
    {
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        StopPanel.SetActive(false);
        Time.timeScale= 1.0f;
    }
}
