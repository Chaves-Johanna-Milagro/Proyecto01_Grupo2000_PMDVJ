using UnityEngine;

public class SimpleHighlight : MonoBehaviour
{
    [SerializeField] private GameObject highlightObject; // el hijo que se ilumina
    [SerializeField] private float fadeSpeed = 5f;       // Qué tan rápido aparece/desaparece

    private Material highlightMat;
    private Color targetColor;
    private Color currentColor;

    void Start()
    {
        // Obtenemos el material del objeto que se ilumina
        Renderer rend = highlightObject.GetComponent<Renderer>();
        highlightMat = rend.material;
        currentColor = highlightMat.color;
        targetColor = currentColor;
    }

    void Update()
    {
        // Suaviza el cambio de alfa
        currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * fadeSpeed);
        highlightMat.color = currentColor;
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
