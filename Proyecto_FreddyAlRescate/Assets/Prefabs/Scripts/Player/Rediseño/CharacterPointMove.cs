using UnityEngine;

public class CharacterPointMove : MonoBehaviour
{
    private CharacterClickMove _mover;

    private Vector2 _min = new Vector2(-25f, -10f); // Límites para el movimiento
    private Vector2 _max = new Vector2(25f, 8f);

    void Awake()
    {
        _mover = GetComponent<CharacterClickMove>();
    }

    void Update()
    {
        if (MiniGameStatus.ActiveMiniGame()) return; //evitar el movimiento si hay un minijuego

        if (PauseStatus.IsPaused) return; //evitar el movimiento si  estsa en pausa por si caso

        if (Input.GetMouseButtonDown(0) && !(ClicEnInteractuable() || CursorStatusInUI.IsPointerOverUI())) //para que no se mueva si clickeo en un obj interactuable o en la UI
        {
            // Convertir la posición del mouse a coordenadas del mundo
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = -0.1f; // Asegura que se quede en el plano 2D


            // Limitar el target dentro del rango permitido
            target.x = Mathf.Clamp(target.x, _min.x, _max.x);
            target.y = Mathf.Clamp(target.y, _min.y, _max.y);

            
            _mover.SetTarget(target);// Enviar esa posición al script de movimiento
        }
    }

    
    private bool ClicEnInteractuable() // Verifica si el clic fue sobre un objeto con tag "Interactuable"
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        return hit.collider != null && hit.collider.CompareTag("Interactuable");
    }

}
