using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HonorbtnScriot : MonoBehaviour
{
    public GameObject HonorPanel;
    bool IClick;
    public Image RedImg;
    public Button[] Honor;
    public Text[] GetText;
    public Image[] Mask;
    public PlayerScript p;
    int[] Get = new int[20];//??????ж???

    int G;//?????±?
    int g;
    public int getnum;//??????????
    public Text WorkTxt;
    public int WorkNum;
    public GameObject ChooseWarriorPanel;
    public GameObject MusicPanel;
    void Start()
    {
        //PlayerPrefs.SetInt("Getnum", 0);
        RedImg.gameObject.SetActive(false);

        //print(getnum);
        if (PlayerPrefs.GetInt("PlayerPrefsLock2", 0) != 0)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("PlayerPrefsLock3", 0) != 0)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("PlayerPrefsLock4", 0) != 0)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("PlayerPrefsLock5", 0) != 0)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("PlayerPrefsLock6", 0) != 0)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("KillNum", 0) > 1)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("KillNum", 0) > 10)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("KillNum", 0) > 100)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("KillNum", 0) > 500)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("KillNum", 0) > 1000)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("ColiNum", 0) > 10)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("ColiNum", 0) > 100)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("ColiNum", 0) > 500)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("ColiNum", 0) > 1000)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("ColiNum", 0) > 5000)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("Point", 0) > 1000)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("Point", 0) > 10000)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("Point", 0) > 100000)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("Point", 0) > 1000000)
        {
            WorkNum++;
        }
        if (PlayerPrefs.GetInt("Point", 0) > 10000000)
        {
            WorkNum++;
        }
    }


    void Update()
    {
        WorkTxt.text = WorkNum.ToString();

        //if (PlayerPrefs.GetInt("Getnum")==0)
        //{
        //    RedImg.gameObject.SetActive(false);
        //}
        //else
        //{
        //    RedImg.gameObject.SetActive(true);
        //}

        //?ж??????????????
        int PlayerPrefsLock2 = PlayerPrefs.GetInt("PlayerPrefsLock2", 0);
        if (PlayerPrefsLock2 == 0)
        {
            GetText[0].gameObject.SetActive(true);
            Honor[0].gameObject.SetActive(false);
        }
        else if (PlayerPrefsLock2 != 0 && PlayerPrefs.GetInt("get1", 0) == 0)
        {

            PlayerPrefs.SetInt("Get1", 1);
        }
        if (PlayerPrefs.GetInt("Get1", 0) == 0)   //δ????
        {
            GetText[0].gameObject.SetActive(true);
            GetText[0].text = "未获得";
            Honor[0].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get1", 0) == 1) //δ???
        {
            GetText[0].gameObject.SetActive(false);
            Honor[0].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get1", 0) == 2)//?????
        {
            GetText[0].gameObject.SetActive(true);
            GetText[0].text = "已获取";
            Honor[0].gameObject.SetActive(false);
            Mask[0].gameObject.SetActive(true);
        }
        int PlayerPrefsLock3 = PlayerPrefs.GetInt("PlayerPrefsLock3", 0);
        if (PlayerPrefsLock3 == 0)
        {
            GetText[1].gameObject.SetActive(true);
            Honor[1].gameObject.SetActive(false);
        }
        else if (PlayerPrefsLock3 != 0 && PlayerPrefs.GetInt("get2", 0) == 0)
        {
            PlayerPrefs.SetInt("Get2", 1);

            int WorkNum = PlayerPrefs.GetInt("WorkNum", 0);  //??????????
            WorkNum++;
            PlayerPrefs.SetInt("WorkNum", WorkNum);

        }
        if (PlayerPrefs.GetInt("Get2", 0) == 0)   //δ????
        {
            GetText[1].gameObject.SetActive(true);
            GetText[1].text = "未获得";
            Honor[1].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get2", 0) == 1) //δ???
        {

            GetText[1].gameObject.SetActive(false);
            Honor[1].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get2", 0) == 2)//?????
        {

            GetText[1].gameObject.SetActive(true);
            GetText[1].text = "已获取";
            Honor[1].gameObject.SetActive(false);
            Mask[1].gameObject.SetActive(true);
        }
        int PlayerPrefsLock4 = PlayerPrefs.GetInt("PlayerPrefsLock4", 0);
        if (PlayerPrefsLock4 == 0)
        {
            GetText[2].gameObject.SetActive(true);
            Honor[2].gameObject.SetActive(false);
        }
        else if (PlayerPrefsLock4 != 0 && PlayerPrefs.GetInt("get3", 0) == 0)
        {
            PlayerPrefs.SetInt("Get3", 1);
        }
        if (PlayerPrefs.GetInt("Get3", 0) == 0)   //δ????
        {
            GetText[2].gameObject.SetActive(true);
            GetText[2].text = "未获得";
            Honor[2].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get3", 0) == 1) //δ???
        {

            GetText[2].gameObject.SetActive(false);
            Honor[2].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get3", 0) == 2)//?????
        {

            GetText[2].gameObject.SetActive(true);
            GetText[2].text = "已获取";
            Honor[2].gameObject.SetActive(false);
            Mask[2].gameObject.SetActive(true);
        }
        //print(PlayerPrefs.GetInt("Get3", 0));
        int PlayerPrefsLock5 = PlayerPrefs.GetInt("PlayerPrefsLock5", 0);
        if (PlayerPrefsLock5 == 0)
        {
            GetText[3].gameObject.SetActive(true);
            Honor[3].gameObject.SetActive(false);
        }
        else if (PlayerPrefsLock5 != 0 && PlayerPrefs.GetInt("get4", 0) == 0)
        {
            PlayerPrefs.SetInt("Get4", 1);
        }
        if (PlayerPrefs.GetInt("Get4", 0) == 0)   //δ????
        {
            GetText[3].gameObject.SetActive(true);
            GetText[3].text = "未获得  ";
            Honor[3].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get4", 0) == 1) //δ???
        {

            GetText[3].gameObject.SetActive(false);
            Honor[3].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get4", 0) == 2)//?????
        {

            GetText[3].gameObject.SetActive(true);
            GetText[3].text = "已获取";
            Honor[3].gameObject.SetActive(false);
            Mask[3].gameObject.SetActive(true);
        }
        int PlayerPrefsLock6 = PlayerPrefs.GetInt("PlayerPrefsLock6", 0);
        if (PlayerPrefsLock6 == 0)
        {
            GetText[4].gameObject.SetActive(true);
            Honor[4].gameObject.SetActive(false);
        }
        else if (PlayerPrefsLock6 != 0 && PlayerPrefs.GetInt("get5", 0) == 0)
        {
            PlayerPrefs.SetInt("Get5", 1);
        }
        if (PlayerPrefs.GetInt("Get5", 0) == 0)   //δ????
        {
            GetText[4].gameObject.SetActive(true);
            GetText[4].text = "未获得";
            Honor[4].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get5", 0) == 1) //δ???
        {

            GetText[4].gameObject.SetActive(false);
            Honor[4].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get5", 0) == 2)//?????
        {

            GetText[4].gameObject.SetActive(true);
            GetText[4].text = "已获取";
            Honor[4].gameObject.SetActive(false);
            Mask[4].gameObject.SetActive(true);
        }








        //?ж????????????????
        int P_KillNum = PlayerPrefs.GetInt("KillNum", 0);
        if (P_KillNum < 1)
        {
            GetText[5].gameObject.SetActive(true);
            Honor[5].gameObject.SetActive(false);
        }
        else if (P_KillNum >= 1 && PlayerPrefs.GetInt("get6", 0) == 0)
        {
            PlayerPrefs.SetInt("Get6", 1);


        }
        if (PlayerPrefs.GetInt("Get6", 0) == 0)   //δ????
        {
            GetText[5].gameObject.SetActive(true);
            GetText[5].text = "未获得";
            Honor[5].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get6", 0) == 1) //δ???
        {

            GetText[5].gameObject.SetActive(false);
            Honor[5].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get6", 0) == 2)//?????
        {

            GetText[5].gameObject.SetActive(true);
            GetText[5].text = "已获取";
            Honor[5].gameObject.SetActive(false);
            Mask[5].gameObject.SetActive(true);
        }
        int P_KillNum1 = PlayerPrefs.GetInt("KillNum", 0);
        if (P_KillNum1 < 10)
        {
            GetText[6].gameObject.SetActive(true);
            Honor[6].gameObject.SetActive(false);
        }
        else if (P_KillNum1 >= 10 && PlayerPrefs.GetInt("get7", 0) == 0)
        {
            PlayerPrefs.SetInt("Get7", 1);
        }
        if (PlayerPrefs.GetInt("Get7", 0) == 0)   //δ????
        {
            GetText[6].gameObject.SetActive(true);
            GetText[6].text = "未获得  ";
            Honor[6].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get7", 0) == 1) //δ???
        {

            GetText[6].gameObject.SetActive(false);
            Honor[6].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get7", 0) == 2)//?????
        {

            GetText[6].gameObject.SetActive(true);
            GetText[6].text = "已获取";
            Honor[6].gameObject.SetActive(false);
            Mask[6].gameObject.SetActive(true);
        }
        int P_KillNum2 = PlayerPrefs.GetInt("KillNum", 0);
        if (P_KillNum2 < 100)
        {
            GetText[7].gameObject.SetActive(true);
            Honor[7].gameObject.SetActive(false);
        }
        else if (P_KillNum2 >= 100 && PlayerPrefs.GetInt("get8", 0) == 0)
        {
            PlayerPrefs.SetInt("Get8", 1);
        }
        if (PlayerPrefs.GetInt("Get8", 0) == 0)   //δ????
        {
            GetText[7].gameObject.SetActive(true);
            GetText[7].text = "未获得";
            Honor[7].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get8", 0) == 1) //δ???
        {

            GetText[7].gameObject.SetActive(false);
            Honor[7].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get8", 0) == 2)//?????
        {

            GetText[7].gameObject.SetActive(true);
            GetText[7].text = "已获取";
            Honor[7].gameObject.SetActive(false);
            Mask[7].gameObject.SetActive(true);
        }
        int P_KillNum3 = PlayerPrefs.GetInt("KillNum", 0);
        if (P_KillNum3 < 500)
        {
            GetText[8].gameObject.SetActive(true);
            Honor[8].gameObject.SetActive(false);
        }
        else if (P_KillNum3 >= 500 && PlayerPrefs.GetInt("get9", 0) == 0)
        {
            PlayerPrefs.SetInt("Get9", 1);
        }
        if (PlayerPrefs.GetInt("Get9", 0) == 0)   //δ????
        {
            GetText[8].gameObject.SetActive(true);
            GetText[8].text = "未获得";
            Honor[8].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get9", 0) == 1) //δ???
        {

            GetText[8].gameObject.SetActive(false);
            Honor[8].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get9", 0) == 2)//?????
        {

            GetText[8].gameObject.SetActive(true);
            GetText[8].text = "已获取";
            Honor[8].gameObject.SetActive(false);
            Mask[8].gameObject.SetActive(true);
        }
        int P_KillNum4 = PlayerPrefs.GetInt("KillNum", 0);
        if (P_KillNum4 < 1000)
        {
            GetText[9].gameObject.SetActive(true);
            Honor[9].gameObject.SetActive(false);
        }
        else if (P_KillNum4 >= 1000 && PlayerPrefs.GetInt("get10", 0) == 0)
        {
            PlayerPrefs.SetInt("Get10", 1);
        }
        if (PlayerPrefs.GetInt("Get10", 0) == 0)   //δ????
        {
            GetText[9].gameObject.SetActive(true);
            GetText[9].text = "未获得";
            Honor[9].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get10", 0) == 1) //δ???
        {

            GetText[9].gameObject.SetActive(false);
            Honor[9].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get10", 0) == 2)//?????
        {

            GetText[9].gameObject.SetActive(true);
            GetText[9].text = "已获取";
            Honor[9].gameObject.SetActive(false);
            Mask[9].gameObject.SetActive(true);
        }





        //?ж?????????????????
        int P_ColiNum = PlayerPrefs.GetInt("ColiNum", 0);
        if (P_ColiNum < 10)
        {
            GetText[10].gameObject.SetActive(true);
            Honor[10].gameObject.SetActive(false);
        }
        else if (P_ColiNum >= 10 && PlayerPrefs.GetInt("get11", 0) == 0)
        {
            PlayerPrefs.SetInt("Get11", 1);
        }
        if (PlayerPrefs.GetInt("Get11", 0) == 0)   //δ????
        {
            GetText[10].gameObject.SetActive(true);
            GetText[10].text = "未获得";
            Honor[10].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get11", 0) == 1) //δ???
        {

            GetText[10].gameObject.SetActive(false);
            Honor[10].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get11", 0) == 2)//?????
        {

            GetText[10].gameObject.SetActive(true);
            GetText[10].text = "已获取";
            Honor[10].gameObject.SetActive(false);
            Mask[10].gameObject.SetActive(true);
        }
        int P_ColiNum1 = PlayerPrefs.GetInt("ColiNum", 0);
        if (P_ColiNum1 < 100)
        {
            GetText[11].gameObject.SetActive(true);
            Honor[11].gameObject.SetActive(false);
        }
        else if (P_ColiNum1 >= 100 && PlayerPrefs.GetInt("get12", 0) == 0)
        {
            PlayerPrefs.SetInt("Get12", 1);
        }
        if (PlayerPrefs.GetInt("Get12", 0) == 0)   //δ????
        {
            GetText[11].gameObject.SetActive(true);
            GetText[11].text = "未获得";
            Honor[11].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get12", 0) == 1) //δ???
        {

            GetText[11].gameObject.SetActive(false);
            Honor[11].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get12", 0) == 2)//?????
        {

            GetText[11].gameObject.SetActive(true);
            GetText[11].text = "已获取";
            Honor[11].gameObject.SetActive(false);
            Mask[11].gameObject.SetActive(true);
        }
        int P_ColiNum2 = PlayerPrefs.GetInt("ColiNum", 0);
        if (P_ColiNum2 < 500)
        {
            GetText[12].gameObject.SetActive(true);
            Honor[12].gameObject.SetActive(false);
        }
        else if (P_ColiNum2 >= 500 && PlayerPrefs.GetInt("get13", 0) == 0)
        {
            PlayerPrefs.SetInt("Get13", 1);

        }
        if (PlayerPrefs.GetInt("Get13", 0) == 0)   //δ????
        {
            GetText[12].gameObject.SetActive(true);
            GetText[12].text = "未获得";
            Honor[12].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get13", 0) == 1) //δ???
        {

            GetText[12].gameObject.SetActive(false);
            Honor[12].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get13", 0) == 2)//?????
        {

            GetText[12].gameObject.SetActive(true);
            GetText[12].text = "已获取";
            Honor[12].gameObject.SetActive(false);
            Mask[12].gameObject.SetActive(true);
        }

        int P_ColiNum3 = PlayerPrefs.GetInt("ColiNum", 0);
        if (P_ColiNum3 < 1000)
        {
            GetText[13].gameObject.SetActive(true);
            Honor[13].gameObject.SetActive(false);
        }
        else if (P_ColiNum3 >= 1000 && PlayerPrefs.GetInt("get14", 0) == 0)
        {
            PlayerPrefs.SetInt("Get14", 1);
        }
        if (PlayerPrefs.GetInt("Get14", 0) == 0)   //δ????
        {
            GetText[13].gameObject.SetActive(true);
            GetText[13].text = "未获得";
            Honor[13].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get14", 0) == 1) //δ???
        {

            GetText[13].gameObject.SetActive(false);
            Honor[13].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get14", 0) == 2)//?????
        {

            GetText[13].gameObject.SetActive(true);
            GetText[13].text = "已获取";
            Honor[13].gameObject.SetActive(false);
            Mask[13].gameObject.SetActive(true);
        }
        int P_ColiNum4 = PlayerPrefs.GetInt("ColiNum", 0);
        if (P_ColiNum4 < 5000)
        {
            GetText[14].gameObject.SetActive(true);
            Honor[14].gameObject.SetActive(false);
        }
        else if (P_ColiNum4 >= 5000 && PlayerPrefs.GetInt("get15", 0) == 0)
        {
            PlayerPrefs.SetInt("Get15", 1);
        }
        if (PlayerPrefs.GetInt("Get15", 0) == 0)   //δ????
        {
            GetText[14].gameObject.SetActive(true);
            GetText[14].text = "未获得";
            Honor[14].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get15", 0) == 1) //δ???
        {

            GetText[14].gameObject.SetActive(false);
            Honor[14].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get15", 0) == 2)//?????
        {

            GetText[14].gameObject.SetActive(true);
            GetText[14].text = "已获取";
            Honor[14].gameObject.SetActive(false);
            Mask[14].gameObject.SetActive(true);
        }
        //?ж?????????????????
        int P_PointNum = PlayerPrefs.GetInt("Point", 0);
        if (P_PointNum < 1000)
        {
            GetText[15].gameObject.SetActive(true);
            Honor[15].gameObject.SetActive(false);
        }
        else if (P_PointNum >= 1000 && PlayerPrefs.GetInt("get16", 0) == 0)
        {
            PlayerPrefs.SetInt("Get16", 1);
        }
        if (PlayerPrefs.GetInt("Get16", 0) == 0)   //δ????
        {
            GetText[15].gameObject.SetActive(true);
            GetText[15].text = "未获得";
            Honor[15].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get16", 0) == 1) //δ???
        {

            GetText[15].gameObject.SetActive(false);
            Honor[15].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get16", 0) == 2)//?????
        {

            GetText[15].gameObject.SetActive(true);
            GetText[15].text = "已获取";
            Honor[15].gameObject.SetActive(false);
            Mask[15].gameObject.SetActive(true);
        }
        int P_PointNum1 = PlayerPrefs.GetInt("Point", 0);
        if (P_PointNum1 < 10000)
        {
            GetText[16].gameObject.SetActive(true);
            Honor[16].gameObject.SetActive(false);
        }
        else if (P_PointNum1 >= 10000 && PlayerPrefs.GetInt("get17", 0) == 0)
        {
            PlayerPrefs.SetInt("Get17", 1);
        }
        if (PlayerPrefs.GetInt("Get17", 0) == 0)   //δ????
        {

            GetText[16].gameObject.SetActive(true);
            GetText[16].text = "未获得";
            Honor[16].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get17", 0) == 1) //δ???
        {

            GetText[16].gameObject.SetActive(false);
            Honor[16].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get17", 0) == 2)//?????
        {

            GetText[16].gameObject.SetActive(true);
            GetText[16].text = "已获取";
            Honor[16].gameObject.SetActive(false);
            Mask[16].gameObject.SetActive(true);
        }
        int P_PointNum2 = PlayerPrefs.GetInt("Point", 0);
        if (P_PointNum2 < 100000)
        {
            GetText[17].gameObject.SetActive(true);
            Honor[17].gameObject.SetActive(false);
        }
        else if (P_PointNum2 >= 100000 && PlayerPrefs.GetInt("get18", 0) == 0)
        {
            PlayerPrefs.SetInt("Get18", 1);
        }
        if (PlayerPrefs.GetInt("Get18", 0) == 0)   //δ????
        {
            GetText[17].gameObject.SetActive(true);
            GetText[17].text = "未获得";
            Honor[17].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get18", 0) == 1) //δ???
        {

            GetText[17].gameObject.SetActive(false);
            Honor[17].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get18", 0) == 2)//?????
        {

            GetText[17].gameObject.SetActive(true);
            GetText[17].text = "已获取";
            Honor[17].gameObject.SetActive(false);
            Mask[17].gameObject.SetActive(true);
        }
        int P_PointNum3 = PlayerPrefs.GetInt("Point", 0);
        if (P_PointNum3 < 1000000)
        {
            GetText[18].gameObject.SetActive(true);
            Honor[18].gameObject.SetActive(false);
        }
        else if (P_PointNum3 >= 1000000 && PlayerPrefs.GetInt("get19", 0) == 0)
        {
            PlayerPrefs.SetInt("Get19", 1);
        }
        if (PlayerPrefs.GetInt("Get19", 0) == 0)   //δ????
        {
            GetText[18].gameObject.SetActive(true);
            GetText[18].text = "未获得";
            Honor[18].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get19", 0) == 1) //δ???
        {

            GetText[18].gameObject.SetActive(false);
            Honor[18].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get19", 0) == 2)//?????
        {

            GetText[18].gameObject.SetActive(true);
            GetText[18].text = "已获取";
            Honor[18].gameObject.SetActive(false);
            Mask[18].gameObject.SetActive(true);
        }
        int P_PointNum4 = PlayerPrefs.GetInt("Point", 0);
        if (P_PointNum4 < 10000000)
        {
            GetText[19].gameObject.SetActive(true);
            Honor[19].gameObject.SetActive(false);
        }
        else if (P_PointNum4 >= 10000000 && PlayerPrefs.GetInt("get20", 0) == 0)
        {
            PlayerPrefs.SetInt("Get20", 1);
        }
        if (PlayerPrefs.GetInt("Get20", 0) == 0)   //δ????
        {
            GetText[19].gameObject.SetActive(true);
            GetText[19].text = "未获得";
            Honor[19].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Get20", 0) == 1) //δ???
        {

            GetText[19].gameObject.SetActive(false);
            Honor[19].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Get20", 0) == 2)//?????
        {

            GetText[19].gameObject.SetActive(true);
            GetText[19].text = "已获取";
            Honor[19].gameObject.SetActive(false);
            Mask[19].gameObject.SetActive(true);
        }
        ActiveRedImg();//???????????
    }
    public void ClickHonorBtn()
    {
        p.audio.clip = p.acilp[0];
        p.audio.Play();

        MusicPanel.SetActive(false);
        HonorPanel.SetActive(true);
        ChooseWarriorPanel.SetActive(false);


    }
    public void ActiveRedImg()
    {
        for (int i = 0; i < Get.Length; i++)
        {
            Get[i] = PlayerPrefs.GetInt(("Get" + i.ToString()));
            //G++;
        }


        foreach (int temp in Get)                          //?ж?????????
        {
            if (temp == 1)
            {
                RedImg.gameObject.SetActive(true);
            }
            else
            {
                G++;
                if (G == 20)
                {
                    RedImg.gameObject.SetActive(false);

                }

            }
        }
        G = 0;
    }
}
