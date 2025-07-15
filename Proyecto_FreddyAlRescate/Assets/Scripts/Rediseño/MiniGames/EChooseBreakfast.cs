using UnityEngine;

public class EChooseBeakfast : MonoBehaviour
{
    private GameObject[] _childs;
    private int _count;

    private string _selectedFood = "";
    private string _selectedDrink = "";

    private GameObject _foodReal;
    private GameObject _drinkReal;

    private Vector3 _posFood;
    private Vector3 _posDrink;

    private bool _foodReady = false;
    private bool _drinkReady = false;

    void Start()
    {
        _count = transform.childCount;
        _childs = new GameObject[_count];

        // Guarda los hijos (botones de selección)
        for (int i = 0; i < _count; i++)
        {
            _childs[i] = transform.GetChild(i).gameObject;
            _childs[i].SetActive(true); // activar visualmente
        }
    }

    public void SelectFood(string foodName)
    {
        // Desactiva anterior si hay
        if (_foodReal != null) _foodReal.SetActive(false);

        _selectedFood = foodName;

        _foodReal = ActivateRealObject(foodName);
        if (_foodReal != null)
        {
            _posFood = _foodReal.transform.position;
            _foodReady = true;
        }

        CheckIfBothSelected();
    }

    public void SelectDrink(string drinkName)
    {
        if (_drinkReal != null) _drinkReal.SetActive(false);

        _selectedDrink = drinkName;

        _drinkReal = ActivateRealObject(drinkName);
        if (_drinkReal != null)
        {
            _posDrink = _drinkReal.transform.position;
            _drinkReady = true;
        }

        CheckIfBothSelected();
    }

    private GameObject ActivateRealObject(string objectName)
    {
        // Busca entre hermanos (el padre del EChooseBeakfast)
        Transform parent = transform.parent;
        Transform realObj = parent.Find(objectName);

        if (realObj != null)
        {
            GameObject obj = realObj.gameObject;
            obj.SetActive(true);

            // Collider desactivado hasta que estén ambas selecciones
            Collider2D col = obj.GetComponent<Collider2D>();
            if (col != null) col.enabled = false;

            return obj;
        }

        return null;
    }

    private void CheckIfBothSelected()
    {
        if (_foodReady && _drinkReady)
        {
            // Activa colliders
            if (_foodReal != null)
            {
                Collider2D col = _foodReal.GetComponent<Collider2D>();
                if (col != null) col.enabled = true;
            }

            if (_drinkReal != null)
            {
                Collider2D col = _drinkReal.GetComponent<Collider2D>();
                if (col != null) col.enabled = true;
            }

            // Desactiva los botones hijos (ya no se puede elegir más)
            DesactiveObjs();
        }
    }

    private void DesactiveObjs()
    {
        for (int i = 0; i < _count; i++)
        {
            _childs[i].SetActive(false);
        }
    }

    public Vector3 GetPosFood() => _posFood;
    public Vector3 GetPosDrink() => _posDrink;
}
