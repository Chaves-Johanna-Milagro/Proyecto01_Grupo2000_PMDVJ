using UnityEngine;

public class AutoScaleObject : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Vector2 referencePosition = new Vector2(0.5f, 0.5f); 
    [SerializeField] private Vector2 referenceScale = Vector2.one; // escala base relativa al fondo

    void Start()
    {
        if (cam == null)
            cam = Camera.main;

        AdjustObject();
    }

    void AdjustObject()
    {
        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        // posición relativa dentro del fondo
        float posX = (referencePosition.x - 0.5f) * width;
        float posY = (referencePosition.y - 0.5f) * height;

        transform.localPosition = new Vector3(posX, posY, transform.localPosition.z);

        // escala proporcional al fondo
        transform.localScale = new Vector3(width * referenceScale.x, height * referenceScale.y, 1f);
    }
}
