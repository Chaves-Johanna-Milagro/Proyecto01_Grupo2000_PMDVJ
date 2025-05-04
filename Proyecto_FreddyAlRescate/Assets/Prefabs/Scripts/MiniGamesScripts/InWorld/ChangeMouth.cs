using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMouth : MonoBehaviour
{

    private Transform _miniGame;

    private Transform _mouthClose;
    private Transform _mouthOpen;
    private Transform _mouthChewing;

    private int _foodCount = 0;
    private bool _isChewing = false;
    private bool _napkinUsed = false;

    private HashSet<Collider2D> _processedFood = new HashSet<Collider2D>();
    private bool _gameFinished = false;

    private void Start()
    {
        _miniGame = transform.parent;

        _mouthClose = transform.GetChild(0);
        _mouthOpen = transform.GetChild(1);
        _mouthChewing = transform.GetChild(2);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (_gameFinished) return;

        if (IsFood(other) && !_isChewing && !_processedFood.Contains(other) && _foodCount < 2)
        {
            StartCoroutine(AnimateChewing(other));
        }
        else if (other.name == "Napkin" && _foodCount >= 2 && !_napkinUsed)
        {
            _napkinUsed = true;
            StartCoroutine(FinishMiniGame());
        }
    }

    private bool IsFood(Collider2D obj)
    {
        return obj.name == "Cup" || obj.name == "Bread";
    }

    private IEnumerator AnimateChewing(Collider2D obj)
    {
        _isChewing = true;

        SetMouth(open: true);
        yield return new WaitForSeconds(1);

        obj.gameObject.SetActive(false);
        _processedFood.Add(obj);  // Ahora sí lo agregamos porque ya fue procesado

        SetMouth(chewing: true);
        yield return new WaitForSeconds(1);

        SetMouth(closed: true);
        _foodCount++;
        _isChewing = false;
    }

    private IEnumerator FinishMiniGame()
    {
        _gameFinished = true;

        SetMouth(chewing: true);
        yield return new WaitForSeconds(1);

        _miniGame.gameObject.SetActive(false);
        NotesController.Instance.ActiveCheck1();
        NotesController.Instance.WinLevel();
    }

    private void SetMouth(bool closed = false, bool open = false, bool chewing = false)
    {
        _mouthClose.gameObject.SetActive(closed);
        _mouthOpen.gameObject.SetActive(open);
        _mouthChewing.gameObject.SetActive(chewing);
    }
}
