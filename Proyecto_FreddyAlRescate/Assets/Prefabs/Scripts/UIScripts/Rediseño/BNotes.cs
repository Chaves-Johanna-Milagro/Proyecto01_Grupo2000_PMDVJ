using UnityEngine;
using UnityEngine.UI;

public class BNotes : MonoBehaviour
{
    private GameObject _img;
    
    private Button _BNotes;

    private bool _isActive = true;
    void Start()
    {
        _img = transform.GetChild(0).gameObject;

        _img.SetActive(false); // desactivada al inicio

        _BNotes = GetComponent<Button>();

        _BNotes.onClick.AddListener(Toggle);
    }

    public void Toggle()
    {
        _isActive = !_isActive;

        if (_isActive)
        {
            _img.SetActive(false);
        }
        else
        {
            _img.SetActive(true);
        }
    }
}
