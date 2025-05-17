using System;
using UnityEngine;

public static class PauseStatus
{
    private static bool _isPaused = false;

    public static bool IsPaused => _isPaused;

    public static void SetPaused(bool pause)
    {
        _isPaused = pause;
        Time.timeScale = pause ? 0f : 1f;
    }
}
