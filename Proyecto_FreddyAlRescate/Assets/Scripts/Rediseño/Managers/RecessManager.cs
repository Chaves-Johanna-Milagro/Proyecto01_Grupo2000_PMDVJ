using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RecessManager : MonoBehaviour // encargado de mover al jugador cuando empize el recreo
{
    private bool _transition = false;

    void Update()
    {
        if (_transition) return;

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Classroom2.0" && !RecessStatus.AlreadyWentToRecess)
        {
            if (ChecksStatus.GetActiveChecksCountForScene(currentScene) >= 2)
            {
                RecessStatus.AlreadyWentToRecess = true;
                StartCoroutine(TransitionToScene("Recess2.0", 2.5f)); // 2.5 segundos de delay
            }
        }
        else if ((currentScene == "Recess2.0" && ChecksStatus.GetActiveChecksCountForScene(currentScene) == 2) ||
                 (currentScene == "Playground2.0" && ChecksStatus.GetActiveChecksCountForScene(currentScene) == 2))
        {
            StartCoroutine(TransitionToScene("Classroom2.0", 2f)); // 2 segundos de delay
        }
    }

    private IEnumerator TransitionToScene(string sceneName, float delay)
    {
        _transition = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
        _transition = false;
    }

}
