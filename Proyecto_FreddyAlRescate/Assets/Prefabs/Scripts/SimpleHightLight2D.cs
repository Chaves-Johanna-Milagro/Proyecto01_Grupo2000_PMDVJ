using UnityEngine;

public class SimpleHightLight2D : MonoBehaviour
{
    private float fadeSpeed = 5f;
    private SpriteRenderer spriteRenderer;
    private Color targetColor;
    private Color currentColor;

    void Start()
    {
        Transform _light = transform.GetChild(2);
        spriteRenderer = _light.GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;
        targetColor = currentColor;
    }

    void Update()
    {
        // Suaviza el cambio de alfa
        currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * fadeSpeed);
        spriteRenderer.color = currentColor;
    }

    void OnMouseEnter()
    {
        // Alpha a 1 (visible)
        targetColor.a = 1f;
    }

    void OnMouseExit()
    {
        // Alpha a 0 (invisible)
        targetColor.a = 0f;
    }

}
