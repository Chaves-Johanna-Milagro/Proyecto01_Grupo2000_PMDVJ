using UnityEngine;
using UnityEngine.SceneManagement;


//utilizara el patron singletons para que sea accesible por cualquier otro script
public class ButtonsController : MonoBehaviour 
{
    public static ButtonsController Instance { get; private set; }

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

    public void StartSceneMorning()
    {
        SceneManager.LoadScene("Morning");
    }

}
