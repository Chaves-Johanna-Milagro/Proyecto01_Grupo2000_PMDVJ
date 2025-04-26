using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StreetCrossingManager : MonoBehaviour
{
    public Button trafficLightButton;
    public Button lookAroundButton;
    public Button crosswalkButton;

    private bool lookedAtTrafficLight = false;
    private bool lookedBothWays = false;

    private static bool initialized = false;

    void Start()
    {
        // inicializar solo una vez
        if (!initialized)
        {
            PlayerPrefs.SetInt("LookedAtTrafficLight", 0);
            PlayerPrefs.SetInt("LookedBothWays", 0);
            initialized = true;
        }

        trafficLightButton.onClick.AddListener(OnClickTrafficLight);
        lookAroundButton.onClick.AddListener(OnClickEyes);
        crosswalkButton.onClick.AddListener(OnClickCrosswalk);
    }

    void OnClickTrafficLight()
    {
        PlayerPrefs.SetInt("LookedAtTrafficLight", 1);
        SceneManager.LoadScene("TrafficLight");
    }

    void OnClickEyes()
    {
        PlayerPrefs.SetInt("LookedBothWays", 1);
        SceneManager.LoadScene("LookBothWays");
    }

    void OnClickCrosswalk()
    {
        SceneManager.LoadScene("CrossStreet");
    }

    void Update()
    {
        // se chequea progreso guardado
        lookedAtTrafficLight = PlayerPrefs.GetInt("LookedAtTrafficLight", 0) == 1;
        lookedBothWays = PlayerPrefs.GetInt("LookedBothWays", 0) == 1;

        // habilitar botones según el progreso
        trafficLightButton.interactable = true;
        lookAroundButton.interactable = lookedAtTrafficLight;
        crosswalkButton.interactable = lookedAtTrafficLight && lookedBothWays;
    }
}
