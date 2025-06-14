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

    private HashSet<string> _objetosComidos = new HashSet<string>(); //es como una lista de colliders

    private float _tiempoParaComer = 0.5f;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    private AudioSource _soundEat;

    private CursorManager _cursorManager;

    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        _mouthDefault = parent.transform.Find("MouthDefault").gameObject;
        _mouthOpen = parent.transform.Find("MouthOpen").gameObject;
        _mouthClose = parent.transform.Find("MouthClose").gameObject;

        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        ActivarBoca("default");

        // Reset de estado
        _comiendo = false;
        _terminado = false;
        _objetosComidos.Clear();

        // Verificar estado de cada objeto
        GameObject bread = GameObject.Find("PAN");
        if (bread == null || !bread.activeInHierarchy) _objetosComidos.Add("PAN");

        GameObject cup = GameObject.Find("TAZA");
        if (cup == null || !cup.activeInHierarchy) _objetosComidos.Add("TAZA");

        GameObject napkin = GameObject.Find("SERVILLETA");
        if (napkin == null || !napkin.activeInHierarchy) _objetosComidos.Add("SERVILLETA");

        // Marcar como terminado si ya están los 3 comidos
        if (_objetosComidos.Contains("PAN") && _objetosComidos.Contains("TAZA") && _objetosComidos.Contains("SERVILLETA"))
        {
            _terminado = true;
        }

        _soundEat = GetComponent<AudioSource>();

        _cursorManager = Object.FindFirstObjectByType<CursorManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_comiendo || _terminado) return;

        RevisarObjeto(other);
    }

    private void RevisarObjeto(Collider2D other)
    {
        string nombre = other.name;

        if (_objetosComidos.Contains(nombre)) return;

        // Primera comida: Bread o Cup
        if ((_objetosComidos.Count == 0 && (nombre == "PAN" || nombre == "TAZA")) ||
            (_objetosComidos.Count == 1 && (nombre == "PAN" || nombre == "TAZA") && !_objetosComidos.Contains(nombre)))
        {
            StartCoroutine(ComerObjeto(other.gameObject));
        }

        // Napkin solo si ya se comieron Bread y Cup
        else if (nombre == "SERVILLETA" &&
                 _objetosComidos.Contains("PAN") &&
                 _objetosComidos.Contains("TAZA") &&
                 !_objetosComidos.Contains("SERVILLETA"))
        {
            StartCoroutine(LimpiarBocaConNapkin(other.gameObject));
        }
    }

    private IEnumerator ComerObjeto(GameObject comida)
    {
        _comiendo = true;



        yield return new WaitForSeconds(_tiempoParaComer);
        ActivarBoca("open");

        _cursorManager?.SetCursorDrop(); //cursor de dropeo

        yield return new WaitForSeconds(0.3f);
        ActivarBoca("close");
        _soundEat?.Play();

        _cursorManager?.SetCursorDefault(); //cursor por defecto

        yield return new WaitForSeconds(0.3f);
        ActivarBoca("default");

        comida.SetActive(false);
        _objetosComidos.Add(comida.name);
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

        _check.Check1(); // marcar minijuego como completado
        _kind.GoodDecision(); // sube la barrita

        _cursorManager?.SetCursorDefault(); //cursor por defecto

        _terminado = true;
        _comiendo = false;
    }

    private void ActivarBoca(string estado)
    {
        _mouthDefault.SetActive(estado == "default");
        _mouthOpen.SetActive(estado == "open");
        _mouthClose.SetActive(estado == "close");
    }
}
