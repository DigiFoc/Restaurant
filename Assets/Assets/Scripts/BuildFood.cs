using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildFood : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BillHolder;
    public string[] foodNames;
    public int[] quantities;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuildFoood()
    {
        ItemHandler[] items = GetComponentsInChildren<ItemHandler>();
        foodNames = new string[items.Length + 1];
        quantities = new int[items.Length + 1];

        for (int i = 0; i < items.Length; i++)
        {
           
            foodNames[i] = items[i].name;
            quantities[i] = items[i].quantity;
           
        }

        for (int i = 0; i < items.Length; i++)
        {
            bool isTrue = FoodEngine.Instance.buildFood(foodNames[i], quantities[i]);
            if (isTrue)
            {
                FoodEngine.Instance.AddFood(foodNames[i], quantities[i]);
                TextManager.Instance.ShowToast(foodNames[i] + "Starts Cooking", 2);
                FoodCounter.Instance.AddFood(foodNames[i]);
            }
            else
                TextManager.Instance.ShowToast(foodNames[i] + "Cannot Cook", 3);
        }


        StockInventory.Instance.UpdateFoodStockUI();

        
        
    }
}
