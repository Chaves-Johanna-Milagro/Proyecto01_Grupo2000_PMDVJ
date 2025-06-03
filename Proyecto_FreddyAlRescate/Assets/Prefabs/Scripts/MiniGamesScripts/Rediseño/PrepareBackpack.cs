using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrepareBackpack : MonoBehaviour
{
    private HashSet<string> _incorrectos = new HashSet<string> { "CEPILLO", "JOYSTICK", "MEDIA" };
    private int _totalCorrectos = 6;

    private Dictionary<string, Vector3> _posInit = new Dictionary<string, Vector3>();// pa guardar la pos inicial de los obj

    private Transform _parent;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    private AudioSource _audioSource;

    void Start()
    {
        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        _parent = transform.parent;

        foreach (Transform child in _parent)
        {
            string nombre = child.name;
            if(nombre == "Backpack" && nombre == "Img") continue;
            _posInit[nombre] = child.position;
        }

        _audioSource = GetComponent<AudioSource>();

        VerificarCheck();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PauseStatus.IsPaused) return;

        if (other.transform.parent != transform.parent) return;

        string nombre = other.name;


        if (_incorrectos.Contains(nombre))
        {
            // Reproducir sonido si el objeto tiene un AudioSource
            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.Play();
            }

            if (_posInit.TryGetValue(nombre, out Vector3 destino)) //movera a su pos inicial a los incorrectos
            {
                StartCoroutine(MoverSuavemente(other.transform, destino, 0.3f));
            }
            return;
        }

        _audioSource.Play();
        other.gameObject.SetActive(false);
        VerificarCheck();
    }

    private void VerificarCheck()
    {
        int desactivadosCorrectos = 0;

        foreach (Transform child in _parent)
        {
            string nombre = child.name;

            if (_incorrectos.Contains(nombre)) continue;
            if (!child.gameObject.activeInHierarchy) desactivadosCorrectos++;
        }

        if (desactivadosCorrectos >= _totalCorrectos)
        {
            _check.Check2(); //activa el check
            _kind.GoodDecision(); //sube la barrita
        }
    }

    private IEnumerator MoverSuavemente(Transform objeto, Vector3 destino, float duracion)
    {
        Vector3 inicio = objeto.position;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            objeto.position = Vector3.Lerp(inicio, destino, tiempo / duracion);
            tiempo += Time.deltaTime;
            yield return null;
        }

        objeto.position = destino;
    }
}
