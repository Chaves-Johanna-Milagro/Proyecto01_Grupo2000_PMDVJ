using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NamePlayer : MonoBehaviour
{
    private TMP_Text _namePlayer;

    private Image _imgComp;
    
    void Start()
    {
        _imgComp = GetComponent<Image>();
        _namePlayer = transform.GetChild(0).GetComponent<TMP_Text>();

        if (PlayerNameStatus.GetplayerName() == "") _namePlayer.text = "NOMBRE: FREEDY";
        if (PlayerNameStatus.GetplayerName() != "") _namePlayer.text = "NOMBRE: " + PlayerNameStatus.GetplayerName();

    }
    public void Update()
    {
        ChangeColor();
    }
    private void ChangeColor()
    {
        var color = _imgComp.color;
        color.a = PauseStatus.IsPaused ? 0.5f : 1f;
        _imgComp.color = color;

        var textColor = _namePlayer.color;
        textColor.a = PauseStatus.IsPaused ? 0.5f : 1f;
        _namePlayer.color = textColor;
    }
}
