using System.Collections;
using UnityEngine;

public class MGMath : MonoBehaviour // pa el kiosko y la verduleria
{
    private GameObject _imgDes; // pa la imagen de la decision
    private GameObject _imgMath; //seria la imagen que contenga a los objetos del mini juego las opciones 

    private GameObject _opt1;
    private GameObject _opt2;
    private GameObject _opt3;

    private GameObject _imgGood; // para cuando responda bien
    private GameObject _imgBad; // para cuando responda mal

    private BKindnessUpDown _kind;

    private BMiniAfton _bAfton; //para dar retroalimentacion positiva cuando acierte

    void Start()
    {
        _imgDes = transform.Find("ImgDes").gameObject;
        _imgMath = transform.Find("ImgMG").gameObject;

        _opt1 = _imgMath.transform.Find("Opt1").gameObject;
        _opt2 = _imgMath.transform.Find("Opt2").gameObject;
        _opt3 = _imgMath.transform.Find("Opt3").gameObject;

        _imgGood = _imgMath.transform.Find("Good").gameObject;
        _imgBad = _imgMath.transform.Find("Bad").gameObject;

        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        _bAfton = Object.FindFirstObjectByType<BMiniAfton>();
    }

    public void ActiveMGMath(bool status)
    {
        _imgMath.SetActive(status);
        _imgDes.SetActive(false);
    }

    public void ChoiceOpt(string opt) // pa las opciones
    {
        if (opt == "Opt1" || opt == "Opt3")
        {
            _imgBad.SetActive(true);

            _opt1.SetActive(false);
            _opt2.SetActive(false);
            _opt3.SetActive(false);

            _kind.BadDecision();

            _bAfton.BadFeedback(); //lo motiva al equivocarse
        }
        if (opt == "Opt2")
        {
            _imgGood.SetActive(true);

            _opt1.SetActive(false);
            _opt2.SetActive(false);
            _opt3.SetActive(false);

            _kind.GoodDecision();   

            _bAfton.GoodFeedback(); //fpa dar felicitaciones
        }
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        _imgMath.SetActive(false);
    }
}
