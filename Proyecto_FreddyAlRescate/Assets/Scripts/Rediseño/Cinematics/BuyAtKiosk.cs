using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BuyAtKiosk : MonoBehaviour
{
    private GameObject _Img;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    //private bool _isClicked = false;
    private string _scene;

    void Start()
    {
        _Img = transform.Find("Img")?.gameObject;

        if (_Img == null)
            Debug.LogWarning("No se encontró el objeto hijo 'Img'.");

        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        _scene = SceneManager.GetActiveScene().name;

        // Restauramos si ya se había hecho antes
        if (CinematicStatus.TieneEstado(gameObject))
        {
            CinematicStatus.RestaurarEstado(gameObject);
            //_isClicked = true; // Ya se había hecho clic antes
        }
    }

    public void OnMouseDown()
    {
      //  if (_isClicked) return;

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (DecisionStatus.ActiveDecision()) return;

        if (CinematicStatus.ActiveCinematic()) return;

       // _isClicked = true;
       if(ChecksStatus.IsCheckActive("Playground2.0",1) || ChecksStatus.IsCheckActive("Recess2.0",1)) return; //evitar que se pued interactual al ya estar activo el check

        if (_Img != null) _Img.SetActive(true);

        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        _check?.Check2();
        _kind?.GoodDecision();

        ChecksStatus.SetCheckActive("Recess2.0",1); //activamos tambien el check en esa escena
       
        yield return new WaitForSeconds(2f);

        if (_Img != null) _Img.SetActive(false);

        // Guardamos el estado final para que se mantenga entre escenas
        CinematicStatus.GuardarEstado(gameObject);

    }
}
