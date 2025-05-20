using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropLetter : MonoBehaviour
{
    private string _spaceName;
    private bool _isOccupied = false;

    // Letras válidas para este minijuego
    private static readonly HashSet<string> letrasValidas = new HashSet<string> {
        "A", "O", "H", "I", "S", "G", "R", "U"
    };

    void Start()
    {
        _spaceName = gameObject.name;

        string expectedLetter = "Letter" + _spaceName.Replace("Space", "");

        // Si ya se colocó antes, la volvemos a posicionar y la bloqueamos
        if (DropItemStatus.ObjetosColocados.Contains(expectedLetter))
        {
            GameObject letra = GameObject.Find(expectedLetter);
            if (letra != null)
            {
                letra.transform.position = transform.position;

                var drag = letra.GetComponent<DragSprite2_0>();
                if (drag != null) drag.enabled = false;

                var col = letra.GetComponent<Collider2D>();
                if (col != null) col.enabled = false;

                _isOccupied = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isOccupied) return;

        string letra = _spaceName.Replace("Space", "");
        string letraEsperada = "Letter" + letra;

        if (collision.name == letraEsperada && letrasValidas.Contains(letra))
        {
            _isOccupied = true;

            // Guardamos para persistir entre escenas
            DropItemStatus.ObjetosColocados.Add(letraEsperada);

            StartCoroutine(SmoothSnap(collision.gameObject, transform.position));
        }
    }

    // Mueve suavemente la letra al centro del espacio
    private IEnumerator SmoothSnap(GameObject letraObj, Vector3 destino)
    {
        float duracion = 0.3f;
        float t = 0f;
        Vector3 inicio = letraObj.transform.position;

        Collider2D col = letraObj.GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        while (t < duracion)
        {
            letraObj.transform.position = Vector3.Lerp(inicio, destino, t / duracion);
            t += Time.deltaTime;
            yield return null;
        }

        letraObj.transform.position = destino;

        DragSprite2_0 drag = letraObj.GetComponent<DragSprite2_0>();
        if (drag != null) drag.enabled = false;
    }

}
