using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeCredits : MonoBehaviour
{
    private float _fadeDuration = 2.5f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        // Buscar todos los hijos que se llamen "img" o "cImg"
        foreach (Transform child in transform)
        {
            if (child.name == "Img" || child.name == "CImg")
            {
                Image img = child.GetComponent<Image>();
                if (img != null)
                {
                    StartCoroutine(FadeImage(img));
                }

                AudioSource audio = GetComponent<AudioSource>();
                if (audio != null)
                {
                    StartCoroutine(FadeAudio(audio));
                }
            }
        }

        yield return null;
    }

    private IEnumerator FadeImage(Image img)
    {
        Color color = Color.black;
        color.a = 1;
        img.color = color;

        float timer = 0f;

        while (timer < _fadeDuration)
        {
            float t = timer / _fadeDuration;
            img.color = Color.Lerp(Color.black, Color.white, t);
            timer += Time.deltaTime;
            yield return null;
        }

        img.color = Color.white;
    }

    private IEnumerator FadeAudio(AudioSource audio)
    {
        float timer = 0f;
        float targetVolume = 0.5f;
        audio.volume = 0f;
        audio.Play();

        while (timer < _fadeDuration)
        {
            audio.volume = Mathf.Lerp(0f, targetVolume, timer / _fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        audio.volume = targetVolume;
    }
}
