using UnityEngine;
using UnityEngine.UIElements;

public class BarKindnessController : MonoBehaviour
{
    public static BarKindnessController Instance { get; private set; }

    private RectTransform _nowBar; // el puntito que se deslizara dependiendo las desiciones que tome el jugador

    private float _maxX = 200; //limite derecho
    private float _minX = -200; //limite izquierdo

    private float _amount = 20f; // la cantidad de frames que se movera

    private void Awake()
    {
        //limita la instancia a una sola
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(this); //permite que sobreviva a cambios de escena
        }
    }


    void Start()
    {
        _nowBar = transform.GetChild(0).GetComponent<RectTransform>();
     
    }

    public void GoodDecision()
    {
        Vector2 newPos = _nowBar.anchoredPosition + new Vector2(_amount, 0f);
        newPos.x = Mathf.Clamp(newPos.x, _minX, _maxX);
        _nowBar.anchoredPosition = newPos;
    }

    public void BadDecision()
    {
        Vector2 newPos = _nowBar.anchoredPosition + new Vector2(-_amount, 0f);
        newPos.x = Mathf.Clamp(newPos.x, _minX, _maxX);
        _nowBar.anchoredPosition = newPos;
    }
}
