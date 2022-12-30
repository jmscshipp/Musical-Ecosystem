using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeFoodManager : MonoBehaviour
{
    public List<food> activeFood = new List<food>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public List<food> GetActiveFood()
    {
        return activeFood;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
