using System.Collections;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public void OnMouseDown()
    {
        if(gameObject.name == "Cupboard")  CharacterInScene.Instance.PutUniform();

        if(gameObject.name == "Bed")  CharacterInScene.Instance.MakeTheBed();

        if(gameObject.name == "Diningroom")  CharacterInScene.Instance.HaveBreackfast();

    }
}
