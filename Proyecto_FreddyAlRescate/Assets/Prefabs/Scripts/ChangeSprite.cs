using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public void OnMouseDown()
    {
        Transform accionComplete = transform.GetChild(0);

        accionComplete.gameObject.SetActive(false);

        Object.FindFirstObjectByType<MiniGameManager>().MiniGameCompleted(); // va sumando a la cantidad de minijuegos completados u obj interactuados
    }
}
