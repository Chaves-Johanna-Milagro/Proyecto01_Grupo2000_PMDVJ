using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionBase : MonoBehaviour
{
    private GameObject _decision;

    private string _sceneName;

    private string _objName;

    private AudioSource _soundDes;
    
    void Start()
    {
        _decision = transform.Find("Decision").gameObject;

        _decision.SetActive(false); //desactivado al inicio

        _objName = gameObject.name;

        _sceneName = SceneManager.GetActiveScene().name;

        _soundDes = _decision?.GetComponent<AudioSource>();

        // Restaurar estado de los hijos del objeto Base
        /*if (DecisionStatus.TieneEstado(_sceneName, _objName))
        {
            DecisionStatus.RestaurarEstado(_sceneName, _objName, _decision.transform);
        }*/
    }
    private void OnDisable()
    {
        if (_decision != null)
        {
            // Guarda la posición y estado activo de todos los hijos de Decision
            DecisionStatus.GuardarEstado(_sceneName, _objName, _decision.transform);
        }
    }
    public void OnMouseDown()
    {
       
        if (PauseStatus.IsPaused) return; // Verifica si el juego está en pausa antes de procesar el click

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // si esta un mini juego no procese el click

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        _decision?.SetActive(true);

        if(_soundDes != null) _soundDes.Play();
    }

    public void ExitDecision()
    {
        _decision?.SetActive(false);
    }
}
