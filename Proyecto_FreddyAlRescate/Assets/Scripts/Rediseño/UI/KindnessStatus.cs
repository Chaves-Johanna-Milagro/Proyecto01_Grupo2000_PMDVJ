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

    // Resetea la posición de la barra a su valor inicial
    public static void ResetKindness()
    {
        _nowBarY = -490f;
    }
}

