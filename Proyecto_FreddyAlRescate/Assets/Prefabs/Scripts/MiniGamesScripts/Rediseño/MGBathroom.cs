using UnityEngine;

public class MGBathroom : MonoBehaviour
{
    private Collider2D _col;
    private GameObject _miniGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _miniGame = transform.GetChild(0).gameObject;

        _miniGame.SetActive(false); //desactivar al inicio

        _col = GetComponent<Collider2D>();
    }

    public void OnMouseDown()
    {
        _miniGame?.SetActive(true);

        _col.enabled = false;
    }
}
