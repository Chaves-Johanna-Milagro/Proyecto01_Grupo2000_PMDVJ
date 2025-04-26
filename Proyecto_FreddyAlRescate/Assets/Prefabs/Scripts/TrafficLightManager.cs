using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrafficLightScene : MonoBehaviour
{
    // paneles que tapan sus respectivas vi�etas del fondo
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject panel3;

    // tiempo de espera para mostrar cada vi�eta
    [SerializeField] private float delay1 = 2f;
    [SerializeField] private float delay2 = 2f; 

    void Start()
    {
        
        StartCoroutine(WaitAndReturn());
        StartCoroutine(RevealPanels());
    }

    IEnumerator RevealPanels()
    {
        yield return new WaitForSeconds(delay1);
        panel2.SetActive(false); // muestra vi�eta 2

        yield return new WaitForSeconds(delay2);
        panel3.SetActive(false); // muestra vi�eta 3
    }


    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(6f); // tiempo de la animaci�n

        // guardar el estado directamente
        PlayerPrefs.SetInt("LookedAtTrafficLight", 1);

        SceneManager.LoadScene("MainStreet");
    }
}

