using UnityEngine;

public class ObjectScaling : MonoBehaviour // para los objetos de los minijuegos 
{
    private float _scaleMultiplier = 1.5f;
    private float _scaleSpeed = 5f;

    private Vector3 _originalScale;
    private Vector3 _targetScale;

    private bool _isMouseHeld = false;

    private void Start()
    {
        _originalScale = transform.localScale;
        _targetScale = _originalScale * _scaleMultiplier;
    }

    private void OnMouseEnter()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        _isMouseHeld = true;
    }

    private void OnMouseExit()
    {
        _isMouseHeld = false; // Por si sale con el botón apretado
    }

    private void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        _isMouseHeld = true;
    }

    private void OnMouseUp()
    {
        _isMouseHeld = false;
    }

    private void Update()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) _isMouseHeld = false;

        // Si el mouse está sobre el objeto y el botón está presionado, escalar
        Vector3 targetScale = (_isMouseHeld) ? _targetScale : _originalScale;

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * _scaleSpeed);
    }
}
