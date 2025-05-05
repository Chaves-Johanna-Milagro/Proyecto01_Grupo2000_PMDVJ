using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoader : MonoBehaviour
{
    public void LoadMenuPrincipal()
    {
        SceneManager.LoadScene("Menu"); 
    }
}