using UnityEngine;

public class ClickOptionMath : MonoBehaviour
{
    private MGMath _math;

    private string _name; //nombre de la opcion

    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        _math = parent.GetComponentInParent<MGMath>();

        _name = gameObject.name;
    }

    public void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        //if (MiniGameStatus.ActiveMiniGame()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        _math.ChoiceOpt(_name);

        gameObject.SetActive(false);
    }
    
}
