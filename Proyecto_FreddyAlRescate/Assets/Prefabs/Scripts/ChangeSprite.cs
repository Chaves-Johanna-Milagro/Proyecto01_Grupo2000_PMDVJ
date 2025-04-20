using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
   
    public void OnMouseDown()
    {
        Transform accionInComplete = transform.GetChild(0);
        Transform accionComplete = transform.GetChild(1);

        accionInComplete.gameObject.SetActive(false);
        accionComplete.gameObject.SetActive(true);

        ActiveCheck();

       // Object.FindFirstObjectByType<MiniGameManager>().MiniGameCompleted(); // va sumando a la cantidad de minijuegos completados u obj interactuados
    }

    public void ActiveCheck()
    {
        string nameObj = gameObject.name;

        if (nameObj == "Bed" || nameObj == "Diningroom")
        {
            NotesController.Instance.ActiveCheck1();
        }
        else if (nameObj == "Cupboard" || nameObj == "Backpack")
        {
            NotesController.Instance.ActiveCheck2();
        }
        else if (nameObj == "Bathroom")
        {
            NotesController.Instance.ActiveCheck3();
        }
    }
}
