using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBtnScript : MonoBehaviour
{
    public GameObject WarriorPanel;
    public GameObject CoinPanel;
    public Sprite[] sp;
    public Button WarriorBtn;
    public Text WarriorTxt;
    public Text CoinTxt;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickCoinBtn()
    {
        if(CoinPanel.activeSelf) return;
        CoinPanel.SetActive(true);
        WarriorPanel.SetActive(false);
        this.GetComponent<Image>().sprite = sp[0];
        WarriorBtn.GetComponent<Image>().sprite = sp[1];
        // CoinTxt.color = new Color(0.98f, 0.65f, 0.31f);
        // WarriorTxt.color =  new Color(0.3f, 0.145f, 0.078f);
    }
}
