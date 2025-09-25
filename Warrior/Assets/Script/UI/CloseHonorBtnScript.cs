using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHonorBtnScript : MonoBehaviour
{
    public GameObject HonorPanel;
    public PlayerScript p;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickCloseHonorPanel()
    {
        HonorPanel.SetActive(false);
        p.audio.clip = p.acilp[0];
        p.audio.Play();
    }
}
