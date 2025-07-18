using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button _bExit;
    private void Start()
    {
        _bExit = GetComponent<Button>();

        _bExit.onClick.AddListener(ExitGame);
    }
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); //cierra el ejecutable
    }
}
