using UnityEngine;
using UnityEngine.UI;

public class BMiniAftonSound : MonoBehaviour
{
    private AudioSource[] audios; // array de sonidos cuando se añadan mas

    private bool _starSound = true; //pa que no suene al desactivar el concejo

    void Start()
    {
        audios = GetComponents<AudioSource>();

        GetComponent<Button>().onClick.AddListener(PlayRandomSound);
    }

    void PlayRandomSound()
    {
        if (PauseStatus.IsPaused) return;

        if (audios.Length == 0) return;

        if (_starSound)
        {
            if (audios.Length > 0)
            {
                int index = Random.Range(0, audios.Length);
                audios[index].Play();
            }
        }

        _starSound = !_starSound; // pa alternar el sonido 
    }
}
