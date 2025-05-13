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
        if (_roomName == "DoorRoom") SceneManager.LoadScene(11); // aquella que te dirige a la habitacion
        if (_roomName == "DoorDiningroom") SceneManager.LoadScene(12); // aquella que te dirige al comedor
       // if (_roomName == "DoorStreet") SceneManager.LoadScene(13); // aqulla que te dirige fuera de la casa

    }
}
