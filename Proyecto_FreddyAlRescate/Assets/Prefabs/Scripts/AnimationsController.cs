using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationsController : MonoBehaviour // la idea es que se utilice para las tranciciones entre cambios de escenas
{
    public static AnimationsController Instance { get; private set; }

    private float _delay = 2f;
    private float _delayTransitions = 2.5f;

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
        Invoke("DesactivaInitialTransition", _delay);
    }

    private void DesactivaInitialTransition() //para desactivar la primera animacion, no me dejaba usar los botones si esta activo el hijo
    { 
       Transform initialFade = transform.GetChild(0);
       initialFade.gameObject.SetActive(false);
    }

    public void ActiveFadeInAndOut() 
    {
        Transform fade = transform.GetChild(1);   //Indice de la transicion 
        StartCoroutine(DesactiveTransition(fade, _delayTransitions));
    }

    private IEnumerator DesactiveTransition(Transform transition,float time) // activara y desactivara las transiciones
    {
        transition.gameObject.SetActive(true);

        yield return new WaitForSeconds(time);

        transition.gameObject.SetActive(false);
    }
}
