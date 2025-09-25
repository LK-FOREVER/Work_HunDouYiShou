using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSafeScript : MonoBehaviour
{
    public GameObject SafePanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickSafeBtn()
    {
        SafePanel.SetActive(true);
    }
}
