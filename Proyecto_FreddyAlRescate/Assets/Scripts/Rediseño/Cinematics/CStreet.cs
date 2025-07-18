using System.Collections;
using UnityEngine;

public class CStreet : MonoBehaviour
{
    private GameObject _img;

    private bool _isCliked = false;

    private PlayerAttention _pAttention;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _img = transform.GetChild(0).gameObject;

        _pAttention = Object.FindFirstObjectByType<PlayerAttention>();
    }

    private void OnMouseDown()
    {
        if (_isCliked) return;

        if (PauseStatus.IsPaused) return;// Verifica si el juego está en pausa antes de procesar el click

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // verifica que no este acivo un minijuego

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        _isCliked = true;

        CrossStreet.SetStep();

        StartCoroutine(DelayPaCinematic());
    }

    private IEnumerator DelayPaCinematic()
    {
        _img.SetActive(true);
        yield return new WaitForSeconds(5f);
        _img.SetActive(false);
        //yield return new WaitForSeconds(0.1f);
        _pAttention.AttentionCrossStreet(gameObject.name,CrossStreet.GetStep());
    }
}

public static class CrossStreet
{
    private static int step = 0;
    
    public static void SetStep()
    {
        step++;
        Debug.Log(step);
    }

    public static int GetStep() {  return step; }
}
