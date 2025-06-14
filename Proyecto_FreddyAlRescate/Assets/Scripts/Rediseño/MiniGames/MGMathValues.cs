using UnityEngine;
using TMPro;
public class MGMathValues : MonoBehaviour // lo tiene el precio y la plata del mg de matematicas
{
    private string _name;

    private TMP_Text _valueText;

    void Start()
    {
        _name = gameObject.name;

        _valueText = GetComponentInChildren<TMP_Text>();

        Text();
    }

    private void Text()
    {
        if (MGLevelMathStatus.GetLevelMath() == "Facil") // del 1 al 10
        {
            if (_name == "Dinero") _valueText.text = "DINERO: 10";

            if (_name == "Precio") _valueText.text = "PRECIO: 6";

        }

        if (MGLevelMathStatus.GetLevelMath() == "Medio") // del 10 al 100
        {
            if (_name == "Dinero") _valueText.text = "DINERO: 100";

            if (_name == "Precio") _valueText.text = "PRECIO: 60";

        }

        if (MGLevelMathStatus.GetLevelMath() == "Dificil") //del 100 al 1000
        {
            if (_name == "Dinero") _valueText.text = "DINERO: 1000";

            if (_name == "Precio") _valueText.text = "PRECIO: 600";

        }
    }
}
