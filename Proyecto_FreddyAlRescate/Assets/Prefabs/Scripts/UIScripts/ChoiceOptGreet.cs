using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceOptGreet : MonoBehaviour // este script lo tendra kiosko/verduleria de la UI
{

    private Button _opt1; //saludar
    private Button _opt2; // no saludar

    private Transform _idle;
    private Transform _greet;
    private Transform _dontGreet;

    void Start()
    {
        _idle = transform.GetChild(2);
        _greet = transform.GetChild(3);
        _dontGreet = transform.GetChild(4);

        _opt1 = transform.GetChild(0).GetComponent<Button>();
        _opt2 = transform.GetChild(1).GetComponent<Button>();

        _opt1.onClick.AddListener(ActiveGreet);
        _opt2.onClick.AddListener(ActiveDontGreet);
    }

    private void ActiveGreet()
    {
        _idle.gameObject.SetActive(false);
        _greet.gameObject.SetActive(true);
        StartCoroutine(Delay());

        BarKindnessController.Instance.GoodDecision();
    }

    private void ActiveDontGreet()
    {
        _idle.gameObject.SetActive(false);
        _dontGreet.gameObject.SetActive(true);
        StartCoroutine(Delay());

        BarKindnessController.Instance.BadDecision();
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
