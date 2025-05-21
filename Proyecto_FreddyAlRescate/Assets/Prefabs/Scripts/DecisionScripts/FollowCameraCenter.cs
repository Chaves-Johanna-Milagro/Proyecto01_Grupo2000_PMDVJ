using UnityEngine;

public class FollowCameraCenter : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (cam != null)
        {
            Vector3 camPos = cam.transform.position;
            transform.position = new Vector3(camPos.x, camPos.y, camPos.z + 5f);
        }
    }
}
