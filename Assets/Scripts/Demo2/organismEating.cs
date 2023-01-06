using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organismEating : MonoBehaviour
{
    food nearestFood;
    float nearestDist;
    activeFoodManager afm;
    organismMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<organismMovement>();
        afm = GameObject.FindGameObjectWithTag("environment").GetComponent<activeFoodManager>();

        // temporaryily assign dummy food
        nearestFood = GameObject.FindGameObjectWithTag("food").GetComponent<food>();
        nearestDist = Vector2.Distance(transform.position, nearestFood.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (afm.activeFood.Count != 0)
        {
            if (!afm.activeFood.Contains(nearestFood))
            {
                ResetNearestFood();
            }
            foreach (food f in afm.activeFood)
            {
                float tempDist = Vector2.Distance(transform.position, f.transform.position);
                if (tempDist <= nearestDist)
                {
                    nearestFood = f;
                    nearestDist = tempDist;
                    movement.SetGoalPos(nearestFood.transform.position);
                }
            }
            if (nearestDist <= 0.15)
                EatFood(nearestFood);
        }
    }

    void ResetNearestFood()
    {
        nearestFood = afm.activeFood[0];
        nearestDist = 10;
    }

    void EatFood(food foodToEat)
    {
        afm.activeFood.Remove(foodToEat);
        afm.FoodEatenNotice(); // to update text display
        Destroy(foodToEat.gameObject);
        ResetNearestFood();
    }
}

