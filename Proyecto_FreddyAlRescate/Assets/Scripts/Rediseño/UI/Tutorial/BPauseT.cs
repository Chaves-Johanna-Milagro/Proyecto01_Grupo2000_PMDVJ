using UnityEngine;
using UnityEngine.UI;

public class BPauseT : MonoBehaviour
{
    private GameObject[] _childs;
    private int _count;

    private bool _isActive = false;

    private Button _bNotes;

    void Start()
    {
        _count = transform.childCount;
        _childs = new GameObject[_count];

        for (int i = 0; i < _count; i++) // desativar al inicio
        {
            _childs[i] = transform.GetChild(i).gameObject;
            _childs[i].SetActive(false);
        }

        _bNotes = GetComponent<Button>();
        _bNotes.onClick.AddListener(Toggle);
    }
    private void Update()
    {
        if (PauseStatus.IsPaused && _isActive)
        {
            _isActive = false;
            Objts(false);
        }
    }
    private void Toggle()
    {
        _isActive = !_isActive;

        Objts(_isActive);
    }

    private void Objts(bool active)
    {
        for (int i = 0; i < _count; i++) // desativar al clikear
        {
            _childs[i].SetActive(active);
        }
    }
}
