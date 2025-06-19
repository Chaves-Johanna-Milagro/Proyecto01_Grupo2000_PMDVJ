using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnim : MonoBehaviour
{
    private CharacterClickMove _moveChar;

    private Animator _anim;

    private string _nameScene;
    void Start()
    {
        _moveChar = GetComponent<CharacterClickMove>();
        _anim = GetComponent<Animator>();

        _nameScene = SceneManager.GetActiveScene().name;

        if (_nameScene == "WayToSchool2.0" || _nameScene == "School2.0" || _nameScene == "Classroom2.0" || _nameScene == "Playground2.0")
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        }
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

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (DecisionStatus.ActiveDecision()) return;

        if (CinematicStatus.ActiveCinematic()) return;


        bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1); // verificamos si se cambio de ropa usando el check activo/inactivo

        if (clickPos.x > transform.position.x)
        {
            if (useRP)
                _anim.SetBool("R_Walk_RP", true);

            else if (!useRP)
                _anim.SetBool("R_Walk_PJ", true);

            if (_nameScene == "WayToSchool2.0" || _nameScene == "School2.0")
            {
                _anim.SetBool("R_Walk_MP", true);
            };
        }
        else if (clickPos.x < transform.position.x)
        {
            if (useRP)
                _anim.SetBool("L_Walk_RP", true);
            else if (!useRP)
                _anim.SetBool("L_Walk_PJ", true);

            if (_nameScene == "WayToSchool2.0" || _nameScene == "School2.0")
            {
                _anim.SetBool("L_Walk_MP", true);
            };
        }
    }

    void HandleIdleTransition()
    {
        if (!_moveChar.IsMoving() || ClicEnInteractuable())
        {
            ResetAllBools();

            bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1); // Revisamos de nuevo porsi la dudas

            if (useRP)
                _anim.SetBool("Idle_RP", true);
            else if (!useRP)
                _anim.SetBool("Idle_PJ", true);

            if (_nameScene == "WayToSchool2.0" || _nameScene == "School2.0")
            {
                _anim.SetBool("Idle_MP", true);
            };
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
