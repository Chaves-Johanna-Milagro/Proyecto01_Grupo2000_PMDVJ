using UnityEngine;
using System.Collections;

public class ChangeSprite2_0 : MonoBehaviour
{
    private GameObject _img;
    private GameObject _objIncom;
    private GameObject _objCom;

    private bool _isClicked = false;

    private BNotesChecks _check;
    private BKindnessUpDown _kind;

    void Start()
    {
        _img = transform.Find("Img").gameObject;
        _objIncom = transform.Find("Incomplete").gameObject;
        _objCom = transform.Find("Complete").gameObject;

        if (CinematicStatus.TieneEstado(gameObject))
        {
            CinematicStatus.RestaurarEstado(gameObject);
            _isClicked = true; // Ya se había hecho clic antes
        }
        else
        {
            CinematicStatus.GuardarEstado(gameObject);
        }

        _check = Object.FindFirstObjectByType<BNotesChecks>();
        _kind = Object.FindFirstObjectByType<BKindnessUpDown>();
    }

    public void OnMouseDown()
    {
        if (_isClicked) return;

        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return; // si el cursor esta sobre la ui

        if (MiniGameStatus.ActiveMiniGame()) return;

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo


        _isClicked = true;

        _img.SetActive(true);
        _objIncom.SetActive(false);
        _objCom.SetActive(true);

        StartCoroutine(DelayImg());
    }

    private IEnumerator DelayImg()
    {
        yield return new WaitForSeconds(2f);
        _img.SetActive(false);

        // Guardamos el estado final de los hijos
        CinematicStatus.GuardarEstado(gameObject);

        _check.Check1();
        _kind.GoodDecision();
    }
}
