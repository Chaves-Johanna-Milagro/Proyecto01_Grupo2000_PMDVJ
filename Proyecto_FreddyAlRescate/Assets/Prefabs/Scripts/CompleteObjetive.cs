using UnityEngine;

public class CompleteObjetive : MonoBehaviour // lo tendran los objetos que al hacer click marque el check en la libreta
{
    public void OnMouseDown() // aqui se podria utilizar el tag para determinar que check activar
    {
        LibretaController.Instance.ActiveCheck1();
    }
}
