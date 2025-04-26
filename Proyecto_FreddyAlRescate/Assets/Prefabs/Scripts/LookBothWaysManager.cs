using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LookBothWaysManager : MonoBehaviour
{
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;
    

    [SerializeField] private float delay = 2f;


    void Start()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
        StartCoroutine(SwitchPanels());
        StartCoroutine(WaitAndReturn());
    }

    IEnumerator SwitchPanels()
    {
        yield return new WaitForSeconds(delay);

        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(5f); // tiempo de lo que va a durar la animacion de viñetas

        // se guarda el estado directamente
        PlayerPrefs.SetInt("LookedBothWays", 1);

        SceneManager.LoadScene("MainStreet");
    }
}