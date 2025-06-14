using UnityEngine;

public class CharacterClickMove : MonoBehaviour // se encargara de mover al player al objetivo
{
    private Vector3 _targetPosition;  // Posición objetivo

    private float _speed = 15f;  // Velocidad de movimiento

    private bool _isMoving = false;
    private bool _canMove = true;     // Permitir o no el movimiento (se puede desactivar desde otro script)


    void Update()
    {
        if (!_canMove || !_isMoving) return;

        // Verifica si el juego está en pausa antes de procesar el click
        if (PauseStatus.IsPaused) return;

        if (MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        // Mover suavemente hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        // Al llegar, dejar de moverse
        if (transform.position == _targetPosition)
            _isMoving = false;
    }


   
    public void SetTarget(Vector3 targetPos) // Llamado por otros scripts para mover al jugador
    {
        _targetPosition = targetPos;
        _isMoving = true;
    }

  
    public void StopMove() => _isMoving = false;  // Detiene el movimiento

    public bool IsMoving () { return _isMoving; } //booleano pa saber si se mueve
}
