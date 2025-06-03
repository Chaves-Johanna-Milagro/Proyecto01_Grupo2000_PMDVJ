using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BExitDecision : MonoBehaviour
{
    private GameObject _img;
    private GameObject _text;

    private Image _imgComp;
    private TextMeshProUGUI _textComp;

    private Button _bExit;

    private DecisionBase[] _allDecision; // array de todos las desiciones en la escena
    void Start()
    {
        // Obtiene todos los DecisionBase en la escena
        _allDecision = Object.FindObjectsByType<DecisionBase>(FindObjectsSortMode.None);

        _img = transform.GetChild(0).gameObject;
        _text = transform.GetChild(1).gameObject;

        _imgComp = _img.GetComponent<Image>();
        _textComp = _text.GetComponent<TextMeshProUGUI>();

        ActiveObjs(false); //desactivar al inicio

        _bExit = GetComponent<Button>();

        _bExit.onClick.AddListener(ExitDes);
    }
    public void Update()
    {

        ChangeColor(); // pa que se desvanesca un poco si esta en pausa

        if (PauseStatus.IsPaused) return;

        if (DecisionStatus.ActiveDecision() && SceneManager.GetActiveScene().name != "WayToSchool2.0") ActiveObjs(true);

    }
    public void ExitDes()
    {
        if (PauseStatus.IsPaused) return;

        foreach (var des in _allDecision)
        {
            if (des.gameObject.activeInHierarchy)
            {
                des.ExitDecision();
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
