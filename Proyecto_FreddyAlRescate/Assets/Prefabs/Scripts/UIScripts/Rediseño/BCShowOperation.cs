using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BCShowOperation : MonoBehaviour // lo tendra la pantalla de la calculadora
{
    private TMP_Text _screenText; //sevira para mostrar

    void Start()
    {
        _screenText = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    // Muestra los valores presionados en los botones
    public void Show(string boton)
    {
        _screenText.text += boton;
    }

    // Evalúa la expresión matemática
    public void Evaluate()
    {
        if (string.IsNullOrEmpty(_screenText.text)) return; // Evita evaluar si la pantalla está vacía

        try
        {
            double result = Convert.ToDouble(new System.Data.DataTable().Compute(_screenText.text, null)); // Convierte a double

            // Si el número es menor a 1, se limita a dos decimales
            if (result < 1 && result > -1)
                _screenText.text = result.ToString("F2");
            else
                _screenText.text = result.ToString(); // Muestra el número completo si es mayor a 1

        }
        catch
        {
            _screenText.text = "Error"; // Muestra error si la expresión es inválida
        }
    }

    // Borra la pantalla
    public void ClearScreen()
    {
        _screenText.text = "";
    }


}
