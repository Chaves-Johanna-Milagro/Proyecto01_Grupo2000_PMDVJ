using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnim : MonoBehaviour
{
    private CharacterClickMove _moveChar;
    private Animator _anim;

    private string _nameScene;
    private bool _sceneWithBackpack; // Escenas donde el personaje puede tener la mochila (colgada o puesta)

    private AudioSource _audioSource;
    void Start()
    {
        _moveChar = GetComponent<CharacterClickMove>();
        _anim = GetComponent<Animator>();

        // Guarda el nombre de la escena actual
        _nameScene = SceneManager.GetActiveScene().name;

        // Solo en escenas diferentes a Morning y Breakfast se puede llevar mochila
        _sceneWithBackpack = _nameScene != "Morning2.0" && _nameScene != "Breackfast2.0";

        // la hacemo ma chiquito
        if (_sceneWithBackpack)
        {
            transform.localScale = new Vector3(0.11f, 0.11f, 1f);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Solo manejamos movimiento si el clic NO es sobre un objeto interactuable
        if (Input.GetMouseButtonDown(0) && !ClicEnInteractuable())
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPos.z = -0.1f;

            HandleWalkAnimation(clickPos);

            _audioSource.Play();
        }

        // Si el personaje no se mueve, transiciona a idle
        HandleIdleTransition();
    }

    void HandleWalkAnimation(Vector3 clickPos)
    {
        ResetAllBools(); // Desactiva todas las animaciones previas

        if (PauseStatus.IsPaused) return; // Verifica si el juego está en pausa
        if (CursorStatusInUI.IsPointerOverUI()) return;
        if (MiniGameStatus.ActiveMiniGame()) return; // Verifica que no esté activo un minijuego
        if (DecisionStatus.ActiveDecision()) return; // Si hay una decisión activa
        if (CinematicStatus.ActiveCinematic()) return; // Si hay una cinemática activa

        bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1); // Verifica si se cambió la ropa

        if (clickPos.x > transform.position.x)
        {
            if (useRP)
                _anim.SetBool("R_Walk_RP", true);
            else
                _anim.SetBool("R_Walk_PJ", true);

            if (!RecessStatus.HangBackpack && _sceneWithBackpack)
            {
                _anim.SetBool("R_Walk_MP", true);
            }
            if (!useRP && RecessStatus.HangBackpack)
            {
                _anim.SetBool("R_Walk_RP", true);
            }
        }
        else if (clickPos.x < transform.position.x)
        {
            if (useRP)
                _anim.SetBool("L_Walk_RP", true);
            else
                _anim.SetBool("L_Walk_PJ", true);

            if (!RecessStatus.HangBackpack && _sceneWithBackpack)
            {
                _anim.SetBool("L_Walk_MP", true);
            }

            if (!useRP && RecessStatus.HangBackpack)
            {
                _anim.SetBool("L_Walk_RP", true);
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

            if (useRP)
                _anim.SetBool("Idle_RP", true);
            else
                _anim.SetBool("Idle_PJ", true);

            if (!RecessStatus.HangBackpack && _sceneWithBackpack)
            {
                _anim.SetBool("Idle_MP", true);
            }

            // Si colgó la mochila, volvemos a usar el idle de ropa puesta normal
            if (!useRP && RecessStatus.HangBackpack)
            {
                _anim.SetBool("Idle_RP", true);
            }

            _audioSource.Stop();
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
