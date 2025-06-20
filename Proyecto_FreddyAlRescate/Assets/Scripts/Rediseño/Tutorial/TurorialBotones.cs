using System.Collections;
using UnityEngine;
using TMPro;

public class TutorialCinematica : MonoBehaviour
{
    public AudioSource vozAfton;
    public TextMeshProUGUI textoExplicacion;

    public AudioClip clipMenu;
    public AudioClip clipLibreta;
    public AudioClip clipBarra;
    public AudioClip clipPausa;
    public AudioClip clipMiniAfton;

    public GameObject flecha;
    public Transform[] botones; // Posiciones de cada botón para que la flecha los apunte

    void Start()
    {
        StartCoroutine(ExplicarBotones());
    }

    IEnumerator ExplicarBotones()
    {
        // Mini Menú
        yield return StartCoroutine(MostrarExplicacion("Si haces clic aquí verás más opciones", clipMenu, botones[0]));

        // Libreta
        yield return StartCoroutine(MostrarExplicacion("Si haces clic aquí podrás ver los objetivos del nivel", clipLibreta, botones[1]));

        // Barra de Amabilidad
        yield return StartCoroutine(MostrarExplicacion("Si haces clic aquí podrás ver tus aciertos y desaciertos", clipBarra, botones[2]));

        // Pausa
        yield return StartCoroutine(MostrarExplicacion("Si quieres descansar un rato puedes hacer clic aquí", clipPausa, botones[3]));

        // Mini Afton
        yield return StartCoroutine(MostrarExplicacion("Si necesitas ayuda, consejos o pistas puedes hacer clic en el mini yo", clipMiniAfton, botones[4]));

        textoExplicacion.text = "¡Listo! Ahora sabes qué hace cada botón.";
    }

    IEnumerator MostrarExplicacion(string texto, AudioClip clip, Transform boton)
    {
        flecha.SetActive(true);
        flecha.transform.position = boton.position + Vector3.up * 50; // flecha encima del botón
        textoExplicacion.text = texto;
        vozAfton.clip = clip;
        vozAfton.Play();
        yield return new WaitForSeconds(clip.length + 1f); // Espera a que termine + un pequeño descanso
    }
}
