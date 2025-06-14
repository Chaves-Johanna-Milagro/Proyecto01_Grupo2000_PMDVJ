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
            // Si no existe a�n, la inicializa con todos los checks en false
            _sceneChecks[sceneName] = new bool[3];
        }

        return _sceneChecks[sceneName];
    }

    // Activa un check en una escena espec�fica
    public static void SetCheckActive(string sceneName, int index)
    {
        if (index < 0 || index > 2) return;

        GetChecksForScene(sceneName)[index] = true;
    }
}
