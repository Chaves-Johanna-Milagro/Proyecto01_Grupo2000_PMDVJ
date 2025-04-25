using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NotesController : MonoBehaviour
{
    public static NotesController Instance { get; private set; }

    private int _objInScene = 0;
    private int _desicionInScene = 0;

    private void Awake()
    {
        //limita la instancia a una sola
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(this); //permite que sobreviva a cambios de escena
        }
    }

    private void Start()  
    {
        _objInScene = 0;  // recargar/reiniciar los contadores de los objetivos

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // obtiene el index de la escena para determinar que objetivos tiene

        // Activar solo el hijo correspondiente al índice de la escena
        for (int i = 1; i < transform.childCount; i++)  //el index de la escena y el del hijo deben coincidir
        {
            transform.GetChild(i).gameObject.SetActive(i == currentSceneIndex);
        }
    }


    // Activadores de checks individuales
    public void ActiveCheck1() => ActivateChild(3);
    public void ActiveCheck2() => ActivateChild(4);
    public void ActiveCheck3() => ActivateChild(5);



    // Activa un check específico por índice
    private void ActivateChild(int index)
    {
        if (index >= 0 && index < transform.childCount)
            transform.GetChild(index).gameObject.SetActive(true);
    }


    // Se llama cuando se completa un objetivo
    public void WinLevel()
    {
        _objInScene++;
        string scene = SceneManager.GetActiveScene().name;

        if (scene == "Morning" && _objInScene == 3)
        {
            _objInScene = 0;
            StartCoroutine(ShowVictoryImage("NextLevelImageNvl1")); // Mostrar imagen de victoria
        }
        else if (scene == "Breackfast" && _objInScene == 2)
        {
            _objInScene = 0;

            Transform imgDesicion = transform.parent.Find("Desicion2Nvl2");
            if (imgDesicion != null) imgDesicion.gameObject.SetActive(true);
        }
    }


    // Se llama cuando se completan todas las decisiones
    public void CompleteDesicions()
    {
        _desicionInScene++;
        string scene = SceneManager.GetActiveScene().name;

        if (scene == "Breackfast" && _desicionInScene == 1)
        {
            _objInScene = 0;
            _desicionInScene = 0;

            Transform parent = transform.parent;
            Transform imgDesicion = parent.Find("Desicion2Nvl2");
            Transform imgVictory = parent.Find("NextLevelImageNvl2");

            if (imgDesicion != null) imgDesicion.gameObject.SetActive(false);
            if (imgVictory != null) StartCoroutine(ShowVictoryImage("NextLevelImageNvl2"));
        }
    }


    // busca la imagen por nombre y la muestra después de un pequeño delay
    private IEnumerator ShowVictoryImage(string imageName)
    {
        Transform image = transform.parent.Find(imageName);
        if (image != null)
        {
            yield return new WaitForSeconds(1.2f); // Espera antes de mostrar la imagen
            image.gameObject.SetActive(true);
        }
    }

}
