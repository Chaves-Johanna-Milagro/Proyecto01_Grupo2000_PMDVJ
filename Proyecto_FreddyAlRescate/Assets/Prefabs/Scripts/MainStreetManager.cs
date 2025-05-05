using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class MainStreetManager : MonoBehaviour
{
    public Button trafficLightButton;
    public Button lookAroundButton;
    public Button crosswalkButton;

    private bool lookedAtTrafficLight = false;
    private bool lookedBothWays = false;

    private static bool initialized = false;

    [SerializeField] private GameObject parrotSpeechBubble;
    [SerializeField] private TMP_Text parrotDialogueText;
    [SerializeField] private GameObject childSpeechBubble;
    [SerializeField] private TMP_Text childDialogueText;
    private static bool childIntroShown = false;
    [SerializeField] private float typeSpeed = 0.04f;

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

        parrotSpeechBubble.SetActive(false);
        parrotDialogueText = parrotSpeechBubble.GetComponentInChildren<TMPro.TMP_Text>(); 


        string pendingDialogue = PlayerPrefs.GetString("PendingDialogue", "");

        if (pendingDialogue == "semaforo")
        {
            StartCoroutine(ShowParrotDialogue("¡MUY BIEN! MIRAR EL SEMÁFORO ES IMPORANTE PARA CRUZAR SEGURO."));
            PlayerPrefs.SetString("PendingDialogue", "");
        }
        else if (pendingDialogue == "costados")
        {
            StartCoroutine(ShowParrotDialogue("¡EXCELENTE! MIRAR A AMBOS LADOS EVITA ACCIDENTES."));
            PlayerPrefs.SetString("PendingDialogue", "");
        }

        childSpeechBubble.SetActive(false);
        childDialogueText = childSpeechBubble.GetComponentInChildren<TMP_Text>();

        if (!childIntroShown)
        {
            childIntroShown = true;
            StartCoroutine(ShowChildDialogue("TENGO QUE TOMAR EL COLECTIVO PERO DEBO CRUZAR ESTA CALLE ¿QUÉ TENGO QUE HACER PRIMERO?."));
        }

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

    IEnumerator ShowParrotDialogue(string message)
    {
        parrotSpeechBubble.SetActive(true);
        parrotDialogueText.text = "";

        foreach (char c in message.ToCharArray())
        {
            parrotDialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return new WaitForSeconds(3f);
        parrotSpeechBubble.SetActive(false);
    }

    IEnumerator ShowChildDialogue(string message)
    {
        childSpeechBubble.SetActive(true);
        childDialogueText.text = "";

        foreach (char c in message.ToCharArray())
        {
            childDialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return new WaitForSeconds(8f);
        childSpeechBubble.SetActive(false);
    }
}
