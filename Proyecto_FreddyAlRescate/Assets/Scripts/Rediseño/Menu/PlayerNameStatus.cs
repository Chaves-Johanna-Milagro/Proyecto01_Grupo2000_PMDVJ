using UnityEngine;

public static class PlayerNameStatus //para que el jugador se ponga su nombre
{
    private static string _namePlayer;

    public static void SetPlayerName(string name)
    {
        _namePlayer = name; 
    }

    public static string GetplayerName()
    {
        return _namePlayer;
    }
}
