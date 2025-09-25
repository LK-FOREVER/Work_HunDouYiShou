using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    public GameObject MainPanel;
    // public Image Warningbackground;
    public GameObject Player;
    public Canvas canvas;
    public PlayerScript p;
    // public Image BackGround;
    void Start()
    {
     // BackGround.gameObject.SetActive(false);
       
    }
    void Update()
    {

    }
    public void Log()
    {
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        // BackGround.gameObject.SetActive(true);
        Invoke("fasleBackGround", 0.5f);
        SceneManager.LoadScene("LoadScene");
      
     
        MainPanel.SetActive(false);

        Player.GetComponent<PlayerScript>().IPoints = true;
        Player.GetComponent<PlayerScript>().ISingle = false;
    }
    //public void log()
    //{
        
    //}
    //public void falseWarning()
    //{
    //    Warningbackground.gameObject.SetActive(false);
    //}
    public void fasleBackGround()
    {
        // BackGround.gameObject.SetActive(false);
    }
}