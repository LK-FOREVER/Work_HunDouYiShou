using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private RectTransform background; // 摇杆背景
    private RectTransform handle; // 摇杆手柄

    private Vector2 inputDirection; // 输入方向

    [Header("Settings")]
    [SerializeField] private float handleRange = 1f;    // 手柄移动范围
    [SerializeField] private float deadZone = 0.2f;     // 死区范围
    private void Awake()
    {
        background = GetComponent<RectTransform>();
        handle = transform.GetChild(0).GetComponent<RectTransform>(); // 摇杆手柄是背景的子元素
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 touchPosition = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out touchPosition))
        {
            // 获取触摸位置相对于摇杆背景的百分比
            touchPosition.x = (touchPosition.x / background.sizeDelta.x);
            touchPosition.y = (touchPosition.y / background.sizeDelta.y);

            inputDirection = touchPosition.normalized;

            // 计算手柄应该移动到的位置
            Vector2 handlePosition = inputDirection * background.sizeDelta * 0.5f * handleRange;


            // 应用死区
            if (inputDirection.magnitude < deadZone)
            {
                handlePosition = Vector2.zero;
                inputDirection = Vector2.zero;
            }

            // 更新手柄位置
            handle.anchoredPosition = handlePosition;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 重置摇杆位置和输入方向
        handle.anchoredPosition = Vector2.zero;
        inputDirection = Vector2.zero;
    }

    // 返回输入方向
    public Vector2 GetInputDirection()
    {
        return inputDirection;
    }
}
