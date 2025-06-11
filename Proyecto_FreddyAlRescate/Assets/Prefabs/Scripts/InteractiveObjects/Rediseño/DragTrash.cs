using UnityEngine;

public class DragTrash : MonoBehaviour
{
    private Vector3 _offset;
    private bool _isDragging = false;

    private Vector2 _min = new Vector2(-20f, -10f); //para limitar el arrastre
    private Vector2 _max = new Vector2(20f, 8f);

    private Collider2D _myCollider;
    private Collider2D _playerCollider;

    private CursorManager _cursorManager; //pa cambiar el cursor

    void Start()
    {
        _myCollider = GetComponent<Collider2D>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            _playerCollider = player.GetComponent<Collider2D>();

        _cursorManager = Object.FindFirstObjectByType<CursorManager>(); 
    }


    void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return; // si esta un mini juego no procese el click

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        _offset = transform.position - GetMouseWorldPos();
        _isDragging = true;

        // Ignorar colisiones mientras arrastra para evitar choques raros
        if (_playerCollider != null)
            Physics2D.IgnoreCollision(_myCollider, _playerCollider, true);

        _cursorManager?.SetCursorDrag();
    }

    void OnMouseUp()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return; // si esta un mini juego no procese el click

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        _isDragging = false;

        _cursorManager?.SetCursorDefault();
    }

    void Update()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) _isDragging = false;

        if (MiniGameStatus.ActiveMiniGame()) _isDragging = false; // si esta un mini juego no procese el click

        if (CinematicStatus.ActiveCinematic()) _isDragging = false; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) _isDragging = false; // si hay alguna desicion corriendo

        if (_isDragging)
        {
            Vector3 newPos = GetMouseWorldPos() + _offset;

            newPos.x = Mathf.Clamp(newPos.x, _min.x, _max.x);
            newPos.y = Mathf.Clamp(newPos.y, _min.y, _max.y);

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
