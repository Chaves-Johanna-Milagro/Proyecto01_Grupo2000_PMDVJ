using UnityEngine;
using UnityEngine.UI;

public class DesactveObjUI : MonoBehaviour
{
    private Transform _panel;

    private Button _pause;
    private Button _resume;

    private int[] _objIU = new int[] {0,1,2}; // pa desactivar los obj de la ui

    private void Start()
    {
        _pause = transform.GetChild(1).GetComponent<Button>();

        _pause.onClick.AddListener(DesactiveObj);

        _panel = transform.GetChild(0);
        _resume = _panel.GetChild(0).GetComponent<Button>();

        _resume.onClick.AddListener(ActiveObj);
    }

    public void DesactiveObj()
    {
        Transform parent = transform.parent;

        foreach (int i in _objIU)
        {
            parent.transform.GetChild(i).gameObject.SetActive(false);
            _pause.gameObject.SetActive(false); // desactivamos tambien el boton de pausa
        }
    }
    public void ActiveObj()
    {
        Transform parent = transform.parent;

        foreach (int i in _objIU)
        {
            parent.transform.GetChild(i).gameObject.SetActive(true);
            _pause.gameObject.SetActive(true);
        }
    }
}
