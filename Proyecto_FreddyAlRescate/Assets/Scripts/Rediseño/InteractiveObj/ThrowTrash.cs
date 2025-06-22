using UnityEngine;

public class ThrowTrash : MonoBehaviour //lo tiene el objeto padre de la basura de la escuela
{
    private GameObject[] _childs;
    private int _count;

    void Start()
    {
        _count = transform.childCount;
        _childs = new GameObject[_count];

        for (int i = 0; i < _count; i++) //obtener los hijos al inicio
        {
            _childs[i] = transform.GetChild(i).gameObject;
        }

        if (CinematicStatus.TieneEstado(gameObject))
        {
            CinematicStatus.RestaurarEstado(gameObject);
        }
    }

    void Update()
    {
        CinematicStatus.GuardarEstado(gameObject);
    }
}
