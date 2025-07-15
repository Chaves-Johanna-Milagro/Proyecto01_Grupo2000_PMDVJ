using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBreakfast : MonoBehaviour // este script lo tiene mout de minijuego desayuno
{
    private GameObject _mouthDefault;
    private GameObject _mouthOpen;
    private GameObject _mouthClose;

    private bool _comiendo = false;
    private bool _terminado = false;

    private HashSet<string> _objetosComidos = new HashSet<string>();

    private float _tiempoParaComer = 0.5f;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;
    private CursorManager _cursorManager;
    private MGBase _mgBase;

    private AudioSource _soundEat;

    private Vector3 _posDrink;
    private EChooseBeakfast _ecBreak;

    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        _mouthDefault = parent.transform.Find("MouthDefault").gameObject;
        _mouthOpen = parent.transform.Find("MouthOpen").gameObject;
        _mouthClose = parent.transform.Find("MouthClose").gameObject;

        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        _cursorManager = Object.FindFirstObjectByType<CursorManager>();

        _mgBase = parent.GetComponentInParent<MGBase>();

        _soundEat = GetComponent<AudioSource>();

        ActivarBoca("default");

        _ecBreak = Object.FindFirstObjectByType<EChooseBeakfast>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_comiendo || _terminado) return;

        RevisarObjeto(other);
    }

    private void RevisarObjeto(Collider2D other)
    {
        string nombre = other.name;
        string tag = other.tag;

        if (_objetosComidos.Contains(nombre)) return;

        // Solo se puede usar comida o bebida primero
        if ((_objetosComidos.Count == 0 && (tag == "Food" || tag == "Drink")) ||
            (_objetosComidos.Count == 1 && (tag == "Food" || tag == "Drink") && !_objetosComidos.Contains(nombre)))
        {
            StartCoroutine(ComerObjeto(other.gameObject));
        }

        // Servilleta solo si ya se usó comida y bebida
        else if (nombre == "SERVILLETA" &&
                 _objetosComidos.ExistsWithTag("Food") &&
                 _objetosComidos.ExistsWithTag("Drink") &&
                 !_objetosComidos.Contains("SERVILLETA"))
        {
            StartCoroutine(LimpiarBocaConNapkin(other.gameObject));
        }
    }

    private IEnumerator ComerObjeto(GameObject obj)
    {
        _comiendo = true;

        yield return new WaitForSeconds(_tiempoParaComer);
        ActivarBoca("open");

        _cursorManager?.SetCursorDrop();

        yield return new WaitForSeconds(0.3f);
        ActivarBoca("close");

        if (obj.CompareTag("Drink"))
        {
            // Guardar la posición original de la bebida antes del rebote
            _posDrink = _ecBreak.GetPosDrink();

            AudioSource bebidaAudio = obj.GetComponent<AudioSource>();
            if (bebidaAudio != null) bebidaAudio.Play();

            StartCoroutine(ReboteBebida(obj));
        }
        else // Si es comida
        {
            _soundEat?.Play();
            obj.SetActive(false);
        }

        _cursorManager?.SetCursorDefault();

        yield return new WaitForSeconds(0.3f);
        ActivarBoca("default");

        _objetosComidos.Add(obj.name);
        _comiendo = false;
    }

    private IEnumerator LimpiarBocaConNapkin(GameObject napkin)
    {
        _comiendo = true;

        yield return new WaitForSeconds(_tiempoParaComer);
        ActivarBoca("close");

        yield return new WaitForSeconds(0.3f);
        ActivarBoca("default");

        napkin.SetActive(false);
        _objetosComidos.Add("SERVILLETA");

        _check.Check1();
        _kind.GoodDecision();
        _cursorManager?.SetCursorDefault();
        _mgBase.ExitMiniGame();

        _terminado = true;
        _comiendo = false;
    }

    private IEnumerator ReboteBebida(GameObject bebida)
    {
        yield return new WaitForSeconds(1f);

        float dur = 0.4f;
        float t = 0f;

        Vector3 inicio = bebida.transform.position;
        Vector3 destino = _posDrink;

        var drag = bebida.GetComponent<DragSprite2_0>();
        if (drag != null) drag.enabled = false;

        while (t < dur)
        {
            float smoothT = Mathf.SmoothStep(0, 1, t / dur);
            float rebote = Mathf.Sin(smoothT * Mathf.PI);
            bebida.transform.position = Vector3.Lerp(inicio, destino, smoothT) + Vector3.up * rebote * 0.1f;

            t += Time.deltaTime;
            yield return null;
        }

        bebida.transform.position = destino;
    }

    private void ActivarBoca(string estado)
    {
        _mouthDefault.SetActive(estado == "default");
        _mouthOpen.SetActive(estado == "open");
        _mouthClose.SetActive(estado == "close");
    }

}
    public static class BreakfastExtensions
    {
        public static bool ExistsWithTag(this HashSet<string> objetosComidos, string tag)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tag))
            {
                if (!obj.activeInHierarchy || objetosComidos.Contains(obj.name)) continue;
                return false;
            }
            return true;
        }
    }
