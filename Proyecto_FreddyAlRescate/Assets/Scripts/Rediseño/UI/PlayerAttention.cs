using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerAttention : MonoBehaviour
{
    private GameObject[] _childs;

    private int _count;

    private TMP_Text _text;// texto de recomendacion de lo q debe hacer antes el jugador

    private Button _button; //pa el ok
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
    }

   public void AttentionBreackfast() // pa que le de una dvertencia de q se cambie pa pasr al sig lvl
   {
        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);
        }

        _text.text = "¡¡¡CAMBIATE ANTES DE SALIR!!!";
   }

    private void Desactiveobjs()
    {
        for (int i = 0; i < _count; i++) // desativar
        {
            _childs[i].SetActive(false);
        }
    }
}
