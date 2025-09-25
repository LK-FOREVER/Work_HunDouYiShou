using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ScrolScript : ScrollRect
{
    float radius;

    public GameObject player;
    public bool INorth=false;
    public bool ISouth=false;
    public bool IWast = false;
    public bool IEast=false;

    void Start()
    {
        radius = (transform as RectTransform).sizeDelta.x * 0.25f;                                           //比例半径

        player = GameObject.Find("Player");
    }
    void Update()
    {

        
    }
    public override void OnDrag(PointerEventData eventData)                                                 //拖拽方法
    {
        player.GetComponent<PlayerScript>().IMove = true;

        base.OnDrag(eventData);

        if (this.content.anchoredPosition.magnitude > radius)
        {
            this.content.anchoredPosition = this.content.anchoredPosition.normalized * radius;               //不超过该方向半径长度
        }

        SetContentAnchoredPosition(this.content.anchoredPosition.normalized * radius);                       //将锚点位置赋给控件 摇杆方向

        Vector2 _d = this.content.anchoredPosition;
        if (player != null)
        {
            player.GetComponent<PlayerScript>().SetDir(_d);                                                   //将遥感方向传入3D世界
        }

    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);                                                                           //原有

        /* player.GetComponent<PlayerScript>().SetDir(Vector2.zero); */                                           //结束拖拽摇杆归位
        player.GetComponent<PlayerScript>().IMove = false;
    }

}
