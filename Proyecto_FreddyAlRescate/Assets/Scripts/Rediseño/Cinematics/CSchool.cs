using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CSchool : MonoBehaviour
{
    private GameObject _imgStart;
    private GameObject _imgEnd;

    private AudioSource _audioSource;
    private void Start()
    {
        _imgStart = transform.Find("ImgStart")?.gameObject;
        _imgEnd = transform.Find("ImgEnd")?.gameObject;

        _audioSource = GetComponent<AudioSource>();

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "CSchoolStart" && _imgStart != null)
        {
            StartCoroutine(FadeAndLoadScene(_imgStart, "School2.0"));
        }
        else if (sceneName == "CSchoolEnd" && _imgEnd != null)
        {
            StartCoroutine(FadeAndLoadScene(_imgEnd, "Night2.0"));
        }

    }

    private IEnumerator FadeAndLoadScene(GameObject root, string nextScene)
    {
        float duration = 1f;
        float stayTime = 2f;

        root.SetActive(true);

        List<Graphic> graphics = new List<Graphic>();
        graphics.AddRange(root.GetComponentsInChildren<Image>(true));
        graphics.AddRange(root.GetComponentsInChildren<TMP_Text>(true));

        Dictionary<Graphic, Color> originalColors = new Dictionary<Graphic, Color>();
        foreach (Graphic g in graphics)
        {
            originalColors[g] = g.color;
            g.color = Color.black;
        }

        // Fade in (negro a color original)
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float lerp = t / duration;

            foreach (Graphic g in graphics)
                g.color = Color.Lerp(Color.black, originalColors[g], lerp);

            yield return null;
        }

        foreach (Graphic g in graphics)
            g.color = originalColors[g];

        // Reproducir sonido solo cuando está todo visible
        if (_audioSource != null)
            _audioSource.Play();

        yield return new WaitForSeconds(stayTime);

        // Detener sonido antes del fade out
        if (_audioSource != null)
            _audioSource.Stop();

        // Fade out (color original a negro)
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

        // Cargar la siguiente escena
        SceneManager.LoadScene(nextScene);
    }
}
