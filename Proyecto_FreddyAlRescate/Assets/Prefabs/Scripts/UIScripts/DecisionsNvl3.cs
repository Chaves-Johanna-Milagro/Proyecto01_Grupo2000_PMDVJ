using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionsNvl3 : MonoBehaviour
{
    public static DecisionsNvl3 Instance { get; private set; }


    private Transform _choiceRoad; // pa la desicion del camino

    private Transform _kiosk; // pa la desicion de saludar o no
    private Transform _greengrocery; // pa la desicion de saludar o no


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
        _choiceRoad = transform.GetChild(0);

        _kiosk = transform.GetChild(1);
        _greengrocery = transform.GetChild(2);

    }

    public void ActiveDecisionRoad()
    {
        _choiceRoad.gameObject.SetActive(true);
    }

    public void ActiveGreetKiosk() 
    {
        _kiosk.gameObject.SetActive(true);
    }
    public void ActiveGreetGreengrocery() 
    {
        _greengrocery.gameObject.SetActive(true);
    }

    public void DesactiveDecision()
    { 
        _kiosk.gameObject.SetActive(false);
        _greengrocery.gameObject.SetActive(false);
    }
}
