using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnim : MonoBehaviour
{
    private CharacterClickMove _moveChar;
    private Animator _anim;

    private string _nameScene;
    private bool _sceneWithBackpack; // Escenas donde el personaje puede tener la mochila (colgada o puesta)

    void Start()
    {
        _moveChar = GetComponent<CharacterClickMove>();
        _anim = GetComponent<Animator>();

        // Guarda el nombre de la escena actual
        _nameScene = SceneManager.GetActiveScene().name;

        // Solo en escenas diferentes a Morning y Breakfast se puede llevar mochila
        _sceneWithBackpack = _nameScene != "Morning2.0" && _nameScene != "Breackfast2.0";

        // Ajustamos el tamaño del personaje en las escenas 
        if (_sceneWithBackpack)
            transform.localScale = new Vector3(0.11f, 0.11f, 1f);
    }

    void Update()
    {
        // Solo manejamos movimiento si el clic NO es sobre un objeto interactuable
        if (Input.GetMouseButtonDown(0) && !ClicEnInteractuable())
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPos.z = -0.2f; // Z fijo
            HandleWalkAnimation(clickPos);
        }

        // Si el personaje no se mueve, transiciona a idle
        HandleIdleTransition();
    }


    void HandleWalkAnimation(Vector3 clickPos)
    {
        ResetAllBools(); // Desactiva todas las animaciones previas

        if (PauseStatus.IsPaused) return;// Verifica si el juego está en pausa 

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo


        bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1); // si se cambio la ropa

        // CAMINAR EN ESCENAS SIN MOCHILA
        if (!_sceneWithBackpack)
        {
            if (clickPos.x > transform.position.x)
                _anim.SetBool(useRP ? "R_Walk_RP" : "R_Walk_PJ", true);
            else
                _anim.SetBool(useRP ? "L_Walk_RP" : "L_Walk_PJ", true);
        }
        // CAMINAR EN ESCENAS CON MOCHILA
        else
        {
            if (useRP)
            {
                if (RecessStatus.HangBackpack)
                {
                    // Ropa puesta y mochila colgada
                    if (clickPos.x > transform.position.x)
                        _anim.SetBool("R_Walk_RP", true);
                    else
                        _anim.SetBool("L_Walk_RP", true);
                }
                else
                {
                    // Ropa puesta pero con mochila 
                    if (clickPos.x > transform.position.x)
                        _anim.SetBool("R_Walk_MP", true);
                    else
                        _anim.SetBool("L_Walk_MP", true);
                }
            }
            else
            {
                // Todavía en pijama
                if (clickPos.x > transform.position.x)
                    _anim.SetBool("R_Walk_PJ", true);
                else
                    _anim.SetBool("L_Walk_PJ", true);
            }
        }
    }

    void HandleIdleTransition()
    {
        // Solo pasamos a Idle si no se está moviendo o hizo clic sobre algo interactuable
        if (!_moveChar.IsMoving() || ClicEnInteractuable())
        {
            ResetAllBools();

            bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1);

            // IDLE EN ESCENAS SIN MOCHILA
            if (!_sceneWithBackpack)
            {
                _anim.SetBool(useRP ? "Idle_RP" : "Idle_PJ", true);
            }
            // IDLE EN ESCENAS CON MOCHILA
            else
            {
                if (useRP)
                {
                    if (RecessStatus.HangBackpack)
                        _anim.SetBool("Idle_RP", true);  // Mochila colgada
                    else
                        _anim.SetBool("Idle_MP", true);  // Mochila puesta
                }
                else
                {
                    _anim.SetBool("Idle_PJ", true); // En pijama
                }
            }
        }
    }
    void ResetAllBools()
    {
        _anim.SetBool("R_Walk_PJ", false);
        _anim.SetBool("L_Walk_PJ", false);
        _anim.SetBool("Idle_PJ", false);

        _anim.SetBool("R_Walk_RP", false);
        _anim.SetBool("L_Walk_RP", false);
        _anim.SetBool("Idle_RP", false);

        _anim.SetBool("R_Walk_MP", false);
        _anim.SetBool("L_Walk_MP", false);
        _anim.SetBool("Idle_MP", false);
    }


    private bool ClicEnInteractuable() // Verifica si el clic fue sobre un objeto con tag "Interactuable"
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        return hit.collider != null && hit.collider.CompareTag("Interactuable");
    }
}
