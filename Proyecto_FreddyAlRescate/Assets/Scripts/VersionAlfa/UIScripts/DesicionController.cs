using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DesicionController : MonoBehaviour
{
    private Transform _characterDesicion; // seria el por defecto

    private Transform _characterOpt1;
    private Transform _characterOpt2;

    private Transform _option1;
    private Transform _option2;

    private Button _option1Button;
    private Button _option2Button;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterDesicion = transform.Find("CharacterDesicion");

        _characterOpt1 = transform.Find("CharacterOpt1");
        _characterOpt2 = transform.Find("CharacterOpt2");

        _option1 = transform.Find("Option1");
        _option2 = transform.Find("Option2");

        _option1Button = _option1.GetComponent<Button>();
        _option2Button = _option2.GetComponent<Button>();

        _option1Button.onClick.AddListener(OnOption1Clicked);
        _option2Button.onClick.AddListener(OnOption2Clicked);
    }

    private void OnOption1Clicked() // si elije la opcion uno se activa su sprite 
    {         

        _characterOpt1.gameObject.SetActive(true);

        DesactiveDefaults();

        StartCoroutine(DelayChoice());

    }

    private void OnOption2Clicked() // si elije la opcion uno se activa su sprite 
    {

        _characterOpt2.gameObject.SetActive(true);

        DesactiveDefaults();

        StartCoroutine(DelayChoice());

    }

    private void DesactiveDefaults() //y desactiva todo lo otro
    { 
        _characterDesicion.gameObject.SetActive(false);

        _option1.gameObject.SetActive(false);

        _option2.gameObject.SetActive(false);
    }

    private  IEnumerator DelayChoice() 
    {
        yield return new WaitForSeconds(1.2f);
        NotesController.Instance.CompleteDesicions();        
    }
}
