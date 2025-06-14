using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMenu : MonoBehaviour
{
    private GameObject _notes;
    private GameObject _phone;
    private GameObject _calculator;

    private string _sceneName;
    void Start()
    {
        _notes = transform.Find("BNotes").gameObject;
        _phone = transform.Find("BPhone").gameObject;
        _calculator = transform.Find("BCalculator").gameObject;

        _sceneName = SceneManager.GetActiveScene().name;

        if (_sceneName == "WayToSchool2.0")
        {
            _notes.SetActive(false);
            _phone.SetActive(true);
        }
        else
        {
            _notes.SetActive(true);
            _phone.SetActive(false);
        }
    }

    public void Update()
    {

        if (_sceneName == "WayToSchool2.0")//pa que solo ocurra en esa escena
        {
            GameObject math = GameObject.FindWithTag("Math"); //para que busque con el tag math

            if (math != null && math.activeInHierarchy)//desactiva el telefono y activa la calculadora para usarla
            {
                _phone.SetActive(false);
                _calculator.SetActive(true);
            }
            else
            {
               _phone.SetActive(true);
               _calculator.SetActive(false);
            }
        }

    }
}

