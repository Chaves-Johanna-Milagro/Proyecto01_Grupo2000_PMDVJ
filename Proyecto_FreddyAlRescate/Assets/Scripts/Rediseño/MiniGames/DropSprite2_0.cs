using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DropSprite2_0 : MonoBehaviour //pa zonas de dropeo de obj de los minijuegos, en especifico las de la escuela
{
    private string _name;
    private bool _ocupado = false;
    private float _alpha;
    private float _tiempoReq = 1f;

    private Dictionary<GameObject, float> _tiempos = new();
    private MGSchool _mg;


    private CursorManager _cursorManager; //pa cambiar el cursor

    private AudioSource _audioSource;

    void Start()
    {

        _cursorManager = Object.FindFirstObjectByType<CursorManager>();

        _name = name;
        string num = _name.Replace("Space", "");

        // Si hay objeto previamente colocado, restaurar su posición y estado
        foreach (string objName in DropItemStatus.ObjetosColocados)
        {
            if (!objName.EndsWith(num)) continue;

            GameObject obj = GameObject.Find(objName);
            if (obj == null) break;

            obj.transform.position = transform.position;

            var drag = obj.GetComponent<DragSprite2_0>();
            if (drag) drag.enabled = false;

            var col = obj.GetComponent<Collider2D>();
            if (col) col.enabled = false;

            _ocupado = true;
            break;
        }

        _alpha = GetComponent<SpriteRenderer>().color.a;
        switch (LevelGameStatus.GetLevel())
        {
            case "Facil": _alpha = 0.8f; break;
            case "Medio": _alpha = 0.4f; break;
            case "Dificil": _alpha = 0f; break;
        }
        SetAlpha();

        _mg = transform.GetComponentInParent<MGSchool>();

        _audioSource = GetComponent<AudioSource>();
    }

    public void OnEnabled()
    {
        switch (LevelGameStatus.GetLevel())
        {
            case "Facil": _alpha = 0.8f; break;
            case "Medio": _alpha = 0.4f; break;
            case "Dificil": _alpha = 0f; break;
        }
        SetAlpha();
    }

    private void SetAlpha()
    {
        var sr = GetComponent<SpriteRenderer>();
        var c = sr.color;
        c.a = _alpha;
        sr.color = c;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (_ocupado) return;

        string num = _name.Replace("Space", "");
        if (!col.name.EndsWith(num)) return;

        float dist = Vector3.Distance(col.transform.position, transform.position);
        if (dist > 1.5f)
        {
            _tiempos[col.gameObject] = 0f;
            return;
        }

        if (!_tiempos.ContainsKey(col.gameObject))
            _tiempos[col.gameObject] = 0f;

        _tiempos[col.gameObject] += Time.deltaTime;

        var drag = col.GetComponent<DragSprite2_0>();
        bool soltado = drag != null && !drag.IsDragging();

        if (_tiempos[col.gameObject] >= _tiempoReq || soltado)
        {
            _ocupado = true;
            DropItemStatus.ObjetosColocados.Add(col.name);
            StartCoroutine(Snap(col.gameObject, transform.position));
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _tiempos.Remove(col.gameObject);
    }

    private IEnumerator Snap(GameObject obj, Vector3 destino)
    {
        float dur = 0.3f, t = 0f;
        Vector3 ini = obj.transform.position;

        var col = obj.GetComponent<Collider2D>();
        if (col) col.enabled = false;

        while (t < dur)
        {
            obj.transform.position = Vector3.Lerp(ini, destino, t / dur);
            t += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = destino;

        var drag = obj.GetComponent<DragSprite2_0>();
        if (drag) drag.enabled = false;

        //////
        if (_audioSource != null) _audioSource.Play();
        /////////
        DropItemStatus.SumarDrop(_mg.GetNameMG());

        int total = DropItemStatus.GetDrops(_mg.GetNameMG());
        Debug.Log(total);

        string nivel = LevelGameStatus.GetLevel();
        string nombreMG = _mg.GetNameMG();

        // Validar si se completó el minijuego según tipo y nivel
        if (
            (nombreMG == "Ahorcadito" && total == _mg.GetTotalAhorcadito()) ||
            (nombreMG == "Dados" && total == _mg.GetTotalDados()) ||
            (nombreMG == "Puzzle" && (
                (nivel == "Facil" && total == _mg.GetTotalPuzzleLvl1()) ||
                (nivel == "Medio" && total == _mg.GetTotalPuzzleLvl2()) ||
                (nivel == "Dificil" && total == _mg.GetTotalPuzzleLvl3()))
            )
        )
        {
            if(_cursorManager == null) _cursorManager = Object.FindFirstObjectByType<CursorManager>();
                
            _cursorManager.SetCursorDefault();//seteamos al por defecto al terminar cualquier minijuego
            _mg.ExitMiniGame();
        }
    }
}
