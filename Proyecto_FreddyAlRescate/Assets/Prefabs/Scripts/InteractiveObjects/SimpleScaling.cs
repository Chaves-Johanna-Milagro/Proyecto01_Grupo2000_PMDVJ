using UnityEngine;
using UnityEngine.Audio;

public class SimpleScaling : MonoBehaviour
{
    // Porcentaje de aumento relativo (por ejemplo, 1.1 = 10% más grande)
     private float _scaleMultiplier = 1.1f;
     private float _scaleSpeed = 5f;

    private Vector3 _originalScale;
    private Vector3 _targetScale;  //la escala aumentada
    public AudioSource hoverButton;

    private bool _isScaling = false;
    
   // public AudioSource hoverButton;

    private void Start()
    {
        _originalScale = transform.localScale;

        // Calcula la escala como un multiplicador relativo
        _targetScale = _originalScale * _scaleMultiplier;
    }

    private void OnMouseEnter()
    {
        _isScaling = true;
        hoverButton.Play();
    }

    private void OnMouseExit()
    {
        _isScaling = false;
    }

    private void Update()
    {
        // Elige la escala objetivo dependiendo del estado del mouse (si paso sobre el obj)
        Vector3 targetScaling = _isScaling ? _targetScale : _originalScale;

        // Transición suave hacia la escala objetivo
        transform.localScale = Vector3.Lerp(transform.localScale, targetScaling, Time.deltaTime * _scaleSpeed);
    }
}
