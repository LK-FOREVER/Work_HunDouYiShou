using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrolWarriorScript : MonoBehaviour
{
    public Sprite[] ArrowSP;
    public Image LeftArrow;
    public Image RightArrow;
    public GameObject Content;
    void Start()
    {
        
    }

    void Update()
    {
        //print(Content.GetComponent<RectTransform>().position.x);
        if (Content.GetComponent<RectTransform>().position.x >39f)
        {
            LeftArrow.GetComponent<Image>().sprite=ArrowSP[0];
            RightArrow.GetComponent<Image>().sprite=ArrowSP[3];
        }
       else if (Content.GetComponent<RectTransform>().position.x < -312f)
       {
            LeftArrow.GetComponent<Image>().sprite = ArrowSP[1];
            RightArrow.GetComponent<Image>().sprite = ArrowSP[2];
       }
        else
        {
            LeftArrow.GetComponent<Image>().sprite = ArrowSP[1];
            RightArrow.GetComponent<Image>().sprite = ArrowSP[3];
        }
    }

}
