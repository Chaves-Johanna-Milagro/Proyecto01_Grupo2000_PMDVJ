using System.Collections;
using UnityEngine;

public class DecisionGreetSeller2_0 : MonoBehaviour
{
    private GameObject _img; //sirve como contenedor de los demas ya que aparece en el centro de la camara

    private GameObject _charDefault;
    private GameObject _charGreet;
    private GameObject _charDontGreet;

    private GameObject _opt1;
    private GameObject _opt2;

    private GameObject _instruction;

    private GameObject _greet; //texto de saludo
    private GameObject _greetSeller; //texto de saludo del vendedor
    private GameObject _instructionSeller; //texto que le dice el vendedor pa arrastrar la comida

    private string _nameObj;

    private bool _next = false;

    private BKindnessUpDown _kind;


    void Start()
    {
        _img = transform?.Find("ImgDes").gameObject;

        _charDefault = _img.transform.Find("CharDefault").gameObject;
        _charGreet = _img.transform.Find("CharGreet").gameObject;
        _charDontGreet = _img.transform.Find("CharDontGreet").gameObject;

        _opt1 = _img.transform.Find("Opt1").gameObject;
        _opt2 = _img.transform.Find("Opt2").gameObject;

        _instruction = _img.transform.Find("Instruccion").gameObject;

        _greet = _img.transform.Find("Saludo").gameObject;
        _greetSeller = _img.transform.Find("SaludoVendedor").gameObject;
        _instructionSeller = _img.transform.Find("InstruccionVendedor").gameObject;

        _nameObj = gameObject.name;

        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();
    }

    private void Update()
    {
        if (PauseStatus.IsPaused) return;

        if (_next) NextAction();
    }

    public void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        if (DecisionStatus.ActiveDecision()) return;

        _img.SetActive(true);
    }

    public void SelectOpt(string opt)
    {
        if (opt == "Opt1")
        {
            _charGreet.SetActive(true); // se activa el saludo

            _charDefault.SetActive(false);
            _opt1.SetActive(false);
            _opt2.SetActive(false);
            _instruction.SetActive(false);

            _greet.SetActive(true);

            _kind.GoodDecision();

            _next = true;

        }
        if (opt == "Opt2")
        {
            _charDontGreet.SetActive(true); // se activa el no saludar

            _charDefault.SetActive(false);
            _opt1.SetActive(false);
            _opt2.SetActive(false);
            _instruction.SetActive(false);

            _greet.SetActive(false);

            _kind.BadDecision();

            _next = true;
        }
    }

    private void NextAction()
    {
        if (_nameObj == "Kiosk" ||  _nameObj == "Greengrocery") 
        {
            StartCoroutine(Delay());

            _next = false;
        }
    }

    private IEnumerator Delay() // pa que despues de elegir, el vendedor lo salude
    {
        yield return new WaitForSeconds(2f);

        _greetSeller.SetActive(true);

        yield return new WaitForSeconds(2f);

        _greet.SetActive(false);
        _greetSeller.SetActive(false);
        _instructionSeller.SetActive(true);

        yield return new WaitForSeconds(1f);

        DragDropFood();    

    }

    private void DragDropFood()
    {
        if (_nameObj == "Greengrocery")
        {
            GameObject _manz = _img.transform.Find("MANZANA").gameObject;
            GameObject _ban = _img.transform.Find("BANANA").gameObject;
            GameObject _nar = _img.transform.Find("NARANJA").gameObject;

            GameObject _bal = _img.transform.Find("BALANZA").gameObject;

            _manz.SetActive(true);
            _ban.SetActive(true);
            _nar.SetActive(true);

            _bal.SetActive(true);
        }

        if (_nameObj == "Kiosk")
        {
            GameObject _san = _img.transform.Find("SANWI").gameObject;
            GameObject _sanJam = _img.transform.Find("SANWI DE JAMON").gameObject;
            GameObject _sanQue = _img.transform.Find("SANWI DE QUESO").gameObject;

            GameObject _most = _img.transform.Find("MOSTRADOR").gameObject;

            _san.SetActive(true);
            _sanJam.SetActive(true);
            _sanQue.SetActive(true);

            _most.SetActive(true);
        }
    }
}
