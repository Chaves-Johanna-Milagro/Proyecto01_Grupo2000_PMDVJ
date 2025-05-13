using UnityEngine;
using UnityEngine.UI;

public class BlockIfPausedUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

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
