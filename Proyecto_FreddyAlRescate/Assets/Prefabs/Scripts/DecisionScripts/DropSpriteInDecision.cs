using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class DropSpriteInDecision : MonoBehaviour
{
    private bool _isOccupied = false;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (PauseStatus.IsPaused) return;// Verifica si el juego está en pausa antes de procesar el click

        if (MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo


        if (_isOccupied) return;

        string dropName = gameObject.name;               // nombre del objeto que tiene este script
        string objetoName = collision.name;   // nombre del objeto que cayó

        Vector3 offset = Vector3.zero;

        if (dropName == "Balanza" && EsFruta(objetoName))
        {
            offset = new Vector3(0f, -0.2f, 0f); // más abajo
        }
        if (dropName == "Mostrador" && EsSandwich(objetoName))
        {
            offset = new Vector3(0f, 3f, 0f); // más arriba
        }
    

        _isOccupied = true;
        StartCoroutine(SmoothSnap(collision.gameObject, transform.position + offset));

    }

    private IEnumerator SmoothSnap(GameObject obj, Vector3 destino)
    {
        float duracion = 0.3f;
        float t = 0f;
        Vector3 inicio = obj.transform.position;

        Collider2D col = obj.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        while (t < duracion)
        {
            obj.transform.position = Vector3.Lerp(inicio, destino, t / duracion);
            t += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = destino;

        DragSpriteInDecision drag = obj.GetComponent<DragSpriteInDecision>();
        if (drag != null) drag.enabled = false;
    }


    private bool EsFruta(string nombre)
    {
        return nombre == "Manzana" || nombre == "Banana" || nombre == "Naranja";
    }

    private bool EsSandwich(string nombre)
    {
        return nombre == "Sanwi" || nombre == "Sanwi de jamon" || nombre == "Sanwi de queso";
    }
}
