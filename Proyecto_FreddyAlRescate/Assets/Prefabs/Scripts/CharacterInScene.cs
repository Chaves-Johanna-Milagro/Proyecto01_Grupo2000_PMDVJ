using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInScene : MonoBehaviour
{
    public static CharacterInScene Instance { get; private set; }

    private Transform _charNvl1, _charNvl2;
    private Transform[] _spritesNvl1; // [0] idle pijama, [1] uniforme, [2] cama tendida (pijama), [3] cama tendida (uniforme)
    private Transform[] _spritesNvl2; // [0] idle uniforme, [1] después de desayunar

    private void Awake()
    {
        // para que solo haya una instancia
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this); // para que sobreviva entre escenas
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void Start()
    {
        AssignCharacters();
        InitializeScene(SceneManager.GetActiveScene().name); // por si la escena inicial ya necesita mostrar al personaje
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Solo debe vivir en estas dos escenas
        if (scene.name != "Morning" && scene.name != "Breackfast")
        {
            Destroy(gameObject);
            return;
        }

        AssignCharacters(); // Reasigna referencias si se perdieron
        InitializeScene(scene.name);
    }

    private void AssignCharacters()
    {
        // Solo asignar si la jerarquía está bien armada
        if (transform.childCount >= 2)
        {
            _charNvl1 = transform.GetChild(0);
            _charNvl2 = transform.GetChild(1);

            _spritesNvl1 = new Transform[]
            {
                _charNvl1.GetChild(0), // idle pijama
                _charNvl1.GetChild(1), // uniforme
                _charNvl1.GetChild(2), // cama tendida pijama
                _charNvl1.GetChild(3)  // cama tendida uniforme
            };

            _spritesNvl2 = new Transform[]
            {
                _charNvl2.GetChild(0), // idle uniforme
                _charNvl2.GetChild(1)  // después de desayunar
            };
        }
        else
        {
            Debug.LogWarning("error en la jerarquía del personaje");
        }
    }

    private void InitializeScene(string sceneName)
    {
        if (_charNvl1 != null) _charNvl1.gameObject.SetActive(false);
        if (_charNvl2 != null) _charNvl2.gameObject.SetActive(false);

        DeactivateAll(_spritesNvl1);
        DeactivateAll(_spritesNvl2);

        if (sceneName == "Morning" && _charNvl1 != null)
        {
            _charNvl1.gameObject.SetActive(true);
            _spritesNvl1?[0]?.gameObject.SetActive(true); // idle pijama
        }
        else if (sceneName == "Breackfast" && _charNvl2 != null)
        {
            _charNvl2.gameObject.SetActive(true);
            _spritesNvl2?[0]?.gameObject.SetActive(true); // idle uniforme
        }
    }

    public void PutUniform()
    {
        SwitchSprite(_spritesNvl1, 1); // Mostrar sprite con uniforme
        _spritesNvl1[0] = _spritesNvl1[1]; // Actualiza el "idle" base
    }

    public void MakeTheBed()
    {
        SwitchSprite(_spritesNvl1, 2); // Mostrar cama tendida (pijama)
    }

    public void MakeTheBedUniform()
    {
        SwitchSprite(_spritesNvl1, 3); // Mostrar cama tendida (uniforme)
    }

    public bool IsCharacterPutUniform()
    {
        return _spritesNvl1 != null && _spritesNvl1[1].gameObject.activeSelf;
    }

    public void HaveBreackfast()
    {
        SwitchSprite(_spritesNvl2, 1); // Mostrar sprite post-desayuno
    }

    private void SwitchSprite(Transform[] sprites, int indexToActivate)
    {
        if (sprites == null) return;

        for (int i = 0; i < sprites.Length; i++)
        {
            if (sprites[i] != null)
                sprites[i].gameObject.SetActive(i == indexToActivate);
        }
    }

    private void DeactivateAll(Transform[] sprites)
    {
        if (sprites == null) return;

        foreach (var sprite in sprites)
        {
            if (sprite != null)
                sprite.gameObject.SetActive(false);
        }
    }
}
