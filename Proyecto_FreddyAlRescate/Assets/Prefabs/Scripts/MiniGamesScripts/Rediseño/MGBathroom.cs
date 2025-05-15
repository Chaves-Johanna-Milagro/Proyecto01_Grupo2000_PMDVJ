using UnityEngine;

public class MGBathroom : MonoBehaviour
{
    private Collider2D _col;
    private GameObject _miniGame;

    void Start()
    {
        _miniGame = transform.GetChild(0).gameObject;

        _miniGame.SetActive(false); //desactivar al inicio

        _col = GetComponent<Collider2D>();
    }

    public void OnMouseDown()
    {
        // Verifica si el juego está en pausa antes de procesar el click
        if (PauseStatus.IsPaused) return;
           
        _miniGame?.SetActive(true);

        //_col.enabled = false;
    }

    public void ExitMiniGame()
    {
        _miniGame?.SetActive(false);
    }
}
