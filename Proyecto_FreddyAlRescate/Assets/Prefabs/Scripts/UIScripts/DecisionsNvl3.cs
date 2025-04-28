using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionsNvl3 : MonoBehaviour
{
    public static DecisionsNvl3 Instance { get; private set; }

    private Transform _bg; // activar el background

    private Transform _bgRoad; // fondo para la desicion del camino

    private void Awake()
    {
        //limita la instancia a una sola
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(this); //permite que sobreviva a cambios de escena

        }
    }
    void Start()
    {
        _bg = transform.GetChild(0);

        _bgRoad = _bg.transform.GetChild(0);
    }

    public void ActiveDecisionRoad()
    {
        _bgRoad.gameObject.SetActive(true);
    }
}
