using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


//encargado de gestionar los botones del menu
public class ButtonsMenuController : MonoBehaviour
{
    private float _delay = 2f;
    public void StartSceneMorning()
    {

        StartCoroutine(DelayBetweenScenes());

    }

    private IEnumerator DelayBetweenScenes() 
    {
        Debug.Log("Delay activado, esperando " + _delay + " segundos...");

        TransitionsScenes.Instance.ActiveFadeInAndOut(); //activar la transision Fade

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene("Morning");
    }
}
