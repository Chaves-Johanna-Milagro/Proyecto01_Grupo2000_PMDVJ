using UnityEngine;

public class ObjectName : MonoBehaviour
{
    private bool isMouseOver = false;
    private Vector3 screenPosition;

    private GUIStyle labelStyle;

    void Start()
    {
        // Estilo para la etiqueta
        labelStyle = new GUIStyle();

        // Texto blanco, negrita, centrado
        labelStyle.fontSize = 40;
        labelStyle.fontStyle = FontStyle.Bold;
        labelStyle.normal.textColor = Color.white;
        labelStyle.alignment = TextAnchor.MiddleCenter;
        labelStyle.padding = new RectOffset(8, 8, 4, 4);

        // Fondo negro semitransparente
        Texture2D bgTexture = new Texture2D(1, 1);
        bgTexture.SetPixel(0, 0, new Color(0f, 0f, 0f, 0.6f)); // negro con 60% de opacidad
        bgTexture.Apply();

        labelStyle.normal.background = bgTexture;
    }

    void OnMouseEnter()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        isMouseOver = true;
    }

    void OnMouseExit()
    {
        isMouseOver = false;
    }

    void Update()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        // Solo actualiza la posición si el mouse está encima
        if (isMouseOver)
        {
            screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        }
    }

    void OnGUI()
    {
        if (isMouseOver)
        {
            Vector2 textSize = labelStyle.CalcSize(new GUIContent(gameObject.name));//obtener el tamaño del nombre

            Vector2 labelPosition = new Vector2(screenPosition.x, Screen.height - screenPosition.y - 30);

            Rect labelRect = new Rect(
                            labelPosition.x - textSize.x / 2f,
                            labelPosition.y,
                            textSize.x + 1f,
                            textSize.y
            );

            GUI.Label(labelRect, gameObject.name, labelStyle);

        }
    }
}
