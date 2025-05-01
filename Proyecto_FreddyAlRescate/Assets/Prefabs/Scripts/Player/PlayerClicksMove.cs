using UnityEngine;

public class PlayerClicksMove : MonoBehaviour
{
    private Vector3 _targetPosition;
    private bool _isMoving = false;
    private float _speed = 5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Detectar el clic izquierdo
        {
            _targetPosition = GetMouseWorldPos();
            _isMoving = true;
        }

        if (_isMoving)
        {
            MovePlayer();
            RotatePlayer();
        } 

        DetectDecisionAndMiniGame();
    }

    private void MovePlayer()
    {
        // Mover al jugador hacia la posición del click
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        // Si el jugador llega a la posición, detener el movimiento
        if (transform.position == _targetPosition)
        {
            _isMoving = false;
        }
       
    }

    private void RotatePlayer() 
    { 
        // Rotar al jugador hacia la dirección del cursor mientras se mueve
        Vector3 dir = GetMouseWorldPos() - transform.position;
        if (dir != Vector3.zero)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

   // Obtener la posición del mouse en el mundo
    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 8f;  // Distancia de la cámara
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        // Cuando colisiona con cualquier objeto, se detiene
        _isMoving = false;
    }

    public void DetectDecisionAndMiniGame() //desactivar el movimiento si esta desidiendo o en un minijuego
    {
        GameObject pause = GameObject.FindGameObjectWithTag("Pause");
        GameObject decision = GameObject.FindGameObjectWithTag("Decision");
        GameObject miniGame = GameObject.FindGameObjectWithTag("MiniGame");

        if(pause != null || decision != null || miniGame != null) { _isMoving = false; }
        
    }
}
