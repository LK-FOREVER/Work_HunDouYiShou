using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CertainBuyScript : MonoBehaviour
{
    public Button CertainBtn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickCertainBuy()
    {
        CertainBtn.GetComponent<CertainScript>().ICertainBuy = true;
        Invoke("falseCertain", 1f);
    }
    public void falseCertain()
    {
        CertainBtn.GetComponent<CertainScript>().ICertainBuy = false;
    }
}
