using UnityEngine;

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
        int incorrectas = ResultStatus.GetIncorrects();

        // Priorizamos el orden para que no se superpongan
        if (correctas == 1 || incorrectas == 5)
        {
            _result1.SetActive(true);
        }
        else if (correctas == 2 || incorrectas == 3)
        {
            _result2.SetActive(true);
        }
        else if (correctas == 3 || (incorrectas == 2 && correctas < 4))
        {
            // Solo mostramos R3 si no hay 4 o más correctas (para que no se solape con R4)
            _result3.SetActive(true);
        }
        else if (correctas >= 4 || incorrectas == 1 || (incorrectas == 2 && correctas >= 4))
        {
            _result4.SetActive(true);
        }
    }

   
}
