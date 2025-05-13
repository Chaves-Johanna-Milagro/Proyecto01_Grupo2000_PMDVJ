using UnityEngine;

public class ActiveCheck : MonoBehaviour
{
    private BNotesChecks _check;

    private string _objName; 

    void Start()
    {
        _check = Object.FindFirstObjectByType<BNotesChecks>();

        _objName = gameObject.name;
    }

    public void OnMouseDown()
    {

        if (_objName == "Bed" || _objName == "Diningroom") _check.Check1();

        if (_objName == "Cupboard" || _objName == "Backpack") _check.Check2();

        if (_objName == "Bathroom") _check.Check3();
    }

}
