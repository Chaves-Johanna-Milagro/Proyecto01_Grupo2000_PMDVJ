using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    private Transform _imgDefault;

    private Transform _choiceRight;
    private Transform _choiceLeft;

    void Start()
    {
        _imgDefault = transform.GetChild(0);

        _choiceRight = transform.GetChild(1);
        _choiceLeft = transform.GetChild(2);

    }

    public void RoadRight() 
    { 
        _imgDefault.gameObject.SetActive(false);
        _choiceRight.gameObject.SetActive(true);
    } 

    public void RoadLeft() 
    { 
        _imgDefault.gameObject.SetActive(false);
        _choiceLeft.gameObject.SetActive(true);
    } 

}
