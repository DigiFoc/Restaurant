using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGoods : MonoBehaviour
{
    // Start is called before the first frame update
    string[] itemNames;
    int[] quantities;
   public int totalPrice;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void OrderGooods()
    {
        bool temp = BuildFoood();
        if (!temp)
            TextManager.Instance.ShowToast("Coins are not enough",2);

        int newCoins = StockInventory.Instance.coins - totalPrice;
       
        StockInventory.Instance.ChangeCoinsTo(newCoins);

    }

    public bool BuildFoood()
    {
        ItemHandler[] items = GetComponentsInChildren<ItemHandler>();
        itemNames = new string[items.Length + 1];
        quantities = new int[items.Length + 1];

        for (int i = 0; i < items.Length; i++)
        {

            itemNames[i] = items[i].name;
            quantities[i] = items[i].quantity;
            totalPrice += items[i].amount;

        }

        if (totalPrice > StockInventory.Instance.coins)
        {
            return false;
        }


        for (int i = 0; i < items.Length; i++)
        {
            StockInventory.Instance.AddStocks(itemNames[i], quantities[i]);
            TextManager.Instance.ShowToast(quantities[i] + " " + itemNames[i] + " Ordered",2);
        }




        return true;



    }
}
