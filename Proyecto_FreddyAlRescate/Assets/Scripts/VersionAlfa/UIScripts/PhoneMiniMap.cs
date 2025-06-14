using UnityEngine;

public class PhoneMiniMap : MonoBehaviour
{
    private RectTransform _miniPlayer;
    private Transform _player;
    private SpriteRenderer _mapRenderer;

    private RectTransform _panelRect;
    private Vector2 _worldMin;
    private Vector2 _worldMax;

    private Vector2 _offset = new Vector2(300f, 400f);
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;
        _mapRenderer = GameObject.FindGameObjectWithTag("Map")?.GetComponent<SpriteRenderer>(); // busca el mapa

        // MiniPlayer es hijo directo de este GameObject (Phone)
        _miniPlayer = transform.Find("MiniPlayer")?.GetComponent<RectTransform>();
        _panelRect = GetComponent<RectTransform>();

        if (_player == null || _mapRenderer == null || _miniPlayer == null || _panelRect == null)
        {
            Debug.LogError("no se encontro (Player, Map o MiniPlayer)");
            enabled = false;
            return;
        }

        // Usamos los límites del mapa
        Bounds bounds = _mapRenderer.bounds;
        _worldMin = bounds.min;
        _worldMax = bounds.max;
    }

    void Update()
    {
        if (!gameObject.activeInHierarchy || _player == null) return;

        Vector2 playerPos = _player.position;

        float normX = Mathf.InverseLerp(_worldMin.x, _worldMax.x, playerPos.x);
        float normY = Mathf.InverseLerp(_worldMin.y, _worldMax.y, playerPos.y);

        float width = _panelRect.rect.width;
        float height = _panelRect.rect.height;

        float localX = normX * width;
        float localY = normY * height;

        _miniPlayer.anchoredPosition = new Vector2(localX - _offset.x, localY - _offset.y);
    }
}

