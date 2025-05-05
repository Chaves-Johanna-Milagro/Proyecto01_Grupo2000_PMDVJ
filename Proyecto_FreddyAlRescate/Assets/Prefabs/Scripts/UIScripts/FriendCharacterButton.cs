using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class FriendCharacterButton : MonoBehaviour
{
    private GameObject _globoImage;
    private GameObject _textObj;
    private TextMeshProUGUI _textComponent;

    private string[] randomTextNvl1 = new string[]
    {
        "¡ES BUENO ORDENAR LA CAMA!",
        "¿NADA COMO UNA BRILLANTE SONRISA?",
        "¡CAMBIATE PARA IR A LA ESCUELA!",

    };

    private string[] randomTextNvl2 = new string[]
    {
        "¡ORDENAR LOS UTILES ES IMPORTANTE!",
        "¡QUE HAMBRE!",
        "¡ES BUENO DESPEDIRSE ANTES DE IR A LA ESCUELA!",

    };

    private string[] randomTextNvl3 = new string[]
    {
        "¡HAY QUE LLEGAR PRONTO A LA PARADA!",
        "¡LA APP PODRIA AYUDARNOS!",
        "¡ES BUENO SALUDAR A LOS VECINOS!",

    };

    private string[] _indicationsTextNvl3 = new string[]
    {
        "PRIMERO ELIJAMOS UN CAMINO",
        "NO ES TIEMPO DE DISTRACCIONES",
        "QUE TAL SI COMPRAMOS ALGO PARA COMER"
    };

    private bool _hasBeenActivated = false;

    private void Start()
    {
        // Obtiene los hijos por índice
        _globoImage = transform.GetChild(0).gameObject;
        _textObj = transform.GetChild(1).gameObject;

        // Obtiene el componente TextMeshProUGUI del objeto de texto
        _textComponent = _textObj.GetComponent<TextMeshProUGUI>();

        // Asocia el evento de click
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (!_hasBeenActivated)
        {
            _globoImage.SetActive(true);
            _textObj.SetActive(true);
            _hasBeenActivated = true;
        }

        string currentScene = SceneManager.GetActiveScene().name; // para que los concejos cambien segun la escena

        if (currentScene == "Morning" && randomTextNvl1.Length > 0)  // Selecciona un concejo aleatorio
        {
            string randomLine = randomTextNvl1[Random.Range(0, randomTextNvl1.Length)];
            _textComponent.text = randomLine;
        }

        if (currentScene == "Breackfast" && randomTextNvl2.Length > 0)
        {
            string randomLine = randomTextNvl2[Random.Range(0, randomTextNvl2.Length)];
            _textComponent.text = randomLine;
        }

        if (currentScene == "WayToSchool" && randomTextNvl3.Length > 0)
        {
            string randomLine = randomTextNvl3[Random.Range(0, randomTextNvl3.Length)];
            _textComponent.text = randomLine;
        }

        StartCoroutine(DelayDesactive());
    }

    public void IndicationsForThePlayer(string nameBlock)
    {
        _globoImage.SetActive(true);
        _textObj.SetActive(true);
        _hasBeenActivated = true;
        if (nameBlock == "BlockArrow") _textComponent.text = _indicationsTextNvl3[0];
        if (nameBlock == "RightBlock" || nameBlock == "LeftBlock") _textComponent.text = _indicationsTextNvl3[1];
        if (nameBlock == "Block") _textComponent.text = _indicationsTextNvl3[2];

        StartCoroutine(DelayDesactive());
        
    }

    private IEnumerator DelayDesactive() 
    { 
        yield return new WaitForSeconds(5f);
        _globoImage.SetActive(false);
        _textObj.SetActive(false);
        _hasBeenActivated = false;
    }
}
