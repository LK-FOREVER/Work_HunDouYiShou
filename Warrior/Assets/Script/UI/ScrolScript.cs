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
        radius = (transform as RectTransform).sizeDelta.x * 0.25f;                                           //??????

        player = GameObject.Find("Player");
    }
    void Update()
    {

        
    }
    public override void OnDrag(PointerEventData eventData)                                                 //???????
    {
        // player.GetComponent<PlayerScript>().IMove = true;

        base.OnDrag(eventData);

        if (this.content.anchoredPosition.magnitude > radius)
        {
            this.content.anchoredPosition = this.content.anchoredPosition.normalized * radius;               //???????��????????
        }

        SetContentAnchoredPosition(this.content.anchoredPosition.normalized * radius);                       //??��??��???????? ??????

        Vector2 _d = this.content.anchoredPosition;
        if (player != null)
        {
            // player.GetComponent<PlayerScript>().SetDir(_d);                                                   //????��?????3D????
        }

    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);                                                                           //???

        /* player.GetComponent<PlayerScript>().SetDir(Vector2.zero); */                                           //???????????��
        // player.GetComponent<PlayerScript>().IMove = false;
    }

}
