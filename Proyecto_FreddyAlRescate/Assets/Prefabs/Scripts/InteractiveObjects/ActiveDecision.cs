using UnityEngine;

public class ActiveDecision : MonoBehaviour
{
    private Collider2D _col;
    private bool _isActive = false;

    private Transform _blockRoads;

    private void Start()
    {
        _col = GetComponent<Collider2D>();
        _blockRoads = transform.GetChild(0);
    }

    public void OnMouseDown()
    {
        _isActive = true;

        if (_isActive) 
        { 
            if (gameObject.name == "Arrows") DecisionsNvl3.Instance.ActiveDecisionRoad();

            if(gameObject.name == "Kiosk") DecisionsNvl3.Instance.ActiveGreetKiosk();

            if(gameObject.name == "Greengrocery") DecisionsNvl3.Instance.ActiveGreetGreengrocery();

            _col.enabled = false;// desactivamos en collider
            _blockRoads.gameObject.SetActive(false);
        }

    }
}
