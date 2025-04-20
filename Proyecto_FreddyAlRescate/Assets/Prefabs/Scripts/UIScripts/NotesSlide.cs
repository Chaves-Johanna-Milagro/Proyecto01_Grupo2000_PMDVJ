using UnityEngine;
using UnityEngine.EventSystems;

public class NotesSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float slideY = -200f;   // Y final al apoyar el cursor
    private float slideSpeed = 5f;

    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private float currentY;
    private bool isSlip = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        currentY = originalPosition.y;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isSlip = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSlip = false;
    }

    private void Update()
    {
        // Calculamos la Y deseada, pero mantenemos la X original
        float targetY = isSlip ? slideY : originalPosition.y;
        currentY = Mathf.Lerp(currentY, targetY, Time.deltaTime * slideSpeed);
        rectTransform.anchoredPosition = new Vector2(originalPosition.x, currentY);
    }
}
