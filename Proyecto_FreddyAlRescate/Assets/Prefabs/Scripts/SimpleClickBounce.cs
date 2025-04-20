using UnityEngine;
using System.Collections;

public class SimpleClickBounce : MonoBehaviour
{
    private float bounceMultiplier = 1.2f;   // cuánto se agranda en el rebote
    private float bounceDuration = 0.4f;     // duración total del rebote

    private Vector3 originalScale;
    private bool isBouncing = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        if (!isBouncing)
            StartCoroutine(DoBounce());
    }

    private IEnumerator DoBounce()
    {
        isBouncing = true;

        Vector3 targetScale = originalScale * bounceMultiplier;
        float halfDuration = bounceDuration / 2f;

        // Escala hacia arriba (fase de expansión)
        float t = 0f;
        while (t < halfDuration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t / halfDuration);
            yield return null;
        }

        // Escala hacia abajo (fase de contracción)
        t = 0f;
        while (t < halfDuration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t / halfDuration);
            yield return null;
        }

        transform.localScale = originalScale;
        isBouncing = false;
    }
}
