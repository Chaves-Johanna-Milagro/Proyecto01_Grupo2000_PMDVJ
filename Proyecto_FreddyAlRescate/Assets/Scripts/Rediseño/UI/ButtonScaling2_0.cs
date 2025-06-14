using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaling2_0 : MonoBehaviour // pa los botones en la version del rediseño
{
    private float _scaleMultiplier = 1.1f;
    private float _scaleSpeed = 5f;

    private RectTransform _rectTransform;

    private Vector3 _originalScale;

    private bool _isScaling = false;

   // private AudioSource _hover;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalScale = _rectTransform.localScale;

       // _hover = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isScaling = true;
        //if (_hover != null) _hover.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isScaling = false;
    }

    private void Update()
    {
        Vector3 desiredScale = _isScaling ? _originalScale * _scaleMultiplier : _originalScale;
        _rectTransform.localScale = Vector3.Lerp(_rectTransform.localScale, desiredScale, Time.deltaTime * _scaleSpeed);
    }
}
