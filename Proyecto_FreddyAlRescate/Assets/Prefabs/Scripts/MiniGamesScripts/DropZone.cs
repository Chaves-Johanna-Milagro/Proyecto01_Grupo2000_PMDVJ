using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    private int _totalToReceive = 0; //la cantidad de objetos
    private int _receivedCount = 0;

    private Transform _miniGame;


    void Start()
    {
        // miniGame es el padre de este objeto MiniGameBackpack
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

    }
  
}
