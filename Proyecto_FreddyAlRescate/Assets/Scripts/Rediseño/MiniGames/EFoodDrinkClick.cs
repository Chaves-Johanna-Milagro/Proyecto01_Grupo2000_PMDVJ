using UnityEngine;

public class EFoodDrinkClick : MonoBehaviour
{
    private EChooseBeakfast _cBreakfast;

    void Start()
    {
        _cBreakfast = GetComponentInParent<EChooseBeakfast>();
    }

    public void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        if (gameObject.name == "GALLETAS" || gameObject.name == "SANWIS" || gameObject.name == "PAN CON MERMELADA") _cBreakfast.SelectFood(gameObject.name);
        if (gameObject.name == "TE" || gameObject.name == "MATE" || gameObject.name == "LICUADO") _cBreakfast.SelectDrink(gameObject.name);
    }
}
