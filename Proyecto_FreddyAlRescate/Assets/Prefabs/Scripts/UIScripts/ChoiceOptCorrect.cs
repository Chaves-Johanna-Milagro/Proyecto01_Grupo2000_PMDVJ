using UnityEngine;
using UnityEngine.UI;

public class ChoiceOptCorrect : MonoBehaviour //se encargara se cambiara el personaje si es que elige la correcta o no
{
    private Button _opt1;
    private Button _opt2;
    private Button _opt3;

    private void Start()
    {
        _opt1 = transform.GetChild(0).GetComponent<Button>();
        _opt2 = transform.GetChild(1).GetComponent<Button>(); // la segunda siempre sera la correcta por ahora
        _opt3 = transform.GetChild(2).GetComponent<Button>();

        _opt1.onClick.AddListener(ChoiceOpt1);
        _opt2.onClick.AddListener(ChoiceOpt2);
        _opt3.onClick.AddListener(ChoiceOpt3);
    }

    public void ChoiceOpt1() 
    {
        ActiveMiniGameUI.Instance.DesactiveMiniGame();
        BarKindnessController.Instance.BadDecision();
    }
    public void ChoiceOpt2()
    {

        ActiveMiniGameUI.Instance.DesactiveMiniGame();
        BarKindnessController.Instance.GoodDecision();//pa que suba la barra si elige bien

    }
    public void ChoiceOpt3()
    {
        ActiveMiniGameUI.Instance.DesactiveMiniGame();
        BarKindnessController.Instance.BadDecision();
    }
}
