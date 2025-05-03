using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    private Transform _imgDefault;

    private Transform _choiceRight;
    private Transform _choiceLeft;

    private Transform _imgNextNvl;

    void Start()
    {
        _imgDefault = transform.GetChild(0);

        _choiceRight = transform.GetChild(1);
        _choiceLeft = transform.GetChild(2);

        Transform parent = transform.parent;
        _imgNextNvl = parent.Find("ImgNextNvl");
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
    public void NextLevel() 
    {
        _imgNextNvl.gameObject.SetActive(true);
    }
}
