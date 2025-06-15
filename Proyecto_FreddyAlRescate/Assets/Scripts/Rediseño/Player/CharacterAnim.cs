using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private CharacterClickMove _moveChar;

    private Animator _anim;

    void Start()
    {
        _moveChar = GetComponent<CharacterClickMove>();
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

        bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1); // verificamos si se cambio de ropa usando el check activo/inactivo

        if (clickPos.x > transform.position.x)
        {
            if (useRP)
                _anim.SetBool("R_Walk_RP", true);
            else
                _anim.SetBool("R_Walk_PJ", true);
        }
        else if (clickPos.x < transform.position.x)
        {
            if (useRP)
                _anim.SetBool("L_Walk_RP", true);
            else
                _anim.SetBool("L_Walk_PJ", true);
        }
    }

    void HandleIdleTransition()
    {
        if (!_moveChar.IsMoving())
        {
            ResetAllBools();

            bool useRP = ChecksStatus.IsCheckActive("Morning2.0", 1); // Revisamos de nuevo porsi la dudas

            if (useRP)
                _anim.SetBool("Idle_RP", true);
            else
                _anim.SetBool("Idle_PJ", true);
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
}
