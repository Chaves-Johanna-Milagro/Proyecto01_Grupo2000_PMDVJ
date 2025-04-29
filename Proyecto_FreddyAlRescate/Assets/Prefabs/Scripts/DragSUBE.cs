using UnityEngine;

public class DragSUBE : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;
    private Plane dragPlane;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // agarrar tarjeta con click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isDragging = true;
                    dragPlane = new Plane(Vector3.forward, transform.position); 
                    float distance;
                    dragPlane.Raycast(ray, out distance);
                    offset = transform.position - ray.GetPoint(distance);
                    Debug.Log("Tarjeta agarrada");
                }
            }
        }

        // Soltar
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Mover tarjeta
        if (isDragging)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            float distance;
            if (dragPlane.Raycast(ray, out distance))
            {
                Vector3 point = ray.GetPoint(distance);
                transform.position = point + offset;
            }
        }
    }

    
}
