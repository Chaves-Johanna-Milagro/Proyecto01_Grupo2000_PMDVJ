using UnityEngine;
using UnityEngine.UI;

public class DesactiveObjUI_Nvl1_Nvl2 : MonoBehaviour
{
    private int _indexUIDesactive = 0;

    private Transform _panel;
    private Transform _parent;

    private Button _pauseButton;
    private Button _resumeButton;


    private void Start()
    {
        _parent = transform.parent;

        _pauseButton = transform.GetChild(1).GetComponent<Button>();
        _pauseButton.onClick.AddListener(DesactiveUI);

        _panel = transform.GetChild(0);
        _resumeButton = _panel.GetChild(0).GetComponent<Button>();
        _resumeButton.onClick.AddListener(ActiveUI);
    }

    private void Update()
    {
        bool isMinigameActive = IsTagActive("MiniGame");
        bool isPauseActive = IsTagActive("Pause");

        if (isMinigameActive || isPauseActive)
        {
            DesactiveUI();
        }
        else
        {
            ActiveUI();
        }
    }

    private bool IsTagActive(string tag)
    {
        GameObject obj = GameObject.FindGameObjectWithTag(tag);
        return obj != null && obj.activeInHierarchy;
    }

    public void DesactiveUI()
    {
        _parent.GetChild(_indexUIDesactive).gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(false);
    }

    public void ActiveUI()
    {
        _parent.GetChild(_indexUIDesactive).gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(true);
    }
}
