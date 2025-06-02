using UnityEngine;
using UnityEngine.UI;

public class BCButton : MonoBehaviour
{
    private GameObject _screen; //la pantalla que mostrara su nombre

    private BCShowOperation _showOperation;

    private string _bName; //nombre del boton 1,2, c, = ,etc 

    private Button _button; //pa su componente 
    
    void Start()
    {
        _screen = transform.parent.transform.Find("Screen").gameObject;

        _showOperation = _screen.GetComponent<BCShowOperation>();

        _bName = gameObject.name;

        _button = GetComponent<Button>();

        _button.onClick.AddListener(SendName);
    }

    public void SendName()
    {
        if (_bName == "c") _showOperation.ClearScreen();

        else if (_bName == "=") _showOperation.Evaluate();

        else  _showOperation.Show(_bName);
    }
}
