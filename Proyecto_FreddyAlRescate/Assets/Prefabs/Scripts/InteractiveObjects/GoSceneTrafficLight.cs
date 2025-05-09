using UnityEngine;
using UnityEngine.SceneManagement;

public class GoSceneTrafficLight : MonoBehaviour
{

    public void OnMouseDown()
    {
        // Obtener ú‹dice actual y cargar la siguiente escena
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Verifica que exista la siguiente escena
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
