using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private CharacterClickMove _moveChar;

    private Animator _anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _moveChar = GetComponent<CharacterClickMove>();

        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPos.z = -0.1f;

            if (clickPos.x > transform.position.x)
            {
                _anim.SetBool("R_Walk_PJ", true);
                _anim.SetBool("Idle_PJ", false);
                _anim.SetBool("L_Walk_PJ", false);
            }
            else if (clickPos.x < transform.position.x)
            {
                _anim.SetBool("L_Walk_PJ", true);
                _anim.SetBool("Idle_PJ", false);
                _anim.SetBool("R_Walk_PJ", false);
            }
        }

        // Siempre chequeamos el estado de movimiento, cada frame
        if (_moveChar.IsMoving() == false)
        {
            _anim.SetBool("Idle_PJ", true);
            _anim.SetBool("R_Walk_PJ", false);
            _anim.SetBool("L_Walk_PJ", false);
        }
    }
}
