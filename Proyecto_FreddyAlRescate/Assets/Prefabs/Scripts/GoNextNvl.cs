using UnityEngine;

public class GoNextNvl : MonoBehaviour
{
    private PhoneController _phoneController; 
    void Start()
    {
        _phoneController = Object.FindFirstObjectByType<PhoneController>();
    }

    public void OnMouseDown()
    {
        _phoneController.NextLevel();
    }
}
