using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartScript : MonoBehaviour
{
    public PlayerScript p;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReStart()
    {
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
        //Player.GetComponent<PlayerScript>().IPoints = false;
        //Player.GetComponent<PlayerScript>().ISingle = false;
        //Player.GetComponent<PlayerScript>().IRegame = false;
    }
}
