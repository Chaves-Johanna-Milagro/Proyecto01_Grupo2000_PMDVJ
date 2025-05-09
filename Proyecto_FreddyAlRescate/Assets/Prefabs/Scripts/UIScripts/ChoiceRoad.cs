using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceRoad : MonoBehaviour // lo tendra el cartel para elegir el camino
{
    private PhoneController _phoneController;

    private GameObject _rightBlock;
    private GameObject _leftBlock;

    private Button _rightButton;
    private Button _leftButton;

    void Start()
    {
        _phoneController = Object.FindFirstObjectByType<PhoneController>();

        _rightBlock = GameObject.FindGameObjectWithTag("RightBlock");
        _leftBlock = GameObject.FindGameObjectWithTag("LeftBlock");

        _rightButton = transform.GetChild(0).GetComponent<Button>();
        _leftButton = transform.GetChild(1).GetComponent<Button>();

        _rightButton.onClick.AddListener(ChoiceRoadRight);
        _leftButton.onClick.AddListener(ChoiceRoadLeft);
    }

    public void ChoiceRoadRight()
    {
        _phoneController.RoadRight();

        _rightBlock.SetActive(false);

        StartCoroutine(Delay());
    }
    public void ChoiceRoadLeft() 
    { 
        _phoneController.RoadLeft();

        _leftBlock.SetActive(false);
        
        StartCoroutine(Delay());
    }


    private IEnumerator Delay() 
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }



}
