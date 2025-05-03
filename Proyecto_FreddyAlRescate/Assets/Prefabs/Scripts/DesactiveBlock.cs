using UnityEngine;

public class DesactiveBlock : MonoBehaviour // para evitar que el jugador pase de largo sin haber entrado al negocio
{
    private Transform _block;
    
    void Start()
    {
        _block = transform.GetChild(0);
    }

    public void OnMouseDown()
    {
        if (_block != null) _block.gameObject.SetActive(false);
    }
}
