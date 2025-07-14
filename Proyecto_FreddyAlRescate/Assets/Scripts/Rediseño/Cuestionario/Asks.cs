using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Asks : MonoBehaviour
{
    private GameObject _question; // Referencia al objeto que contiene la pregunta
    private List<GameObject> _answersCorrect = new List<GameObject>();   // Respuestas correctas
    private List<GameObject> _answersIncorrect = new List<GameObject>(); // Respuestas incorrectas
    private Cuestionario _cuestionario; // Referencia al script cuestionario

    void Awake()
    {
        // Buscar al script Cuestionario en el padre
        _cuestionario = GetComponentInParent<Cuestionario>();

        // Clasificar hijos
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Question"))
                _question = child.gameObject;
            else if (child.name.StartsWith("AC"))
                _answersCorrect.Add(child.gameObject);
            else if (child.name.StartsWith("AI"))
                _answersIncorrect.Add(child.gameObject);

            // Desactivamos todos al principio
            child.gameObject.SetActive(false);
        }
    }

    // Método que muestra la pregunta y mezcla aleatoriamente las respuestas
    public void MostrarPregunta()
    {
        gameObject.SetActive(true); // Por si estaba desactivado
        _question?.SetActive(true); // Mostrar la pregunta

        List<GameObject> toShow = new List<GameObject>();

        // Elegimos UNA respuesta correcta aleatoria
        GameObject correcta = null;
        if (_answersCorrect.Count > 0)
        {
            correcta = _answersCorrect[Random.Range(0, _answersCorrect.Count)];
            toShow.Add(correcta);
        }

        // Elegimos hasta 2 incorrectas que NO tengan el mismo número final que la correcta
        List<GameObject> posiblesIncorrectas = new List<GameObject>(_answersIncorrect);
        posiblesIncorrectas.RemoveAll(ai => correcta != null && TieneMismoNumero(ai.name, correcta.name));

        Shuffle(posiblesIncorrectas);
        for (int i = 0; i < Mathf.Min(2, posiblesIncorrectas.Count); i++)
        {
            toShow.Add(posiblesIncorrectas[i]);
        }

        // Mezclamos todas las respuestas
        Shuffle(toShow);

        // Activamos respuestas y asignamos su botón
        foreach (GameObject obj in toShow)
        {
            obj.SetActive(true);
            Button btn = obj.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();

            bool esCorrecta = _answersCorrect.Contains(obj); // Verifica si es una correcta

            btn.onClick.AddListener(() =>
            {
                // Notificar al cuestionario si fue correcta o incorrecta
                _cuestionario.RegistrarRespuesta(esCorrecta);


                OcultarTodo();               // Oculta hijos de este Ask
                _cuestionario.Continuar();   // Avisa al Cuestionario que pase al siguiente
            });
        }
    }

    // Oculta todos los hijos del Ask (pregunta y respuestas)
    private void OcultarTodo()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Mezcla aleatoriamente los elementos de una lista
    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }

    // Revisa si dos nombres terminan con el mismo número (ej: AC2 y AI2 → true)
    private bool TieneMismoNumero(string name1, string name2)
    {
        string num1 = ObtenerNumeroFinal(name1);
        string num2 = ObtenerNumeroFinal(name2);
        return num1 != "" && num1 == num2;
    }

    // Extrae el número final de un nombre, por ejemplo "AI2" → "2"
    private string ObtenerNumeroFinal(string name)
    {
        for (int i = name.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(name[i]))
                return name.Substring(i + 1);
        }
        return "";
    }

}
