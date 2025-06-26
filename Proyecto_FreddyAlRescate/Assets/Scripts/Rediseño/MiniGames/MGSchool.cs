using UnityEngine;
using UnityEngine.SceneManagement;

public class MGSchool : MonoBehaviour
{
    private string _nombre;
    private string _escena;

    private AudioSource _sonido;

    private CursorManager _cursor;
    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    private bool _completado = false;

    private GameObject _fondo;
    private GameObject _pag1, _pag2, _pag3;

    private readonly int _ahorcTotal = 21;
    private readonly int _dadosTotal = 3;
    private readonly int _puzL1 = 4, _puzL2 = 9, _puzL3 = 16;

    void Start()
    {
        _nombre = name;
        _escena = SceneManager.GetActiveScene().name;

        if (MiniGameStatus.TieneEstado(gameObject))
            MiniGameStatus.RestaurarEstado(gameObject);

        _cursor = Object.FindFirstObjectByType<CursorManager>();
        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        _fondo = transform.Find("Img").gameObject;

        // Asignar páginas según minijuego
        if (_nombre == "Ahorcadito")
        {
            _pag1 = transform.Find("Pag1").gameObject;
            _pag2 = transform.Find("Pag2").gameObject;
            _pag3 = transform.Find("Pag3").gameObject;
        }
        else if (_nombre == "Dados" || _nombre == "Puzzle")
        {
            _pag1 = transform.Find("PagLvl1").gameObject;
            _pag2 = transform.Find("PagLvl2").gameObject;
            _pag3 = transform.Find("PagLvl3").gameObject;
        }
    }

    void OnMouseDown()
    {
        if (_completado || PauseStatus.IsPaused || CursorStatusInUI.IsPointerOverUI() ||
            MiniGameStatus.ActiveMiniGame() || CinematicStatus.ActiveCinematic() || DecisionStatus.ActiveDecision())
            return;

        // Evita que se vuelva a activar si ya se hizo el check
        if ((_nombre == "Ahorcadito" && ChecksStatus.IsCheckActive("Classroom2.0", 0)) ||
            (_nombre == "Dados" && ChecksStatus.IsCheckActive("Classroom2.0", 1)) ||
            (_nombre == "Puzzle" && ChecksStatus.IsCheckActive("Classroom2.0", 2)))
            return;

        if (_sonido) _sonido.Play();

        _fondo.SetActive(true);

        if (_nombre == "Ahorcadito")
        {
            transform.Find("ArrowRight").gameObject.SetActive(true);
            transform.Find("ArrowLeft").gameObject.SetActive(true);
            _pag1.SetActive(true);
        }
        else if (_nombre == "Dados" || _nombre == "Puzzle")
        {
            string lvl = LevelGameStatus.GetLevel();
            if (lvl == "Facil") _pag1?.SetActive(true);
            else if (lvl == "Medio") _pag2?.SetActive(true);
            else if (lvl == "Dificil") _pag3?.SetActive(true);
        }
    }

    public void ExitMiniGame()
    {
        _fondo.SetActive(false);
        _pag1?.SetActive(false);
        _pag2?.SetActive(false);
        _pag3?.SetActive(false);

        if (_nombre == "Ahorcadito")
        {
            transform.Find("ArrowRight").gameObject.SetActive(false);
            transform.Find("ArrowLeft").gameObject.SetActive(false);
            _check.Check1();
        }
        else if (_nombre == "Dados") _check.Check2();
        else if (_nombre == "Puzzle") _check.Check3();

        _cursor?.SetCursorDefault();
        MiniGameStatus.GuardarEstado(gameObject);
    }

    // Getters usados por DropSprite para saber cuántos objetos deben colocarse
    public string GetNameMG() => _nombre;
    public int GetTotalAhorcadito() => _ahorcTotal;
    public int GetTotalDados() => _dadosTotal;
    public int GetTotalPuzzleLvl1() => _puzL1;
    public int GetTotalPuzzleLvl2() => _puzL2;
    public int GetTotalPuzzleLvl3() => _puzL3;
}
