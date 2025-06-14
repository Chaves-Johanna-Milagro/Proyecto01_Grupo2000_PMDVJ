using UnityEngine;

public class StayZone : MonoBehaviour
{
    private float brushTimer = 0f;
    private float brushTimeRequired = 2f;

    private Transform _miniGame;

    private Transform _dirtyMouht;
    private Transform _cleanMouht;
    private void Start()
    {
        //mini juego es el padre de este obj Mouth
        _miniGame = transform.parent;

        _dirtyMouht = transform.GetChild(0);
        _cleanMouht = transform.GetChild(1);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Brush")
        {
            brushTimer += Time.deltaTime;

            _dirtyMouht.gameObject.SetActive(false);
            _cleanMouht.gameObject.SetActive(true);

            if (brushTimer >= brushTimeRequired)
            {
   
                _miniGame.gameObject.SetActive(false);

                NotesController.Instance.ActiveCheck3();
                NotesController.Instance.WinLevel();

            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Brush")
        {
            brushTimer = 0f; // reinicia si sale antes
        }
    }
}
