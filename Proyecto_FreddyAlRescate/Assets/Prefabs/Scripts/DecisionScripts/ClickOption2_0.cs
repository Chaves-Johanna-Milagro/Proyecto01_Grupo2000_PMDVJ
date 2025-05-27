using UnityEngine;

public class ClickOption2_0 : MonoBehaviour
{
    private DecisionGreet2_0 _des;

    private string _nameOpt;
    
    void Start()
    {
        _des = GetComponentInParent<DecisionGreet2_0>();
        _nameOpt = gameObject.name;
    }

    public void OnMouseDown()
    {
        _des.SelectOpt(_nameOpt);
    }
}
