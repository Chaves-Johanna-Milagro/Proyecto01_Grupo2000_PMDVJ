using UnityEngine;
using UnityEngine.UI;

public class MiniMenu : MonoBehaviour
{
    // �ndices:
    // [0] = Bot�n de Pausa
    // [1] = Bot�n de Notas
    // [2] = Bot�n de Kindness
    // [3] = Bot�n de Afton
    private GameObject[] _buttons;

    private Button _BMiniMenu;

    private bool _isActive = true;

    void Start()
    {
        // Inicializamos el array con 4 elementos (los hijos del men�)
        _buttons = new GameObject[4];

        for (int i = 0; i < 4; i++)
        {
            _buttons[i] = transform.GetChild(i).gameObject;
            _buttons[i].SetActive(false); //desactivados al inicio
        }

        _BMiniMenu = GetComponent<Button>();
        _BMiniMenu.onClick.AddListener(Toggle);
    }

    public void Toggle()
    {
        _isActive = !_isActive;

        for (int i = 0; i < _buttons.Length; i++)
        {
            // Activamos o desactivamos todos los botones seg�n el estado
            _buttons[i].SetActive(!_isActive);
        }
    }
}
