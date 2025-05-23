using UnityEngine;

public class DecisionRoad : MonoBehaviour
{
    private GameObject _des;

    private GameObject _roadLeft; //serviran de botones
    private GameObject _roadRight;

    private BPhone _phone;

    void Start()
    {
        _des = transform.parent.gameObject;

        _roadLeft = _des.transform.Find("RoadLeft").gameObject;
        _roadRight = _des.transform.Find("RoadRight").gameObject;

        _phone = Object.FindFirstObjectByType<BPhone>();
    }

    public void ChoiceRoad(string name)
    {
        if (_phone == null) return;

        if (name == "RoadLeft") _phone.ActiveRoad("Izquierda");
        else if (name == "RoadRight") _phone.ActiveRoad("Derecha");
    }
}
