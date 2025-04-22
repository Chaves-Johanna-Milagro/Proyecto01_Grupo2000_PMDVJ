using UnityEngine;
using UnityEngine.Audio;

public class SimpleScaling : MonoBehaviour
{
    // Porcentaje de aumento relativo (por ejemplo, 1.1 = 10% más grande)
     private float ScaleMultiplier = 1.1f;
     private float scaleSpeed = 5f;

    private Vector3 originalScale;
    private Vector3 targetScale;  //la escala aumentada
    public AudioSource hoverButton;

    private bool isScaling = false;

    private void Start()
    {
        originalScale = transform.localScale;

        // Calcula la escala como un multiplicador relativo
        targetScale = originalScale * ScaleMultiplier;
    }

    private void OnMouseEnter()
    {
        isScaling = true;
        hoverButton.Play();
    }

    private void OnMouseExit()
    {
        isScaling = false;
    }

    private void Update()
    {
        // Elige la escala objetivo dependiendo del estado del mouse (si paso sobre el obj)
        Vector3 targetScaling = isScaling ? targetScale : originalScale;

        // Transición suave hacia la escala objetivo
        transform.localScale = Vector3.Lerp(transform.localScale, targetScaling, Time.deltaTime * scaleSpeed);
    }
}
