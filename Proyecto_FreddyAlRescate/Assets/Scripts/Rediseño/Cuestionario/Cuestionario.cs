using System.Collections.Generic;
using UnityEngine;

public class Cuestionario : MonoBehaviour
{
    private List<Asks> _asksPendientes = new List<Asks>(); // Lista de Asks no mostrados
                                                           
    // Contadores de respuestas
    private int _correctas = 0;
    private int _incorrectas = 0;

    // Máximo de preguntas que se pueden mostrar 
    private int _maxPreguntas = 5;

    void Start()
    {
        // Reunimos todos los Asks hijos y los desactivamos
        List<Asks> todosLosAsks = new List<Asks>();
        foreach (Transform child in transform)
        {
            Asks ask = child.GetComponent<Asks>();
            if (ask != null)
            {
                todosLosAsks.Add(ask);
                child.gameObject.SetActive(false);
            }
        }

        // Elegimos al azar hasta 5 Asks distintos
        Shuffle(todosLosAsks);
        _asksPendientes = todosLosAsks.GetRange(0, Mathf.Min(_maxPreguntas, todosLosAsks.Count));


        MostrarProximaPregunta(); // Inicia con la primera
    }

    // Llamado por un Ask cuando se respondió → muestra otra pregunta
    public void Continuar()
    {
        MostrarProximaPregunta();
    }

    // Muestra un Ask al azar de los pendientes
    private void MostrarProximaPregunta()
    {
        if (_asksPendientes.Count == 0)
        {
            Debug.Log("¡Cuestionario terminado!");
            Debug.Log("Correctas: " + _correctas + " | Incorrectas: " + _incorrectas);
            return;
        }

        int rand = Random.Range(0, _asksPendientes.Count);
        Asks elegido = _asksPendientes[rand];
        _asksPendientes.RemoveAt(rand);

        elegido.MostrarPregunta(); // El Ask se encarga de mostrar sus cosas
    }

    // Recibe si la respuesta fue correcta o incorrecta y suma al contador
    public void RegistrarRespuesta(bool esCorrecta)
    {
        if (esCorrecta)
        {
            _correctas++; 
            PlaySound("SoundSuccess");
        }
        else {
            _incorrectas++;
            PlaySound("SoundError");
        }
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }

    public void PlaySound(string name)
    {
        AudioSource[] sounds = GetComponents<AudioSource>();

        foreach (AudioSource sound in sounds)
        {
            if (sound.clip != null && sound.clip.name == name) sound.Play();
        }
    }
}
