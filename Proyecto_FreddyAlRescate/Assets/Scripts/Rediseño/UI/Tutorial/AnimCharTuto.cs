using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimCharTuto : MonoBehaviour
{
    private MoveCharTuto _moveChar;
    private Animator _anim;

    private string _nameScene;

    private AudioSource _audioSource;

    void Start()
    {
        _moveChar = GetComponent<MoveCharTuto>();
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
            _anim.SetBool("R_Walk", true);
        }
        else if (clickPos.x < transform.position.x)
        {
            _anim.SetBool("L_Walk", true);
        }

        _audioSource.Play();
    }


    void HandleIdleTransition()
    {
        if (!_moveChar.IsMoving() || ClicEnInteractuable())
        {
            ResetAllBools();

            _anim.SetBool("Idle", true);
            _audioSource.Stop();
        }
        
    }

    void ResetAllBools()
    {
        _anim.SetBool("R_Walk", false);
        _anim.SetBool("L_Walk", false);
        _anim.SetBool("Idle", false);
    }

    private bool ClicEnInteractuable() // Verifica si el clic fue sobre un objeto con tag "Interactuable"
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        return hit.collider != null && hit.collider.CompareTag("Interactuable");
    }
}
