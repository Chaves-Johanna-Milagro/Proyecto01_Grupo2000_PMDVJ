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
    public void ActiveCheck1() => transform.GetChild(3).gameObject.SetActive(true);
    public void ActiveCheck2() => transform.GetChild(4).gameObject.SetActive(true);
    public void ActiveCheck3() => transform.GetChild(5).gameObject.SetActive(true);


    public void WinLevel()
    {
        _objInScene++;

        string currentScene = SceneManager.GetActiveScene().name;   

        if( currentScene == "Morning" && _objInScene == 3 )
        {
            _objInScene = 0;

            Transform parent = transform.parent;
            Transform imgVictory = parent.Find("NextLevelImageNvl1");

            if( imgVictory != null ) imgVictory.gameObject.SetActive(true);
        }

        else if( currentScene == "Breackfast" && _objInScene == 2 ) 
        {
            _objInScene = 0;

            Transform parent = transform.parent;
            Transform imgDesicion = parent.Find("Desicion2Nvl2");

            if (imgDesicion != null) imgDesicion.gameObject.SetActive(true);

        }

    }

    public void CompleteDesicions()
    {
        _desicionInScene++;

        string currentScene = SceneManager.GetActiveScene().name;


        if (currentScene == "Breackfast" && _desicionInScene == 1)
        {
            _objInScene = 0;
            _desicionInScene = 0;

            Transform parent = transform.parent;
            Transform imgDesicion = parent.Find("Desicion2Nvl2");
            Transform imgVictory = parent.Find("NextLevelImageNvl2");

            if (imgDesicion != null) imgDesicion.gameObject.SetActive(false);

            if (imgVictory != null) imgVictory.gameObject.SetActive(true);
        }

    }

}
