using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionGreet2_0 : MonoBehaviour
{
    private GameObject _img;

    private GameObject _charDefault;
    private GameObject _charGreet;
    private GameObject _charDontGreet;

    private GameObject _opt1;
    private GameObject _opt2;

    private GameObject _instruction;

    private string _nameObj;

    private bool _next = false;

    private BKindnessUpDown _kind;

    void Start()
    {
        _img = transform.Find("Img").gameObject;

        _charDefault = transform.Find("CharDefault").gameObject;
        _charGreet = transform.Find("CharGreet").gameObject;
        _charDontGreet = transform.Find("CharDontGreet").gameObject;

        _opt1 = transform.Find("Opt1").gameObject;
        _opt2 = transform.Find("Opt2").gameObject;

        _instruction = transform.Find("Instruccion").gameObject;

        _nameObj = gameObject.name;

        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();
    }

    public void Update()
    {
        if (_next) NextAction();
    }

    public void OnMouseDown()
    {
        StatusSprites(true);
    }

    private void StatusSprites(bool status)
    {
        _img.SetActive(status);

        _charDefault.SetActive(status);

        _opt1.SetActive(status);
        _opt2.SetActive(status);

        _instruction.SetActive(status);
    }

    public void SelectOpt(string opt)
    {
        if (opt == "Opt1")
        {
            _charGreet.SetActive(true);
            _charDefault.SetActive(false);
            _opt1.SetActive(false);
            _opt2.SetActive(false);
            _instruction.SetActive(false);

            _kind.GoodDecision();

            _next = true;
           
        }
        if (opt == "Opt2")
        {
            _charDontGreet.SetActive(true);
            _charDefault.SetActive(false);
            _opt1.SetActive(false);
            _opt2.SetActive(false);
            _instruction.SetActive(false);

            _kind.BadDecision();

            _next = true;
        }
    } 

    private void NextAction()
    {
        if (_nameObj == "DoorStreet")
        {
            GameObject _despedida = transform.Find("Despedida").gameObject;

            _despedida.SetActive(true);

            StartCoroutine(Delay());
            
            _next = false;
        }
    }
  
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        if (_nameObj == "DoorStreet") SceneManager.LoadScene("WayToSchool2.0");
    }
}
