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
        "�QUI�N NO AMA UNA CAMA BIEN HECHA?",
        "�UNA SONRISA LIMPIA ES TU MEJOR ARMADURA!",
        "�ESE PIJAMA YA CUMPLI� SU MISI�N, HORA DE VESTIRSE!",
        "ORDENAR TU ESPACIO TAMBI�N ORDENA TU CABEZA.",
        "UN CUARTO LIMPIO DICE: '�ESTOY LISTO PARA TODO!'",
        "TODO H�ROE EMPIEZA SU D�A CON BUENOS H�BITOS.",
        "CAMA ORDENADA, MENTE ENFOCADA.",
        "�HASTA LOS DIENTES QUIEREN LLEGAR PROLIJOS A CLASE!"
    };

    private string[] _randomTextNvl2 = new string[]
    {
        "�NO OLVIDES NADA, FREDDY!",
        "DESAYUNAR ES COMO CARGAR COMBUSTIBLE PARA TU CEREBRO.",
        "UNA MOCHILA ORDENADA ES UN SUPERPODER ESCOLAR.",
        "�AGRADECER LA COMIDA TAMBI�N ES EDUCACI�N!",
        "�YA PUSISTE TU CUADERNO? �NO LO DEJES!",
        "TODO SABE MEJOR CUANDO EST�S PREPARADO.",
        "�NO TE VAYAS SIN DESPEDIRTE!",
        "SI TE VAS SIN DESPEDIRTE, ALGUIEN TE VA A EXTRA�AR."
    };

    private string[] _randomTextNvl3 = new string[]
    {
        "�SALUDAR ES EL PRIMER PASO PARA UNA BUENA COMPRA!",
        "FREDDY, RECORD� MIRAR A AMBOS LADOS ANTES DE CRUZAR.",
        "SI EL SEM�FORO EST� EN ROJO, �ESPER�!",
        "NO HAY APURO SI SE TRATA DE CRUZAR SEGURO.",
        "�YA CASI LLEG�S A LA PARADA!",
        "CAMINAR CON ATENCI�N TAMBI�N ES SER UN H�ROE.",
        "�VISTE QUE NADIE VEN�A? �BUEN MOMENTO PARA CRUZAR!"
    };

    private string[] _randomGoodFeedback = new string[]
    {
        "�EXCELENTE TRABAJO!",
        "�LO HICISTE MUY BIEN!",
        "�S�PER!",
        "�GENIAL, SIGUE AS�!",
        "�BUEN INTENTO!",
        "�LO EST�S HACIENDO MUY BIEN!",
        "�ERES UN CAMPE�N!",
        "�MUY BUENA ELECCI�N!",
        "�SIGUE PRACTICANDO, VAS MUY BIEN!",
        "�FANT�STICO!",
        "�BRAVO!",
        "�MUY INTELIGENTE!",
        "�CADA VEZ MEJOR!",
        "�VAMOS, T� PUEDES!",
        "�MUY BIEN HECHO!",
        "�INCRE�BLE!",
        "�EST�S APRENDIENDO MUY R�PIDO!",
        "�ME IMPRESIONAS!",
        "�EXCELENTE ELECCI�N!",
        "�S�PER LOGRO!"
    };

    private string[] _randomBadFeedback = new string[]
    {
        "�NO PASA NADA, INT�NTALO OTRA VEZ!",
        "�CASI! SIGUE PROBANDO.",
        "�MUY CERCA! T� PUEDES LOGRARLO.",
        "�NO TE RINDAS, SIGUE JUGANDO!",
        "�BUEN INTENTO, INT�NTALO NUEVAMENTE!",
        "�LO IMPORTANTE ES SEGUIR INTENTANDO!",
        "�APRENDER ES DIVERTIDO, VAMOS DE NUEVO!",
        "�SIGUE ADELANTE, LO EST�S HACIENDO BIEN!",
        "�POCO A POCO LO VAS A CONSEGUIR!",
        "�CADA VEZ TE SALE MEJOR!",
        "�LOS ERRORES NOS AYUDAN A MEJORAR!",
        "�VAS POR BUEN CAMINO, INT�NTALO OTRA VEZ!",
        "�NO TE DESANIMES, SIGUE JUGANDO!",
        "�TODO GRAN LOGRO COMIENZA CON UN INTENTO!",
        "�PRACTICANDO SE APRENDE, SIGUE ADELANTE!",
        "�T� PUEDES CON ESTO!",
        "�AUNQUE TE EQUIVOQUES, EST�S APRENDIENDO!",
        "�SIGUE JUGANDO, CADA VEZ LO HAR�S MEJOR!",
        "�MUY BIEN POR INTENTARLO!",
        "�EXCELENTE ACTITUD, SIGAMOS JUGANDO!"
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
        else if (_sceneName == "WayToSchool2.0") ConcejosNvl3();
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

    private void ConcejosNvl3()
    {
        if (_randomTextNvl3.Length > 0)
            _textComp.text = _randomTextNvl3[Random.Range(0, _randomTextNvl3.Length)];
    }

    public void GoodFeedback() //metodo para cuando en jugador complete o realize buenas acciones
    {
        _activated = true;

        SetActive(_activated); //activar el globo y texto

        if (_randomGoodFeedback.Length > 0)  // Selecciona un felicitaciones aleatorias
        {
            string randomLine = _randomGoodFeedback[Random.Range(0, _randomGoodFeedback.Length)];
            _textComp.text = randomLine;
        }
    }

    public void BadFeedback() //metodo para cuando en jugador se equivoque
    {
        _activated = true;

        SetActive(_activated); //activar el globo y texto

        if (_randomBadFeedback.Length > 0)  // Selecciona una motivacion aleatoria
        {
            string randomLine = _randomBadFeedback[Random.Range(0, _randomBadFeedback.Length)];
            _textComp.text = randomLine;
        }
    }
}
