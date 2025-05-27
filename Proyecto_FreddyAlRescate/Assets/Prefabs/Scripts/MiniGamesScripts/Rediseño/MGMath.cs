using UnityEngine;

public class MGMath : MonoBehaviour // pa el kiosko y la verduleria
{
    private DecisionBase _desBase;
    private GameObject _mgmath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _desBase = GetComponent<DecisionBase>();
        _mgmath = transform.Find("MiniGameMath").gameObject;
    }

    public void ActiveMGMath()
    {
        _mgmath.SetActive(true);
        _desBase.ExitDecision();
        
    }
}
