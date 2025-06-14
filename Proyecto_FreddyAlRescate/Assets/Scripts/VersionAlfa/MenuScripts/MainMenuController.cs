using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{
    public AudioSource menuButton;
    public void PlayGame()
    {
        menuButton.Play();
        SceneManager.LoadScene("Morning");
    }
}
