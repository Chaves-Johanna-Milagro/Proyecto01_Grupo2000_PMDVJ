using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceLevelMath : MonoBehaviour
{
    private GameObject _easy;
    private GameObject _medium;
    private GameObject _hard;

    private Button _bEasy;
    private Button _bMedium;
    private Button _bHard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _easy = transform.Find("BEasy").gameObject;
        _medium = transform.Find("BMedium").gameObject;
        _hard = transform.Find("BHard").gameObject;

        _bEasy = _easy.GetComponent<Button>();
        _bMedium = _medium.GetComponent<Button>();
        _bHard = _hard.GetComponent<Button>();

        SetupLevelButtons();
    }

    private void StartRediseño()
    {
        SceneManager.LoadScene("Morning2.0");
    }
    void SetupLevelButtons()
    {
        _bEasy.onClick.AddListener(() => SetLevelAndStart("Fácil"));
        _bMedium.onClick.AddListener(() => SetLevelAndStart("Medio"));
        _bHard.onClick.AddListener(() => SetLevelAndStart("Difícil"));
    }

    void SetLevelAndStart(string level)
    {
        MGLevelMathStatus.SetLevelMath(level);
        Debug.Log("Nivel seleccionado: " + MGLevelMathStatus.GetLevelMath()); // Para verificar en consola
        StartRediseño(); // Cargar la siguiente escena
    }

}
