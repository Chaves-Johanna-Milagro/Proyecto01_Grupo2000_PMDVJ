using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInScene : MonoBehaviour
{
    public static CharacterInScene Instance {  get; private set; }


    private string _currentScene;

    private Transform _charNvl1;
    private Transform _charNvl2;

    private Transform _idleNvl1;  //personaje en pijama
    private Transform _action1Nvl1; // sprite con la ropa cambiada
    private Transform _action2Nvl1; //temdiemdo la cama

    private Transform _idleNvl2;  //personaje con la ropa cambiada
    private Transform _action1Nvl2; // sprite despues de desayunar

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
        _charNvl1 = transform.GetChild(0);
        _charNvl2 = transform.GetChild(1);

        _idleNvl1 = _charNvl1.transform.GetChild(0);
        _action1Nvl1 = _charNvl1.transform.GetChild(1);
        _action2Nvl1 = _charNvl1.transform.GetChild(2);


        _idleNvl2 = _charNvl2.transform.GetChild(0);
        _action1Nvl2 = _charNvl2.transform.GetChild(1);


        _currentScene = SceneManager.GetActiveScene().name;


        if (_currentScene == "Morning")
        {
            _charNvl1.gameObject.SetActive(true);
            _idleNvl1 .gameObject.SetActive(true);

        }

        else if (_currentScene == "Breackfast")
        {
            _charNvl2.gameObject.SetActive(true);
            _idleNvl2.gameObject.SetActive(true);
        }
    }

    public void MakeTheBed()
    {
        _idleNvl1.gameObject.SetActive(false);

        _action2Nvl1 .gameObject.SetActive(true);
    }
    public void PutUniform()
    {
        _idleNvl1.gameObject.SetActive (false);

        _action1Nvl1.gameObject.SetActive(true);

        _idleNvl1 = _action1Nvl1;

    }


    public void HaveBreackfast()
    {
        _idleNvl2.gameObject.SetActive(false);

        _action1Nvl2.gameObject.SetActive(true);
    }
    public void DesactiveAction()
    {
        if(_currentScene == "Morning")
        {
            _idleNvl1.gameObject.SetActive(false);
            _action1Nvl1.gameObject.SetActive(false);
            _action2Nvl1.gameObject.SetActive(false);
        }

        else if (_currentScene == "Breackfast")
        {
            _idleNvl2.gameObject.SetActive(false);
            _action1Nvl2.gameObject.SetActive(false);
        }

    }

}
