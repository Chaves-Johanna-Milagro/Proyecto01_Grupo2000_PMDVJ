using UnityEngine;
using UnityEngine.SceneManagement;

public class MGBase : MonoBehaviour // se encarga de activar los minijuegos y guardar el estado en el que se dejo
{
    private GameObject _miniGame;

    private string _obj; //nombre del objeto que tiene el script
    private string _sceneName;

    private AudioSource _soundMG;

    private CursorManager _cursorManager;

   // private bool _isCompleted = false;

    private void Start()
    {
        _miniGame = transform.Find("MiniGame")?.gameObject;


        _miniGame.SetActive(false); // Lo oculta al inicio

        _obj = gameObject.name;
        _sceneName = SceneManager.GetActiveScene().name;

        _soundMG = _miniGame?.GetComponent<AudioSource>();

        // Restaurar estado del objeto MiniGame
        if (MiniGameStatus.TieneEstado(gameObject))
        {
            MiniGameStatus.RestaurarEstado(gameObject);
            //_isCompleted = true;
        }

        _cursorManager = Object.FindFirstObjectByType<CursorManager>();
    }

    private void OnMouseDown()
    {
       // if (_isCompleted) return;

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; //si hay uno activo que retorne

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        //_isCompleted = true;
        if (_obj == "Bathroom" && ChecksStatus.IsCheckActive("Morning2.0",2) ||
            _obj == "Diningroom" && ChecksStatus.IsCheckActive("Breackfast2.0", 0) ||
            _obj == "Backpack" && ChecksStatus.IsCheckActive("Breackfast2.0", 1) ||
            _obj == "Bathroom" && ChecksStatus.IsCheckActive("Night2.0",2)) return; //pa q ya no interactue si ya estan sus checks activos

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
