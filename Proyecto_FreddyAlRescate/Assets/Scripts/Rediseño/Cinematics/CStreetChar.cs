using System.Collections;
using UnityEngine;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cStopBus = transform.Find("CStopBus").gameObject;
        _cUpBus = transform.Find("CUpBus").gameObject;

        _char1 = transform.Find("Char1").gameObject;
        _char2 = transform.Find("Char2").gameObject;

        _chofer = transform.Find("Chofer").gameObject;

        _bGreet = transform.Find("BGreet").gameObject;
        _bDontGreet = transform.Find("BDontGreet").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (_isBus) return;

        if (CinematicStatus.ActiveCinematic()) _char1.SetActive(false); // si hay alguna cinematica corriendo
        else _char1.SetActive(true);

        if (CrossStreetStatus.GetStep() == 3) StartCoroutine(DelayCinematict());
    }
    public void Greet(string opt)
    {
        if (opt == "BGreet")
        {
            GameObject tGreet = _chofer.transform.Find("TextG").gameObject;
            GameObject globo = _chofer.transform.Find("Globo").gameObject;

            if (tGreet != null) tGreet.SetActive(true);
            if (globo != null) globo.SetActive(true);

            AudioSource _ag = _char2.GetComponent<AudioSource>();
            if (_ag != null) _ag.Play();

            Debug.Log("se saludo");
        }
        if(opt == "BDontGreet")
        {
            GameObject tDGreet = _chofer.transform.Find("TextDG").gameObject;
            GameObject globo = _chofer.transform.Find("Globo").gameObject;

            if (tDGreet != null) tDGreet.SetActive(true);
            if (globo != null) globo.SetActive(true);

            Debug.Log("no se saludo");
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
}
