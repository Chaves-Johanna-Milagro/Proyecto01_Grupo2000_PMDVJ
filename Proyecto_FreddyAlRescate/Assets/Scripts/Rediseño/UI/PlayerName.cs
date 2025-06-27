using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerName : MonoBehaviour
{
    private TMP_Text _namePlayer;

    private Image _imgComp;

    private string _name;
    
    void Start()
    {
        _imgComp = GetComponent<Image>();
        _namePlayer = transform.GetChild(0).GetComponent<TMP_Text>();

        _name = PlayerNameStatus.GetplayerName();

        if (string.IsNullOrEmpty(_name))
            _namePlayer.text = "NOMBRE: FREDDY";
        else
            _namePlayer.text = "NOMBRE: " + _name;

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
