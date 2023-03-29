using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderGoods : MonoBehaviour
{
    // Start is called before the first frame update
    string[] itemNames;
    int[] quantities;
    public int totalPrice;
    public TMP_Text totalPriceText;
    ItemHandler[] items;
    public GameObject ItemHolder;

        private void Start()
    {
        

    }
    public void OrderGooods()
    {
        items = ItemHolder.GetComponentsInChildren<ItemHandler>();
        StartCoroutine(OrderGoooods());
    }

    IEnumerator OrderGoooods()
    {
        MenuManager.Instance.ChangeMenu("side");
        yield return new WaitForSeconds(0.5f);
        bool temp = BuildFoood();
       
        if (!temp)
        {
            TextManager.Instance.ShowToast("Coins are not enough", 2);
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            TextManager.Instance.ShowToast("Ordered", 2);
            int newCoins = StockInventory.Instance.coins - totalPrice;

            StockInventory.Instance.ChangeCoinsTo(newCoins);
            GetVehicle.Instance.StartRide();
            Debug.Log(50/(GetVehicle.Instance.speeds[GetVehicle.Instance.currentVehicle - 1] ));

            yield return new WaitForSeconds(50 / (GetVehicle.Instance.speeds[GetVehicle.Instance.currentVehicle - 1]));
            TextManager.Instance.ShowToast("Agya", 2);
            SoundManager.Instance.PlaySound("horn");
            for (int i = 0; i < items.Length; i++)
        {
            StockInventory.Instance.AddStocks(itemNames[i], quantities[i]);
            TextManager.Instance.ShowToast(quantities[i] + " " + itemNames[i] + " Ordered Recieved",2);
        }

        }
        

    }

    public bool BuildFoood()
    {
       
        itemNames = new string[items.Length + 1];
        quantities = new int[items.Length + 1];

        for (int i = 0; i < items.Length; i++)
        {

            itemNames[i] = items[i].name;
            quantities[i] = items[i].quantity;
            totalPrice += items[i].amount;
            totalPriceText.text = "Total Rs:- " + totalPrice.ToString();

        }

        if (totalPrice > StockInventory.Instance.coins)
        {
            return false;
        }

       // yield return new WaitForSeconds((GetVehicle.Instance.speeds[GetVehicle.Instance.currentVehicle - 1] / 25f) * 2);
       



        return true;



    }
}
