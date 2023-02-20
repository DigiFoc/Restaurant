using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTrigger : MonoBehaviour
{

    public string foodName;
    public int quntity;
  
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
            if (isTrue)
            {
                Debug.Log("COnditions Satisfied");
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
}
