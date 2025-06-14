using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu2_0 : MonoBehaviour
{
    private GameObject _bJugar;
    private GameObject _bRedise�o;

    private GameObject _imgMath;//hijo del boton de redise�o

    private Button _bRedise;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bJugar = transform.Find("PlayButton").gameObject;

        _bRedise�o = transform.Find("BRedise�o").gameObject;

        _imgMath = _bRedise�o.transform.Find("ImgMath").gameObject;

        _bRedise = _bRedise�o.GetComponent<Button>();

        _bRedise.onClick.AddListener(StartRedise�o);
    }

    public void StartRedise�o()
    {
       // SceneManager.LoadScene("Morning2.0");
       _bJugar.SetActive(false);
       _imgMath.SetActive(true);
    }
}
