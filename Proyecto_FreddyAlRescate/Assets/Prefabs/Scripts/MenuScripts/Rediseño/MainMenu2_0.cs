using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu2_0 : MonoBehaviour
{
    private GameObject _bRediseño;

    private Button _bRedise;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bRediseño = transform.Find("BRediseño").gameObject;

        _bRedise = _bRediseño.GetComponent<Button>();

        _bRedise.onClick.AddListener(StartRediseño);
    }

    public void StartRediseño()
    {
        SceneManager.LoadScene("Morning2.0");
    }
}
