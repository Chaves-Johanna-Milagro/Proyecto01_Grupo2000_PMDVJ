using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CStreetChar : MonoBehaviour
{
    private GameObject _cStopBus; //cinematicas
    private GameObject _cUpBus;
    private GameObject _cBus; // pa cuando ya esta en el cole

    private GameObject _char1; //el que mira la calle
    private GameObject _char2; // el q mira al chofer

    private GameObject _chofer;

    private GameObject _bGreet; //boton de buenos dias
    private GameObject _bDontGreet; //boton de ...

    private bool _isBus = false;
    private bool _isCompleted = false;
    private bool _isIncompleted = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cStopBus = transform.Find("CStopBus").gameObject;
        _cUpBus = transform.Find("CUpBus").gameObject;
        _cBus = transform.Find("CBus").gameObject;

        _char1 = transform.Find("Char1").gameObject;
        _char2 = transform.Find("Char2").gameObject;

        _chofer = transform.Find("Chofer").gameObject;

        _bGreet = transform.Find("BGreet").gameObject;
        _bDontGreet = transform.Find("BDontGreet").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (_isIncompleted && _isCompleted) StartCoroutine(NextScene());

        if (_isBus) return;

        if (CinematicStatus.ActiveCinematic()) _char1.SetActive(false); // si hay alguna cinematica corriendo
        else _char1.SetActive(true);

        if (CrossStreetStatus.GetStep() == 3) StartCoroutine(DelayCinematict());


    }
    public void Greet(string opt)
    {
        if (opt == "BGreet")
        {
            //GameObject tGreet = _chofer.transform.Find("TextG").gameObject;
            //GameObject globo = _chofer.transform.Find("Globo").gameObject;

            StartCoroutine(DelayGreet());

            //if (tGreet != null) tGreet.SetActive(true);
            //if (globo != null) globo.SetActive(true);

            Debug.Log("se saludo");

            StartCoroutine(DelayMGsube());
        }
        if(opt == "BDontGreet")
        {
            GameObject tDGreet = _chofer.transform.Find("TextDG").gameObject;
            GameObject globo = _chofer.transform.Find("Globo").gameObject;

            if (tDGreet != null) tDGreet.SetActive(true);
            if (globo != null) globo.SetActive(true);

            Debug.Log("no se saludo");

            StartCoroutine(DelayMGsube());
        }

        _bGreet.SetActive(false);
        _bDontGreet.SetActive(false);
    }

    private IEnumerator DelayCinematict()
    {
        _isBus = true;
        _char1.SetActive(false);

        yield return new WaitForSeconds(5f);

        _cStopBus.SetActive(true);

        yield return new WaitForSeconds(5f);
        _char2.SetActive(true);
        _cUpBus.SetActive(true);
        _chofer.SetActive(true);
        _bGreet.SetActive(true);
        _bDontGreet.SetActive(true);
    }

    private IEnumerator DelayMGsube()
    {
        yield return new WaitForSeconds(7f);
        GameObject mj = transform.Find("MGSube").gameObject;
        mj.SetActive(true);
        yield return new WaitForSeconds(2f);
        _char2.SetActive(false);
        _cUpBus.SetActive(false);
        _chofer.SetActive(false);
    }

    private IEnumerator NextScene()
    {
        _isIncompleted = false;

        yield return new WaitForSeconds(3.5f);
        _cBus.SetActive(true);
        GameObject mj = transform.Find("MGSube").gameObject;
        mj.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("CSchoolStart");
    }
    private IEnumerator DelayGreet() 
    {
        AudioSource _ag = _char2.GetComponent<AudioSource>();
        if (_ag != null) _ag.Play();

        yield return new WaitForSeconds(2.5f);
        GameObject tGreet = _chofer.transform.Find("TextG").gameObject;
        GameObject globo = _chofer.transform.Find("Globo").gameObject;

        AudioSource _agc = _chofer.GetComponent<AudioSource>();
        if (_agc != null) _agc.Play();

        if (tGreet != null) tGreet.SetActive(true);
        if (globo != null) globo.SetActive(true);
    }
    public void IsCompleteMG() { _isCompleted = true; }
}
