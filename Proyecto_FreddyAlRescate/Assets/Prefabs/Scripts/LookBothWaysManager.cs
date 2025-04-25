using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LookBothWaysManager : MonoBehaviour
{
    void Start()
    {
        // se muestra mensaje de importancia y animacion
        StartCoroutine(WaitAndReturn());
    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(3f); // tiempo de lo que va a durar la animacion

        // se guarda el estado directamente
        PlayerPrefs.SetInt("LookedBothWays", 1);

        SceneManager.LoadScene("MainStreet");
    }
}