using UnityEngine;

public class MGBathroomStart : MonoBehaviour
{
    private PlayerAttention _pAttention;
    void Start()
    {
        _pAttention = Object.FindFirstObjectByType<PlayerAttention>();
        _pAttention.AttentionBathroom(); // activa el cartel explicacion del mj mochila
    }

    void Update()
    {
        
    }
}
