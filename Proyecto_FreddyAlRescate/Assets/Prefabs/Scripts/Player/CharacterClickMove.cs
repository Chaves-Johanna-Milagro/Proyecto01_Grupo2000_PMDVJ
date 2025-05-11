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


}
