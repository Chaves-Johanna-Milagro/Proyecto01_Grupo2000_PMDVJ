using UnityEngine;
using UnityEngine.SceneManagement;

public class MGBase : MonoBehaviour // se encarga de activar los minijuegos y guardar el estado en el que se dejo
{
    private GameObject _miniGame;

    private string _objName;
    private string _sceneName;

    private void Start()
    {
        _miniGame = transform.Find("MiniGame")?.gameObject;


        _miniGame.SetActive(false); // Lo oculta al inicio

        _objName = gameObject.name;
        _sceneName = SceneManager.GetActiveScene().name;

        // Restaurar estado de los hijos del objeto MiniGame
        if (MiniGameStatus.TieneEstado(_sceneName, _objName))
        {
            MiniGameStatus.RestaurarEstado(_sceneName, _objName, _miniGame.transform);
        }
    }

    private void OnDisable()
    {
        if (_miniGame != null)
        {
            // Guarda la posición y estado activo de todos los hijos de MiniGame
            MiniGameStatus.GuardarEstado(_sceneName, _objName, _miniGame.transform);
        }
    }

    private void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        _miniGame?.SetActive(true);
    }

    public void ExitMiniGame()
    {
        _miniGame?.SetActive(false);
    }
}
