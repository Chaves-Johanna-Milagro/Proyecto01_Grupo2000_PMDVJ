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
        if (PauseStatus.IsPaused && _isActive)
        {
            _isActive = false;
            SetActive(false);
        }
    }

    public void Toggle()
    {
        if (PauseStatus.IsPaused) return;

        GameObject kindness = GameObject.FindWithTag("Kindness");

        if (kindness != null && kindness.activeInHierarchy) return;    // No se activa si Kindness está activo
       

        _isActive = !_isActive;
        SetActive(_isActive);
    }

    private void SetActive(bool state)
    {
        _img.SetActive(state);
        _text.SetActive(state);
    }
}
