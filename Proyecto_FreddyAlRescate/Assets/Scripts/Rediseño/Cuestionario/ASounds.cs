using UnityEngine;
using UnityEngine.EventSystems;

public class ASounds : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler // pa que suenen al poner el cursor
{
    private AudioSource _aSound;  

    void Start()
    {
        _aSound = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_aSound != null) _aSound.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_aSound != null) _aSound.Stop();
    }
}
