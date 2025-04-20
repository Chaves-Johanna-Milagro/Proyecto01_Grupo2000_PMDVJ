using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NotesController : MonoBehaviour
{
    public static NotesController Instance { get; private set; }

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

    void Start()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // obtiene el index de la escena

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


    public void DesactiveChecks() // pa ser llamadoCuando se pase al sig nvl
    {
        Transform check1 = transform.GetChild(3);
        check1.gameObject.SetActive(false);

        Transform check2 = transform.GetChild(4);
        check2.gameObject.SetActive(false);

        Transform check3 = transform.GetChild(5);
        check3.gameObject.SetActive(false);
    }
}
