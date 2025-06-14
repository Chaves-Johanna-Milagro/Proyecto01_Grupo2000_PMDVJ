using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CrossStreetManager : MonoBehaviour
{
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;

    [SerializeField] private float delay = 2f;

    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        StartCoroutine(SwitchPanels());
        StartCoroutine(LoadSceneMinigameSUBE());

    }

    IEnumerator SwitchPanels()
    {
        yield return new WaitForSeconds(delay);

        panel1.SetActive(true);
        panel2.SetActive(false);
    }
    IEnumerator LoadSceneMinigameSUBE()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("GreetingsBus");
    }
}
