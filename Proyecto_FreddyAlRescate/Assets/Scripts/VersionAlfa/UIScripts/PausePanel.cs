using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    private RectTransform _panel;

    private Button _buttonContinue;
    private Button _buttonPause;

    private Vector2 _up = new Vector2(0f, 800f);
    private Vector2 _center = Vector2.zero;

    private Vector2 _target;

    private float _speed = 8f;

    private bool _isPause = false;
    
    void Start()
    {

        _panel = transform.GetChild(0).GetComponent<RectTransform>();
        _panel.anchoredPosition = _up;
        _target = _up;

        _buttonContinue = _panel.transform.GetChild(0).GetComponent<Button>();
        _buttonPause = transform.GetChild(1).GetComponent<Button>();

        _buttonPause.GetComponent<Button>().onClick.AddListener(Toggle);
        _buttonContinue.onClick.AddListener(Toggle);
    
    }

   
    void Update()
    {
        //movimiento suave hacia arriba
        _panel.anchoredPosition = Vector2.Lerp(_panel.anchoredPosition,_target, Time.unscaledDeltaTime * _speed);


        // Si estamos despausando y el panel ya llegó arriba, lo desactivamos
        if (!_isPause && Vector2.Distance(_panel.anchoredPosition, _up) < 15f)
        {
            _panel.gameObject.SetActive(false);
        }
    }

    public void Toggle()
    {

        _isPause = !_isPause;
        _target = _isPause ? _center : _up;

        if (_isPause)
        {
            _panel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

}
