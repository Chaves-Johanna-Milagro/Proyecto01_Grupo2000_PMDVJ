using UnityEngine;
using System.Collections;

public class QSounds : MonoBehaviour
{
    private AudioSource _qSound;

    private void Start()
    {
        //Obtiene su audio sourse
        _qSound = GetComponent<AudioSource>();

        if (_qSound != null) _qSound.Play();
    }


}
