using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRoom : MonoBehaviour
{
    private string _roomName;

    private BKindnessUpDown _kind;// se utilizara para manejar la cantidad de checks sin activar para bajar la barrita
    private BNotesChecks _check;

    private CursorManager _cursorManager;

    private bool _isClicked = false;

    private AudioSource _audioSource;

    void Start()
    {
        _roomName = gameObject.name;

        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();
        _check = Object.FindFirstObjectByType<BNotesChecks>();

        _cursorManager = Object.FindFirstObjectByType<CursorManager>();

        _audioSource = transform.Find("Child")?.GetComponent<AudioSource>(); 
    }

    public void OnMouseDown()
    {
        if (_isClicked) return;

        if (PauseStatus.IsPaused) return; // Verifica si el juego está en pausa antes de procesar el click

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // si esta un mini juego no procese el click

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        if (_audioSource != null) _audioSource.Play();


        if (_roomName == "DoorRoom") SceneManager.LoadScene("Morning2.0"); // aquella que te dirige a la habitacion
        if (_roomName == "DoorDiningroom" && SceneManager.GetActiveScene().name != "Night2.0") SceneManager.LoadScene("Breackfast2.0"); // aquella que te dirige al comedor

        if (_roomName == "DoorStreet")
        {
            if (ChecksStatus.GetTotalInactiveChecks() > 3) _kind.BadDecision(); // si hay mas de tres check inactivos baja la barrita

            SceneManager.LoadScene("WayToSchool2.0"); // aquella que te dirige fuera de la casa
        }
      

        if (_roomName == "DoorSchool" && SceneManager.GetActiveScene().name == "Playground2.0") SceneManager.LoadScene("Recess2.0"); // aquella que te dirige a la entrada de la escuela cuando es recreo

        if (_roomName == "DoorPatio" && SceneManager.GetActiveScene().name == "Recess2.0") SceneManager.LoadScene("Playground2.0"); // aquella que te dirige al patio de la escuela en el recreo

        //de momento se saltara el mg de la sube
        if (_roomName == "TrafficLight") SceneManager.LoadScene("CSchoolStart"); // aquella que te dirige a la entrada de la escuela

        if (_roomName == "DoorClassroom" && SceneManager.GetActiveScene().name == "School2.0") StartCoroutine(DelayPaCheck()); // aqulla que te dirige al aula

        _cursorManager.SetCursorDefault();//setee al cursor por defecto

    }

    private IEnumerator DelayPaCheck()
    {
        _isClicked = true; //pa evitar que se reinicie la corrutina si cleckiea de nuevo

        _check.Check1();
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Classroom2.0");
    }

}
