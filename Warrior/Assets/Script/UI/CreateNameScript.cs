using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNameScript : MonoBehaviour
{
    public Button certainBtn; //确定按钮
    public Button randomBtn; //随机按钮
    public InputField inputField; //输入框
    public Text nameTxt; //名称
    void Start()
    {
        certainBtn.onClick.AddListener(CertainBtnClick);
        randomBtn.onClick.AddListener(RandomBtnClick);
    }

    void CertainBtnClick()
    {
        if (inputField.text == "")
        {
            //提示名称不能为空
            Debug.Log("名称不能为空");
            return;
        }
        //名称不能包含敏感字符
        if (inputField.text.Contains("敏感字符"))
        {
            //提示名称不能包含敏感字符
            Debug.Log("名称不能包含敏感字符");
            return;
        }
        //名称长度不能超过6个字符
        if (inputField.text.Length > 6)
        {
            //提示名称长度不能超过6个字符
            Debug.Log("名称长度不能超过6个字符");
            return;
        }
        //保存名称
        nameTxt.text = inputField.text;
        PlayerPrefs.SetString(SdkScript.nickname + "PlayerName", inputField.text);
        gameObject.SetActive(false);
    }
    void RandomBtnClick()
    {
        inputField.text = RandomName();
    }
    string RandomName()
    {
        string name = "";
        //名称长度不能超过6个字符
        for (int i = 0; i < 6; i++)
        {
            name += (char)('a' + UnityEngine.Random.Range(0, 26));
        }
        return name;
    }
}
