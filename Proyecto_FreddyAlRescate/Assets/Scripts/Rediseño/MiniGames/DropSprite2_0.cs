using UnityEngine;
using System.Collections;

public class DropSprite2_0 : MonoBehaviour //pa zonas de dropeo de obj de los minijuegos, en especifico las de la escuela
{
    private string _spaceName;
    private bool _isOccupied = false;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isOccupied) return;

        string numero = _spaceName.Replace("Space", "");

        if (collision.name.EndsWith(numero))
        {
            _isOccupied = true;

            DropItemStatus.ObjetosColocados.Add(collision.name);

            StartCoroutine(SmoothSnap(collision.gameObject, transform.position));
        }
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
