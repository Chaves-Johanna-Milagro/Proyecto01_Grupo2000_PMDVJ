using UnityEngine;

public class DragSprite2_0 : MonoBehaviour
{
    private Vector3 _offset;
    private bool _isDragging = false;

    private Vector2 _min = new Vector2(-20f,-10f); //para limitar el arrastre
    private Vector2 _max = new Vector2(20f,8f);

    private CursorManager _cursorManager; //pa cambiar el cursor

    private void Start()
    {
        _cursorManager = Object.FindFirstObjectByType<CursorManager>();
    }
    void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        _offset = transform.position - GetMouseWorldPos();
        _isDragging = true;

        _cursorManager?.SetCursorDrag(); //cursor de arrastre
    }

    void OnMouseUp()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        _isDragging = false;
        _cursorManager?.SetCursorDefault(); //de nuevo al default
    }

    void Update()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) _isDragging = false;

        if (_isDragging)
        {
            Vector3  newPos = GetMouseWorldPos() + _offset;

            newPos.x = Mathf.Clamp(newPos.x,_min.x,_max.x);
            newPos.y = Mathf.Clamp(newPos.y,_min.y,_max.y);

            transform.position = newPos;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f; // distancia de la cámara
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}


