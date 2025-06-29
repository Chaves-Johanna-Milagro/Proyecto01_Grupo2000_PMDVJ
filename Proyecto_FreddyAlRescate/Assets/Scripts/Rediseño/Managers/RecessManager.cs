using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RecessManager : MonoBehaviour // encargado de mover al jugador cuando empize el recreo
{
    private bool _transition = false;

    private PlayerAttention _pAttention;
    private void Start()
    {
        string _scene = SceneManager.GetActiveScene().name;

        _pAttention = Object.FindFirstObjectByType<PlayerAttention>();

        if (!RecessStatus.AlreadyWentToRecess && (_scene == "Recess2.0" || _scene == "Playground2.0"))
        {
            RecessStatus.AlreadyWentToRecess = true;
        }
    }

    void Update()
    {
        if (_transition) return;

        string currentScene = SceneManager.GetActiveScene().name;
        int activeChecks = ChecksStatus.GetActiveChecksCountForScene("Classroom2.0"); 

        // Si ya completó los 3 checks, sin importar dónde esté, que terminen las clases
        if (activeChecks == 3)
        {
            _pAttention.AttentionEndRecess();
            StartCoroutine(TransitionToScene("CSchoolEnd", 3f));
            return;
        }

        // ▶Si está en Classroom2.0 y aún no fue al recreo
        if (currentScene == "Classroom2.0" && !RecessStatus.AlreadyWentToRecess)
        {
            if (activeChecks >= 2)
            {
                RecessStatus.AlreadyWentToRecess = true;
                _pAttention.AttentionStartRecess();
                StartCoroutine(TransitionToScene("Recess2.0", 5f));
            }
        }

        //  Transiciones desde Recess o Playground de vuelta a clase
        else if ((currentScene == "Recess2.0" && ChecksStatus.GetActiveChecksCountForScene(currentScene) == 2) ||
                 (currentScene == "Playground2.0" && ChecksStatus.GetActiveChecksCountForScene(currentScene) == 2))
        {
            StartCoroutine(TransitionToScene("Classroom2.0", 2f));
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

