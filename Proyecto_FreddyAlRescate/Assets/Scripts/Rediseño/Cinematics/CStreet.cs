using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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

        CrossStreetStatus.SetStep();

        StartCoroutine(DelayPaCinematic());
    }

    private IEnumerator DelayPaCinematic()
    {
        _img.SetActive(true);
        yield return new WaitForSeconds(5f);
        _img.SetActive(false);
        //if (CrossStreetStatus.GetStep() == 1 || CrossStreetStatus.GetStep() == 2) SceneManager.LoadScene("GameOver");
        //yield return new WaitForSeconds(1f);
        _pAttention.AttentionCrossStreet(gameObject.name,CrossStreetStatus.GetStep());
    }
}

public static class CrossStreetStatus
{
    private static int step = 0;
    
    public static void SetStep()
    {
        step++;
        Debug.Log(step);
    }

    public static int GetStep() {  return step; }

    public static void ResetStep()
    {
        step = 0;
    }
}
