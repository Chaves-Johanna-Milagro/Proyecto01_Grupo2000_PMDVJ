using UnityEngine;

public class ActiveDecision : MonoBehaviour
{
    private Collider2D _col;
    private bool _isActive = false;

    private void Start()
    {
        _col = GetComponent<Collider2D>();
    }

    public void OnMouseDown()
    {
        _isActive = true;

        if (_isActive) 
        { 
            if (gameObject.name == "Arrows") DecisionsNvl3.Instance.ActiveDecisionRoad();

            _col.enabled = false;// desactivamos en collider
        }

    }
}
