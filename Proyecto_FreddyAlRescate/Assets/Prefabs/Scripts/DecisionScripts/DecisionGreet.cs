using UnityEngine;

public class DecisionGreet : MonoBehaviour
{
    private GameObject _bOpt1;
    private GameObject _bOpt2;


    private GameObject _charDefault;
    private GameObject _charGreet;
    private GameObject _charDontGreet;

    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        _bOpt1 = parent.transform.Find("Opt1").gameObject;
        _bOpt2 = parent.transform.Find("Opt2").gameObject;

        _charDefault = parent.transform.Find("CharDefault").gameObject;
        _charGreet = parent.transform.Find("CharGreet").gameObject;
        _charDontGreet = parent.transform.Find("CharDontGreet").gameObject;
    }

    public void ChoiceOpt(string name)
    {
        if (name == "Opt1")
        {
            _charGreet.SetActive(true);
            DesactiveOpts();
        }
        if (name == "Opt2")
        {
            _charDontGreet.SetActive(true);
            DesactiveOpts();
        }
    }

    private void DesactiveOpts()
    {
        _charDefault.SetActive(false);
        _bOpt1.SetActive(false);
        _bOpt2.SetActive(false);
    }
}
