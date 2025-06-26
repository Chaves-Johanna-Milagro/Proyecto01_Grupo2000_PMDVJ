using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Intro : MonoBehaviour
{
    private GameObject _cImg1;
    private GameObject _cImg2;
    private GameObject _cImg3;

    private TMP_Text _cText1;
    private TMP_Text _cText2;
    private TMP_Text _cText3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cImg1 = transform.Find("Img1").gameObject;
        _cImg2 = transform.Find("Img2").gameObject;
        _cImg3 = transform.Find("Img3").gameObject;

        _cText1 = _cImg1.transform.Find("Text").GetComponent<TMP_Text>();
        _cText2 = _cImg2.transform.Find("Text").GetComponent<TMP_Text>();
        _cText3 = _cImg3.transform.Find("Text").GetComponent<TMP_Text>();

        if (PlayerNameStatus.GetplayerName() == "") _cText1.text = "AFTON:" + "\n   BUENOS DIAS FREDDY" + "! \n   YA ES HORA DE LEVANTARSE!!!";
        if (PlayerNameStatus.GetplayerName() != "") _cText1.text = "AFTON:" + "\n   BUENOS DIAS " + PlayerNameStatus.GetplayerName() + "! \n   YA ES HORA DE LEVANTARSE!!!";

        _cText2.text = "AFTON:" + "\n   VAMOS! ARRIBA! ARRIBA! ARRIBA" + "\n   QUE LLEGARAS TARDE";

        _cText3.text = "AFTON:" + "\n   HAY QUE PREPARARNOS PARA IR A LA ESCUELA" + "\n  ¿RECUERDAS QUE DEBES HACER EN LA MAÑANA?";

        StartCoroutine(PlayIntroSequence());
    }
    private IEnumerator PlayIntroSequence()
    {
        yield return StartCoroutine(FadeSequence(_cImg1));
        yield return StartCoroutine(FadeSequence(_cImg2));
        yield return StartCoroutine(FadeSequence(_cImg3));
        SceneManager.LoadScene("Morning2.0");
    }

    private IEnumerator FadeSequence(GameObject root)
    {
        float duration = 1f;
        float stayTime = 1.5f;

        root.SetActive(true);

        // Obtener todos los Image y TMP_Text del objeto y sus hijos
        List<Graphic> graphics = new List<Graphic>();
        graphics.AddRange(root.GetComponentsInChildren<Image>(true));
        graphics.AddRange(root.GetComponentsInChildren<TMP_Text>(true));

        // Guardar sus colores originales
        Dictionary<Graphic, Color> originalColors = new Dictionary<Graphic, Color>();
        foreach (Graphic g in graphics)
        {
            originalColors[g] = g.color;
            g.color = Color.black; // los dejamos negros para el inicio
        }

        // Fade in (negro a su color original)
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float lerp = t / duration;
            foreach (Graphic g in graphics)
                g.color = Color.Lerp(Color.black, originalColors[g], lerp);
            yield return null;
        }
        foreach (Graphic g in graphics)
            g.color = originalColors[g];

        yield return new WaitForSeconds(stayTime);

        // Fade out (de su color original a negro)
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float lerp = t / duration;
            foreach (Graphic g in graphics)
                g.color = Color.Lerp(originalColors[g], Color.black, lerp);
            yield return null;
        }
        foreach (Graphic g in graphics)
            g.color = Color.black;

        root.SetActive(false);
    }
}
