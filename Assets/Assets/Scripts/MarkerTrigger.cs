using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTrigger : MonoBehaviour
{

    public string foodName;
    public int quntity;
   public  CustomerAI customer;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bool isTrue =  CheckConditionSuccessful();
            if (isTrue )
            {
                if (PlayerFoodHandling.Instance.itemName.Equals(foodName, System.StringComparison.OrdinalIgnoreCase))
                {
                    SubtractFoodItems();
                    StockInventory.Instance.UpdateFoodStockUI();
                    customer.ServeFood();

                    PlayerFoodHandling.Instance.RemoveFood("UniversalFood");
                    Debug.Log("COnditions Satisfied");
                    TextManager.Instance.ShowToast("FOOD SERVED", 3);
                    this.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Wrong Tray Delivered");
                    TextManager.Instance.ShowToast("Wrong Tray", 1);
                }
            }
            else
                Debug.Log("Condtions Not Matched");
        }
    }

    public bool CheckConditionSuccessful()
    {
        if(foodName == "samosa")
        if (StockInventory.Instance.currentFoodStocks.samosa >= quntity)
        {
                return true;
        }

        if (foodName == "tea")
            if (StockInventory.Instance.currentFoodStocks.tea >= quntity)
            {
                return true;
            }

        if (foodName == "paneerTikka")
            if (StockInventory.Instance.currentFoodStocks.paneerTikka >= quntity)
            {
                return true;
            }

        if (foodName == "pakori")
            if (StockInventory.Instance.currentFoodStocks.pakora >= quntity)
            {
                return true;
            }


        return false;
    }


    void SubtractFoodItems()
    {
        if (foodName == "samosa")
            StockInventory.Instance.currentFoodStocks.samosa -= quntity;

        if (foodName == "tea")
            StockInventory.Instance.currentFoodStocks.tea -= quntity;


        if (foodName == "paneerTikka")
            StockInventory.Instance.currentFoodStocks.paneerTikka -= quntity;

        if (foodName == "pakori")
            StockInventory.Instance.currentFoodStocks.pakora -= quntity;
            
               
    }   
}
