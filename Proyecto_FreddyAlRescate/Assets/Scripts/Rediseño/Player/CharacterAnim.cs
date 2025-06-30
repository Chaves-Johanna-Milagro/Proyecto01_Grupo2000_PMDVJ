using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnim : MonoBehaviour
{
    private CharacterClickMove _moveChar;
    private Animator _anim;

    private string _nameScene;

    private AudioSource _audioSource;

    void Start()
    {
        _moveChar = GetComponent<CharacterClickMove>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        _nameScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ClicEnInteractuable())
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPos.z = -0.1f;
            HandleWalkAnimation(clickPos);
        }

        HandleIdleTransition();
    }

    void HandleWalkAnimation(Vector3 clickPos)
    {
        ResetAllBools();

        if (PauseStatus.IsPaused || CursorStatusInUI.IsPointerOverUI() || MiniGameStatus.ActiveMiniGame() || DecisionStatus.ActiveDecision() || CinematicStatus.ActiveCinematic())
            return;

        bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1);

        bool toRight = clickPos.x > transform.position.x;

        if (useRP)
            _anim.SetBool(toRight ? "R_Walk_RP" : "L_Walk_RP", true);
        else
            _anim.SetBool(toRight ? "R_Walk_PJ" : "L_Walk_PJ", true);

        _audioSource.Play();
    }

    void HandleIdleTransition()
    {
        if (!_moveChar.IsMoving() || ClicEnInteractuable())
        {
            ResetAllBools();

            bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1);
            
            if (useRP)
                _anim.SetBool("Idle_RP", true);
            else
                _anim.SetBool("Idle_PJ", true);

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
    }

    private bool ClicEnInteractuable() // Verifica si el clic fue sobre un objeto con tag "Interactuable"
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        return hit.collider != null && hit.collider.CompareTag("Interactuable");
    }
}
