using UnityEngine;
using UnityEngine.UI;

public class MiniMenu : MonoBehaviour
{
    private GameObject _BPause;
    private GameObject _BNotes;
    private GameObject _BKindness;
    private GameObject _BAfton;

    private Button _BMiniMenu;

    private bool _isActive = false;
    void Start()
    {
        _BPause = transform.GetChild(0).gameObject;
        _BNotes = transform.GetChild(1).gameObject;
        _BKindness = transform.GetChild(2).gameObject;
        _BAfton = transform.GetChild(3).gameObject;

        _BMiniMenu = GetComponent<Button>();

        _BMiniMenu.onClick.AddListener(Toggle);
    }

    public void Toggle() 
    {
        _isActive = !_isActive;

        if (_isActive)
        {
            _BPause.SetActive(false);
            _BNotes.SetActive(false);
            _BKindness.SetActive(false);
            _BAfton.SetActive(false);
        }
        else
        {
            _BPause.SetActive(true);
            _BNotes.SetActive(true);
            _BKindness.SetActive(true);
            _BAfton.SetActive(true);
        }
    }
}
