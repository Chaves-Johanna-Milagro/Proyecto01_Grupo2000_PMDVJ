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

    private Coroutine currentPulse;

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
            StartCoroutine(ShowParrotDialogue("�MUY BIEN! MIRAR EL SEM�FORO ES IMPORANTE PARA CRUZAR SEGURO."));
            PlaySound("afton_semaforo_1");
            PlayerPrefs.SetString("PendingDialogue", "");
            
        }
        else if (pendingDialogue == "costados")
        {
            StartCoroutine(ShowParrotDialogue("�EXCELENTE! MIRAR A AMBOS LADOS EVITA ACCIDENTES."));
            PlaySound("afton_semaforo_2");
            PlayerPrefs.SetString("PendingDialogue", "");
        }

        childSpeechBubble.SetActive(false);
        childDialogueText = childSpeechBubble.GetComponentInChildren<TMP_Text>();

        if (!childIntroShown)
        {
            childIntroShown = true;
            StartCoroutine(ShowChildDialogue("TENGO QUE TOMAR EL COLECTIVO PERO DEBO CRUZAR ESTA CALLE �QU� TENGO QUE HACER PRIMERO?."));
            PlaySound("freddy_calle");
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

        // habilitar botones seg�n el progreso
        trafficLightButton.interactable = true;
        lookAroundButton.interactable = lookedAtTrafficLight;
        crosswalkButton.interactable = lookedAtTrafficLight && lookedBothWays;
        // L�gica para resaltar solo el bot�n correspondiente
        if (!lookedAtTrafficLight)
        {
            EmpezarResaltado(trafficLightButton);
        }
        else if (lookedAtTrafficLight && !lookedBothWays)
        {
            EmpezarResaltado(lookAroundButton);
        }
        else if (lookedAtTrafficLight && lookedBothWays)
        {
            EmpezarResaltado(crosswalkButton);
        }
        else
        {
            DetenerResaltado();
        }
    }

    void EmpezarResaltado(Button boton)
    {
        if (currentPulse != null) return; // ya est� resaltando
        currentPulse = StartCoroutine(ResaltarBoton(boton));
    }

    void DetenerResaltado()
    {
        if (currentPulse != null)
        {
            StopCoroutine(currentPulse);
            ResetearEscalaTodosLosBotones();
            currentPulse = null;
        }
    }

    IEnumerator ResaltarBoton(Button boton)
    {
        RectTransform rect = boton.GetComponent<RectTransform>();
        Vector3 escalaOriginal = rect.localScale;

        while (true)
        {
            yield return Escalar(rect, escalaOriginal, escalaOriginal * 1.2f, 0.5f);
            yield return Escalar(rect, escalaOriginal * 1.2f, escalaOriginal, 0.5f);
        }
    }

    IEnumerator Escalar(RectTransform rect, Vector3 inicio, Vector3 fin, float duracion)
    {
        float t = 0;
        while (t < duracion)
        {
            t += Time.deltaTime;
            rect.localScale = Vector3.Lerp(inicio, fin, t / duracion);
            yield return null;
        }
    }

    void ResetearEscalaTodosLosBotones()
    {
        trafficLightButton.GetComponent<RectTransform>().localScale = Vector3.one;
        lookAroundButton.GetComponent<RectTransform>().localScale = Vector3.one;
        crosswalkButton.GetComponent<RectTransform>().localScale = Vector3.one;
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
    
    public void PlaySound(string name)
    {
        AudioSource[] sounds = GetComponents<AudioSource>();

        foreach (AudioSource sound in sounds)
        {
            if (sound.clip != null && sound.clip.name == name) sound.Play();
        }
    }
}
