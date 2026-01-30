using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class CloseWarriorScript : MonoBehaviour
{
    public StartSceneScript s;
    public PlayerScript p;
    public void ColseChooseWarriors()    //�رհ�ť
    {
        p.audio.clip = p.acilp[0];
        p.audio.Play();
        s.ChooseWarriors();
        s.changePanel.SetActive(false);
        if (PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 1)
        {
            s.Background[0].gameObject.SetActive(true);                             //��ԭӢ��ͼƬ
            foreach (var item in s.Background)
            {
                if (item != s.Background[0])
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 2)
        {
            s.Background[1].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[1])
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 3)
        {
            s.Background[2].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[2])
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 4)
        {
            s.Background[3].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[3])
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 5)
        {
            s.Background[4].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[4])
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
        if (PlayerPrefs.GetInt(SdkScript.nickname + "CurrentPlayer", 1) == 6)
        {
            s.Background[5].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[5])
                {
                    item.gameObject.SetActive(false);
                }
            }
        }
    }

}
