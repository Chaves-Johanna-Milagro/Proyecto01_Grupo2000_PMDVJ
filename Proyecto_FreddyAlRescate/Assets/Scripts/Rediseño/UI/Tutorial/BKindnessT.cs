using UnityEngine;
using UnityEngine.UI;

public class BKindnessT : MonoBehaviour //pa la barrita de amabilidad del tutorial
{
    private GameObject[] _childs;
    private int _count;

    private bool _isActive = false;

    private Button _bNotes;

    private RectTransform _nowBar;

    private Vector2 _posNow;
    private float _amount = 50f;
    void Start()
    {
        _count = transform.childCount;
        _childs = new GameObject[_count];

        for (int i = 0; i < _count; i++) // desativar al inicio
        {
            _childs[i] = transform.GetChild(i).gameObject;
            _childs[i].SetActive(false);
        }

        _bNotes = GetComponent<Button>();
        _bNotes.onClick.AddListener(Toggle);

        _nowBar = transform.Find("Now").GetComponent<RectTransform>();

        _posNow = _nowBar.anchoredPosition;
    }
    private void Update()
    {
        if (PauseStatus.IsPaused && _isActive)
        {
            _isActive = false;
            StopSound("ButtonKindness");
            Objts(false);
        }
    }
    private void Toggle()
    {
        _isActive = !_isActive;

        if (_isActive) PlaySound("ButtonKindness");
        if (_isActive == false) StopSound("ButtonKindness");
        Objts(_isActive);
    }

    private void Objts(bool active)
    {
        for (int i = 0; i < _count; i++) // desativar al clikear
        {
            _childs[i].SetActive(active);
        }
    }
    public void PlaySound(string name)
    {
        AudioSource[] sounds = GetComponents<AudioSource>();

        foreach (AudioSource sound in sounds)
        {
            if (sound.clip != null && sound.clip.name == name) sound.Play();
        }
    }
    public void StopSound(string name)
    {
        AudioSource[] sounds = GetComponents<AudioSource>();

        foreach (AudioSource sound in sounds)
        {
            if (sound.clip != null && sound.clip.name == name) sound.Stop();
        }
    }

    public void UpBarKindnessTuto()//pa que suba al completa el objetivo
    {
        float newPosY = _posNow.y + _amount;

        _posNow = new Vector2(_posNow.x, newPosY);

        _nowBar.anchoredPosition = _posNow;
    }
}
