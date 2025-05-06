using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeSprite : MonoBehaviour
{
    public AudioSource correctSound;

    public void OnMouseDown()
    {
        Transform accionInComplete = transform.GetChild(0);
        Transform accionComplete = transform.GetChild(1);

        accionInComplete.gameObject.SetActive(false);
        accionComplete.gameObject.SetActive(true);
        correctSound.Play();

    }

}
