using UnityEngine;

public class ClickRoad : MonoBehaviour
{
    private string _name;

    private DecisionRoad _des;
    
    void Start()
    {
        _name = gameObject.name;

        _des = GetComponentInParent<DecisionRoad>();
    }

    void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        _des?.ChoiceRoad(_name);
    }
}
