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
        public Vector3 pos;
        public bool activo;
    }

    // Guarda: escena -> objeto -> nombreHijo -> estado
    private static Dictionary<string, Dictionary<string, Dictionary<string, HijoEstado>>> _data =
        new Dictionary<string, Dictionary<string, Dictionary<string, HijoEstado>>>();

    // Guarda el estado de los hijos del objeto que llama
    public static void GuardarEstado(GameObject objeto)
    {
        string escena = SceneManager.GetActiveScene().name;
        string nombreObjeto = objeto.name;

        if (!_data.ContainsKey(escena))
            _data[escena] = new Dictionary<string, Dictionary<string, HijoEstado>>();

        var hijos = new Dictionary<string, HijoEstado>();

        foreach (Transform hijo in objeto.transform)
        {
            hijos[hijo.name] = new HijoEstado
            {
                pos = hijo.position,
                activo = hijo.gameObject.activeSelf
            };
        }

        _data[escena][nombreObjeto] = hijos;
    }

    // Restaura el estado de los hijos del objeto que llama
    public static void RestaurarEstado(GameObject objeto)
    {
        string escena = SceneManager.GetActiveScene().name;
        string nombreObjeto = objeto.name;

        if (!_data.ContainsKey(escena) || !_data[escena].ContainsKey(nombreObjeto)) return;

        var hijosGuardados = _data[escena][nombreObjeto];

        foreach (Transform hijo in objeto.transform)
        {
            if (hijosGuardados.TryGetValue(hijo.name, out var estado))
            {
                hijo.position = estado.pos;
                hijo.gameObject.SetActive(estado.activo);
            }
        }
    }

    // Verifica si hay datos guardados para este objeto
    public static bool TieneEstado(GameObject objeto)
    {
        string escena = SceneManager.GetActiveScene().name;
        string nombreObjeto = objeto.name;

        return _data.ContainsKey(escena) && _data[escena].ContainsKey(nombreObjeto);
    }

}
