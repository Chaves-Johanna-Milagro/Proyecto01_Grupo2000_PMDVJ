using System.Collections.Generic;
using UnityEngine;

public static class MiniGameStatus
{
    public static bool ActiveMiniGame()
    {
        GameObject[] miniGames = GameObject.FindGameObjectsWithTag("MiniGame");

        foreach (GameObject mg in miniGames)
        {
            if (mg.activeInHierarchy)
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

    // Guarda: escena -> minijuego -> nombreHijo -> estado
    private static Dictionary<string, Dictionary<string, Dictionary<string, HijoEstado>>> _data =
        new Dictionary<string, Dictionary<string, Dictionary<string, HijoEstado>>>();

    // Guarda el estado de los hijos
    public static void GuardarEstado(string escena, string miniJuego, Transform padre)
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

        _data[escena][miniJuego] = hijos;
    }

    // Restaura el estado si existe
    public static void RestaurarEstado(string escena, string miniJuego, Transform padre)
    {
        if (!_data.ContainsKey(escena) || !_data[escena].ContainsKey(miniJuego)) return;

        var hijosGuardados = _data[escena][miniJuego];

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
    public static bool TieneEstado(string escena, string miniJuego)
    {
        return _data.ContainsKey(escena) && _data[escena].ContainsKey(miniJuego);
    }
}
