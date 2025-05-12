using UnityEngine;
using UnityEngine.UI;

public class BKindness : MonoBehaviour
{
    private GameObject[] _imgs;

    private int _count;

    private Button _BKind;

    private bool _isActive = false;

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
    }

    public void Toggle()
    {
        _isActive = !_isActive;

        for (int i = 0; i < _count; i++)
        {
            _imgs[i].SetActive(_isActive); // activa o desactiva según el estado
        }
    }
}
