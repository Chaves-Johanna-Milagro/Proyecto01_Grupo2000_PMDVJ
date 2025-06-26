using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BNotesObjetives : MonoBehaviour
{
    private GameObject _objNvl1;
    private GameObject _objNvl2;

    // COMO TAL EL NIVEL 4 TIENE TRES PARTES
    private GameObject _objNvl4_1;  //la entrada de la scul
    private GameObject _objNvl4_2; // el aula
    private GameObject _objNvl4_3; // el recreo

    private GameObject _objNvl5; //la vuelta a la pieza

    private Button _buttonActive;

    private string _sceneName;

    private bool _active = false;
    void Start()
    {
        _objNvl1 = transform.Find("ImgNvl1").gameObject;
        _objNvl2 = transform.Find("ImgNvl2").gameObject;

        _objNvl4_1 = transform.Find("ImgNvl4_1").gameObject;
        _objNvl4_2 = transform.Find("ImgNvl4_2").gameObject;
        _objNvl4_3 = transform.Find("ImgNvl4_3").gameObject;

        _objNvl5 = transform.Find("ImgNvl5").gameObject;

        _objNvl1.SetActive(false);
        _objNvl2.SetActive(false); // desactivado al inicio

        _objNvl4_1.SetActive(false); // desactivado al inicio
        _objNvl4_2.SetActive(false); // desactivado al inicio
        _objNvl4_3.SetActive(false); // desactivado al inicio

        _objNvl5.SetActive(false); // desactivado al inicio

        _sceneName = SceneManager.GetActiveScene().name;

        _buttonActive = GetComponent<Button>();

        _buttonActive.onClick.AddListener(ActveObjetives);
    }


    void Update()
    {

        if (PauseStatus.IsPaused && _active)
        {
            _active = false;
            Desactive();
        }
    }

    public void ActveObjetives()
    {
        if (PauseStatus.IsPaused) return;

        GameObject kindness = GameObject.FindWithTag("Kindness");

        if (kindness != null && kindness.activeInHierarchy) return; // No se activa si Kindness está activo

        _active = !_active;

        if (!_active)
        {
            Desactive();
            return;
        }

        ShowByScene();
    }

    public void ShowByScene()
    {
        if (_sceneName == "Morning2.0") ObjNvl1();
        else if (_sceneName == "Breackfast2.0") ObjNvl2();

        else if (_sceneName == "School2.0") ObjNvl4_1();
        else if (_sceneName == "Classroom2.0") ObjNvl4_2();
        else if (_sceneName == "Playground2.0") ObjNvl4_3();

        else if (_sceneName == "Recess2.0") ObjNvl4_3();
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
    public void ObjNvl4_1()
    {
        _objNvl4_1.SetActive(true);

        _objNvl1.SetActive(false);
        _objNvl2.SetActive(false);

        _objNvl4_2.SetActive(false);
        _objNvl4_3.SetActive(false);

        _objNvl5.SetActive(false);
    }

    public void ObjNvl4_2()
    {
        _objNvl4_2.SetActive(true);

        _objNvl1.SetActive(false);
        _objNvl2.SetActive(false);

        _objNvl4_1.SetActive(false);
        _objNvl4_3.SetActive(false);

        _objNvl5.SetActive(false);
    }
    public void ObjNvl4_3()
    {
        _objNvl4_3.SetActive(true);

        _objNvl1.SetActive(false);
        _objNvl2.SetActive(false);

        _objNvl4_1.SetActive(false);
        _objNvl4_2.SetActive(false);

        _objNvl5.SetActive(false);
    }
    public void ObjNvl5()
    {
        _objNvl5.SetActive(true);

        _objNvl1.SetActive(false);
        _objNvl2.SetActive(false);

        _objNvl4_1.SetActive(false);
        _objNvl4_2.SetActive(false);
        _objNvl4_3.SetActive(false);
    }

    private void Desactive()
    {
        _objNvl1.SetActive(false);
        _objNvl2.SetActive(false);

        _objNvl4_1.SetActive(false);
        _objNvl4_2.SetActive(false);
        _objNvl4_3.SetActive(false);
    }
}
