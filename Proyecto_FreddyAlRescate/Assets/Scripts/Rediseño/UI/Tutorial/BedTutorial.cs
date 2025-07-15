using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class BedTutorial : MonoBehaviour
{
    private GameObject _complete;
    private GameObject _incomplete;

    private AudioSource _sound;

    private BNotesT _bNotesT;
    private BKindnessT _bKindT;

    private bool _isClicked = false;
    void Start()
    {
        _complete = transform.Find("Complete").gameObject;
        _incomplete = transform.Find("Incomplete").gameObject;

        _complete.SetActive(false);
        _incomplete.SetActive(true);

        _sound = transform.Find("Child").GetComponent<AudioSource>();

        _bNotesT = Object.FindFirstObjectByType<BNotesT>();
        _bKindT = Object.FindFirstObjectByType<BKindnessT>();
    }

    public void OnMouseDown()
    {
        if (_isClicked) return;

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (DecisionStatus.ActiveDecision()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        _isClicked = true;

        if (_sound != null) _sound.Play();
        if (_complete != null) _complete.SetActive(true);
        if (_incomplete != null) _incomplete.SetActive(false);

        if (_bNotesT != null) _bNotesT.ActiveCheckTuto();
        if (_bKindT != null) _bKindT.UpBarKindnessTuto();
    }
}
