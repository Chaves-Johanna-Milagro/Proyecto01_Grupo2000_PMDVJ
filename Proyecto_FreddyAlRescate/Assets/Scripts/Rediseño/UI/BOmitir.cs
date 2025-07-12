using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BOmitir : MonoBehaviour
{
    private Button _bOmitir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bOmitir = GetComponent<Button>();

        _bOmitir.onClick.AddListener(() => Next(SceneManager.GetActiveScene().name));
    }

    private void Next(string scene)
    {
        if(scene == "Intro2.0") SceneManager.LoadScene("Tutorial");
    }
}
