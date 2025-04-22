using UnityEngine;

public class PauseButtonAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PausePanelAnimationUp() 
    { 
        _animator.SetBool("PauseEnter",false);
    }
    public void PausePanelAnimationDown()
    {
        _animator.SetBool("PauseEnter", true);
    }


}
