using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;
    private Vector2 movementInput;
    private Vector2 clickTarget;
    private bool isMovingToClick = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ; // congela la rotacion y el eje z 
    }

    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if (movementInput != Vector2.zero)
        {
            isMovingToClick = false;
            movementInput = movementInput.normalized; // hace que el movimiento diagonal sea igual al de los demas y no sea tan rapido
        }
        else if (Input.GetMouseButtonDown(0)) // clic izquierdo
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition); // toma la posicion del mouse en pantalla y lo convierte a una posicion en el mundo
            clickTarget = new Vector2(mouseWorld.x, mouseWorld.y); // se guarda esa posicion como el destino
            isMovingToClick = true;
        }
        // se calcula la direccion hacia donde debe ir el jugador
        if (isMovingToClick)
        {
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = (clickTarget - position); 

            if (direction.magnitude < 0.1f) // si esta cerca del punto seleccionado, se detiene el movimiento
            {
                movementInput = Vector2.zero;
                isMovingToClick = false;
            }
            else // si no, se normaliza la direccion para que se mueva a velocidad constante
            {
                movementInput = direction.normalized; 
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput * speed;
    }
}
