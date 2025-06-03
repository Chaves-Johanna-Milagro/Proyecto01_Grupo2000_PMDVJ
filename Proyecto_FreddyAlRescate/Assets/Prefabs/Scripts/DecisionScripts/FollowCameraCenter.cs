using UnityEngine;

public class FollowCameraCenter : MonoBehaviour
{
    private Camera cam;
    private float _dist;

    void Start()
    {
        cam = Camera.main;
        _dist = 5f;
    }

    void LateUpdate()
    {
        if (cam != null)
        {
            Vector3 camPos = cam.transform.position;
            transform.position = new Vector3(camPos.x, camPos.y, camPos.z + _dist);
        }
    }
}
