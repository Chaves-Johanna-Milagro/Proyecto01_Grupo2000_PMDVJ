using UnityEngine;
using UnityEngine.EventSystems;

public class NotesSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float _slideY = -200f;   // Y final al apoyar el cursor
    private float _slideSpeed = 5f;

    private RectTransform _rectTransform;
    private Vector2 _originalPosition;
    private float _currentY;
    private bool _isSlip = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPosition = _rectTransform.anchoredPosition;
        _currentY = _originalPosition.y;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isSlip = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isSlip = false;
    }

    private void Update()
    {
        // Calculamos la Y deseada, pero mantenemos la X original
        float targetY = _isSlip ? _slideY : _originalPosition.y;
        _currentY = Mathf.Lerp(_currentY, targetY, Time.deltaTime * _slideSpeed);
        _rectTransform.anchoredPosition = new Vector2(_originalPosition.x, _currentY);
    }
}
