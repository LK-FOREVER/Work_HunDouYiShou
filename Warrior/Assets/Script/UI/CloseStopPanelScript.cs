using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseStopPanelScript : MonoBehaviour
{
    public GameObject StopPanel;
    public void OnClickCloseStopPanel()
    {
        StopPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
