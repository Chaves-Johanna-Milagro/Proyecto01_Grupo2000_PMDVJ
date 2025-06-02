using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRoom : MonoBehaviour
{
    private string _roomName;
    void Start()
    {
        _roomName = gameObject.name;
    }

    public void OnMouseDown()
    {

        if (PauseStatus.IsPaused) return; // Verifica si el juego está en pausa antes de procesar el click

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // si esta un mini juego no procese el click

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        if (_roomName == "DoorRoom") SceneManager.LoadScene("Morning2.0"); // aquella que te dirige a la habitacion
        if (_roomName == "DoorDiningroom") SceneManager.LoadScene("Breackfast2.0"); // aquella que te dirige al comedor
        if (_roomName == "DoorStreet") SceneManager.LoadScene("WayToSchool2.0"); // aqulla que te dirige fuera de la casa
       // if (_roomName == "DoorHouse") SceneManager.LoadScene(12); // aqulla que te dirige al comedor


        if (_roomName == "DoorSchool") SceneManager.LoadScene("School2.0"); // aqulla que te dirige a la entrada de la escuela

        //de momento se saltara el mg de la sube
        if (_roomName == "TrafficLight") SceneManager.LoadScene("School2.0"); // aqulla que te dirige a la entrada de la escuela

        if (_roomName == "DoorClassroom") SceneManager.LoadScene("Classroom2.0"); // aqulla que te dirige al aula

    }
}
