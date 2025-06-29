using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MakeBed : MonoBehaviour
{
    private GameObject _imgPJ;
    private GameObject _imgRP;
    private GameObject _objIncom;
    private GameObject _objCom;

    private bool _isClicked = false;
    private bool _useClothes = false;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    private AudioSource _audioSource;

    private PlayerAttention _pAttention;

    void Start()
    {
        _imgPJ = transform.Find("ImgPJ")?.gameObject;
        _imgRP = transform.Find("ImgRP")?.gameObject;
        _objIncom = transform.Find("Incomplete")?.gameObject;
        _objCom = transform.Find("Complete")?.gameObject;

        if (_imgPJ == null) Debug.LogWarning("ImgPJ no encontrado");
        if (_imgRP == null) Debug.LogWarning("ImgRP no encontrado");
        if (_objIncom == null) Debug.LogWarning("Incomplete no encontrado");
        if (_objCom == null) Debug.LogWarning("Complete no encontrado");

        if (CinematicStatus.TieneEstado(gameObject))
        {
            CinematicStatus.RestaurarEstado(gameObject);
            _isClicked = true;
        }

        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();

        /*if(SceneManager.GetActiveScene().name == "Night2.0")
        {
            if (_objIncom != null) _objIncom.SetActive(false);
            if (_objCom != null) _objCom.SetActive(true);
            _isClicked= true;
        }*/
        _audioSource = _objCom.GetComponent<AudioSource>();

        _pAttention = Object.FindFirstObjectByType<PlayerAttention>();
    }

    public void OnMouseDown()
    {
        if (_isClicked) return;

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (DecisionStatus.ActiveDecision()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        string scene = SceneManager.GetActiveScene().name;

        bool usePJ = ChecksStatus.IsCheckActive("Night2.0", 1); // verificamos si se cambio de ropa usando el check activo/inactivo
  
        if (scene == "Night2.0" && usePJ)
        {
            SceneManager.LoadScene("Cuestionario");// si se puso el pijama que active 
            return;
        }
         else if (!usePJ) _pAttention.AttentionNight(); // sino que le de una advertencia



        _useClothes = ChecksStatus.IsCheckActive("Morning2.0", 1);

        if (scene == "Morning2.0")
        {
            _isClicked = true;

            if (_useClothes && _imgRP != null) _imgRP.SetActive(true);
            else if (!_useClothes && _imgPJ != null) _imgPJ.SetActive(true);

            if (_objIncom != null) _objIncom.SetActive(false);
            if (_objCom != null) _objCom.SetActive(true);

            StartCoroutine(DelayImg(_useClothes));

        }


        if(_audioSource != null)_audioSource.Play();


    }

    private IEnumerator DelayImg(bool used)
    {
        _check?.Check1();

        yield return new WaitForSeconds(2f);

        if (used && _imgRP != null) _imgRP.SetActive(false);
        else if (!used && _imgPJ != null) _imgPJ.SetActive(false);

        if (_audioSource != null) _audioSource.Stop();

        CinematicStatus.GuardarEstado(gameObject);

        _kind?.GoodDecision();
    }
}
