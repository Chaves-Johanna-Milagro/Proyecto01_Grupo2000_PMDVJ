using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu2_0 : MonoBehaviour
{
    private GameObject _bRedise�o;

    private Button _bRedise;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bRedise�o = transform.Find("BRedise�o").gameObject;

        _bRedise = _bRedise�o.GetComponent<Button>();

        _bRedise.onClick.AddListener(StartRedise�o);
    }

    public void StartRedise�o()
    {
        SceneManager.LoadScene("Morning2.0");
    }
}
