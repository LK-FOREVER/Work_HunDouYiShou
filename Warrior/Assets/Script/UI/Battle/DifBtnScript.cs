using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifBtnScript : MonoBehaviour
{
   public Button[] AllDifBtn;
   public bool IClick;
    public PlayerScript p;
    public Sprite[] sprite;
    void Start()
    {
        p.GetComponent<PlayerScript>().IEasy = true;
    }

    void Update()
    {
       
    }
    public void ClickDifBtn()
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });

        IClick = !IClick;
        if (IClick)
        {
            gameObject.GetComponent<Image>().sprite = sprite[1];
            ShowDifBtn();
        }
        else if (!IClick)
        {
            gameObject.GetComponent<Image>().sprite = sprite[0];
            FalseDifBtn();
        }
    }
    public void ShowDifBtn()
    {
        for(int i = 0; i < AllDifBtn.Length; i++)
        {
            AllDifBtn[i].gameObject.SetActive(true);
        }
    }
    public void FalseDifBtn()
    {
        for (int i = 0; i < AllDifBtn.Length; i++)
        {
            AllDifBtn[i].gameObject.SetActive(false);
        }
    }
}
