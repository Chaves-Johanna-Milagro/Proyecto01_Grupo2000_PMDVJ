using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMenu : MonoBehaviour
{
    private GameObject _notes;
    private GameObject _phone;

    private string _sceneName;
    void Start()
    {
        _notes = transform.Find("BNotes").gameObject;
        _phone = transform.Find("BPhone").gameObject;

        _sceneName = SceneManager.GetActiveScene().name;

        if (_sceneName == "WayToSchool2.0")
        {
            _notes.SetActive(false);
            _phone.SetActive(true);
        }
        else
        {
            _notes.SetActive(true);
            _phone.SetActive(false);
        }
    }
}

