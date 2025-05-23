using System.Collections;
using UnityEngine;

public class DecisionGreet : MonoBehaviour
{
    private GameObject _bOpt1;
    private GameObject _bOpt2;


    private GameObject _charDefault;
    private GameObject _charGreet;
    private GameObject _charDontGreet;

    private GameObject _greet;
    private GameObject _greetSeller;

    private DecisionFood _choiseFood;

    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        _bOpt1 = parent.transform.Find("Opt1").gameObject;
        _bOpt2 = parent.transform.Find("Opt2").gameObject;

        _charDefault = parent.transform.Find("CharDefault").gameObject;
        _charGreet = parent.transform.Find("CharGreet").gameObject;
        _charDontGreet = parent.transform.Find("CharDontGreet").gameObject;

        _greet = parent.transform.Find("Greet").gameObject;
        _greetSeller = parent.transform.Find("GreetSeller").gameObject;

        _choiseFood = GetComponent<DecisionFood>();
    }

    public void ChoiceOpt(string name)
    {
        if (name == "Opt1")
        {
            _charGreet.SetActive(true);
            _greet.SetActive(true);
            DesactiveOpts();

            StartCoroutine(MensajeSeller());
        }
        if (name == "Opt2")
        {
            _charDontGreet.SetActive(true);
            DesactiveOpts();

            StartCoroutine(MensajeSeller());
        }
    }

    private void DesactiveOpts()
    {
        _charDefault.SetActive(false);
        _bOpt1.SetActive(false);
        _bOpt2.SetActive(false);
    }

    private IEnumerator MensajeSeller()
    {
        yield return new WaitForSeconds(2f);

        _greet.SetActive(false);

        yield return new WaitForSeconds(1f);

        _greetSeller.SetActive(true);
        _choiseFood.ActiveFood();
    }
}
