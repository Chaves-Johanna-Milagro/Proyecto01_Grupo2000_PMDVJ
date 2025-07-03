using UnityEngine;

public class MGBackpackStart : MonoBehaviour
{
    private PlayerAttention _pAttention;
    void Start()
    {
        _pAttention = Object.FindFirstObjectByType<PlayerAttention>();
        _pAttention.AttentionBackpack(); // activa el cartel explicacion del mj mochila
    }

    void Update()
    {
        
    }
}
