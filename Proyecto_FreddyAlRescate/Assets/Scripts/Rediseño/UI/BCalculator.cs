using UnityEngine;
using UnityEngine.UI;

public class BCalculator : MonoBehaviour
{
    private GameObject[] _buttons; // los hijos que tiene el boton 

    private int _count; // pa la cantidad de hijos que tenga el boton

    private Button _bCal;

    private bool _isActive = false;
    void Start()
    {
        _count = transform.childCount;

        _buttons = new GameObject[_count];

        for (int i = 0; i < _count; i++) // desativar al inicio
        {
            _buttons[i] = transform.GetChild(i).gameObject;
            _buttons[i].SetActive(false);
        }

        _bCal = GetComponent<Button>();

        _bCal.onClick.AddListener(Toggle);
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
        for (int i = 0; i < _count; i++)
        {
            _buttons[i].SetActive(state);
        }
    }
}
