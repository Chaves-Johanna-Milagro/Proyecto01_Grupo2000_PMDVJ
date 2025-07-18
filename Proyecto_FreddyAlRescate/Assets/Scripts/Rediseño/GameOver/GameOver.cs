using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private Button _bMenu;
    private Button _bExit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bMenu = transform.Find("BMenu").GetComponent<Button>();
        _bExit = transform.Find("BExit").GetComponent<Button>();

        _bMenu.onClick.AddListener(ReturnMenu);
        _bExit.onClick.AddListener(ExitGame);
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

        Debug.Log("volviendo al menu");
    }
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); //cierra el ejecutable
    }
}
