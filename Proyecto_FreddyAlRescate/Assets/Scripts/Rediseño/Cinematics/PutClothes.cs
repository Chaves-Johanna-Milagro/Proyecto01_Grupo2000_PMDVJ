using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PutClothes : MonoBehaviour
{
    private GameObject _ImgRP;
    private GameObject _ImgPJ;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;

   // private bool _isClicked = false;

    private AudioSource _audioSource;
    void Start()
    {
        _ImgRP = transform.Find("ImgRP")?.gameObject;
        _ImgPJ = transform.Find("ImgPJ")?.gameObject;

        if (_ImgRP == null)
            Debug.LogWarning("No se encontró el objeto hijo 'Img'.");

        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        // Restauramos si ya se había hecho antes
        if (CinematicStatus.TieneEstado(gameObject))
        {
            CinematicStatus.RestaurarEstado(gameObject);
            //_isClicked = true; // Ya se había hecho clic antes
        }

        _audioSource = transform.Find("Child").GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
      //  if (_isClicked) return;

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (DecisionStatus.ActiveDecision()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        //_isClicked = true;

        if(ChecksStatus.IsCheckActive("Morning2.0",1) || ChecksStatus.IsCheckActive("Night2.0", 1)) return; //evitar que se active si su check ya se marco

        if (_audioSource != null) _audioSource.Play();

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Morning2.0" && _ImgRP != null) _ImgRP.SetActive(true);

        else if (sceneName == "Night2.0" && _ImgPJ != null) _ImgPJ.SetActive(true);
           
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        _check?.Check2();

        yield return new WaitForSeconds(2f);

        if (_ImgRP != null) _ImgRP.SetActive(false);
        if (_ImgPJ != null) _ImgPJ.SetActive(false);

        if (_audioSource != null) _audioSource.Stop();

        // Guardamos el estado final para que se mantenga entre escenas
        CinematicStatus.GuardarEstado(gameObject);

        _kind?.GoodDecision();
    }
}
