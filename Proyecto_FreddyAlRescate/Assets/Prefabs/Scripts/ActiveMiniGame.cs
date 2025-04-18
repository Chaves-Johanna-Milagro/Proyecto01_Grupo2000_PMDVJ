using UnityEngine;

public class ActiveMiniGame : MonoBehaviour
{

    public void OnMouseDown()
    {
        Transform _miniGame = transform.Find("MiniGame"); // lo buscara por el nombre
        _miniGame.gameObject.SetActive(true);
    }
}
