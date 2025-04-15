using UnityEngine;

public class LibretaController : MonoBehaviour // la usaremos para activar los checks de los obj
{
    public static LibretaController Instance { get; private set; }

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

    public void ActiveCheck1() 
    {
        Transform check1 = transform.GetChild(0);
        check1.gameObject.SetActive(true);
    }

    public void desactiveChecks() 
    {
        Transform check1 = transform.GetChild(0);
        check1.gameObject.SetActive(false);

        Transform check2 = transform.GetChild(0);
        check2.gameObject.SetActive(false);

        Transform check3 = transform.GetChild(0);
        check3.gameObject.SetActive(false);

        Transform check4 = transform.GetChild(0);
        check4.gameObject.SetActive(false);
    }
}
