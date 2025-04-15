using UnityEngine;
using UnityEngine.EventSystems;

public class LibretaAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator _transitionAnimator;

    void Start()
    {
        _transitionAnimator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _transitionAnimator.SetBool("MouseEnter", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _transitionAnimator.SetBool("MouseEnter", false);
    }
}
