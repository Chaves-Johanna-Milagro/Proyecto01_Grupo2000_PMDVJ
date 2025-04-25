using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    private int _totalToReceive = 0; //la cantidad de objetos
    private int _receivedCount = 0;

    private Transform _miniGame;

    private HashSet<Collider2D> _detectedObjects = new HashSet<Collider2D>(); // es como una lista de colliders

    void Start()
    {
        // miniGame es el padre de este objeto (MiniGameBackpack/Moth)
        _miniGame = transform.parent;

        // Contar cuántos hermanos (menos este mismo) tienen el tag "Arrastrable"
        foreach (Transform child in _miniGame)
        {
            if (child != transform && child.CompareTag("Arrastrable"))
            {
                _totalToReceive++;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrastrable"))
        {
            other.gameObject.SetActive(false);

            _receivedCount++;

            if (_receivedCount >= _totalToReceive)
            {
                _miniGame.gameObject.SetActive(false);

                NotesController.Instance.ActiveCheck2();
                NotesController.Instance.WinLevel();

            }
        }

        if (_detectedObjects.Contains(other)) return; //retorna si es que el other es un objeto que ya colisiono


        _detectedObjects.Add(other);


        if (other.name == "Brush") // para objetos que requieran un delay para completarse la accion
        {
            StartCoroutine(DelayInZone());
        }
    }

    private IEnumerator DelayInZone() // los objetos que requieran el delay no deben tener el tag arrastrable
    {

        yield return new WaitForSeconds(2f);

        _miniGame.gameObject.SetActive(false);

        NotesController.Instance.ActiveCheck3();
        NotesController.Instance.WinLevel();
    }
}
