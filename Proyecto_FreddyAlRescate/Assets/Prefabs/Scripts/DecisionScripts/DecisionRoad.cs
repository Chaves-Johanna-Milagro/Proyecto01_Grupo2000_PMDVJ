using System.Collections;
using UnityEngine;

public class DecisionRoad : MonoBehaviour
{
    private GameObject _img;

    private GameObject _roadLeft; //serviran de botones
    private GameObject _roadRight;

    private GameObject _instruction;

    private BPhone _phone;

    void Start()
    {
        _img = transform.Find("Img").gameObject;
    
        _roadRight = transform.Find("ArrowRight").gameObject;
        _roadLeft = transform.Find("ArrowLeft").gameObject;

        _instruction = transform.Find("Instruccion").gameObject;

        _phone = Object.FindFirstObjectByType<BPhone>();
    }

    public void ChoiceRoad(string name)
    {
        if (_phone == null) return;

        if (name == "ArrowLeft") _phone.ActiveRoad("Izquierda");
        else if (name == "ArrowRight") _phone.ActiveRoad("Derecha");
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        _img.SetActive(false);
        _roadRight.SetActive(false);
        _roadLeft.SetActive(false);
        _instruction.SetActive(false);
    }
}
