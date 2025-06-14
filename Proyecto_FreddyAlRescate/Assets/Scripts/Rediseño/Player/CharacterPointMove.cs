using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterPointMove : MonoBehaviour
{
    private CharacterClickMove _mover;

    private Vector2 _min = new Vector2(-20f, -10f); // Límites para el movimiento
    private Vector2 _max = new Vector2(20f, 8f);


    private Vector2 _minNav = new Vector2(-20f, -32f); //limites para la escen waytoschool
    private Vector2 _maxNav = new Vector2(20f, 32f); //limites para la escen waytoschool

    private string _nvlName;
    void Awake()
    {
        _mover = GetComponent<CharacterClickMove>();
        _nvlName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        
        if (PauseStatus.IsPaused) return;// Verifica si el juego está en pausa antes de procesar el click

        if (MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        if (Input.GetMouseButtonDown(0) && !(ClicEnInteractuable() || CursorStatusInUI.IsPointerOverUI())) //para que no se mueva si clickeo en un obj interactuable o en la UI
        {
            // Convertir la posición del mouse a coordenadas del mundo
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = -0.1f; // Asegura que se quede en el plano 2D

            if (_nvlName == "WayToSchool2.0")
            {
                // Limitar el target dentro del rango permitido
                target.x = Mathf.Clamp(target.x, _minNav.x, _maxNav.x);
                target.y = Mathf.Clamp(target.y, _minNav.y, _maxNav.y);
            } else
            {
                // Limitar el target dentro del rango permitido
                target.x = Mathf.Clamp(target.x, _min.x, _max.x);
                target.y = Mathf.Clamp(target.y, _min.y, _max.y);
            }
            
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
