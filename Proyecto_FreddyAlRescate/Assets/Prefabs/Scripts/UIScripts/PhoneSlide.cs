using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class PhoneSlide : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float _slideY = -200f;   // Y final al apoyar el cursor
    private float _slideSpeed = 5f;
    public AudioSource phoneNoti;

    private RectTransform _rectTransform;
    private Vector2 _originalPosition;

    private float _currentY;
    private bool _isSlip = false;

    private Vector2 _miniGamePos = new Vector2(560f, -1000f);
    private bool _isMiniGameActive = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPosition = _rectTransform.anchoredPosition;
        _currentY = _originalPosition.y;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isSlip = true;
        phoneNoti.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isSlip = false;
    }

    private void Update()
    {
        // Chequea si hay un objeto activo con tag "Minigame"
        GameObject minigame = GameObject.FindGameObjectWithTag("MiniGame");

        if (minigame != null && minigame.activeInHierarchy)
        {
            // Si el minijuego estÅEactivo, mueve el panel m·s abajo y bloquea el slide
            _isMiniGameActive = true;
        }
        else
        {
            _isMiniGameActive = false;
        }

        // Calculamos el targetY seg˙n el estado actual
        float targetY;

        if (_isMiniGameActive)
        {
            targetY = _miniGamePos.y;
        }
        else
        {
            targetY = _isSlip ? _slideY : _originalPosition.y;
        }
        _currentY = Mathf.Lerp(_currentY, targetY, Time.deltaTime * _slideSpeed);
        _rectTransform.anchoredPosition = new Vector2(_originalPosition.x, _currentY);
    }
}
