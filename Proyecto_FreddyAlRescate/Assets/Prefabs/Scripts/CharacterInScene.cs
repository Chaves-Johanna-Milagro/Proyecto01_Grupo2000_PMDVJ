using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInScene : MonoBehaviour
{
    public static CharacterInScene Instance {  get; private set; }


    private string _currentScene;

    private Transform _charNvl1, _charNvl2;
    private Transform[] _spritesNvl1; // [0] idle pijama, [1] uniforme, [2] cama tendida (pijama), [3] cama tendida (uniforme)
    private Transform[] _spritesNvl2; // [0] idle uniforme, [1] después de desayunar

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


    private void Start()
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

        _currentScene = SceneManager.GetActiveScene().name;

        if (_currentScene == "Morning")
        {
            _charNvl1.gameObject.SetActive(true);
            _spritesNvl1[0].gameObject.SetActive(true); // idle pijama
        }
        else if (_currentScene == "Breackfast")
        {
            _charNvl2.gameObject.SetActive(true);
            _spritesNvl2[0].gameObject.SetActive(true); // idle uniforme
        }
    }



    public void PutUniform()
    {
        SwitchSprite(_spritesNvl1, 1); // uniforme
        _spritesNvl1[0] = _spritesNvl1[1]; // actualiza el idle
    }



    public void MakeTheBed()
    {
        SwitchSprite(_spritesNvl1, 2); // cama tendida con pijama
    }

    public bool IsCharacterPutUniform()  // para saber si es que el sprite con el uniforme puesto se activo
    {
        return _spritesNvl1[1].gameObject.activeSelf;
    }


    public void MakeTheBedUniform()
    {
        SwitchSprite(_spritesNvl1, 3); // cama tendida con uniforme
    }



    public void HaveBreackfast()
    {
        SwitchSprite(_spritesNvl2, 1); // después de desayunar
    }



    public void DesactiveAction()
    {
        if (_currentScene == "Morning")
        {
            DeactivateAll(_spritesNvl1);
        }
        else if (_currentScene == "Breackfast")
        {
            DeactivateAll(_spritesNvl2);
        }
    }

    private void SwitchSprite(Transform[] sprites, int indexToActivate)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].gameObject.SetActive(i == indexToActivate);
        }
    }

    private void DeactivateAll(Transform[] sprites)
    {
        foreach (var sprite in sprites)
        {
            sprite.gameObject.SetActive(false);
        }
    }

}
