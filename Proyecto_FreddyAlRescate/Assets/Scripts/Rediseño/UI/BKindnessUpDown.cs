using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BKindnessUpDown : MonoBehaviour
{
    private RectTransform _nowBar;

    private float _maxY = -270f; //limite superior
    private float _minY = -720f; //limite inferior

    private float _amount = 30f; // la cantidad de frames que se movera
    private float _minAmount = 5f; //para acciones peque�as como tirar l�a basura al tacho
    void Start()
    {
        _nowBar = transform.Find("Now").GetComponent<RectTransform>();


        // Cargar la posici�n guardada
        float savedY = Mathf.Clamp(KindnessStatus.GetNowBarY(), _minY, _maxY);
        Vector2 newPos = _nowBar.anchoredPosition;
        newPos.y = savedY;
        _nowBar.anchoredPosition = newPos;
    }

  /*  public void Update()//prueba de funcionamiento
    {
        if (Input.GetMouseButtonDown(0)) GoodDecision();
        if (Input.GetMouseButtonDown(1)) BadDecision();
    }*/

    public void GoodDecision()
    {
        Vector2 newPos = _nowBar.anchoredPosition + new Vector2(0f,_amount );
        newPos.y = Mathf.Clamp(newPos.y, _minY, _maxY);
        _nowBar.anchoredPosition = newPos;

        KindnessStatus.SetNowBarY(newPos.y); // Guardar la nueva posici�n
    }

    public void MiniGoodDecision()
    {
        Vector2 newPos = _nowBar.anchoredPosition + new Vector2(0f, _minAmount);
        newPos.y = Mathf.Clamp(newPos.y, _minY, _maxY);
        _nowBar.anchoredPosition = newPos;

        KindnessStatus.SetNowBarY(newPos.y); // Guardar la nueva posici�n
    }


    public void BadDecision()
    {
        Vector2 newPos = _nowBar.anchoredPosition + new Vector2(0f, -_amount);
        newPos.y = Mathf.Clamp(newPos.y, _minY, _maxY);
        _nowBar.anchoredPosition = newPos;

        KindnessStatus.SetNowBarY(newPos.y); // Guardar la nueva posici�n
    }

    public void MiniBadDecision()
    {
        Vector2 newPos = _nowBar.anchoredPosition + new Vector2(0f, -_minAmount);
        newPos.y = Mathf.Clamp(newPos.y, _minY, _maxY);
        _nowBar.anchoredPosition = newPos;

        KindnessStatus.SetNowBarY(newPos.y); // Guardar la nueva posici�n
    }
}
