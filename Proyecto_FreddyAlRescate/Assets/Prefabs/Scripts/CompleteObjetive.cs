using UnityEngine;

public class CompleteObjetive : MonoBehaviour // lo tendran los objetos que al hacer click marque el check en la libreta
{
    public void OnMouseDown() // a que check activar
    {
        string nameObj = gameObject.name;


        //para los del nvl 1
        if (nameObj == "Bed")
        {
            NotesController.Instance.ActiveCheck1();
            NotesController.Instance.WinLevel();  
        }
        else if (nameObj == "Cupboard")
        {
            NotesController.Instance.ActiveCheck2();
            NotesController.Instance.WinLevel();
        }
        else if (nameObj == "Bathroom") // los que tengan mini juego seran controlados por el script DropZone
        {
            NotesController.Instance.ActiveCheck3();
        }


        //para los del nvl 2
        if (nameObj == "Diningroom")
        {
            NotesController.Instance.ActiveCheck1();
        }
        else if(nameObj == "Backpack")
        {
            NotesController.Instance.ActiveCheck2();
        }
    }
}
