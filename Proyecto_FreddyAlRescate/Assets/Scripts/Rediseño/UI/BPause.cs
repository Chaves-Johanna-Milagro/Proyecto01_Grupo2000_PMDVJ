using UnityEngine;
using UnityEngine.UI;

public class BPause : MonoBehaviour
{
    private GameObject _img;
    private GameObject _bContinue;

    private Button _BPause;
    private Button _BResume;

    void Start()
    {
        _img = transform.GetChild(0).gameObject;
        _bContinue = transform.GetChild(1).gameObject;

        _BPause = GetComponent<Button>();
        _BResume = _bContinue.GetComponent<Button>();

        _img.SetActive(false);
        _bContinue.SetActive(false);

        _BPause.onClick.AddListener(PauseGame);
        _BResume.onClick.AddListener(ResumeGame);
    }

    void Update()
    {
        // Activar o desactivar la UI según el estado global de pausa
        bool isPaused = PauseStatus.IsPaused;

        _img.SetActive(isPaused);
        _bContinue.SetActive(isPaused);
    }

    private void PauseGame()
    {
        if (!PauseStatus.IsPaused)
        {
            PauseStatus.SetPaused(true);
        }
    }

    private void ResumeGame()
    {
        if (PauseStatus.IsPaused)
        {
            PauseStatus.SetPaused(false);
        }
    }
}
