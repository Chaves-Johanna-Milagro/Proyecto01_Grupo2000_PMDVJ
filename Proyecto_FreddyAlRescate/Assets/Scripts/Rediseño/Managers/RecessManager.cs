using UnityEngine;
using UnityEngine.SceneManagement;

public class RecessManager : MonoBehaviour // encargado de mover al jugador cuando empize el recreo
{
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Classroom2.0" && !RecessStatus.AlreadyWentToRecess)
        {
            if (ChecksStatus.GetActiveChecksCountForScene(currentScene) >= 2)
            {
                RecessStatus.AlreadyWentToRecess = true;
                SceneManager.LoadScene("Recess2.0");
                Debug.Log(RecessStatus.AlreadyWentToRecess);
            }
        }
        else if ((currentScene == "Recess2.0" && ChecksStatus.GetActiveChecksCountForScene(currentScene) == 2) ||
                 (currentScene == "Playground2.0" && ChecksStatus.GetActiveChecksCountForScene(currentScene) == 2))
        {
            SceneManager.LoadScene("Classroom2.0");
        }
    }

}
