using System.Collections;
using UnityEngine;

public class CharacterBounceObstacle : MonoBehaviour
{
    private float _bounceDist = 1f;
    private float _bounceDuration = 0.2f;

    private CharacterClickMove _mover;

    void Awake()
    {
        _mover = GetComponent<CharacterClickMove>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Interactuable"))
        {
            Vector2 contacto = other.GetContact(0).point;
            Vector2 direccion = ((Vector2)transform.position - contacto).normalized;

            StartCoroutine(Bounce(direccion));
        }
    }

    private IEnumerator Bounce(Vector2 direccion)
    {
        Vector3 origen = transform.position;
        Vector3 destino = origen + (Vector3)(direccion * _bounceDist);

        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime / _bounceDuration;
            transform.position = Vector3.Lerp(origen, destino, t);
            yield return null;
        }
         _mover.StopMove();
    }
}
