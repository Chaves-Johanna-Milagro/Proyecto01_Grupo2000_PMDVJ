using UnityEngine;

public class SlideCredits : MonoBehaviour
{
    private RectTransform _image; // La imagen que se va a deslizar
    private float _speed = 0.05f;     // Velocidad del deslizamiento

    private Vector2 _startPos;
    private Vector2 _targetPos;
    private bool _sliding = false;

    private void Start()
    {
        //if (_image == null)
            _image = gameObject.GetComponent<RectTransform>();

        _startPos = _image.anchoredPosition;

        // Invertimos la Y para que vaya de negativo a positivo manteniendo el mismo valor absoluto
        _targetPos = new Vector2(_startPos.x, Mathf.Abs(_startPos.y));

        StartSlide();
    }

    private void Update()
    {
        if (_sliding)
        {
            _image.anchoredPosition = Vector2.Lerp(_image.anchoredPosition, _targetPos, Time.deltaTime * _speed);

            // Detenemos cuando est� cerca del objetivo
            if (Vector2.Distance(_image.anchoredPosition, _targetPos) < 0.05f)
            {
                _image.anchoredPosition = _targetPos;
                _sliding = false;
            }
        }
    }

    public void StartSlide()
    {
        _sliding = true;
    }
}
