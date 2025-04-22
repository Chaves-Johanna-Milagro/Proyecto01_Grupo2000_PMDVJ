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
        if (_detectedObjects.Contains(other)) return; //retorna si es que el other es un objeto que ya colisiono


        _detectedObjects.Add(other);
        _count++;

        if (_count < 3 && (other.name == "Cup" || other.name == "Bread")) StartCoroutine(ChangeSpriteMouth(other));
                

        if (_count == 3 && other.name == "Napkin") StartCoroutine(LastObject());
                

    }
    private IEnumerator ChangeSpriteMouth(Collider2D collider)
    {
        _mouthChewing.gameObject.SetActive(false);
        _mouthClose.gameObject.SetActive(false);

        _mouthOpen.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        _mouthOpen.gameObject.SetActive(false);

        collider.gameObject.SetActive(false);

        _mouthChewing.gameObject.SetActive(true);
    }

    private IEnumerator LastObject()
    {
        _mouthOpen.gameObject.SetActive(false);
        _mouthChewing.gameObject.SetActive(true);

        yield return new WaitForSeconds(1);

        _miniGame.gameObject.SetActive(false);

        NotesController.Instance.WinLevel();
    }
}
