using UnityEngine;

public class ClickOptionGSeller : MonoBehaviour
{
    private string _name;

    private DecisionGreetSeller _decision;

    void Start()
    {
        _name = gameObject.name;

        GameObject parent = transform.parent.gameObject;
        
        _decision = transform.parent.GetComponentInChildren<DecisionGreetSeller>();
    }

    public void OnMouseDown()
    {
        // Verifica si el juego está en pausa antes de procesar el click
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        _decision.ChoiceOpt(_name);
    }
}
