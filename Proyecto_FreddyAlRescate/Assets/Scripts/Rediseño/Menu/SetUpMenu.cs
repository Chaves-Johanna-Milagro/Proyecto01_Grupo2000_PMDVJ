using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SetUpMenu : MonoBehaviour
{
    private TMP_InputField _inputText; // pa que ponga su nombre

    private Button _lvlEasy; //botones para elegir la dificultad
    private Button _lvlMedium;
    private Button _lvlHard;

    private void Start()
    {
        _inputText = transform.Find("SetName").GetComponent<TMP_InputField>();

        _lvlEasy = transform.Find("BEasy").GetComponent<Button>();
        _lvlMedium = transform.Find("BMedium").GetComponent<Button>();
        _lvlHard = transform.Find("BHard").GetComponent<Button>();

        SetupLevelButtons();
    }
    public void SaveName()
    {
        string name = _inputText.text;

        PlayerNameStatus.SetPlayerName(name);

        Debug.Log("nombre elegido " + name);

    }

    public void StartRediseño()
    {
        SceneManager.LoadScene("Intro2.0");
        SaveName();
    }


    void SetupLevelButtons()
    {
        _lvlEasy.onClick.AddListener(() => SetLevelAndStart("Facil")); // numeros del 1 al 10
        _lvlMedium.onClick.AddListener(() => SetLevelAndStart("Medio")); // numeros del 10 al 100
        _lvlHard.onClick.AddListener(() => SetLevelAndStart("Dificil"));  // numeros del 100 al 1000
    }

    void SetLevelAndStart(string level)
    {
        LevelGameStatus.SetLevel(level);
        Debug.Log("Nivel seleccionado: " + LevelGameStatus.GetLevel()); // Para verificar en consola
        StartRediseño(); // Cargar la siguiente escena
    }
}
