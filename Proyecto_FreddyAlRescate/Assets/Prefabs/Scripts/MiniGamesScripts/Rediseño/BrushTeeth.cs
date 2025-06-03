using UnityEngine;

public class BrushTeeh : MonoBehaviour // Este script lo tiene Mouth
{
    private GameObject _mouthDirty;
    private GameObject _mouthClean;

    private float _timer = 0f;
    private float _requiredTime = 2f;

    private bool _isTouching = false;
    private bool _completed = false;


    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    private AudioSource _soundBrush;


    private void Start()
    {
        // Busca a MouthClean dentro del padre (MiniGame)
        _mouthDirty = transform.parent.Find("MouthDirty")?.gameObject;
        _mouthClean = transform.parent.Find("MouthClean")?.gameObject;
        // if (_mouthClean != null) _mouthClean.SetActive(false); // Asegura que esté oculta al inicio


        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        _soundBrush = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (_completed || !_isTouching) return;

        _timer += Time.deltaTime;

        if (_timer >= _requiredTime)
        {
            _check.Check3(); //si se completa activa el check
            _kind.GoodDecision(); //si se completa sube la barrita

            _mouthDirty.SetActive(false);        // Desactiva MouthDirty
            _mouthClean?.SetActive(true);       // Activa MouthClean
            _completed = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_completed) return;

        if (collision.gameObject.name == "CEPILLO")
        {
            _soundBrush?.Play();
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (_completed) return;

        if (other.gameObject.name == "CEPILLO")
        {
            _isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "CEPILLO")
        {
            _isTouching = false;
            _timer = 0f;
            _soundBrush.Stop();
        }
    }
}
