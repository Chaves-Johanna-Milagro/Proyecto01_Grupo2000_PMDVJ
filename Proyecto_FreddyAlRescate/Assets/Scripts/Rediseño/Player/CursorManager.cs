using UnityEngine;

public class CursorManager : MonoBehaviour // el script lo tiene el miniMenu
{
    [SerializeField] private Texture2D _cDefault; //textura de cursor por defecto
    [SerializeField] private Texture2D _cSelect; //textura de cursor al pasar por objetos interactyuables
    [SerializeField] private Texture2D _cDrag; //textura de cursor para cuando arrastre obj
    [SerializeField] private Texture2D _cDrop; //textura de cursor para cuando suelte obj

    private Vector3 _hospost = Vector3.zero; //pos centrada

    private void Start()
    {
        SetCursorDefault(); //setear el cursor al principio
    }
    public void SetCursorDefault()
    {
        Cursor.SetCursor(_cDefault, _hospost, CursorMode.Auto);
    }
    public void SetCursorSelect()
    {
        Cursor.SetCursor(_cSelect, _hospost, CursorMode.Auto);
    }
    public void SetCursorDrag()
    {
        Cursor.SetCursor(_cDrag, _hospost, CursorMode.Auto);
    }
    public void SetCursorDrop()
    {
        Cursor.SetCursor(_cDrop, _hospost, CursorMode.Auto);
    }
} 

