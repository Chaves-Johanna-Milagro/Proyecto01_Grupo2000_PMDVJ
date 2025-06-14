using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform _player;
    private SpriteRenderer _map; //para obtener el tam del mapa y determinar los limites

    private Camera _cam;
    private Vector2 _min, _max;

    private float _speed = 5f;

    private void Start()
    {
        _cam = Camera.main;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _map = GameObject.FindGameObjectWithTag("Map").GetComponent<SpriteRenderer>();

        SetLimits();
    }

    private void LateUpdate()
    {
        if (_player == null) return;

        Vector3 target = new Vector3(_player.position.x, _player.position.y, transform.position.z);

        // Limitar dentro del fondo
        target.x = Mathf.Clamp(target.x, _min.x, _max.x);
        target.y = Mathf.Clamp(target.y, _min.y, _max.y);

        // Movimiento suave
        transform.position = Vector3.Lerp(transform.position, target, _speed * Time.deltaTime);
    }

    private void SetLimits()
    {
        float h = _cam.orthographicSize * 2f;
        float w = h * _cam.aspect;
        Bounds b = _map.bounds; //vendrian siendo los limites

        _min = new Vector2(b.min.x + w / 2f, b.min.y + h / 2f);
        _max = new Vector2(b.max.x - w / 2f, b.max.y - h / 2f);
    }
}
