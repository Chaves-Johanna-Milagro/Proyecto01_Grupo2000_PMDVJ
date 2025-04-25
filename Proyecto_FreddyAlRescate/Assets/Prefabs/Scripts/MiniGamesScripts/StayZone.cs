using UnityEngine;

public class StayZone : MonoBehaviour
{
    private float brushTimer = 0f;
    private float brushTimeRequired = 2f;

    private Transform _miniGame;


    private void Start()
    {
        //mini juego es el padre de este obj Mouth
        _miniGame = transform.parent;

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Brush")
        {
            brushTimer += Time.deltaTime;

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
