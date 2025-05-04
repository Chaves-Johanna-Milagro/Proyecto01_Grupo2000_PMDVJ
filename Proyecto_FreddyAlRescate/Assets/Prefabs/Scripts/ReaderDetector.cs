using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class ReaderDetector : MonoBehaviour
{
    private float timer = 0f;
    private bool isInside = false;
    private GameObject subeCard;
    private bool paymentSuccessful = false;
    private bool showedFailure = false;
    [SerializeField] private TMP_Text payText;

    public Animator checkAnimator;
    public Animator crossAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SUBE"))
        {
            subeCard = other.gameObject;
            isInside = true;
            timer = 0f;
            paymentSuccessful = false;
            showedFailure = false;
            
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!isInside || other.gameObject != subeCard || paymentSuccessful)
            return;

        timer += Time.deltaTime;

        Collider cardCollider = subeCard.GetComponent<Collider>();
        Collider readerCollider = GetComponent<Collider>();

        // Verifica si todo el collider de la tarjeta está dentro del collider del lector
        Bounds cardBounds = cardCollider.bounds;
        Bounds readerBounds = readerCollider.bounds;

        bool completelyInside = readerBounds.Contains(cardBounds.min) && readerBounds.Contains(cardBounds.max);

        if (completelyInside)
        {
            if (timer >= 3f)
            { 
                Debug.Log("Pago exitoso");
                paymentSuccessful = true;
         
                if (checkAnimator != null)
            
                checkAnimator.SetTrigger("Successful");
                StartCoroutine(LoadFinalScene());

                if (payText != null)
                {
                    payText.text = "PAGO EXITOSO";
                    payText.gameObject.SetActive(true);
                }
            }


        }
        else 
        {
           
            if (timer >= 4f && !showedFailure)
            {     
            
                Debug.Log("Pago fallido");
                showedFailure = true;
               if (crossAnimator != null)
               {
                  crossAnimator.SetTrigger("Failure");
                  StartCoroutine(ResetCross());
               }
            }
        }
    }

IEnumerator ResetCross()
    {
        yield return new WaitForSeconds(2f);
        if (crossAnimator != null)
        {
            crossAnimator.SetTrigger("Reset"); // Esto vuelve al estado gris

        }
        if (isInside)
        {
            timer = 0f;
            showedFailure = false;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SUBE"))
        {
            isInside = false;
            subeCard = null;
            timer = 0f;
            paymentSuccessful = false;
            showedFailure = false;
        }
    }

    IEnumerator LoadFinalScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("BusLevelComplete");
    }
}
