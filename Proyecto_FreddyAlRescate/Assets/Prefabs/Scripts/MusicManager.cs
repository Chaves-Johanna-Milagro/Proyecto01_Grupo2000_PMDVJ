using UnityEngine;

public class KeepMusicAlive : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Opcional: destruir si ya existe otro igual
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            Destroy(gameObject);
        }
    }
}