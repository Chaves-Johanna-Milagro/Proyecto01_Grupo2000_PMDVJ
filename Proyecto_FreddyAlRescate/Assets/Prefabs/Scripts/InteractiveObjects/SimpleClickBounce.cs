using UnityEngine;
using System.Collections;

public class SimpleClickBounce : MonoBehaviour
{
    private float _bounceMultiplier = 1.2f;   // cu�nto se agranda en el rebote
    private float _bounceDuration = 0.4f;     // duraci�n total del rebote

    private Vector3 _originalScale;
    private bool _isBouncing = false;

    private void Start()
    {
        _originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        // Verifica si el juego est� en pausa antes de procesar el click
        if (PauseStatus.IsPaused) return;
            
        if (MiniGameStatus.ActiveMiniGame()) return; // si esta un mini juego no procese el click

        if (!_isBouncing && !CursorStatusInUI.IsPointerOverUI()) //pa que no rebote si se clickea en la UI
            StartCoroutine(DoBounce());
    }

    private IEnumerator DoBounce()
    {
        _isBouncing = true;

        Vector3 targetScale = _originalScale * _bounceMultiplier;
        float halfDuration = _bounceDuration / 2f;

        // Escala hacia arriba (fase de expansi�n)
        float t = 0f;
        while (t < halfDuration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(_originalScale, targetScale, t / halfDuration);
            yield return null;
        }

        // Escala hacia abajo (fase de contracci�n)
        t = 0f;
        while (t < halfDuration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, _originalScale, t / halfDuration);
            yield return null;
        }

        transform.localScale = _originalScale;
        _isBouncing = false;
    }

}
