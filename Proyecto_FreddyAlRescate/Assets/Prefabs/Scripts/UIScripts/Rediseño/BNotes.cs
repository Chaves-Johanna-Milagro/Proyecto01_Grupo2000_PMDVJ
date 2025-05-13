using UnityEngine;
using UnityEngine.UI;

public class BNotes : MonoBehaviour
{
    private GameObject _img;
    private GameObject _text;
    
    private Button _BNotes;

    private bool _isActive = false;
    void Start()
    {
        _img = transform.GetChild(0).gameObject;
        _text = transform.GetChild(1).gameObject;

        _img.SetActive(false); // desactivada al inicio
        _text.SetActive(false); // desactivada al inicio

        _BNotes = GetComponent<Button>();

        _BNotes.onClick.AddListener(Toggle);
    }


    void Update()
    {
        // Si el juego está pausado y hay algo activo, lo cerramos
        if (PauseStatus.IsPaused && _isActive)
        {
            _img.SetActive(false);
            _text.SetActive(false);
            _isActive = false;
        }
    }

    public void Toggle()
    {
        _isActive = !_isActive;

        _img.SetActive(_isActive);
        _text.SetActive(_isActive);
    }
}
