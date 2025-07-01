using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipTutorial : MonoBehaviour
{
    private Button _bSkip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bSkip = GetComponent<Button>();

        _bSkip.onClick.AddListener(SkipTuto);
    }

    private void SkipTuto()
    {
        SceneManager.LoadScene("Morning2.0");
    }
 }
