using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScript : MonoBehaviour
{
    public GameObject MusicPanel;
    public PlayerScript p;
    public GameObject StopPanel;
    public GameObject HonorView;
    public GameObject BuyPanel;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetMusicBtn()
    {
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        MusicPanel.SetActive(true);
        StopPanel.SetActive(false);

        HonorView.SetActive(false);
        BuyPanel.SetActive(false);
    }
}
