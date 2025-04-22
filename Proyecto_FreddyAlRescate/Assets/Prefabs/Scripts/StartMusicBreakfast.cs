using UnityEngine;
using UnityEngine.Audio;

public class StartMusicBreakfast : MonoBehaviour
{
    public AudioSource breakfastMusic;
    public AudioSource chirpingBirds;
    void Start()
    {
        breakfastMusic.Play();
        chirpingBirds.Play();
    }

}
