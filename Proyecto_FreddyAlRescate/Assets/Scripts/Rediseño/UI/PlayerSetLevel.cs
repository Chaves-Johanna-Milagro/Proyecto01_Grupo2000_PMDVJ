using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSetLevel : MonoBehaviour
{
    private GameObject[] _childs;

    private int _count;

    private Button _lvlEasy; //botones para elegir la dificultad si es que se recarga la escena
    private Button _lvlMedium;
    private Button _lvlHard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _count = transform.childCount;
        _childs = new GameObject[_count];

        for (int i = 0; i < _count; i++) // desativar al inicio
        {
            _childs[i] = transform.GetChild(i).gameObject;
            //_childs[i].SetActive(false);
        }

        _lvlEasy = transform.Find("BSetEasy").GetComponent<Button>();
        _lvlMedium = transform.Find("BSetMedium").GetComponent<Button>();
        _lvlHard = transform.Find("BSetHard").GetComponent<Button>();

        SetupLevelButtons();

        if (string.IsNullOrEmpty(LevelGameStatus.GetLevel())) ActiveSetMenu();
            
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
        Desactive();
    }

    private void ActiveSetMenu()
    {
        for (int i = 0; i < _count; i++) // desativar al inicio
        {
            _childs[i].SetActive(true);
        }
    }
    private void Desactive()
    {
        for (int i = 0; i < _count; i++) // desativar al inicio
        {
            _childs[i].SetActive(false);
        }
    }
}
