using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalScript : MonoBehaviour
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
    public void ClickNormalBtn()
    {
        p.GetComponent<PlayerScript>().IVeryHard = false;
        p.GetComponent<PlayerScript>().IEasy = false;
        p.GetComponent<PlayerScript>().INormal = true;
        p.GetComponent<PlayerScript>().IHard = false; 
        IClick = true;
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        DifTxt.text = "难度：正常";
        // DifTxt.color = new Color(0.188f, 0.886f, 0.784f);
        DifBtn.GetComponent<DifBtnScript>().FalseDifBtn();
        DifBtn.GetComponent<DifBtnScript>().IClick = !DifBtn.GetComponent<DifBtnScript>().IClick;

        Player.GetComponent<PlayerScript>().R1 = 5;
        Player.GetComponent<PlayerScript>().R2 = 15;

        DifBtn.GetComponent<Image>().sprite = DifBtn.GetComponent<DifBtnScript>().sprite[0];
        //难度属性
        p.TrapNum = 30;
        p.AddNum = 30;
        p.TrapAfterNum = 15;
        p.AddAfterNum = 15;
        p.T1 = 1; p.T2 = 21;
        p.B1 = 1; p.B2 = 21;
     
    }
}
