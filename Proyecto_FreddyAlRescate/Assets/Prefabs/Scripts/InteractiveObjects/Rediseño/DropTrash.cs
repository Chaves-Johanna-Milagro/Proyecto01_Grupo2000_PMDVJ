using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class DropTrash : MonoBehaviour
{
    private BKindnessUpDown _Kind;

    private void Start()
    {
        _Kind = Object.FindFirstObjectByType<BKindnessUpDown>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (PauseStatus.IsPaused) return;

        if (CursorStatusInUI.IsPointerOverUI()) return;

        if (MiniGameStatus.ActiveMiniGame()) return; // si esta un mini juego no procese el click

        if (CinematicStatus.ActiveCinematic()) return; // si hay alguna cinematica corriendo

        if (DecisionStatus.ActiveDecision()) return; // si hay alguna desicion corriendo

        if (collision.CompareTag("Player")) return;//ignore si colisiona con el player

        if (collision.gameObject.name == "Trash1" || collision.gameObject.name == "Trash2" || collision.gameObject.name == "Trash3")
        {
            collision.gameObject.SetActive(false);
            _Kind.MiniGoodDecision();
        }
    }
}
