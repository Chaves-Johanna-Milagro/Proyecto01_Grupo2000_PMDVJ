using System.Collections.Generic;
using UnityEngine;

public static class DropItemStatus // para que los objetos de algunos minijuegos se queden donde esten
{
    public static HashSet<string> ObjetosColocados = new HashSet<string>();

    private static Dictionary<string, int> dropsPorMinijuego = new Dictionary<string, int>();

    public static void SumarDrop(string nombreMG)
    {
        if (!dropsPorMinijuego.ContainsKey(nombreMG))
            dropsPorMinijuego[nombreMG] = 0;

        dropsPorMinijuego[nombreMG]++;
    }

    public static int GetDrops(string nombreMG)
    {
        if (!dropsPorMinijuego.ContainsKey(nombreMG))
            return 0;

        return dropsPorMinijuego[nombreMG];
    }

    public static void ResetearDrops(string nombreMG)
    {
        if (dropsPorMinijuego.ContainsKey(nombreMG))
            dropsPorMinijuego[nombreMG] = 0;
    }
}
