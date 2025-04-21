using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FriendCharacterButton : MonoBehaviour
{
    private GameObject globoImage;
    private GameObject textObj;
    private TextMeshProUGUI textComponent;

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

    private bool hasBeenActivated = false;

    private void Start()
    {
        // Obtiene los hijos por índice
        globoImage = transform.GetChild(0).gameObject;
        textObj = transform.GetChild(1).gameObject;

        // Obtiene el componente TextMeshProUGUI del objeto de texto
        textComponent = textObj.GetComponent<TextMeshProUGUI>();

        // Asocia el evento de click
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (!hasBeenActivated)
        {
            globoImage.SetActive(true);
            textObj.SetActive(true);
            hasBeenActivated = true;
        }

        string currentScene = SceneManager.GetActiveScene().name; // para que los concejos cambien segun la escena

        if (currentScene == "Morning" && randomTextNvl1.Length > 0)  // Selecciona un concejo aleatorio
        {
            string randomLine = randomTextNvl1[Random.Range(0, randomTextNvl1.Length)];
            textComponent.text = randomLine;
        }

        if (currentScene == "Breackfast" && randomTextNvl2.Length > 0)
        {
            string randomLine = randomTextNvl2[Random.Range(0, randomTextNvl2.Length)];
            textComponent.text = randomLine;
        }
    }
}
