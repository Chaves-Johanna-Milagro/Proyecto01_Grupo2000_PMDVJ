using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class BKindness : MonoBehaviour
{
    private GameObject[] _imgs;

    private int _count;

    private Button _BKind;

    private bool _isActive = false;

    private AudioSource _audioSource;

    void Start()
    {
        _count = transform.childCount;
        _imgs = new GameObject[_count];

        for (int i = 0; i < _count; i++) // desativar al inicio
        {
            _imgs[i] = transform.GetChild(i).gameObject;
            _imgs[i].SetActive(false);
        }

        _BKind = GetComponent<Button>();
        _BKind.onClick.AddListener(Toggle);

        _audioSource = GetComponent<AudioSource>();
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

        GameObject notes = GameObject.FindWithTag("Notes");

        if (notes != null && notes.activeInHierarchy) return; // No se activa si Notes está activo

        _isActive = !_isActive;
        SetActive(_isActive);
        if(_isActive) _audioSource.Play();
    }

    private void SetActive(bool state)
    {
        for (int i = 0; i < _count; i++)
        {
            _imgs[i].SetActive(state);
        }
    }
}
