using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionBase : MonoBehaviour
{
    private GameObject _decision;

    private string _sceneName;

    private string _objName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _decision = transform.Find("Decision").gameObject;

        _decision.SetActive(false); //desactivado al inicio

        _objName = gameObject.name;

        _sceneName = SceneManager.GetActiveScene().name;

        // Restaurar estado de los hijos del objeto MiniGame
        if (DecisionStatus.TieneEstado(_sceneName, _objName))
        {
            DecisionStatus.RestaurarEstado(_sceneName, _objName, _decision.transform);
        }
    }
    private void OnDisable()
    {
        if (_decision != null)
        {
            // Guarda la posición y estado activo de todos los hijos de MiniGame
            DecisionStatus.GuardarEstado(_sceneName, _objName, _decision.transform);
        }
    }
    public void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; //si hay uno activo que retorne

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        _decision?.SetActive(true);
    }

    public void ExitDecision()
    {
        _decision?.SetActive(false);
    }
}
