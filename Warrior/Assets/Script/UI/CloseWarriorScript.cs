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
        s.IClose = true;
        s.ChooseWarriors();
        s.changePanel.SetActive(false);
        if (s.WarriorBtn[0].GetComponent<W1btnScript>().IPress)
        {
            p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[0];            //����Ӣ��ͼƬ  
            p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[0];
            p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[0];
            s.Background[0].gameObject.SetActive(true);                             //��ԭӢ��ͼƬ
            foreach (var item in s.Background)
            {
                if (item != s.Background[0])
                {
                    item.gameObject.SetActive(false);
                }
            }
            s.SkillBtn[0].gameObject.SetActive(true);                           //��ԭӢ�ۼ���
            s.Background[0].gameObject.SetActive(true);                            //��ԭӢ�۱���
        }
        if (s.WarriorBtn[1].GetComponent<W2btnScript>().IPress)
        {
            p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[1];            //����Ӣ��ͼƬ  
            p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[1];
            p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[1];
            s.Background[1].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[1])
                {
                    item.gameObject.SetActive(false);
                }
            }
            s.SkillBtn[1].gameObject.SetActive(true);                           //��ԭӢ�ۼ���
            s.Background[1].gameObject.SetActive(true);                            //��ԭӢ�۱���
        }
        if (s.WarriorBtn[2].GetComponent<W3btnScript>().IPress)
        {
            p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[2];            //����Ӣ��ͼƬ  
            p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[2];
            p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[2];
            s.Background[2].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[2])
                {
                    item.gameObject.SetActive(false);
                }
            }
            s.SkillBtn[2].gameObject.SetActive(true);                           //��ԭӢ�ۼ���
            s.Background[2].gameObject.SetActive(true);                            //��ԭӢ�۱���
        }
        if (s.WarriorBtn[3].GetComponent<W4btnScript>().IPress)
        {
            p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[3];            //����Ӣ��ͼƬ  
            p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[3];
            p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[3];
            s.Background[3].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[3])
                {
                    item.gameObject.SetActive(false);
                }
            }
            s.SkillBtn[3].gameObject.SetActive(true);                           //��ԭӢ�ۼ���
            s.Background[3].gameObject.SetActive(true);                            //��ԭӢ�۱���
        }
        if (s.WarriorBtn[4].GetComponent<W5btnScript>().IPress)
        {
            p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[4];            //����Ӣ��ͼƬ  
            p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[4];
            p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[4];
            s.Background[4].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[4])
                {
                    item.gameObject.SetActive(false);
                }
            }
            s.SkillBtn[4].gameObject.SetActive(true);                           //��ԭӢ�ۼ���
            s.Background[4].gameObject.SetActive(true);                            //��ԭӢ�۱���
        }
        if (s.WarriorBtn[5].GetComponent<W6btnScript>().IPress)
        {
            p.GetComponent<SpriteRenderer>().sprite = p.WarriorImg[5];            //����Ӣ��ͼƬ  
            p.SingleWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[5];
            p.PointsWarriorImage.GetComponent<Image>().sprite = p.WarriorImg[5];
            s.Background[5].gameObject.SetActive(true);
            foreach (var item in s.Background)
            {
                if (item != s.Background[5])
                {
                    item.gameObject.SetActive(false);
                }
            }
            s.SkillBtn[5].gameObject.SetActive(true);                           //��ԭӢ�ۼ���
            s.Background[5].gameObject.SetActive(true);                            //��ԭӢ�۱���
        }
    }

}
