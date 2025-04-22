using UnityEngine;
using UnityEngine.Audio;

public class StartMusicBreakfast : MonoBehaviour
{
    public AudioSource breakfastMusic;
    void Start()
    {
        breakfastMusic.Play();
    }

}
