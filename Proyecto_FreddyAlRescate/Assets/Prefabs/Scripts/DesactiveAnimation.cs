using UnityEngine;

public class DesactiveAnimation : MonoBehaviour
{
    private Collider2D _collider2D;
    private bool _isClick = false;
    
    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    public void OnMouseDown()
    {
        _isClick = true;

        if (_isClick )  _collider2D.enabled = false;

    }

    public void Update()
    {
        GameObject miniGame = GameObject.FindGameObjectWithTag("MiniGame");

        if ( miniGame != null && miniGame.activeInHierarchy) _collider2D.enabled = false;

        if( miniGame == null && _isClick == false) _collider2D.enabled = true;


        GameObject pause = GameObject.FindGameObjectWithTag("Pause");

        if (pause != null && pause.activeInHierarchy) _collider2D.enabled = false;

        if (miniGame == null && _isClick == false) _collider2D.enabled = true;
    }
}
