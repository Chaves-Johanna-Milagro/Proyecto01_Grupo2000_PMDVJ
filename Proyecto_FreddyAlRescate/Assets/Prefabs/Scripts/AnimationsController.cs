using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{

    public static AnimationsController Instance { get; private set; }

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
        Invoke("DesactivaInitialTransition", 2f);
    }

    private void DesactivaInitialTransition() //para desactivar la primera animacion, no me dejaba usar los botones si esta activo el hijo
    { 
       Transform initialFade = transform.GetChild(0);
       initialFade.gameObject.SetActive(false);    
    }
    public void ActiveFadeInAndOut() 
    {
        Transform Fade = transform.GetChild(1);
        Fade.gameObject.SetActive(true);
    }
}
