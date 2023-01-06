using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activeFoodManager : MonoBehaviour
{
    public List<food> activeFood = new List<food>();

    int foodEaten = 0;
    public Text foodEatenText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public List<food> GetActiveFood()
    {
        return activeFood;
    }

    // called by organism when it eats a food
    public void FoodEatenNotice()
    {
        foodEaten++;
        foodEatenText.text = foodEaten.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
