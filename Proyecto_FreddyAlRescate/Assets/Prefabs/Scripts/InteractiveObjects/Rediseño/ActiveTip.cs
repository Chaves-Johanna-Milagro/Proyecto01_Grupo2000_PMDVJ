using System.Collections;
using UnityEngine;

public class ActiveTip : MonoBehaviour // objetos con los que se puede interactuar y te dan alguna informacion
{
    private GameObject[] _childs;
    private int _count;
   
    void Start()
    {
        _count = transform.childCount;
        _childs = new GameObject[_count];

        for (int i = 0; i < _count; i++) //desactivar los hijos al inicio
        {
            _childs[i] = transform.GetChild(i).gameObject;
            _childs[i].SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        
        if (PauseStatus.IsPaused) return; // Verifica si el juego está en pausa antes de procesar el click

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        for (int i = 0; i < _count; i++)
        {
            _childs[i].SetActive(true);
        }
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < _count; i++)
        {
            _childs[i].SetActive(false);
        }
    }
}
