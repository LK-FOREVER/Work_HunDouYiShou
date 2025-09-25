using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardScript : MonoBehaviour
{
    public Text DifTxt;
    public Button DifBtn;
    public GameObject Player;
    public PlayerScript p;
    bool IClick;
    void Start()
    {
       
    }

    void Update()
    {
       
           
        
    }
    public void ClickHardBtn()
    {
        p.GetComponent<PlayerScript>().IVeryHard = false;
        p.GetComponent<PlayerScript>().IEasy = false;
        p.GetComponent<PlayerScript>().INormal = false;
        p.GetComponent<PlayerScript>().IHard = true;
        IClick = true;
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        DifTxt.text = "难度：困难";
        // DifTxt.color = new Color(0.894f, 0.553f, 0.188f);
        DifBtn.GetComponent<DifBtnScript>().FalseDifBtn();
        DifBtn.GetComponent<DifBtnScript>().IClick = !DifBtn.GetComponent<DifBtnScript>().IClick;

        Player.GetComponent<PlayerScript>().R1 = 0;
        Player.GetComponent<PlayerScript>().R2 = 15;
        DifBtn.GetComponent<Image>().sprite = DifBtn.GetComponent<DifBtnScript>().sprite[0];
        //�Ѷ�����
        p.TrapNum = 35;
        p.AddNum = 25;
        p.TrapAfterNum = 20;
        p.AddAfterNum = 10;
        p.T1 = 1; p.T2 = 81;
        p.B1 = 1; p.B2 = 28;
       
    }
}
