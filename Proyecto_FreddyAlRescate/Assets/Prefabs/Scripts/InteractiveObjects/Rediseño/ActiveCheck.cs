using UnityEngine;

public class ActiveCheck : MonoBehaviour
{
    private BNotesChecks _check;

    private string _objName; 

    void Start()
    {
        _check = Object.FindFirstObjectByType<BNotesChecks>();

        _objName = gameObject.name;
    }

    public void OnMouseDown()
    {
        // Verifica si el juego está en pausa antes de procesar el click
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // no active checks si esta un mini juego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo


        //if (_objName == "Bed" || _objName == "Diningroom") _check.Check1();
        //if (_objName == "Bed") _check.Check1();

        //if (_objName == "Cupboard" || _objName == "Backpack") _check.Check2();
        if (_objName == "Cupboard") _check.Check2();

        //if (_objName == "Bathroom") _check.Check3();
    }
}
