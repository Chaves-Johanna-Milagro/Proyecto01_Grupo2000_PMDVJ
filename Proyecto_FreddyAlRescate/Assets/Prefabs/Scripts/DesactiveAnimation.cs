using UnityEngine;

public class DesactiveAnimation : MonoBehaviour
{
 
    public void OnMouseDown()
    {
        Collider2D collider2D = GetComponent<Collider2D>();

        collider2D .enabled = false;
    }
}
