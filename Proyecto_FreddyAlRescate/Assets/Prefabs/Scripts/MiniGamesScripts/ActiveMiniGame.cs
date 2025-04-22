using UnityEngine;

public class ActiveMiniGame : MonoBehaviour
{
    private bool _hasBeenClicked = false;  //servira para que solo pueda hacer click unavez

    public void OnMouseDown()
    {
        if (_hasBeenClicked) return;

        _hasBeenClicked = true;

        Transform _miniGame = transform.Find("MiniGame"); // lo buscara por el nombre
        _miniGame.gameObject.SetActive(true);
    }
}
