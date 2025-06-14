using UnityEngine;
using UnityEngine.UI;

public class BlockIfPausedUI : MonoBehaviour //objetos UI que deban bloquearse al estar en pausa
{
    private CanvasGroup _canvasGroup; //deben tener un componente canvas group

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        bool isPaused = PauseStatus.IsPaused;
        _canvasGroup.interactable = !isPaused;
        _canvasGroup.blocksRaycasts = !isPaused;
    }
}
