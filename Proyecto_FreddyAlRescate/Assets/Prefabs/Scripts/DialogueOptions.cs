using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueOptions : MonoBehaviour
{
    
    public void Greetings()
    {
        
        SceneManager.LoadScene("MinigameSube");
    }

    
    public void StayQuiet()
    {
        
        Debug.Log("El ni�o decidi� no decir nada.");
    }
}
