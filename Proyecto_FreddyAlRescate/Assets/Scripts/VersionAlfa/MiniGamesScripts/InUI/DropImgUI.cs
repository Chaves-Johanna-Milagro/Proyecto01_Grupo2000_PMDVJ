using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropImgUI : MonoBehaviour, IDropHandler
{
  private Vector3 _offset = new Vector3(0f, 40f, 0f);
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dragged = eventData.pointerDrag;

        if (dragged != null)
        {
            RectTransform draggedRT = dragged.GetComponent<RectTransform>();

            if (draggedRT.name == "Sanwi")
            {
                draggedRT.position = GetComponent<RectTransform>().position + _offset;

            } else {

                draggedRT.position = GetComponent<RectTransform>().position; //pa que el obj arrastrable se quede en la pos del drop
            }

            StartCoroutine(delay());
        }
    }

    private IEnumerator delay() 
    {
        yield return new WaitForSeconds(1f);

        Transform parent = transform.parent; // para activar el minijuego de matematica una vez la comida este en el mostrador

        Transform MiniGame = parent.Find("ChoiceOptCorrect");

        MiniGame.gameObject.SetActive(true);
    }
}
