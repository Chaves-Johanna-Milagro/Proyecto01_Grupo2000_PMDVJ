using UnityEngine;

public class DragSprite : MonoBehaviour
{
    private Vector3 _offset;
    private bool _isDragging = false;

    void OnMouseDown()
    {
        _offset = transform.position - GetMouseWorldPos();
        _isDragging = true;
    }

    void OnMouseUp()
    {
        _isDragging = false;
    }

    void Update()
    {
        if (_isDragging)
        {
            transform.position = GetMouseWorldPos() + _offset;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f; // distancia de la cámara
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
