using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMonster : MonoBehaviour
{
    public StartSceneScript s;
    public GameObject BuyPanel;
    public void OnClickBuyMonster(int index)
    {
        EventManager.Instance.TriggerEvent(EventName.ChangeSound, this, new ChangeSoundArgs { index_sound = (int)SoundType.ClickBtn });
        BuyPanel.SetActive(true);
        BuyPanel.GetComponent<BuyMonsterPanel>().InitUI(index);
        s.ChooseWarrior = index;          //选择购买哪个异兽
    }
}
