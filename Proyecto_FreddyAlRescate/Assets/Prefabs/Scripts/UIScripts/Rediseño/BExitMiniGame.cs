using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BExitMiniGame : MonoBehaviour
{
    private GameObject _img;
    private GameObject _text;

    private Image _imgComp;
    private TextMeshProUGUI _textComp;

    private Button _bExit;

    private MGBase[] _allMiniGames; // array de todos los MGBase en la escena
    void Start()
    {
        // Obtiene todos los MGBase en la escena
        _allMiniGames = Object.FindObjectsByType<MGBase>(FindObjectsSortMode.None);

        _img = transform.GetChild(0).gameObject;
        _text = transform.GetChild(1).gameObject;

        _imgComp = _img.GetComponent<Image>();
        _textComp = _text.GetComponent<TextMeshProUGUI>();

        ActiveObjs(false); //desactivar al inicio

        _bExit = GetComponent<Button>();

        _bExit.onClick.AddListener(ExitMG);
    }
    public void Update()
    {

        ChangeColor(); // pa que se desvanesca un poco si esta en pausa

        if (PauseStatus.IsPaused) return;

        if (MiniGameStatus.ActiveMiniGame() && SceneManager.GetActiveScene().name != "WayToSchool2.0") ActiveObjs(true);

    }
    public void ExitMG()
    {
        if (PauseStatus.IsPaused) return;

        foreach (var mg in _allMiniGames)
        {
            if (mg.gameObject.activeInHierarchy)
            {
                mg.ExitMiniGame();
            }
        }

        ActiveObjs(false);
    }


    private void ActiveObjs(bool status)
    {
        _img.SetActive(status);
        _text.SetActive(status);
    }

    private void ChangeColor()
    {
        var color = _imgComp.color;
        color.a = PauseStatus.IsPaused ? 0.5f : 1f;
        _imgComp.color = color;

        var textColor = _textComp.color;
        textColor.a = PauseStatus.IsPaused ? 0.5f : 1f;
        _textComp.color = textColor;
    }
}
