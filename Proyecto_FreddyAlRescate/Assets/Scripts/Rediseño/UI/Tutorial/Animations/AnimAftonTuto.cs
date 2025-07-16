using UnityEngine;

public class AnimAftonTuto : MonoBehaviour
{
    private GuiaAftonT _gAftont;

    private Animator _anim;

    void Start()
    {
        _gAftont = GetComponent<GuiaAftonT>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_gAftont.IsActiveGuia())
        {
            if (_gAftont.GetCurrentAnim() == 1) _anim.SetBool("G_Walk", true);
            if (_gAftont.GetCurrentAnim() == 2)_anim.SetBool("G_Interact", true);
            if (_gAftont.GetCurrentAnim() == 3)_anim.SetBool("G_Buttons", true);
            if (_gAftont.GetCurrentAnim() == 4)_anim.SetBool("G_BPause", true);
            if (_gAftont.GetCurrentAnim() == 5)_anim.SetBool("G_BNotes", true);
            if (_gAftont.GetCurrentAnim() == 6)_anim.SetBool("G_BKind", true);
            if (_gAftont.GetCurrentAnim() == 7)_anim.SetBool("G_BMiniA", true);
        }
        if (!_gAftont.IsActiveGuia()) ResetsAnims();
    }
    private void ResetsAnims()
    {
        _anim.SetBool("G_Walk", false);
        _anim.SetBool("G_Interact", false);
        //_anim.SetBool("G_Buttons", false);
        _anim.SetBool("G_BPause", false);
        _anim.SetBool("G_BNotes", false);
        _anim.SetBool("G_BKind", false);
        _anim.SetBool("G_BMiniA", false);
    }
}
