using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VeryHardScript : MonoBehaviour
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
    public void ClickVeryHardBtn()
    {
        p.GetComponent<PlayerScript>().IVeryHard = true;
        p.GetComponent<PlayerScript>().IEasy = false;
        p.GetComponent<PlayerScript>().INormal = false;
        p.GetComponent<PlayerScript>().IHard=false;
        IClick =true;
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        DifTxt.text = "难度：极难";
        // DifTxt.color = new Color(0.808f, 0.184f, 0.172f);
        DifBtn.GetComponent<DifBtnScript>().FalseDifBtn();
        DifBtn.GetComponent<DifBtnScript>().IClick = !DifBtn.GetComponent<DifBtnScript>().IClick;

        Player.GetComponent<PlayerScript>().R1 = 0;
        Player.GetComponent<PlayerScript>().R2 = 20;

        DifBtn.GetComponent<Image>().sprite = DifBtn.GetComponent<DifBtnScript>().sprite[0];

        //�Ѷ�����
        p.TrapNum = 35;
        p.AddNum = 0;
        p.TrapAfterNum = 25;
        p.AddAfterNum = 0;
        p.T1 = 21; p.T2 = 30;
        p.B1 = 1; p.B2 = 21;
       
    }
}
