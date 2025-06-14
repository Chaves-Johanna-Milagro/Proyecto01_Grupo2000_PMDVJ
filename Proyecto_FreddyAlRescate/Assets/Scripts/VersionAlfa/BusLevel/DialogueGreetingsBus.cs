using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class DialogueGreetingsBus : MonoBehaviour
{
    [SerializeField] private GameObject greetButton;
    [SerializeField] private GameObject stayQuietButton;

    [SerializeField] private GameObject childSpeechBubble;
    [SerializeField] private TMP_Text childDialogueText;

    [SerializeField] private GameObject driverSpeechBubble;
    [SerializeField] private TMP_Text driverDialogueText;

    [SerializeField] private float typeSpeed = 0.05f; // velocidad entre letras

    void Start()
    {
        childSpeechBubble.SetActive(false);
        driverSpeechBubble.SetActive(false);
    }

    public void Greetings()
    {
        greetButton.SetActive(false);
        stayQuietButton.SetActive(false);
        StartCoroutine(GreetingsSequence());
    }

    public void StayQuiet()
    {
        greetButton.SetActive(false);
        stayQuietButton.SetActive(false);
        StartCoroutine(QuietSequence());
    }

    IEnumerator GreetingsSequence()
    {
        childSpeechBubble.SetActive(true);
        yield return StartCoroutine(TypeText(childDialogueText, "¡BUENOS DIAS, CHOFER!"));

        yield return new WaitForSeconds(2f);

        childSpeechBubble.SetActive(false);
        driverSpeechBubble.SetActive(true);
        yield return StartCoroutine(TypeText(driverDialogueText, "¡HOLA JOVEN! PASE POR FAVOR."));

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MinigameSube");
    }

    IEnumerator QuietSequence()
    {
        childSpeechBubble.SetActive(true);
        yield return StartCoroutine(TypeText(childDialogueText, "..."));

        yield return new WaitForSeconds(2f);

        childSpeechBubble.SetActive(false);
        driverSpeechBubble.SetActive(true);
        yield return StartCoroutine(TypeText(driverDialogueText, "ADELANTE, POR FAVOR."));

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MinigameSube");
    }

    IEnumerator TypeText(TMP_Text textComponent, string message)
    {
        textComponent.text = "";
        foreach (char letter in message.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}
