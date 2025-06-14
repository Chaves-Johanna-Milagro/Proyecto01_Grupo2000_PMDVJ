using System.Collections.Generic;
using UnityEngine;

public static class ChecksStatus
{
    // Guarda el estado de los checks para cada escena
    // Clave = nombre de la escena, Valor = array de 3 bools para los 3 checks
    private static Dictionary<string, bool[]> _sceneChecks = new Dictionary<string, bool[]>();

    // Obtiene el array de estados para una escena
    public static bool[] GetChecksForScene(string sceneName)
    {
        if (!_sceneChecks.ContainsKey(sceneName))
        {
            // Si no existe aún, la inicializa con todos los checks en false
            _sceneChecks[sceneName] = new bool[3];
        }

        return _sceneChecks[sceneName];
    }

    // Activa un check en una escena específica
    public static void SetCheckActive(string sceneName, int index)
    {
        if (index < 0 || index > 2) return;

        GetChecksForScene(sceneName)[index] = true;
    }

    // Devuelve la cantidad total de checks inactivos en todas las escenas
    public static int GetTotalInactiveChecks()
    {
        int total = 0;
        foreach (var kvp in _sceneChecks)
        {
            bool[] checks = kvp.Value;
            foreach (bool check in checks)
            {
                if (!check)
                    total++;
            }
        }
        return total;
    }
}
