using UnityEngine;

public class CStreetGreet : MonoBehaviour
{
    private CStreetChar _schar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _schar = GetComponentInParent<CStreetChar>();
    }

    private void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;// Verifica si el juego está en pausa antes de procesar el click

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        //if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        _schar.Greet(gameObject.name);
    }
}
