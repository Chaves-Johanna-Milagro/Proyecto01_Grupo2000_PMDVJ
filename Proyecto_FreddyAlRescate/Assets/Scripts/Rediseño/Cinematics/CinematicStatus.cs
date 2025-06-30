using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CinematicStatus //para aquellos obj que muetren alguna cinematica/imagen
{
    public static bool ActiveCinematic()
    {
        GameObject[] cinematics = GameObject.FindGameObjectsWithTag("Cinematic");

        foreach (GameObject cinematic in cinematics)
        {
            if (cinematic.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
    }

    private class HijoEstado
    {
        public Vector3 posicion;
        public bool activo;
    }

    // Guarda: escena -> objeto -> lista de estados de hijos (por índice)
    private static Dictionary<string, Dictionary<string, List<HijoEstado>>> _data =
        new Dictionary<string, Dictionary<string, List<HijoEstado>>>();

    // Guarda el estado de los hijos del objeto dado
    public static void GuardarEstado(GameObject objeto)
    {
        string escena = SceneManager.GetActiveScene().name;
        string nombreObjeto = objeto.name;

        if (!_data.ContainsKey(escena))
            _data[escena] = new Dictionary<string, List<HijoEstado>>();

        var hijos = new List<HijoEstado>();

        for (int i = 0; i < objeto.transform.childCount; i++)
        {
            Transform hijo = objeto.transform.GetChild(i);
            hijos.Add(new HijoEstado
            {
                posicion = hijo.position,
                activo = hijo.gameObject.activeSelf
            });
        }

        _data[escena][nombreObjeto] = hijos;
    }

    // Restaura el estado de los hijos del objeto dado
    public static void RestaurarEstado(GameObject objeto)
    {
        string escena = SceneManager.GetActiveScene().name;
        string nombreObjeto = objeto.name;

        if (!_data.ContainsKey(escena) || !_data[escena].ContainsKey(nombreObjeto))
        {
            Debug.LogWarning($"[CinematicStatus] No hay estado guardado para {nombreObjeto} en escena {escena}");
            return;
        }

        var hijosGuardados = _data[escena][nombreObjeto];

        for (int i = 0; i < Mathf.Min(hijosGuardados.Count, objeto.transform.childCount); i++)
        {
            Transform hijo = objeto.transform.GetChild(i);
            HijoEstado estado = hijosGuardados[i];

            hijo.position = estado.posicion;
            hijo.gameObject.SetActive(estado.activo);
        }
    }

    // Verifica si hay datos guardados para ese objeto
    public static bool TieneEstado(GameObject objeto)
    {
        string escena = SceneManager.GetActiveScene().name;
        string nombreObjeto = objeto.name;

        return _data.ContainsKey(escena) && _data[escena].ContainsKey(nombreObjeto);
    }

    // Resetea todos los estados guardados de todas las escenas
    public static void ResetCinematicStatus()
    {
        _data.Clear();
    }
}
