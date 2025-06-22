using UnityEngine;

public class LimitRoad : MonoBehaviour
{
    private GameObject _RLimit; //limite derecho
    private GameObject _LLimit; //limite izquierdo

    private BPhone _phone;

    void Start()
    {
        _RLimit = transform.Find("RightLimit").gameObject;
        _LLimit = transform.Find("LeftLimit").gameObject;

        _phone = Object.FindFirstObjectByType<BPhone>();
    }

   
    void Update()
    {
       if ( _phone == null ) _phone = Object.FindFirstObjectByType<BPhone>();

        string lastRoad = _phone.GetLastRoad();

        if (lastRoad == "Derecha")
        {
            _LLimit.SetActive(true);
            _RLimit.SetActive(false);
        }
        else if (lastRoad == "Izquierda")
        {
            _RLimit.SetActive(true);
            _LLimit.SetActive(false);
        }

    }
}
