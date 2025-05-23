using UnityEngine;

public class DecisionFood : MonoBehaviour
{
    private GameObject _food1;
    private GameObject _food2;
    private GameObject _food3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject parent = transform.parent.gameObject;

        _food1 = parent.transform.GetChild(9).gameObject;
        _food2 = parent.transform.GetChild(10).gameObject;
        _food3 = parent.transform.GetChild(11).gameObject;

        _food1?.SetActive(false);
        _food2?.SetActive(false);
        _food3?.SetActive(false);
    }

   public void ActiveFood()
   {
        _food1?.SetActive(true);
        _food2?.SetActive(true);
        _food3?.SetActive(true);
   }
}
