using UnityEngine;

public class DropZone : MonoBehaviour
{
    private int totalToReceive = 0; //la cantidad de objetos
    private int receivedCount = 0;

    private Transform miniGame;


    void Start()
    {
        // miniGame es el padre de este objeto (MiniGameBackpack/Moth)
        miniGame = transform.parent;

        // Contar cuántos hermanos (menos este mismo) tienen el tag "Arrastrable"
        foreach (Transform child in miniGame)
        {
            if (child != transform && child.CompareTag("Arrastrable"))
            {
                totalToReceive++;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrastrable"))
        {
            other.gameObject.SetActive(false);

            receivedCount++;

            if (receivedCount >= totalToReceive)
            {
                miniGame.gameObject.SetActive(false);

                //Object.FindFirstObjectByType<MiniGameManager>().MiniGameCompleted(); // va sumando a la cantidad de minijuegos completados

            }
        }
    }
}
