using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TrafficLightScene : MonoBehaviour
{
    void Start()
    {
        // se muestra mensaje de importancia y animacion
        StartCoroutine(WaitAndReturn());
    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(3f); // tiempo de la animación

        // guardar el estado directamente
        PlayerPrefs.SetInt("LookedAtTrafficLight", 1);

        SceneManager.LoadScene("MainStreet");
    }
}

