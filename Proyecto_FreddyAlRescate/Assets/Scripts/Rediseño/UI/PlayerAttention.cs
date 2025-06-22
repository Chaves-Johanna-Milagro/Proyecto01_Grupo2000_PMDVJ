using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;


public class PlayerAttention : MonoBehaviour
{
    private GameObject[] _childs;

    private int _count;

    private TMP_Text _text;// texto de recomendacion de lo q debe hacer antes el jugador

    private Button _button; //pa el ok

    private bool _isShow = false; // pa evita q se muestren de nuevo al cargar una escena
    void Start()
    {
        _count = transform.childCount;
        _childs = new GameObject[_count];

        for (int i = 0; i < _count; i++) // desativar al inicio
        {
            _childs[i] = transform.GetChild(i).gameObject;
            _childs[i].SetActive(false);
        }

        _text = transform.Find("Text").GetComponent<TMP_Text>();

        _button = transform.Find("Button").GetComponent<Button>();

        _button.onClick.AddListener(Desactiveobjs);

        if (SceneManager.GetActiveScene().name == "School2.0" && !AftonStatus.TieneEstado(gameObject))
        {
            AttentionSchool();
        }
    }

   public void AttentionBreackfast() // pa que le de una dvertencia de q se cambie pa pasr al sig lvl
   {
        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);
        }

        _text.text = "¡¡¡CAMBIATE ANTES DE SALIR!!!";
   }

    public void AttentionGreet() // pa que le explique al momento de decidir saludar o no
    {
        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);
        }

        _text.text = "ELIGE SALUDAR O NO. \nRECUERDA QUE: \n¡ES BUENO TENER MODALES!";
    }
    public void AttentionSchool() // pa que el jugador sepa que puede tira la basura
    {
        if (_isShow) return;

        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);
            _isShow = true;
        }

        _text.text = "MIRA " + PlayerNameStatus.GetplayerName() + "!! \nHAY BASURA EN EL SUELO" + "\nTIRALA EN EL TACHO";

        AftonStatus.GuardarEstado(gameObject);
    }
    private void Desactiveobjs()
    {
        for (int i = 0; i < _count; i++) // desativar
        {
            _childs[i].SetActive(false);
        }
    }
}
