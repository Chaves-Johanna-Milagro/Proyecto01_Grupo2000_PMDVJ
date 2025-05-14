using UnityEngine;

public static class MiniGameStatus
{
    public static bool ActiveMiniGame()
    {
        GameObject _mg = GameObject.FindGameObjectWithTag("MiniGame");

        return (_mg != null && _mg.activeInHierarchy);
    }
}
