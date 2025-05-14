using UnityEngine;
using UnityEngine.EventSystems;

public static class CharacterBlockMoveUI
{
    // Devuelve true si el mouse est� sobre cualquier UI
    public static bool IsPointerOverUI()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }
}
