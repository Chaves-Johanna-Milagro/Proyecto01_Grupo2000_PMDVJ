using UnityEngine;

public static class MGLevelMathStatus //pa saber que nivel se escogio
{
    private static string _levelmath;
    public static void SetLevelMath(string level)
    {
       /* if (level == "Facil")
        {
            _levelmath = "Facil";
        }*/
       _levelmath = level;
    }
    public static string GetLevelMath () => _levelmath;

    public static string ClearLevelMath () => _levelmath = "";
}


