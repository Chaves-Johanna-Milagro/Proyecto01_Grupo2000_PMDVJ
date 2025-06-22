using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropSprite2_0 : MonoBehaviour //pa zonas de dropeo de obj de los minijuegos, en especifico las de la escuela
{
    private string _spaceName;

    private bool _isOccupied = false;

    private float _alfa; //e usara para que las guias sean cada vez mas transparentes mediante el alfa

    private Dictionary<GameObject, float> _tiemposEnZona = new Dictionary<GameObject, float>();
    private float _tiempoNecesario = 1f; // tiempo en segundos que debe quedarse para encastrar

    void Start()
    {
        _spaceName = gameObject.name;
        string numero = _spaceName.Replace("Space", "");

        // Buscar coincidencia manualmente
        string objetoColocado = null;
        foreach (string nombre in DropItemStatus.ObjetosColocados)
        {
            if (nombre.EndsWith(numero))
            {
                objetoColocado = nombre;
                break;
            }
        }

        if (!string.IsNullOrEmpty(objetoColocado))
        {
            GameObject obj = GameObject.Find(objetoColocado);
            if (obj != null)
            {
                obj.transform.position = transform.position;

                var drag = obj.GetComponent<DragSprite2_0>();
                if (drag != null) drag.enabled = false;

                var col = obj.GetComponent<Collider2D>();
                if (col != null) col.enabled = false;

                _isOccupied = true;
            }
        }

        _alfa = GetComponent<SpriteRenderer>().color.a; // para setear las guias mediante el nivel elegido

        if (LevelGameStatus.GetLevel() == "Facil") _alfa = 0.8f;
        if (LevelGameStatus.GetLevel() == "Medio") _alfa = 0.4f;
        if (LevelGameStatus.GetLevel() == "Dificil") _alfa = 0f;

        SetAlpha();
    }
    public void OnEnabled() //pa ser llamado una vez se active
    {
        _alfa = GetComponent<SpriteRenderer>().color.a; // para setear las guias mediante el nivel elegido

        if (LevelGameStatus.GetLevel() == "Facil") _alfa = 0.8f;
        if (LevelGameStatus.GetLevel() == "Medio") _alfa = 0.4f;
        if (LevelGameStatus.GetLevel() == "Dificil") _alfa = 0f;

        SetAlpha();
    }

    private void SetAlpha()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color c = sr.color;
        c.a = _alfa;
        sr.color = c;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isOccupied) return;

        string numero = _spaceName.Replace("Space", "");
        if (!collision.name.EndsWith(numero)) return;

        float distancia = Vector3.Distance(collision.transform.position, transform.position);
        float distanciaMaximaPermitida = 3f; // como distancia cercana

        if (distancia > distanciaMaximaPermitida)
        {
            // Si está muy lejos, no acumula tiempo
            if (_tiemposEnZona.ContainsKey(collision.gameObject))
                _tiemposEnZona[collision.gameObject] = 0f;
            return;
        }

        if (!_tiemposEnZona.ContainsKey(collision.gameObject))
            _tiemposEnZona[collision.gameObject] = 0f;

        _tiemposEnZona[collision.gameObject] += Time.deltaTime;

        if (_tiemposEnZona[collision.gameObject] >= _tiempoNecesario)
        {
            _isOccupied = true;
            DropItemStatus.ObjetosColocados.Add(collision.name);
            StartCoroutine(SmoothSnap(collision.gameObject, transform.position));
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //si la letra sale reiniciar el contador
    {
        if (_tiemposEnZona.ContainsKey(collision.gameObject))
            _tiemposEnZona.Remove(collision.gameObject);
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

        DragSprite2_0 drag = obj.GetComponent<DragSprite2_0>();
        if (drag != null) drag.enabled = false;
    }
}
