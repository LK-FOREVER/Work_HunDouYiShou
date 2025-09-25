using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseMusicBtnScript : MonoBehaviour
{
    public GameObject MusicPanel;
    public PlayerScript p;
    public GameObject StopPanel;
    bool IGame;
    void Start()
    {
        
    }

    void Update()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (SceneManager.GetSceneByName("StartScene").isLoaded)
        {
            IGame=false;
        }
        if (SceneManager.GetSceneByName("GameScene").isLoaded)
        {
            IGame = true;
        }
    }
    public void ClickCloseMusicPanel()
    {
        if(IGame)
        {
            StopPanel.SetActive(true);
        }
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        MusicPanel.SetActive(false);
       
    }
}
