using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnim3 : MonoBehaviour //para la escena de la noche
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

    }

    private void LateUpdate()
    {
        HandleIdleTransition();
    }

    void HandleWalkAnimation(Vector3 clickPos)
    {
        ResetAllBools();

        if (PauseStatus.IsPaused || CursorStatusInUI.IsPointerOverUI() || MiniGameStatus.ActiveMiniGame() || DecisionStatus.ActiveDecision() || CinematicStatus.ActiveCinematic())
            return;


        if (clickPos.x > transform.position.x)
        {
            bool usePJ = ChecksStatus.IsCheckActive("Night2.0", 1);

            if (usePJ)
                _anim.SetBool("R_Walk_PJ", true);
            else
                _anim.SetBool("R_Walk_RP", true);
        }
        else if (clickPos.x < transform.position.x)
        {
            bool usePJ = ChecksStatus.IsCheckActive("Night2.0", 1);

            if (usePJ)
                _anim.SetBool("L_Walk_PJ", true);
            else
                _anim.SetBool("L_Walk_RP", true);
        }

        _audioSource.Play();
    }


    void HandleIdleTransition()
    {
        if (!_moveChar.IsMoving() || ClicEnInteractuable())
        {
            ResetAllBools();

            bool usePJ = ChecksStatus.IsCheckActive("Night2.0", 1);

            if (usePJ)
                _anim.SetBool("Idle_PJ", true);
            else
                _anim.SetBool("Idle_RP", true);

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
