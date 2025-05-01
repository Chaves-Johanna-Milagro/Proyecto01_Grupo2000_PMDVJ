using UnityEngine;
using UnityEngine.EventSystems;

public class DragImgUI : MonoBehaviour, IBeginDragHandler, IDragHandler//, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector3 _startPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) //actualiza la pos actual 
    {
        _startPosition = _rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = Input.mousePosition;
    }
}
