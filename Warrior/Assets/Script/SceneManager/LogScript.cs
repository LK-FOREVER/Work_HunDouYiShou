using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogScript : MonoBehaviour
{
    public GameObject MainPanel;
    public Image Warningbackground;
    void Start()
    {
        Warningbackground.gameObject.SetActive(false);

    }

 
    void Update()
    {
        
    }
    public void Log()
    {
        Invoke("log", 3f);
        Invoke("falseWarning", 3.1f);
        Warningbackground.gameObject.SetActive(true);
        MainPanel.SetActive(false);
        
    }
    public void log()
    {
        SceneManager.LoadScene("LoadScene");
       
    }
    public void falseWarning()
    {
        Warningbackground.gameObject.SetActive(false);
    }
}
