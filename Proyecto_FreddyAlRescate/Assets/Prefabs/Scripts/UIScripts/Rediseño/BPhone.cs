using UnityEngine;
using UnityEngine.UI;

public class BPhone : MonoBehaviour
{
    private GameObject _img1; // pa el camino izquierdo
    private GameObject _img2; // pa el camino derecho

    private Button _BPhone;

    private bool _isActive = false;

    private string _lastRoad = ""; // Guarda el último camino elegido

    void Start()
    {
        _img1 = transform.GetChild(0).gameObject;
        _img2 = transform.GetChild(1).gameObject;

        _img1.SetActive(false);
        _img2.SetActive(false);

        _BPhone = GetComponent<Button>();
        _BPhone.onClick.AddListener(Toggle);
    }

    void Update()
    {
        if (PauseStatus.IsPaused && _isActive)
        {
            _isActive = false;
            SetActive(false); // oculta si el juego se pausa
        }
    }

    public void Toggle()
    {
        if (PauseStatus.IsPaused) return;

        GameObject kindness = GameObject.FindWithTag("Kindness");
        if (kindness != null && kindness.activeInHierarchy) return;

        _isActive = !_isActive;
        SetActive(_isActive);
    }

    private void SetActive(bool state)
    {
        _img1.SetActive(false);
        _img2.SetActive(false);

        if (!state) return;

        if (_lastRoad == "Izquierda") _img1.SetActive(true);
        else if (_lastRoad == "Derecha") _img2.SetActive(true);
    }

    public void ActiveRoad(string road)
    {
        _lastRoad = road; // Se guarda el camino elegido
        if (_isActive)
        {
            SetActive(true); // si ya está abierto, actualiza la imagen mostrada
        }
    }
}
