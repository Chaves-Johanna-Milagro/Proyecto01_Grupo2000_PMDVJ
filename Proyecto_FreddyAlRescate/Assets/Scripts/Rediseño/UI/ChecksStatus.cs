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

    // Devuelve todos los índices de checks activos en una escena específica
    public static List<int> GetActiveChecksForScene(string sceneName)
    {
        List<int> activeIndexes = new List<int>();
        bool[] checks = GetChecksForScene(sceneName);
        for (int i = 0; i < checks.Length; i++)
        {
            if (checks[i])
                activeIndexes.Add(i);
        }
        return activeIndexes;
    }

    // Verifica si un check específico está activo
    public static bool IsCheckActive(string sceneName, int index)
    {
        if (index < 0 || index > 2)
            return false;

        bool[] checks = GetChecksForScene(sceneName);
        return checks[index];
    }

    // Consume el check si está activo 
    public static bool ConsumeCheckIfActive(string sceneName, int index)
    {
        if (index < 0 || index > 2)
            return false;

        bool[] checks = GetChecksForScene(sceneName);
        if (checks[index])
        {
            checks[index] = false; // Lo consume (lo desactiva)
            return true;
        }
        return false;
    }

    // Devuelve la cantidad de checks activos en una escena específica
    public static int GetActiveChecksCountForScene(string sceneName)
    {
        int count = 0;
        bool[] checks = GetChecksForScene(sceneName);
        foreach (bool check in checks)
        {
            if (check)
                count++;
        }
        return count;
    }

    // Resetea todos los checks de todas las escenas
    public static void ResetAllChecks()
    {
        _sceneChecks.Clear();
    }
}
