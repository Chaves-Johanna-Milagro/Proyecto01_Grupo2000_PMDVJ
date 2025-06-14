using UnityEngine;
using UnityEngine.UI;

public class BCButton : MonoBehaviour
{
    private GameObject _screen; //la pantalla que mostrara su nombre

    private BCShowOperation _showOperation;

    private string _bName; //nombre del boton 1,2, c, = ,etc 

    private Button _button; //pa su componente 

    private AudioSource _audioSource;
    
    void Start()
    {
        _screen = transform.parent.transform.Find("Screen").gameObject;

        _showOperation = _screen.GetComponent<BCShowOperation>();

        _bName = gameObject.name;

        _button = GetComponent<Button>();

        _button.onClick.AddListener(SendName);

        _audioSource = GetComponent<AudioSource>();
    }

    public void SendName()
    {
        if (_audioSource != null) _audioSource.Play();

        if (_bName == "c") _showOperation.ClearScreen();

        else if (_bName == "=") _showOperation.Evaluate();

        else  _showOperation.Show(_bName);
    }
}
