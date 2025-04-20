using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonsScaling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float scaleMultiplier = 1.1f;
    private float scaleSpeed = 5f;

    private RectTransform rectTransform;
    private Vector3 originalScale;
    private Vector3 targetScale;
    private bool isScaling = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isScaling = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isScaling = false;
    }

    private void Update()
    {
        Vector3 desiredScale = isScaling ? originalScale * scaleMultiplier : originalScale;
        rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, desiredScale, Time.deltaTime * scaleSpeed);
    }
}
