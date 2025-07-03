using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoToBathroom : MonoBehaviour
{
    private GameObject _img;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    private bool _isClicked = false;
   
    private AudioSource _audioSource;
    void Start()
    {
        _img = transform.Find("Img").gameObject;

        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        // Restauramos si ya se hab�a hecho antes
        if (CinematicStatus.TieneEstado(gameObject))
        {
            CinematicStatus.RestaurarEstado(gameObject);
            _isClicked = true; // Ya se hab�a hecho clic antes
        }
        _audioSource = _img.GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
        if (_isClicked) return;

        if (SceneManager.GetActiveScene().name == "School2.0") return; //paq namas se lave la mano en el recreo

        if (PauseStatus.IsPaused) return; // Verifica si el juego est� en pausa antes de procesar el click

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return; // si esta un mini juego no procese el click

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        _isClicked = true;

        if (_img != null) _img.SetActive(true);

        StartCoroutine(Delay());

    }
    private IEnumerator Delay()
    {
        if(_audioSource != null) _audioSource.Play();

        yield return new WaitForSeconds(5f);

        ChecksStatus.SetCheckActive("Playground2.0", 0); //activamos tambien el check en esa escena

        if (_img != null) _img.SetActive(false);

        if (_audioSource != null) _audioSource.Stop();

        // Guardamos el estado final para que se mantenga entre escenas
        CinematicStatus.GuardarEstado(gameObject);

        _check?.Check1();
        _kind?.GoodDecision();
    }
}
