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

    private string _name;

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

        _name = PlayerNameStatus.GetplayerName();


        if (string.IsNullOrEmpty(_name))
            PlayerNameStatus.SetPlayerName("FREDDY");

        if (SceneManager.GetActiveScene().name == "School2.0" && !AftonStatus.TieneEstado(gameObject))
        {
            AttentionSchool();
        }
        /*if (SceneManager.GetActiveScene().name == "Recess2.0" && !AftonStatus.TieneEstado(gameObject))
        {
            AttentionRecess();
        }*/

        if (SceneManager.GetActiveScene().name == "Night2.0" && !AftonStatus.TieneEstado(gameObject))
        {
           AttentionInitNight();
        }
    }

    public void AttentionBreackfast() // pa que le de una dvertencia de q se cambie pa pasr al sig lvl
   {
        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);
            PlaySound("afton_avisoRopa");
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

    public void AttentionStartRecess() // pa que el jugador sepa lo que puede hacer en el recreo
    {
        if (_isShow) return;

        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);
            _isShow = true;
        }

        _text.text = "MIRA " + PlayerNameStatus.GetplayerName() + "!! \nES HORA DEL RECREO" + "\nAPROVECHA ESTE MOMENTO PARA " + "\nIR AL BAÑO O COMPRAR ALGO EN EL KIOSCO";

        AftonStatus.GuardarEstado(gameObject);
    }

    public void AttentionEndRecess() // pa que el jugador sepa que ya terminaron las clases
    {
        if (_isShow) return;

        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);
            PlaySound("afton_escuela_completado");
            _isShow = true;
        }

        _text.text = "BIEN " + PlayerNameStatus.GetplayerName() + "!! \nHICISTE LAS ACTIVIDADES DE HOY";

        AftonStatus.GuardarEstado(gameObject);
    }

    public void AttentionInitNight() // pa que le de una dvertencia de q se ponga el pijama antes de acostarse
    {
        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);

        }

        _text.text = "HA SIDO UN DIA LARGO, SEGURO ESTAS CANSADO ASI QUE PREPARATE PARA IR A DORMIR!!!";
    }

    public void AttentionNight() // pa que le de una dvertencia de q se ponga el pijama antes de acostarse
    {
        for (int i = 0; i < _count; i++) // activar
        {
            _childs[i].SetActive(true);
            
        }

        _text.text = "¡¡¡PONTE EL PIJAMA ANTES DE DORMIR!!!";
    }


    private void Desactiveobjs()
    {
        for (int i = 0; i < _count; i++) // desativar
        {
            _childs[i].SetActive(false);
        }
    }

    public void PlaySound(string name)
    {
        AudioSource[] sounds = GetComponents<AudioSource>();

        foreach (AudioSource sound in sounds)
        {
            if (sound.clip != null && sound.clip.name == name) sound.Play();
        }
    }
}
