using System.Collections;
using UnityEngine;

public class ActiveMiniGameUI : MonoBehaviour
{
    public static ActiveMiniGameUI Instance { get; private set; }

    private Transform _miniKiosk;
    private Transform _miniGreengrocery;


    private void Awake()
    {
        //limita la instancia a una sola
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(this); //permite que sobreviva a cambios de escena

        }
    }

    void Start()
    {
        _miniKiosk = transform.GetChild(0);
        _miniGreengrocery = transform.GetChild(1);

    }

    public void MiniGameKiosk() 
    {
        _miniKiosk.gameObject.SetActive(true);
    }

    public void MiniGameGreengrocery()
    {
        _miniGreengrocery.gameObject.SetActive(true);
    }

    public void DesactiveMiniGame()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay() 
    { 
        yield return new WaitForSeconds(1f);
        _miniKiosk.gameObject.SetActive(false);
        _miniGreengrocery.gameObject.SetActive(false);
    }
}
