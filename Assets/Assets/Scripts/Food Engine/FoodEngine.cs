using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEngine : MonoBehaviour
{
    [System.Serializable]
    public class Ingredients
        {
            string potato = "Potato";
            string oil = "Oil";
            string besan = "Besan";
            string spice = "Flour";
            string sugar = "Sugar";
            string milk = "Milk";

        }
    [SerializeField]

    public Ingredients ingredientsList;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buildFood(string food)
    {
        if (food == "Samosa")
        {
            StockInventory.Instance.currentFoodStocks.samosa += 1;
        }

        if (food == "Paneer Tikka")
        {
            StockInventory.Instance.currentFoodStocks.paneerTikka += 1;
        }

        if (food == "Tea")
        {
            StockInventory.Instance.currentFoodStocks.tea += 1;
        }

        if (food == "Pakora")
        {
            StockInventory.Instance.currentFoodStocks.pakora += 1;
        }

    }

    
}
