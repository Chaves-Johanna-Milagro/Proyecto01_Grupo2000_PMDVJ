using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BNotesObjetives : MonoBehaviour
{
    private GameObject _objNvl1;
    private GameObject _objNvl2;

    private Button _buttonActive;

    private string _sceneName;

    private bool _active = false;
    void Start()
    {
        _objNvl1 = transform.Find("ImgNvl1").gameObject;
        _objNvl2 = transform.Find("ImgNvl2").gameObject;

        _objNvl1.SetActive(false);
        _objNvl2.SetActive(false); // desactivado al inicio

        _sceneName = SceneManager.GetActiveScene().name;

        _buttonActive = GetComponent<Button>();

        _buttonActive.onClick.AddListener(ActveObjetives);
    }


    void Update()
    {
        if (PauseStatus.IsPaused && _active)
        {
            _active = false;
            _objNvl1.SetActive(false);
            _objNvl2.SetActive(false);
        }
    }

    public void ActveObjetives()
    {
        _active = !_active;

        if (!_active)
        {
            _objNvl1.SetActive(false);
            _objNvl2.SetActive(false);
            return;
        }

        ShowByScene();
    }

    public void ShowByScene()
    {
        if (_sceneName == "Morning2.0") ObjNvl1();
        else if (_sceneName == "Breackfast2.0") ObjNvl2();
    }

    public void ObjNvl1()
    {
        _objNvl1.SetActive(true);
        _objNvl2.SetActive(false);
    }

    public void ObjNvl2()
    {
        _objNvl1.SetActive(false);
        _objNvl2.SetActive(true);
    }
}
