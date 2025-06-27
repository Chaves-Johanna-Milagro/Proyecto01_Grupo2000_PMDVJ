using UnityEngine;
using System.Collections;

public class HangBackpack : MonoBehaviour
{
    private GameObject _img;
    
    private GameObject _objIncom;
    private GameObject _objCom;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    private bool _isClicked = false;
    void Start()
    {
        _img = transform.Find("Img")?.gameObject;

        _objIncom = transform.Find("Incomplete")?.gameObject;
        _objCom = transform.Find("Complete")?.gameObject;


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


        if (_img != null) _img.SetActive(true);

        if (_objIncom != null) _objIncom.SetActive(false);
        if (_objCom != null) _objCom.SetActive(true);

        StartCoroutine(DelayImg());
    }

    private IEnumerator DelayImg()
    {

        yield return new WaitForSeconds(2f);

         _img.SetActive(false);

        CinematicStatus.GuardarEstado(gameObject);

        _kind?.GoodDecision();

        RecessStatus.HangBackpack = true; //pa que la animacion ya este sin la mochi
    }
}
