using System.Collections.Generic;
using UnityEngine;

public static class DecisionStatus
{
    public static bool ActiveDecision()
    {
        GameObject[] decisions = GameObject.FindGameObjectsWithTag("Decision");

        foreach (GameObject decision in decisions)
        {
            if (decision.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
    }

    // Estado de un hijo (posición y si está activo)
    private class HijoEstado
    {
        public Vector3 pos;
        public bool activo;
    }

    // Guarda: escena -> desicion -> nombreHijo -> estado
    private static Dictionary<string, Dictionary<string, Dictionary<string, HijoEstado>>> _data =
        new Dictionary<string, Dictionary<string, Dictionary<string, HijoEstado>>>();

    // Guarda el estado de los hijos
    public static void GuardarEstado(string escena, string decision, Transform padre)
    {
        if (!_data.ContainsKey(escena))
            _data[escena] = new Dictionary<string, Dictionary<string, HijoEstado>>();

        var hijos = new Dictionary<string, HijoEstado>();

        foreach (Transform hijo in padre)
        {
            hijos[hijo.name] = new HijoEstado
            {
                pos = hijo.position,
                activo = hijo.gameObject.activeSelf
            };
        }

        _data[escena][decision] = hijos;
    }

    // Restaura el estado si existe
    public static void RestaurarEstado(string escena, string decision, Transform padre)
    {
        if (!_data.ContainsKey(escena) || !_data[escena].ContainsKey(decision)) return;

        var hijosGuardados = _data[escena][decision];

        foreach (Transform hijo in padre)
        {
            if (hijosGuardados.TryGetValue(hijo.name, out var estado))
            {
                hijo.position = estado.pos;
                hijo.gameObject.SetActive(estado.activo);
            }
        }
    }

    // Verifica si hay datos guardados
    public static bool TieneEstado(string escena, string decision)
    {
        return _data.ContainsKey(escena) && _data[escena].ContainsKey(decision);
    }
}
