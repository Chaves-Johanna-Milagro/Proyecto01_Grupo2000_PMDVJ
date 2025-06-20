using UnityEngine;

public class ChangeValues : MonoBehaviour //lo tiene el minijuego de los dados
{
    private GameObject _mg;

    private GameObject _pagNvl1;
    private GameObject _pagNvl2;
    private GameObject _pagNvl3;

    void Start()
    {
        _mg = transform.parent.gameObject;

        _pagNvl1 = _mg.transform.Find("PagLvl1").gameObject;
        _pagNvl2 = _mg.transform.Find("PagLvl2").gameObject;
        _pagNvl3 = _mg.transform.Find("PagLvl3").gameObject;

        SetDados();
    }

    private void OnEnable()
    {
        SetDados();
    }

    private void SetDados()
    {
        if(LevelGameStatus.GetLevel() == "Facil") _pagNvl1?.SetActive(true);
        if(LevelGameStatus.GetLevel() == "Medio") _pagNvl2?.SetActive(true);
        if(LevelGameStatus.GetLevel() == "Dificil") _pagNvl3?.SetActive(true);

    }

    private void Update() //busque de nuevo los objtetos
    {
        if (_pagNvl1 == null) _pagNvl1 = _mg.transform.Find("PagLvl1").gameObject;
        if (_pagNvl2 == null) _pagNvl2 = _mg.transform.Find("PagLvl2").gameObject;
        if (_pagNvl3 == null) _pagNvl3 = _mg.transform.Find("PagLvl3").gameObject;
    }
}
