using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMouth : MonoBehaviour
{

    private Transform _miniGame;

    private Transform _mouthClose;
    private Transform _mouthOpen;
    private Transform _mouthChewing;

    private int _count = 0;

    private HashSet<Collider2D> _detectedObjects = new HashSet<Collider2D>(); // es como una lista de colliders

    private void Start()
    {
        _miniGame = transform.parent;

        _mouthClose = transform.GetChild(0);
        _mouthOpen = transform.GetChild(1);
        _mouthChewing = transform.GetChild(2);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!_detectedObjects.Add(other)) return; // solo si es nuevo

        _count++;

        if (_count < 3 && IsFood(other))  StartCoroutine(AnimateChewing(other));
          

        else if (_count == 3 && other.name == "Napkin")  StartCoroutine(FinishMiniGame());
 
    }

    private bool IsFood(Collider2D obj)
    {
        return obj.name == "Cup" || obj.name == "Bread";
    }

    private IEnumerator AnimateChewing(Collider2D obj)
    {
        SetMouth(open: true);

        yield return new WaitForSeconds(1);

        obj.gameObject.SetActive(false);

        SetMouth(chewing: true);
    }

    private IEnumerator FinishMiniGame()
    {
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
