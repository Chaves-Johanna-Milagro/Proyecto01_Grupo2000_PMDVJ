using UnityEngine;

public class PaySube : MonoBehaviour
{
    private GameObject _load; // pa la pantalla de los 3 puntitos
    private GameObject _error;
    private GameObject _correct;

    private GameObject _xNormal;
    private GameObject _xError;

    private GameObject _iNormal;
    private GameObject _iCorrect;

    private float _timer = 0f;
    private float _requiredTime = 2f;

    private bool _isTouching = false;
    private bool _completed = false;

    private CStreetChar _streetChar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform mj = transform.parent;

        _load = mj.transform.Find("Load").gameObject;
        _error = mj.transform.Find("Error").gameObject;
        _correct = mj.transform.Find("Correct").gameObject;

        _xNormal = mj.transform.Find("XBlanca").gameObject;
        _xError = mj.transform.Find("XRoja").gameObject;

        _iNormal = mj.transform.Find("CheckB").gameObject;
        _iCorrect = mj.transform.Find("CheckV").gameObject;

        _streetChar = mj.GetComponentInParent<CStreetChar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_completed || !_isTouching) return;

        _timer += Time.deltaTime;

        if (_timer >= _requiredTime)
        {
            _load.SetActive(false);
            _correct.SetActive(true);
            _iNormal.SetActive(false);
            _iCorrect.SetActive(true);
            _completed = true;
            _streetChar.IsCompleteMG();//marcar como completado
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_completed) return;

        if (collision.gameObject.name == "Sube")
        {
            _load.SetActive(true);
            _correct.SetActive(false);
            _error.SetActive(false);
            _xNormal.SetActive(true);
            _xError.SetActive(false);
            _iNormal.SetActive(true);
            _iCorrect.SetActive(false);

            Debug.Log("cargando");
        } 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_completed) return;

        if (collision.gameObject.name == "Sube")
        {
            _isTouching = true;

            Debug.Log("pago exitoso");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_completed) return;

        if (collision.gameObject.name == "Sube")
        {
            _isTouching = false;

            _load.SetActive(false);
            _error.SetActive(true);
            _xNormal.SetActive(false);
            _xError.SetActive(true);

            _timer = 0f;

            Debug.Log("no pagado");
        }
    }
}
