using UnityEngine;

public static class LevelGameStatus //pa saber que nivel se escogio
{
    private static string _level;
    public static void SetLevel(string level)
    {
       _level = level;
    }
    public static string GetLevel () => _level;

    public static string ClearLevel () => _level = "";
}


