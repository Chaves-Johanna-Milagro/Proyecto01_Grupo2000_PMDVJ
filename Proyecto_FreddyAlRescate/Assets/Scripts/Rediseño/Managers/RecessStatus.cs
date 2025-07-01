using UnityEngine;

public static class RecessStatus
{
    public static bool AlreadyWentToRecess = false;

    public static bool HangBackpack = false; //para determinar si la animacion seguira con michila op sin ella

    // Resetea el estado del recreo y mochila
    public static void ResetRecessStatus()
    {
        AlreadyWentToRecess = false;
        HangBackpack = false;
    }
}
