using UnityEngine;

public class ChangePag : MonoBehaviour // lo tiene la flchicas del mg de el ahorcadito
{
    private GameObject[] _pages;

    private int _currentPageIndex = 0;

    private string _nameArrow;

    private AudioSource _audioSource;
    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        // Detectamos todas las pag por nombre
        _pages = new GameObject[]
        {
            parent.transform.Find("Pag1").gameObject,
            parent.transform.Find("Pag2").gameObject,
            parent.transform.Find("Pag3").gameObject
        };

        _nameArrow = gameObject.name;

        // Solo activamos la primera pag
        for (int i = 0; i < _pages.Length; i++)
            _pages[i].SetActive(i == 0);

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (PauseStatus.IsPaused) return;
        if (CursorStatusInUI.IsPointerOverUI()) return;
        if (CinematicStatus.ActiveCinematic()) return;
        if (DecisionStatus.ActiveDecision()) return;

        // Averiguamos cual esta activa 
        for (int i = 0; i < _pages.Length; i++)
        {
            if (_pages[i].activeInHierarchy)
            {
                _currentPageIndex = i;
                break;
            }
        }

        if (_audioSource != null) _audioSource.Play();

        // Desactivamos la actual
        _pages[_currentPageIndex].SetActive(false);

        // Cambiamos de pag segun la flecha
        if (_nameArrow == "ArrowRight")
        {
            _currentPageIndex = (_currentPageIndex + 1) % _pages.Length;
        }
        else if (_nameArrow == "ArrowLeft")
        {
            _currentPageIndex = (_currentPageIndex - 1 + _pages.Length) % _pages.Length;
        }

        // Activamos la nueva
        _pages[_currentPageIndex].SetActive(true);
    }
}
