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

       if (_phone.GetLastRoad() == "Derecha" ) _LLimit.SetActive(true);
       if (_phone.GetLastRoad() == "Izquierda" ) _RLimit.SetActive(true);
    }
}
