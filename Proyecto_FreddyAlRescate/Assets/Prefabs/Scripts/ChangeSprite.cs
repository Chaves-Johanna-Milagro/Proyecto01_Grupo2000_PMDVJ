using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public void OnMouseDown()
    {
        Transform accionInComplete = transform.GetChild(0);
        Transform accionComplete = transform.GetChild(1);

        accionInComplete.gameObject.SetActive(false);
        accionComplete.gameObject.SetActive(true);

       // Object.FindFirstObjectByType<MiniGameManager>().MiniGameCompleted(); // va sumando a la cantidad de minijuegos completados u obj interactuados
    }
}
