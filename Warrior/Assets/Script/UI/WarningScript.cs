using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarningScript : MonoBehaviour
{
 
    void Start()
    {
        Invoke("LoadStart", 2f);
        //return;
      
    }
    public void LoadStart()
    {
        SceneManager.LoadScene("LoadStartScene");
    }
   
}