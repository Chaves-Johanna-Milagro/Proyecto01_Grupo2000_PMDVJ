using UnityEngine;
using TMPro;

public class MGMathClickOption : MonoBehaviour//lo tienen las opciones del mini juego de matemamticas
{
    private MGMath _math;

    private string _name; //nombre de la opcion

    private TMP_Text _levelText;

    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        _math = parent.GetComponentInParent<MGMath>();

        _name = gameObject.name;

        _levelText = GetComponentInChildren<TMP_Text>();

        Text();

    }

    public void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        //if (MiniGameStatus.ActiveMiniGame()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        _math.ChoiceOpt(_name);

       // gameObject.SetActive(false);
    }
    private void Text()
    {
        if (MGLevelMathStatus.GetLevelMath() == "Facil") // del 1 al 10
        {
            if (_name == "Opt1") _levelText.text = "5 + 10 = 6";

            if (_name == "Opt2") _levelText.text = "10 - 6 = 4";

            if (_name == "Opt3") _levelText.text = "10 + 4 = 9";
        }

        if (MGLevelMathStatus.GetLevelMath() == "Medio") // del 10 al 100
        {
            if (_name == "Opt1") _levelText.text = "50 + 100 = 60";

            if (_name == "Opt2") _levelText.text = "100 - 60 = 40";

            if (_name == "Opt3") _levelText.text = "100 + 40 = 90";
        }

        if (MGLevelMathStatus.GetLevelMath() == "Dificil") //del 100 al 1000
        {
            if (_name == "Opt1") _levelText.text = "500 + 1000 = 600";

            if (_name == "Opt2") _levelText.text = "1000 - 600 = 400";

            if (_name == "Opt3") _levelText.text = "1000 + 400 = 900";
        }
    }
}
