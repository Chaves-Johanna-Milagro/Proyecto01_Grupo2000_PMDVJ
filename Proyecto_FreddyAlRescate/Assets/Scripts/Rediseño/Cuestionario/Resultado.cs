using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resultado : MonoBehaviour
{
    private GameObject _result1; //pa los resultados 
    private GameObject _result2; //pa los resultados 
    private GameObject _result3; //pa los resultados 
    private GameObject _result4; //pa los resultados 

    void Start()
    {
        _result1 = transform.Find("R1").gameObject;
        _result2 = transform.Find("R2").gameObject;
        _result3 = transform.Find("R3").gameObject;
        _result4 = transform.Find("R4").gameObject;

        int correctas = ResultStatus.GetCorrects();
        int totalPreguntas = 5;

        //Porcentaje de respuestas correctas
        float porcentajeQuiz = (float)correctas / totalPreguntas;

        //Porcentaje de amabilidad (posición de la barra)
        float porcentajeBarra = KindnessStatus.GetKindnessPercent();

        //Promedio final
        float promedioFinal = (porcentajeQuiz + porcentajeBarra) / 2f;

        Debug.Log($"Quiz: {porcentajeQuiz}, Barra: {porcentajeBarra}, Promedio final: {promedioFinal}");

        //Evaluación combinada
        if (promedioFinal < 0.3f)
        {
            _result1.SetActive(true);
        }
        else if (promedioFinal < 0.55f)
        {
            _result2.SetActive(true);
        }
        else if (promedioFinal < 0.8f)
        {
            _result3.SetActive(true);
        }
        else
        {
            _result4.SetActive(true);
        }
        StartCoroutine(DelayCredits());
    }

    private IEnumerator DelayCredits()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Credits");
    }
}
