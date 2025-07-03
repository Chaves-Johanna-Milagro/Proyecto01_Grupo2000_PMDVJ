using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("inicie");
        Invoke("End", 118f);
    }

    private void End()
    {
        Debug.Log("funcione");
        SceneManager.LoadScene("Morning2.0");
    }
}
