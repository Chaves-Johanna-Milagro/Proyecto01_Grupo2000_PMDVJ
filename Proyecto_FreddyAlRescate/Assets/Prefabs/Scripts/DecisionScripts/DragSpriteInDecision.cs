using UnityEngine;

public class DragSpriteInDecision : MonoBehaviour
{
    private Vector3 _offset;
    private bool _isDragging = false;

    private Vector2 _minBounds;
    private Vector2 _maxBounds;

    public float padding = 1f; // margen  para que no toque los bordes exactos

    void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;
        if (CursorStatusInUI.IsPointerOverUI()) return;

        _offset = transform.position - GetMouseWorldPos();
        _isDragging = true;
    }

    void OnMouseUp()
    {
        if (PauseStatus.IsPaused) return;
        if (CursorStatusInUI.IsPointerOverUI()) return;

        _isDragging = false;
    }

    void Update()
    {
        if (PauseStatus.IsPaused) _isDragging = false;

        if (CursorStatusInUI.IsPointerOverUI()) _isDragging = false;

        if (MiniGameStatus.ActiveMiniGame()) _isDragging = false; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) _isDragging = false; // si hay alguna cinematica corriendo


        if (_isDragging)
        {
            // Recalcular los bordes actuales de la cámara
            Camera cam = Camera.main;
            Vector3 lowerLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 10f));
            Vector3 upperRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 10f));

            _minBounds = new Vector2(lowerLeft.x + padding, lowerLeft.y + padding);
            _maxBounds = new Vector2(upperRight.x - padding, upperRight.y - padding);

            // Mover el objeto dentro de los límites visibles
            Vector3 newPos = GetMouseWorldPos() + _offset;

            newPos.x = Mathf.Clamp(newPos.x, _minBounds.x, _maxBounds.x);
            newPos.y = Mathf.Clamp(newPos.y, _minBounds.y, _maxBounds.y);

            transform.position = newPos;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
