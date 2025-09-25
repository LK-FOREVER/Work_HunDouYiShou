using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Easycript : MonoBehaviour
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
    public void ClickEasyBtn()
    {
        p.GetComponent<PlayerScript>().IVeryHard = false;
        p.GetComponent<PlayerScript>().IEasy = true;
        p.GetComponent<PlayerScript>().INormal = false;
        p.GetComponent<PlayerScript>().IHard = false;
        IClick = true;
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        DifTxt.text = "难度：简单";
        // DifTxt.color = new Color(0.372f,0.690f,0.372f);
        DifBtn.GetComponent<DifBtnScript>().FalseDifBtn();
        DifBtn.GetComponent<DifBtnScript>().IClick=!DifBtn.GetComponent<DifBtnScript>().IClick;

        Player.GetComponent<PlayerScript>().R1 = 0;
        Player.GetComponent<PlayerScript>().R2 = 5;

        DifBtn.GetComponent<Image>().sprite = DifBtn.GetComponent<DifBtnScript>().sprite[0];


        //难度属性
        p.TrapNum = 0;
        p.AddNum = 50;
        p.TrapAfterNum = 0;
        p.AddAfterNum = 20;
        p.T1 = 1; p.T2 = 21;
        p.B1 = 21; p.B2 = 30;

        // 技能释放频率
       
    }
}
