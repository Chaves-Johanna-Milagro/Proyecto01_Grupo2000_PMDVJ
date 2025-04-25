using System.Collections;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (gameObject.name == "Cupboard") CharacterInScene.Instance.PutUniform();


        if(gameObject.name == "Bed")
        {
            // Si el sprite actual es el del personaje con uniforme (�ndice 1), usar cama con uniforme (�ndice 3)
            if (CharacterInScene.Instance.IsCharacterPutUniform())
            {
                CharacterInScene.Instance.MakeTheBedUniform();
            }
            else
            {
                CharacterInScene.Instance.MakeTheBed();
            }
        }
  

        if(gameObject.name == "Diningroom")  CharacterInScene.Instance.HaveBreackfast();

    }
}
