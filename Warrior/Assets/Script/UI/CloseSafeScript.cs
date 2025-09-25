using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSafeScript : MonoBehaviour
{
    public GameObject SafePanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickCloseSafePanel()
    {
        SafePanel.SetActive(false);
    }
}
