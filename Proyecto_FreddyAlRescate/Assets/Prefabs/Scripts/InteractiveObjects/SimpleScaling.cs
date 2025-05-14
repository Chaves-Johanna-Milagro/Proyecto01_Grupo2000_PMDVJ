using UnityEngine;
using UnityEngine.Audio;

public class SimpleScaling : MonoBehaviour
{
    // Porcentaje de aumento relativo (por ejemplo, 1.1 = 10% más grande)
     private float _scaleMultiplier = 1.1f;
     private float _scaleSpeed = 5f;

    private Vector3 _originalScale;
    private Vector3 _targetScale;  //la escala aumentada
   
    private bool _isScaling = false;

    public AudioSource hoverButton;
    

    private void Start()
    {
        _originalScale = transform.localScale;

        // Calcula la escala como un multiplicador relativo
        _targetScale = _originalScale * _scaleMultiplier;
    }

    private void OnMouseEnter()
    {
        // Verifica si el juego está en pausa antes de procesar el click
        if (PauseStatus.IsPaused)
            return;

        _isScaling = true;
        if (hoverButton != null) hoverButton.Play();
    }

    private void OnMouseExit()
    {
        _isScaling = false;
    }

    private void Update()
    {
        if (CursorStatusInUI.IsPointerOverUI()) _isScaling = false; //si el cursor esta sobre la UI se desactiva la escala

        if (MiniGameStatus.ActiveMiniGame()) _isScaling = false; //si esta en un minijuego desactive la escala


        // Elige la escala objetivo dependiendo del estado del mouse (si paso sobre el obj)
        Vector3 targetScaling = _isScaling ? _targetScale : _originalScale;

        // Transición suave hacia la escala objetivo
        transform.localScale = Vector3.Lerp(transform.localScale, targetScaling, Time.deltaTime * _scaleSpeed);
    }

}
