using UnityEngine;

public class ActiveMiniGame : MonoBehaviour
{
    private bool hasBeenClicked = false;  //servira para que solo pueda hacer click unavez

    public void OnMouseDown()
    {
        if (hasBeenClicked) return;

        hasBeenClicked = true;

        Transform _miniGame = transform.Find("MiniGame"); // lo buscara por el nombre
        _miniGame.gameObject.SetActive(true);
    }
}
