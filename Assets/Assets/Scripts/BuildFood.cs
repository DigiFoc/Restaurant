using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildFood : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BillHolder;
    ItemHandler[] items;
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
        items = GetComponentsInChildren<ItemHandler>();
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
                //Debug.Log(foodNames[i]);

                TextManager.Instance.ShowToast(foodNames[i] + "Starts Cooking", 2);
                FoodCounter.Instance.AddFood(foodNames[i], quantities[i]);
                FoodEngine.Instance.AddFood(foodNames[i], quantities[i]);
             //   FoodEngine.Instance.AddFood(foodNames[i], quantities[i]);
            }
            else
                TextManager.Instance.ShowToast(foodNames[i] + "Cannot Cook", 3);
        }



        StockInventory.Instance.UpdateFoodStockUI();

        foreach (Transform child in transform) {
            child.gameObject.GetComponent<ItemHandler>().RemoveMe();

        }

        ReceiptGenerator.Instance.CurrSlots = 0;

    }


    public void PickFoood()
    {
        //if (items == null)
        //{
        //  return;
        ////}
        //foodNames = new string[items.Length + 1];
        //  quantities = new int[items.Length + 1];

        // for (int i = 0; i < items.Length; i++)
        // {

        //     foodNames[i] = items[i].name;
        //     quantities[i] = items[i].quantity;

        // }

        // for (int i = 0; i < items.Length; i++)
        // {
        //   bool isTrue = FoodEngine.Instance.buildFood(foodNames[i], quantities[i]);
        //     if (isTrue)
        //    {

        //        FoodEngine.Instance.AddFood(foodNames[i], quantities[i]);

        //  FoodCounter.Instance.RemoveFood(foodNames[i]);
        //    }
        // }

        GameObject[] items = GameObject.FindGameObjectsWithTag("foodModel");


        for (int i = 0; i < items.Length; i++)
        {
            string name = items[i].GetComponent<quantityInfo>().name;
            int quantity = items[i].GetComponent<quantityInfo>().quantity;
            items[i].GetComponent<quantityInfo>().quantity = 0;
            if (quantity > 0)
            {
                FoodEngine.Instance.AddFood(name, quantity);
                TextManager.Instance.ShowToast(name + " Is ADDED", 2);
            }
        }

        quantities = null;
        items = null;


        StockInventory.Instance.UpdateFoodStockUI();



    }
}
