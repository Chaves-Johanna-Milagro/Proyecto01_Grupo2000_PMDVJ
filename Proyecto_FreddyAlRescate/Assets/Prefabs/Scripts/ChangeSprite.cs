using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public void OnMouseDown()
    {
        Transform accionInComplete = transform.GetChild(0);
        Transform accionComplete = transform.GetChild(1);

        accionInComplete.gameObject.SetActive(false);
        accionComplete.gameObject.SetActive(true);

    }
}
