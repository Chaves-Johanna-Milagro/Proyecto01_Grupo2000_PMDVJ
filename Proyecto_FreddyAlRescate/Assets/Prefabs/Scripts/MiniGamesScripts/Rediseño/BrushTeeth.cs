using UnityEngine;

public class BrushTeeh : MonoBehaviour // ste script lo tiene MouthDirty
{
    private GameObject _mouthClean;

    private float _timer = 0f;
    private float _requiredTime = 2f;

    private bool _isTouching = false;
    private bool _completed = false;


    private BNotesChecks _check;


    private void Start()
    {
        // Busca a MouthClean dentro del padre (MiniGame)
        _mouthClean = transform.parent.Find("MouthClean")?.gameObject;
        // if (_mouthClean != null) _mouthClean.SetActive(false); // Asegura que esté oculta al inicio


        _check = Object.FindFirstObjectByType<BNotesChecks>();

    }

    private void Update()
    {
        if (_completed || !_isTouching) return;

        _timer += Time.deltaTime;

        if (_timer >= _requiredTime)
        {
            _check.Check3(); //si se completa activa el check

            gameObject.SetActive(false);        // Desactiva MouthDirty
            _mouthClean?.SetActive(true);       // Activa MouthClean
            _completed = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_completed) return;

        if (other.gameObject.name == "Brush")
        {
            _isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Brush")
        {
            _isTouching = false;
            _timer = 0f;
        }
    }
}
