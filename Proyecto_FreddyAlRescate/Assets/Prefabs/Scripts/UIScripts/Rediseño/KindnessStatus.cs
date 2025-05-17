using UnityEngine;

public static class KindnessStatus
{
    private static float _nowBarY = -490f; // valor inicial (centro)

    public static float GetNowBarY()
    {
        return _nowBarY;
    }

    public static void SetNowBarY(float y)
    {
        _nowBarY = y;
    }
}

