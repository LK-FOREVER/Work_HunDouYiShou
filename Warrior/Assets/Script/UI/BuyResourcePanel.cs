using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyResourcePanel : MonoBehaviour
{
    public StartSceneScript s;
    public Text Asktxt;

    public void InitUI(int index)
    {
        s.ChooseResource = index;
        switch (index)
        {
            case 1:
                Asktxt.text = "是否充值5元购买该礼包？";
                break;
            case 2:
                Asktxt.text = "是否充值25元购买该礼包？";
                break;
            case 3:
                Asktxt.text = "是否花费10水晶购买该礼包？";
                break;
            case 4:
                Asktxt.text = "是否花费40水晶购买该礼包？";
                break;
            case 5:
                Asktxt.text = "是否花费100水晶购买该礼包？";
                break;
            default:
                break;
        }
    }
}
