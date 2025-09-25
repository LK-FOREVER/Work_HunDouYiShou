using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorBtnScript : MonoBehaviour
{
    public GameObject WarriorPanel;
    public GameObject CoinPanel;
    public Sprite[] sp;
    public Button CoinBtn;
    public Text WarriorTxt;
    public Text CoinTxt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickWarriorBtn()
    {
        if(WarriorPanel.activeSelf) return;
        WarriorPanel.SetActive(true);
        WarriorPanel.GetComponent<monsterPanelScript>().InitUI();
        CoinPanel.SetActive(false);
        this.GetComponent<Image>().sprite = sp[0];
        CoinBtn.GetComponent<Image>().sprite = sp[1];
        // WarriorTxt.color =  new Color(0.98f, 0.65f, 0.31f);
        // CoinTxt.color = new Color(0.3f, 0.145f, 0.078f);
    }
}
