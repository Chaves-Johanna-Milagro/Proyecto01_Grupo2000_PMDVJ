using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ResolutionScaler : MonoBehaviour
{
    [SerializeField] private Camera cam; 
    void Start()
    {
        AdjustScale();
    }

    void AdjustScale()
    {
        if (cam == null)
            cam = Camera.main;

        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        
        transform.localScale = new Vector3(width, height, 1);
    }
}
