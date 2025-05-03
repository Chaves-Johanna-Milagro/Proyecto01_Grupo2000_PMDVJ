using System.Globalization;
using UnityEngine;

public class ActiveIndications : MonoBehaviour
{
    private FriendCharacterButton _friendButton;

    private string _nameBlock;

    private void Start()
    {
        _friendButton = Object.FindFirstObjectByType<FriendCharacterButton>();

        _nameBlock = gameObject.name;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && _friendButton != null)
        {
            _friendButton.IndicationsForThePlayer(_nameBlock);

        }
    }
}
