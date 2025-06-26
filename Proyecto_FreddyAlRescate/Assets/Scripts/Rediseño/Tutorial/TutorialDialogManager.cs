using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialFreddyDialogManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float typingSpeed = 0.03f;

    private Coroutine typingCoroutine;

    [System.Serializable]
    public class Dialogo
    {
        public string id;
        [TextArea]
        public string texto;
    }

    public List<Dialogo> dialogos = new List<Dialogo>();

    public void MostrarDialogoPorID(string id)
    {
        string mensaje = dialogos.Find(d => d.id == id)?.texto;

        if (mensaje == null)
        {
            Debug.LogWarning($"No se encontro dialogo con ID: {id}");
            return;
        }

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(EscribirTexto(mensaje));
    }

    private IEnumerator EscribirTexto(string mensaje)
    {
        textComponent.text = "";
        foreach (char letra in mensaje)
        {
            textComponent.text += letra;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
