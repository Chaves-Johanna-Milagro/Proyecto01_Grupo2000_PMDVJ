using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GuiaAftonT : MonoBehaviour
{
    private GameObject _img; //pa la pantalla oscura

    private GameObject _imgAfton; //pa el afton
    private GameObject _imgGlobo; //pa el globo
    private GameObject _imgGText; //pa el texto del globo

    private TextMeshProUGUI _gText;

    private string[] _guiasText = new string[]
    {
        "HOLA SOY AFTON Y TE VOY A GUIAR EN ESTA AVENTURA!",//audio tuto6

        "PARA MOVERTE HAZ CLICK A DONDE QUIERAS IR!",  //audio tuto1
        "PARA INTERACTUAR CON ALGO HAZ CLICK EN EL OBJETO!",//audio tuto2

        "VEAMOS PARA QUE SIRVEN LOS BOTONES!",//audio tuto7

        "SI QUIERES DESCANZAR UN RATO PUEDES HACER CLICK AQUI",//audio tuto8
        "SI NO SABES QUÉ HACER ÉSTA LIBRETA TE AYUDARÁ!",//audio tuto3
        "ESTE MEDIDOR MOSTRARÁ QUE TAN BIEN TE COMPORTAS. COMPLETA LOS OBJETIVOS Y  HAZ BUENAS ACCIONES PARA QUE AUMENTE!",//audio tuto5
        "YO TAMBIEN ESTOY AQUI SI LO NECESITAS",//audio tuto4
        
        "ESO ES TODO BUENA SUERTE"//audio tuto9
    };    
    void Start()
    {
        _img = transform.Find("Background").gameObject;

        _imgAfton = transform.Find("Afton").gameObject;
        _imgGlobo = transform.Find("Globo").gameObject;
        _imgGText = transform.Find("GText").gameObject;

        _gText = _imgGText.GetComponent<TextMeshProUGUI>();

        // Activar todos al inicio
        _img.SetActive(true);
        _imgAfton.SetActive(true);
        _imgGlobo.SetActive(true);
        _imgGText.SetActive(true);

        _gText.text = _guiasText[0];//pa mostra la presentacion de afton

        StartCoroutine(DelayGuia());
    }

    private IEnumerator DelayGuia()
    {
        yield return new WaitForSeconds(3f);

        for (int i = 1; i < 3; i++)
        {
            _img.SetActive(true); // Mostrar fondo
            _gText.text = _guiasText[i]; // Mostrar texto

            yield return new WaitForSeconds(8f); // Tiempo de lectura

            _img.SetActive(false); // Ocultar fondo unos segundos (como respiro)
            yield return new WaitForSeconds(4f); // Pausa entre frases
        }

        yield return new WaitForSeconds(2f);

        _img.SetActive(true);
        _gText.text = _guiasText[3];//pa mostra la presentacion de afton

        yield return new WaitForSeconds(2f);

        for (int i = 4; i < _guiasText.Length; i++)
        {
            _img.SetActive(true); // Mostrar fondo
            _gText.text = _guiasText[i]; // Mostrar texto

            yield return new WaitForSeconds(8f); // Tiempo de lectura

            _img.SetActive(false); // Ocultar fondo unos segundos (como respiro)
            yield return new WaitForSeconds(4f); // Pausa entre frases
        }

        // Al terminar la guía, cambiar de escena
        SceneManager.LoadScene("Morning2.0");
    }

}
