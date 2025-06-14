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

    private string[] _randomTextNvl3 = new string[]
    {
        "¡SALUDAR ES EL PRIMER PASO PARA UNA BUENA COMPRA!",
        "FREDDY, RECORDÁ MIRAR A AMBOS LADOS ANTES DE CRUZAR.",
        "SI EL SEMÁFORO ESTÁ EN ROJO, ¡ESPERÁ!",
        "NO HAY APURO SI SE TRATA DE CRUZAR SEGURO.",
        "¡YA CASI LLEGÁS A LA PARADA!",
        "CAMINAR CON ATENCIÓN TAMBIÉN ES SER UN HÉROE.",
        "¿VISTE QUE NADIE VENÍA? ¡BUEN MOMENTO PARA CRUZAR!"
    };

    private string[] _randomGoodFeedback = new string[]
    {
        "¡EXCELENTE TRABAJO!",
        "¡LO HICISTE MUY BIEN!",
        "¡SÚPER!",
        "¡GENIAL, SIGUE ASÍ!",
        "¡BUEN INTENTO!",
        "¡LO ESTÁS HACIENDO MUY BIEN!",
        "¡ERES UN CAMPEÓN!",
        "¡MUY BUENA ELECCIÓN!",
        "¡SIGUE PRACTICANDO, VAS MUY BIEN!",
        "¡FANTÁSTICO!",
        "¡BRAVO!",
        "¡MUY INTELIGENTE!",
        "¡CADA VEZ MEJOR!",
        "¡VAMOS, TÚ PUEDES!",
        "¡MUY BIEN HECHO!",
        "¡INCREÍBLE!",
        "¡ESTÁS APRENDIENDO MUY RÁPIDO!",
        "¡ME IMPRESIONAS!",
        "¡EXCELENTE ELECCIÓN!",
        "¡SÚPER LOGRO!"
    };

    private string[] _randomBadFeedback = new string[]
    {
        "¡NO PASA NADA, INTÉNTALO OTRA VEZ!",
        "¡CASI! SIGUE PROBANDO.",
        "¡MUY CERCA! TÚ PUEDES LOGRARLO.",
        "¡NO TE RINDAS, SIGUE JUGANDO!",
        "¡BUEN INTENTO, INTÉNTALO NUEVAMENTE!",
        "¡LO IMPORTANTE ES SEGUIR INTENTANDO!",
        "¡APRENDER ES DIVERTIDO, VAMOS DE NUEVO!",
        "¡SIGUE ADELANTE, LO ESTÁS HACIENDO BIEN!",
        "¡POCO A POCO LO VAS A CONSEGUIR!",
        "¡CADA VEZ TE SALE MEJOR!",
        "¡LOS ERRORES NOS AYUDAN A MEJORAR!",
        "¡VAS POR BUEN CAMINO, INTÉNTALO OTRA VEZ!",
        "¡NO TE DESANIMES, SIGUE JUGANDO!",
        "¡TODO GRAN LOGRO COMIENZA CON UN INTENTO!",
        "¡PRACTICANDO SE APRENDE, SIGUE ADELANTE!",
        "¡TÚ PUEDES CON ESTO!",
        "¡AUNQUE TE EQUIVOQUES, ESTÁS APRENDIENDO!",
        "¡SIGUE JUGANDO, CADA VEZ LO HARÁS MEJOR!",
        "¡MUY BIEN POR INTENTARLO!",
        "¡EXCELENTE ACTITUD, SIGAMOS JUGANDO!"
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
