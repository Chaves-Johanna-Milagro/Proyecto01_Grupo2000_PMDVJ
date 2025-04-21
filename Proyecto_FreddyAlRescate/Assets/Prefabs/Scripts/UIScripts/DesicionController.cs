using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DesicionController : MonoBehaviour
{
    private Transform characterDesicion; // seria el por defecto

    private Transform characterOpt1;
    private Transform characterOpt2;

    private Transform option1;
    private Transform option2;

    private Button option1Button;
    private Button option2Button;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterDesicion = transform.Find("CharacterDesicion");

        characterOpt1 = transform.Find("CharacterOpt1");

        option1 = transform.Find("Option1");
        option2 = transform.Find("Option2");

        option1Button = option1.GetComponent<Button>();

        option1Button.onClick.AddListener(OnOption1Clicked);
    }

    private void OnOption1Clicked() // si elije la opcion uno se activa su sprite 
    {         

        characterOpt1.gameObject.SetActive(true);

        DesactiveDefaults();

        StartCoroutine(DelayChoice());

    }

    private void DesactiveDefaults() //y desactiva todo lo otro
    { 
        characterDesicion.gameObject.SetActive(false);

        option1.gameObject.SetActive(false);

        option2.gameObject.SetActive(false);
    }

    private  IEnumerator DelayChoice() 
    {
        yield return new WaitForSeconds(2f);
        NotesController.Instance.CompleteDesicions();        
    }
}
