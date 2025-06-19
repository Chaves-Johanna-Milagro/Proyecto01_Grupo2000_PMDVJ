using UnityEngine;
using UnityEngine.SceneManagement;

public class MGBase : MonoBehaviour // se encarga de activar los minijuegos y guardar el estado en el que se dejo
{
    private GameObject _miniGame;

    private string _objName;
    private string _sceneName;

    private AudioSource _soundMG;

    private CursorManager _cursorManager;

    private bool _isCompleted = false;

    private void Start()
    {
        _miniGame = transform.Find("MiniGame")?.gameObject;


        _miniGame.SetActive(false); // Lo oculta al inicio

        _objName = gameObject.name;
        _sceneName = SceneManager.GetActiveScene().name;

        _soundMG = _miniGame?.GetComponent<AudioSource>();

        // Restaurar estado del objeto MiniGame
        if (MiniGameStatus.TieneEstado(gameObject))
        {
            MiniGameStatus.RestaurarEstado(gameObject);
            _isCompleted = true;
        }

        _cursorManager = Object.FindFirstObjectByType<CursorManager>();
    }

    private void OnMouseDown()
    {
        if (_isCompleted) return;

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; //si hay uno activo que retorne

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        _isCompleted = true;

        _miniGame?.SetActive(true);

        if (_soundMG != null) _soundMG.Play();
    }

    public void ExitMiniGame()
    {
        _miniGame?.SetActive(false);

        _cursorManager?.SetCursorDefault();

        MiniGameStatus.GuardarEstado(gameObject);
    }
}
