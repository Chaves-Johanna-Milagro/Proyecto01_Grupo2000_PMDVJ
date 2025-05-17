using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BMiniAfton : MonoBehaviour
{
    private GameObject _globoImg;
    private GameObject _textObj;

    private Button _bMiniAfton;

    private TextMeshProUGUI _textComp;

    private string _sceneName;

    private bool _activated = false;

    private string[] _randomTextNvl1 = new string[]
    {
        "¿QUIÉN NO AMA UNA CAMA BIEN HECHA?",
        "¡UNA SONRISA LIMPIA ES TU MEJOR ARMADURA!",
        "¡ESE PIJAMA YA CUMPLIÓ SU MISIÓN, HORA DE VESTIRSE!",
        "ORDENAR TU ESPACIO TAMBIÉN ORDENA TU CABEZA.",
        "UN CUARTO LIMPIO DICE: '¡ESTOY LISTO PARA TODO!'",
        "TODO HÉROE EMPIEZA SU DÍA CON BUENOS HÁBITOS.",
        "CAMA ORDENADA, MENTE ENFOCADA.",
        "¡HASTA LOS DIENTES QUIEREN LLEGAR PROLIJOS A CLASE!"
    };

    private string[] _randomTextNvl2 = new string[]
    {
        "¡NO OLVIDES NADA, FREDDY!",
        "DESAYUNAR ES COMO CARGAR COMBUSTIBLE PARA TU CEREBRO.",
        "UNA MOCHILA ORDENADA ES UN SUPERPODER ESCOLAR.",
        "¡AGRADECER LA COMIDA TAMBIÉN ES EDUCACIÓN!",
        "¿YA PUSISTE TU CUADERNO? ¡NO LO DEJES!",
        "TODO SABE MEJOR CUANDO ESTÁS PREPARADO.",
        "¡NO TE VAYAS SIN DESPEDIRTE!",
        "SI TE VAS SIN DESPEDIRTE, ALGUIEN TE VA A EXTRAÑAR."
    };

    private AudioSource _soundAfton;
    void Start()
    {
        _globoImg = transform.GetChild(0).gameObject;
        _textObj = transform.GetChild(1).gameObject;

        SetActive(false); //desactivar al inicio

        _textComp = _textObj.GetComponent<TextMeshProUGUI>();

        _sceneName = SceneManager.GetActiveScene().name;

        _bMiniAfton = GetComponent<Button>();

        _bMiniAfton.onClick.AddListener(Toggle);

        _soundAfton = GetComponent<AudioSource>();

    }
    public void Update()
    {
        if (PauseStatus.IsPaused && _activated)
        {
            _activated = false;
            SetActive(false);
        }
    }
    public void Toggle()
    {
        if (PauseStatus.IsPaused) return;

        _activated = !_activated;
        SetActive(_activated);

        ShowByScene();

        if (_activated) _soundAfton.Play();
    }

    private void SetActive(bool state)
    {
        _globoImg.SetActive(state);
        _textObj.SetActive(state);
    }

    private void ShowByScene()
    {
        if (_sceneName == "Morning2.0") ConcejosNvl1();
        else if (_sceneName == "Breackfast2.0") ConcejosNvl2();
    }


    private void ConcejosNvl1()
    {
        if (_randomTextNvl1.Length > 0)  // Selecciona un concejo aleatorio
        {
            string randomLine = _randomTextNvl1[Random.Range(0, _randomTextNvl1.Length)];
            _textComp.text = randomLine;
        }
    }

    private void ConcejosNvl2()
    {
        if (_randomTextNvl2.Length > 0)  // Selecciona un concejo aleatorio
        {
            string randomLine = _randomTextNvl2[Random.Range(0, _randomTextNvl2.Length)];
            _textComp.text = randomLine;
        }
    }
}
