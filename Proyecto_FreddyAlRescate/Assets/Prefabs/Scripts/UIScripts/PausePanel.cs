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

    private float _speed = 5f;

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
    
    }

    public void Toggle()
    {
        _isPause = !_isPause;
        _target = _isPause ? _center : _up;
        
    }

}
