using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource buttonSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonSound != null && !buttonSound.isPlaying)
        {
            buttonSound.Play();
        }
    }
}