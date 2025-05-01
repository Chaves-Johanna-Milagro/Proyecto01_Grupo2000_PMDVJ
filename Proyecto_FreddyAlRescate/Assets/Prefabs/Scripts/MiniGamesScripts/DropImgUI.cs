using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropImgUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragged = eventData.pointerDrag;

        if (dragged != null)
        {
            RectTransform draggedRT = dragged.GetComponent<RectTransform>();
            draggedRT.position = GetComponent<RectTransform>().position; //pa que el obj arrastrable se quede en la pos del drop

            StartCoroutine(delay());
        }
    }

    private IEnumerator delay() 
    {
        yield return new WaitForSeconds(1f);

        Transform parent = transform.parent; // para activar el minijuego de matematica una vez la comida este en el mostrador

        Transform MiniGame = parent.GetChild(2);

        MiniGame.gameObject.SetActive(true);
    }
}
