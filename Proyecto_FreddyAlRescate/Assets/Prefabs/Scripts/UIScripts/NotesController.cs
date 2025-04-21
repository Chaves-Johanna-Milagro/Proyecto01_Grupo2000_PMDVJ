using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NotesController : MonoBehaviour
{
    public static NotesController Instance { get; private set; }

    private int _objInScene = 0;

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

    public void ActiveCheck1() // pa ser llamado por los demas objetos cuando se interactue con ellos
    {
        Transform check1 = transform.GetChild(3);
        check1.gameObject.SetActive(true);
    }

    public void ActiveCheck2() // pa ser llamado por los demas objetos cuando se interactue con ellos
    {
        Transform check2 = transform.GetChild(4);
        check2.gameObject.SetActive(true);
    }

    public void ActiveCheck3() // pa ser llamado por los demas objetos cuando se interactue con ellos
    {
        Transform check2 = transform.GetChild(5);
        check2.gameObject.SetActive(true);
    }


   public void WinLevel()
    {
        _objInScene++;

        string currentScene = SceneManager.GetActiveScene().name;   

        if( currentScene == "Morning" && _objInScene == 3 || currentScene == "Breackfast" && _objInScene == 2)
        {
            _objInScene = 0;

            Transform parent = transform.parent;
            Transform imgVictory = parent.Find("NextLevelImage");

            if( imgVictory != null ) imgVictory.gameObject.SetActive(true);
        }
    }
}
