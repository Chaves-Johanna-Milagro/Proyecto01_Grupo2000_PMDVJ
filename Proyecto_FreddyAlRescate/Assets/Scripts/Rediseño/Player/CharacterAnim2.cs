using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnim2 : MonoBehaviour // para las escenas de camino y en la escul
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

        transform.localScale = new Vector3(0.11f, 0.11f, 1f);
    }

    // Update is called once per frame
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
            if (RecessStatus.HangBackpack)
                _anim.SetBool("R_Walk_SM", true);
            else
                _anim.SetBool("R_Walk_MP", true);
        }
        else if (clickPos.x < transform.position.x)
        {
            if (RecessStatus.HangBackpack)
                _anim.SetBool("L_Walk_SM", true);
            else
                _anim.SetBool("L_Walk_MP", true);
        }

            _audioSource.Play();
    }


    void HandleIdleTransition()
    {
        if (!_moveChar.IsMoving() || ClicEnInteractuable())
        {
            ResetAllBools();

            if (RecessStatus.HangBackpack)
                _anim.SetBool("Idle_SM", true);
            else
                _anim.SetBool("Idle_MP", true);

            _audioSource.Stop();
        }
    }

    void ResetAllBools()
    {
        _anim.SetBool("R_Walk_MP", false);
        _anim.SetBool("L_Walk_MP", false);
        _anim.SetBool("Idle_MP", false);

        _anim.SetBool("R_Walk_SM", false);
        _anim.SetBool("L_Walk_SM", false);
        _anim.SetBool("Idle_SM", false);
    }

    private bool ClicEnInteractuable() // Verifica si el clic fue sobre un objeto con tag "Interactuable"
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        return hit.collider != null && hit.collider.CompareTag("Interactuable");
    }
}
