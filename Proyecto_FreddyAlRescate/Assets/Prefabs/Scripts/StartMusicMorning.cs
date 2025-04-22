using UnityEngine;
using UnityEngine.Audio;

public class StartMusic : MonoBehaviour
{
    public AudioSource morningMusic;
    public AudioSource chirpingBirds;

    void Start()
    {
        morningMusic.Play();
        chirpingBirds.Play();  
    }
}
