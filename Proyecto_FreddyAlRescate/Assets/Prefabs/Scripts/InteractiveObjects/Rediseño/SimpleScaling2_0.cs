using UnityEngine;

public class SimpleScaling2_0 : MonoBehaviour
{
    // Porcentaje de aumento relativo (por ejemplo, 1.1 = 10% más grande)
    private float _scaleMultiplier = 1.1f;
    private float _scaleSpeed = 5f;

    private Vector3 _originalScale;
    private Vector3 _targetScale;  //la escala aumentada

    private bool _isScaling = false;

    private AudioSource _hoverButton;


    private void Start()
    {
        _originalScale = transform.localScale;

        // Calcula la escala como un multiplicador relativo
        _targetScale = _originalScale * _scaleMultiplier;

        _hoverButton = GetComponent<AudioSource>();
    }

    private void OnMouseEnter()
    {
        // Verifica si el juego está en pausa antes de procesar el click
        if (PauseStatus.IsPaused) return;         
        
        if(MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        _isScaling = true;
        if (_hoverButton != null) _hoverButton.Play();
    }

    private void OnMouseExit()
    {
        _isScaling = false;
    }

    private void Update()
    {
        if (CursorStatusInUI.IsPointerOverUI()) _isScaling = false; //si el cursor esta sobre la UI se desactiva la escala

        if (MiniGameStatus.ActiveMiniGame()) _isScaling = false; //si esta en un minijuego desactive la escala

        if (CinematicStatus.ActiveCinematic()) _isScaling = false; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) _isScaling = false; // si hay alguna desicion corriendo


        // Elige la escala objetivo dependiendo del estado del mouse (si paso sobre el obj)
        Vector3 targetScaling = _isScaling ? _targetScale : _originalScale;

        // Transición suave hacia la escala objetivo
        transform.localScale = Vector3.Lerp(transform.localScale, targetScaling, Time.deltaTime * _scaleSpeed);
    }
}
