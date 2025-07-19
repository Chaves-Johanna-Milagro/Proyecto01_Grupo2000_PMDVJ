using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private Button _bMenu;
    private Button _bExit;

    private AudioSource[] _audios;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bMenu = transform.Find("BMenu").GetComponent<Button>();
        _bExit = transform.Find("BExit").GetComponent<Button>();

        _bMenu.onClick.AddListener(ReturnMenu);
        _bExit.onClick.AddListener(ExitGame);

        _audios = GetComponents<AudioSource>();

        if(GameOverStatus.GetMotive() == "Cross") _audios[0].Play();
        if(GameOverStatus.GetMotive() == "DownBar") _audios[1].Play();
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

public static class GameOverStatus
{
    //private static AudioSource[] _audio = GetComponents<AudioSource>();
    private static string _reason = "";
    public static void MotiveCross()
    {
        _reason = "Cross";
    }
    public static void MotiveDownBar()
    {
        _reason = "DownBar";
    }
    public static string GetMotive() { return _reason; }
    public static void ResetMotive() { _reason = ""; }
}
