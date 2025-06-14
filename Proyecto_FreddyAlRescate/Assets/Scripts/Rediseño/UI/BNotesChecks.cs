using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BNotesChecks : MonoBehaviour
{
    private GameObject _imgChecks;

    private GameObject _check1;
    private GameObject _check2;
    private GameObject _check3;

    private Button _BNotes;

    private string _sceneName;

    private bool _isActive = false;

    //private AudioSource _audioCheck;

    private BMiniAfton _bAfton; //para dar retroalimentacion positiva cada que complete un objetivo

    private void Start()
    {
        _imgChecks = transform.Find("ImgChecks")?.gameObject;

        _check1 = _imgChecks.transform.Find("Check1")?.gameObject;
        _check2 = _imgChecks.transform.Find("Check2")?.gameObject;
        _check3 = _imgChecks.transform.Find("Check3")?.gameObject;

        _imgChecks.SetActive(false); // Oculta contenedor al inicio

        _sceneName = SceneManager.GetActiveScene().name;

        _BNotes = GetComponent<Button>();
        _BNotes.onClick.AddListener(ActiveChecks);

        UpdateChecks();

        //_audioCheck = GetComponent<AudioSource>();

        _bAfton = Object.FindFirstObjectByType<BMiniAfton>();
    }

    private void Update()
    {
        if (PauseStatus.IsPaused && _isActive)
        {
            _isActive = false;
            _imgChecks.SetActive(false);
        }
    }

    public void ActiveChecks()
    {
        if (PauseStatus.IsPaused) return;

        GameObject kindness = GameObject.FindWithTag("Kindness");

        if (kindness != null && kindness.activeInHierarchy) return; // No se activa si Kindness está activo

        _isActive = !_isActive;
        _imgChecks.SetActive(_isActive);
    }

    public void Check1()
    {
        ChecksStatus.SetCheckActive(_sceneName, 0);
        UpdateChecks();

        //_audioCheck.Play();
        PlaySound("Correct");

        _bAfton.GoodFeedback();//activa el lorito para dar felicitaciones
    }

    public void Check2()
    {
        ChecksStatus.SetCheckActive(_sceneName, 1);
        UpdateChecks();

        //_audioCheck.Play();
        PlaySound("Correct");

        _bAfton.GoodFeedback();//activa el lorito para dar felicitaciones
    }

    public void Check3()
    {
        ChecksStatus.SetCheckActive(_sceneName, 2);
        UpdateChecks();

        PlaySound("Correct");

        _bAfton.GoodFeedback();//activa el lorito para dar felicitaciones
    }

    private void UpdateChecks()
    {
        bool[] current = ChecksStatus.GetChecksForScene(_sceneName);

        if (_check1 != null) _check1.SetActive(current[0]);
        if (_check2 != null) _check2.SetActive(current[1]);
        if (_check3 != null) _check3.SetActive(current[2]);
    }

    public void PlaySound(string name)
    {
        AudioSource[] sounds = GetComponents<AudioSource>();

        foreach (AudioSource sound in sounds)
        {
            if (sound.clip != null && sound.clip.name == name) sound.Play();
        }
    }
}
