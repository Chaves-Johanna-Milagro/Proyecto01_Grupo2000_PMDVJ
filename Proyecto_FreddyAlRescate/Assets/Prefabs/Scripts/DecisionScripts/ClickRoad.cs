using UnityEngine;

public class ClickRoad : MonoBehaviour
{
    private string _name;

    private DecisionRoad _des;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _name = gameObject.name;

        GameObject parent = transform.parent.gameObject;

        _des = transform.parent.GetComponentInChildren<DecisionRoad>();
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
