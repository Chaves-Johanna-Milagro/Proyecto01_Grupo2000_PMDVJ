using UnityEngine;

public class MoveCharTuto : MonoBehaviour
{
    private Vector3 _targetPosition;  // Posición objetivo

    private float _speed = 15f;  // Velocidad de movimiento

    private bool _isMoving = false;
    private bool _canMove = true;     // Permitir o no el movimiento (se puede desactivar desde otro script)

    private Vector2 _min = new Vector2(-20f, -10f); // Límites para el movimiento
    private Vector2 _max = new Vector2(20f, 8f);

    void Update()
    {
        if (!_canMove) return;

        if (PauseStatus.IsPaused) return;
        if (MiniGameStatus.ActiveMiniGame()) return;
        if (CinematicStatus.ActiveCinematic()) return;
        if (DecisionStatus.ActiveDecision()) return;

        // Procesar el clic aunque no se esté moviendo
        if (Input.GetMouseButtonDown(0) && !(ClicEnInteractuable() || CursorStatusInUI.IsPointerOverUI()))
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = -0.2f;

            target.x = Mathf.Clamp(target.x, _min.x, _max.x);
            target.y = Mathf.Clamp(target.y, _min.y, _max.y);

            SetTarget(target);
        }

        // Solo mover si está activado el movimiento
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

            if (transform.position == _targetPosition || CursorStatusInUI.IsPointerOverUI())
                _isMoving = false;
        }
    }

    public void SetTarget(Vector3 targetPos) // Llamado por otros scripts para mover al jugador
    {
        _targetPosition = targetPos;
        _isMoving = true;
    }

    private bool ClicEnInteractuable() // Verifica si el clic fue sobre un objeto con tag "Interactuable"
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        return hit.collider != null && hit.collider.CompareTag("Interactuable");
    }

    public void StopMove() => _isMoving = false;  // Detiene el movimiento

    public bool IsMoving() { return _isMoving; } //booleano pa saber si se mueve
}
