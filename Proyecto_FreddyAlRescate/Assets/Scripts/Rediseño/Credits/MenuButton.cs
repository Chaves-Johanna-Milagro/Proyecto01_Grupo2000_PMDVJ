using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour //script del boton de menu de los creditos
{
    private Button _bMenu;
    private void Start()
    {
        _bMenu = GetComponent<Button>();

        _bMenu.onClick.AddListener(ReturnMenu);
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
}
