using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BPause : MonoBehaviour
{
    private GameObject _img;
    private GameObject _bContinue;
    private GameObject _bMenuPrin;
    private GameObject _bSalir;

    private Button _BPause;
    private Button _BResume;
    private Button _BMenu;
    private Button _BExit;

    void Start()
    {
        _img = transform.GetChild(0).gameObject;
        _bContinue = transform.GetChild(1).gameObject;
        _bMenuPrin = transform.GetChild(2).gameObject;
        _bSalir = transform.GetChild(3).gameObject;

        _BPause = GetComponent<Button>();
        _BResume = _bContinue.GetComponent<Button>();
        _BMenu = _bMenuPrin.GetComponent<Button>();
        _BExit = _bSalir.GetComponent<Button>();

        _img.SetActive(false);
        _bContinue.SetActive(false);
        _bMenuPrin.SetActive(false);
        _bSalir.SetActive(false);

        _BPause.onClick.AddListener(PauseGame);
        _BResume.onClick.AddListener(ResumeGame);
        _BMenu.onClick.AddListener(ReturnMenu);
        _BExit.onClick.AddListener(ExitGame);

        PauseStatus.SetPaused(false); //pa que este sin pausa ala inicio
    }

    void Update()
    {
        // Activar o desactivar la UI según el estado global de pausa
        bool isPaused = PauseStatus.IsPaused;

        _img.SetActive(isPaused);
        _bContinue.SetActive(isPaused);
        _bMenuPrin.SetActive(isPaused);
        _bSalir.SetActive(isPaused);
    }

    private void PauseGame()
    {
        if (!PauseStatus.IsPaused)
        {
            PauseStatus.SetPaused(true);
        }
    }

    private void ResumeGame()
    {
        if (PauseStatus.IsPaused)
        {
            PauseStatus.SetPaused(false);
        }
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu2.0");

        PlayerNameStatus.ResetPlayerName(); //resetiar todo
        LevelGameStatus.ClearLevel();
        ChecksStatus.ResetAllChecks();
        KindnessStatus.ResetKindness();
        CinematicStatus.ResetCinematicStatus();
        DecisionStatus.ResetDecisionStatus();
        CrossStreetStatus.ResetStep();
        RecessStatus.ResetRecessStatus();
        PauseStatus.ResetPause();
        GameOverStatus.ResetMotive();

        Debug.Log("volviendo al menu");
    }
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); //cierra el ejecutable
    }
}
