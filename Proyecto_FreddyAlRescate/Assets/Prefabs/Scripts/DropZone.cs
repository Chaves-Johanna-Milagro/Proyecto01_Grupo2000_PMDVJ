using UnityEngine;

public class DropZone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrastrable"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
