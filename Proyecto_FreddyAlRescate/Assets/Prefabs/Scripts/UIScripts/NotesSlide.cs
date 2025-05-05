using UnityEngine;
using UnityEngine.EventSystems;

public class NotesSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float _slideY = -200f;   // Y final al apoyar el cursor
    private float _slideSpeed = 5f;

    private RectTransform _rectTransform;
    private Vector2 _originalPosition;

    private float _currentY;
    private bool _isSlip = false;

    private Vector2 _newPos = new Vector2(560f,-1000f);

    private bool _isMiniGameOrPauseActive = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPosition = _rectTransform.anchoredPosition;
        _currentY = _originalPosition.y;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isSlip = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isSlip = false;
    }

    private void Update()
    {
        // Verifica si hay un objeto activo con tag "MiniGame" o "Pause"
        GameObject minigame = GameObject.FindGameObjectWithTag("MiniGame");
        GameObject pause = GameObject.FindGameObjectWithTag("Pause");

        bool isMinigameActive = minigame != null && minigame.activeInHierarchy;
        bool isPauseActive = pause != null && pause.activeInHierarchy;

        _isMiniGameOrPauseActive = isMinigameActive || isPauseActive;

        // Determina a qué posición debe ir
        float targetY;

        if (_isMiniGameOrPauseActive)
        {
            targetY = _newPos.y;  // Se desliza hacia abajo
        }
        else
        {
            targetY = _isSlip ? _slideY : _originalPosition.y;  // Slide al pasar el mouse
        }

        // Desliza suavemente (aunque el juego esté en pausa)
        _currentY = Mathf.Lerp(_currentY, targetY, Time.unscaledDeltaTime * _slideSpeed);
        _rectTransform.anchoredPosition = new Vector2(_originalPosition.x, _currentY);
    }
}
