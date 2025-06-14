using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu2_0 : MonoBehaviour
{
    private GameObject _bJugar;
    private GameObject _bRediseño;

    private GameObject _imgMath;//hijo del boton de rediseño

    private Button _bRedise;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bJugar = transform.Find("PlayButton").gameObject;

        _bRediseño = transform.Find("BRediseño").gameObject;

        _imgMath = _bRediseño.transform.Find("ImgMath").gameObject;

        _bRedise = _bRediseño.GetComponent<Button>();

        _bRedise.onClick.AddListener(StartRediseño);
    }

    public void StartRediseño()
    {
       // SceneManager.LoadScene("Morning2.0");
       _bJugar.SetActive(false);
       _imgMath.SetActive(true);
    }
}
