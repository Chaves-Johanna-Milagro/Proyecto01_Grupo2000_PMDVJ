using UnityEngine;

public class DesactiveAnimation : MonoBehaviour
{
    private Collider2D _collider2D;
    private bool _isClick = false;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        _isClick = true;
        _collider2D.enabled = false;
    }

    private void Update()
    {
        GameObject miniGame = GameObject.FindGameObjectWithTag("MiniGame");
        GameObject pause = GameObject.FindGameObjectWithTag("Pause");

        // Si el minijuego o la pausa est�n activos, desactiva el collider
        if ((miniGame != null && miniGame.activeInHierarchy) || (pause != null && pause.activeInHierarchy))
        {
            _collider2D.enabled = false;
            return; // Sale del m�todo para evitar que se vuelva a activar m�s abajo
        }

        // Si no hay minijuego, no se ha hecho click y el juego no est� pausado, activa el collider
        if (!_isClick)
        {
            _collider2D.enabled = true;
        }
    }
}
