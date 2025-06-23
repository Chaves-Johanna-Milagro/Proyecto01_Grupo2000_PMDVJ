using UnityEngine;
using System.Collections;

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
    }

    public void OnMouseDown()
    {
        if (_isClicked) return;

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (DecisionStatus.ActiveDecision()) return;

        if (CinematicStatus.ActiveCinematic()) return;

        _isClicked = true;

        _useClothes = ChecksStatus.IsCheckActive("Morning2.0", 1);

        if (_useClothes && _imgRP != null) _imgRP.SetActive(true);
        else if (!_useClothes && _imgPJ != null) _imgPJ.SetActive(true);

        if (_objIncom != null) _objIncom.SetActive(false);
        if (_objCom != null) _objCom.SetActive(true);

        StartCoroutine(DelayImg(_useClothes));
    }

    private IEnumerator DelayImg(bool used)
    {
        _check?.Check1();

        yield return new WaitForSeconds(2f);

        if (used && _imgRP != null) _imgRP.SetActive(false);
        else if (!used && _imgPJ != null) _imgPJ.SetActive(false);

        CinematicStatus.GuardarEstado(gameObject);

        _kind?.GoodDecision();
    }
}
