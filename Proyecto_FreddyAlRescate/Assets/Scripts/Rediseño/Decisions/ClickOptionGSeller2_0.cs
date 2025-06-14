using UnityEngine;

public class ClickOptionGSeller2_0 : MonoBehaviour
{
    private DecisionGreetSeller2_0 _des;

    private string _nameOpt;
    void Start()
    {
        GameObject _parent = transform.parent.gameObject; 

        _des = _parent?.transform.GetComponentInParent<DecisionGreetSeller2_0>();

        _nameOpt = gameObject.name;
    }

    public void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        _des.SelectOpt(_nameOpt);
    }

}
