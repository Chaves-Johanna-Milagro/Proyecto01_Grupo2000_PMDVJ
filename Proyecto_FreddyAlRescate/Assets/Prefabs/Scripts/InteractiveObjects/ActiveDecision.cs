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
            if (gameObject.name == "Arrow")
            {
                DecisionsNvl3.Instance.ActiveDecisionRoad();

                Transform _blockRoad = transform.parent.Find("BlockArrow");
                _blockRoad.gameObject.SetActive(false);

            }
            if(gameObject.name == "Kiosk") DecisionsNvl3.Instance.ActiveGreetKiosk();

            if(gameObject.name == "Greengrocery") DecisionsNvl3.Instance.ActiveGreetGreengrocery();

            _col.enabled = false;// desactivamos en collider

        }

    }
}
