using UnityEngine;

public class CharacterPointMove : MonoBehaviour
{
    private CharacterClickMove _mover;

    void Awake()
    {
        _mover = GetComponent<CharacterClickMove>();
    }

    void Update()
    {
        if (MovimientoDesactivado()) return;

        if (Input.GetMouseButtonDown(0) && !(ClicEnInteractuable() || CharacterBlockMoveUI.IsPointerOverUI())) //para que no se mueva si clickeo en un obj interactuable o en la UI
        {
            // Convertir la posición del mouse a coordenadas del mundo
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = -0.1f; // Asegura que se quede en el plano 2D

            // Enviar esa posición al script de movimiento
            _mover.SetTarget(target);
        }
    }

    // Verifica si el clic fue sobre un objeto con tag "Interactuable"
    private bool ClicEnInteractuable()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        return hit.collider != null && hit.collider.CompareTag("Interactuable");
    }

    // Verifica si hay algo que impida moverse (pausa, decisiones, minijuegos)
    private bool MovimientoDesactivado()
    {
        return GameObject.FindGameObjectWithTag("Pause") != null ||
               GameObject.FindGameObjectWithTag("Decision") != null ||
               GameObject.FindGameObjectWithTag("MiniGame") != null;
    }
}
