using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMonsterPanel : MonoBehaviour
{
    public Text Asktxt;
    public Sprite[] headImg;
    public Image HeadImg;
    public Sprite[] resourceImg;
    public Image ResourceImg;
    public Text ResourceTxt;

    public void InitUI(int index)
    {
        switch (index)
        {
            case 2:
                Asktxt.text = "是否花费5000金币解锁该异兽？";
                HeadImg.sprite = headImg[1];
                ResourceImg.sprite = resourceImg[0];
                ResourceTxt.text = "*5000";
                break;
            case 3:
                Asktxt.text = "是否花费20000金币解锁该异兽？";
                HeadImg.sprite = headImg[2];
                ResourceImg.sprite = resourceImg[0];
                ResourceTxt.text = "*20000";
                break;
            case 4:
                Asktxt.text = "是否花费50000钻石解锁该异兽？";
                HeadImg.sprite = headImg[3];
                ResourceImg.sprite = resourceImg[1];
                ResourceTxt.text = "*50000";
                break;
            case 5:
                Asktxt.text = "是否花费300钻石解锁该异兽？";
                HeadImg.sprite = headImg[4];
                ResourceImg.sprite = resourceImg[1];
                ResourceTxt.text = "*300";
                break;
            case 6:
                Asktxt.text = "是否花费500钻石解锁该异兽？";
                HeadImg.sprite = headImg[5];
                ResourceImg.sprite = resourceImg[1];
                ResourceTxt.text = "*500";
                break;
            default:
                break;
        }
    }
}
