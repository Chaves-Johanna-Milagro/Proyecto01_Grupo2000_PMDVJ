using UnityEngine;
using UnityEngine.Audio;

public class StartMusic : MonoBehaviour
{
    public AudioSource morningMusic;

    void Start()
    {
        morningMusic.Play();
    }
}
