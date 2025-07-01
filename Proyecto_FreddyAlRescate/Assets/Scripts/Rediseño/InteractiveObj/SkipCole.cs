using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SkipCole : MonoBehaviour
{

    private Button _bSkip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bSkip = GetComponent<Button>();

        _bSkip.onClick.AddListener(SkipColectivo);
    }

    private void SkipColectivo()
    {
        SceneManager.LoadScene("CSchoolStart");
    }
}

