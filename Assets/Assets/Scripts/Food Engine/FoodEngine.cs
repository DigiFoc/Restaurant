using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEngine : MonoBehaviour
{


    
   

    public Conditions conditions;
    public static FoodEngine Instance  { get; set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool buildFood(string food,int quantity)
    {
        if (food == "Samosa")
        {

          
            bool isValid = checkConditionForSamosa(quantity);
            if (isValid)
            {
              
                return true;
            }
            else
                return false;
        }
        if (food == "PaneerTikka")
        {
            bool isValid = checkConditionForPaneerTikka(quantity);
            if (isValid)
            {
               
                return true;
            }
            else
                return false;
        }

        if (food == "Tea")
        {
            bool isValid = checkConditionForTea(quantity);
            if (isValid)
            {
                StockInventory.Instance.currentFoodStocks.tea += 1;
                return true;
            }
            else
            {
                return false;
            }

            bool isAvailable = checkConditionForSamosa();
            StockInventory.Instance.currentFoodStocks.samosa += 1;

        }

        if (food == "Pakori")
        {
            bool isValid = checkConditionForPakora(quantity);
            Debug.Log("Pakora valid" + isValid);
            if (isValid)
            {
                return true;
               
            }
            else
            {
                return false;
            }
        }

        return false;

    }


    public void AddFood(string food,int quantity)
    {
        if(food == "Samosa")
        {
            StockInventory.Instance.currentFoodStocks.samosa += quantity;
        }

        if (food == "PaneerTikka")
        {
            StockInventory.Instance.currentFoodStocks.paneerTikka += quantity;
        }


        if (food == "Tea")
        {
            StockInventory.Instance.currentFoodStocks.tea += quantity;
        }

        if(food == "Pakora")
        {

            StockInventory.Instance.currentFoodStocks.pakora += quantity;
        }
    }
    bool checkConditionForSamosa(int quantity)
    {
        if(StockInventory.Instance.currentIngredientStocks.flour  >= conditions.forSamosa.flour * quantity)
        {
          
        }
        else
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan >= conditions.forSamosa.besan *quantity )
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.spice >= conditions.forSamosa.spice * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.milk >= conditions.forSamosa.milk * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.potato >= conditions.forSamosa.potato * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.sugar >= conditions.forSamosa.sugar * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.tealeaves >= conditions.forSamosa.tea_leaves * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.oil >= conditions.forSamosa.oil * quantity)
        {
            
        }
        else
        {
            return false;
        }

        return true;


    }

    public void removeSamosaIngredients(int quantity)
    {
        StockInventory.Instance.currentIngredientStocks.flour = StockInventory.Instance.currentIngredientStocks.flour - conditions.forSamosa.flour * quantity;
        StockInventory.Instance.currentIngredientStocks.besan = StockInventory.Instance.currentIngredientStocks.besan - conditions.forSamosa.besan * quantity;
        StockInventory.Instance.currentIngredientStocks.spice = StockInventory.Instance.currentIngredientStocks.spice - conditions.forSamosa.spice * quantity;
        StockInventory.Instance.currentIngredientStocks.milk = StockInventory.Instance.currentIngredientStocks.milk - conditions.forSamosa.milk * quantity;
        StockInventory.Instance.currentIngredientStocks.potato = StockInventory.Instance.currentIngredientStocks.potato - conditions.forSamosa.potato * quantity;
        StockInventory.Instance.currentIngredientStocks.sugar = StockInventory.Instance.currentIngredientStocks.sugar - conditions.forSamosa.sugar * quantity;
        StockInventory.Instance.currentIngredientStocks.tealeaves = StockInventory.Instance.currentIngredientStocks.tealeaves - conditions.forSamosa.tea_leaves * quantity;
        StockInventory.Instance.currentIngredientStocks.oil = StockInventory.Instance.currentIngredientStocks.oil - conditions.forSamosa.oil * quantity;
    }




    bool checkConditionForTea(int quantity)
    {
        if (StockInventory.Instance.currentIngredientStocks.flour >= conditions.forTea.flour * quantity)
        {
            
        }
        else
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan >= conditions.forTea.besan * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.spice >= conditions.forTea.spice * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.milk >= conditions.forTea.milk * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.potato >= conditions.forTea.potato * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.sugar >= conditions.forTea.sugar * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.tealeaves >= conditions.forTea.tea_leaves * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.oil >= conditions.forTea.oil * quantity)
        {
            
        }
        else
        {
            return false;
        }

        return true;


    }


    public void removeTeaIngredients(int quantity)
    {
        StockInventory.Instance.currentIngredientStocks.flour = StockInventory.Instance.currentIngredientStocks.flour - conditions.forTea.flour * quantity;
        StockInventory.Instance.currentIngredientStocks.besan = StockInventory.Instance.currentIngredientStocks.besan - conditions.forTea.besan * quantity;
        StockInventory.Instance.currentIngredientStocks.spice = StockInventory.Instance.currentIngredientStocks.spice - conditions.forTea.spice * quantity;
        StockInventory.Instance.currentIngredientStocks.milk = StockInventory.Instance.currentIngredientStocks.milk - conditions.forTea.milk * quantity;
        StockInventory.Instance.currentIngredientStocks.potato = StockInventory.Instance.currentIngredientStocks.potato - conditions.forTea.potato * quantity;
        StockInventory.Instance.currentIngredientStocks.sugar = StockInventory.Instance.currentIngredientStocks.sugar - conditions.forTea.sugar  *quantity;
        StockInventory.Instance.currentIngredientStocks.tealeaves = StockInventory.Instance.currentIngredientStocks.tealeaves - conditions.forTea.tea_leaves * quantity;
        StockInventory.Instance.currentIngredientStocks.oil = StockInventory.Instance.currentIngredientStocks.oil - conditions.forTea.oil * quantity;

    }

    public void removePakoraIngredients(int quantity)
    {
        StockInventory.Instance.currentIngredientStocks.flour = StockInventory.Instance.currentIngredientStocks.flour - conditions.forPakora.flour * quantity;
        StockInventory.Instance.currentIngredientStocks.besan = StockInventory.Instance.currentIngredientStocks.besan - conditions.forPakora.besan * quantity;
        StockInventory.Instance.currentIngredientStocks.spice = StockInventory.Instance.currentIngredientStocks.spice - conditions.forPakora.spice * quantity;
        StockInventory.Instance.currentIngredientStocks.milk = StockInventory.Instance.currentIngredientStocks.milk - conditions.forPakora.milk * quantity;
        StockInventory.Instance.currentIngredientStocks.potato = StockInventory.Instance.currentIngredientStocks.potato - conditions.forPakora.potato * quantity;
        StockInventory.Instance.currentIngredientStocks.sugar = StockInventory.Instance.currentIngredientStocks.sugar - conditions.forPakora.sugar * quantity;
        StockInventory.Instance.currentIngredientStocks.tealeaves = StockInventory.Instance.currentIngredientStocks.tealeaves - conditions.forPakora.tea_leaves * quantity;
        StockInventory.Instance.currentIngredientStocks.oil = StockInventory.Instance.currentIngredientStocks.oil - conditions.forPakora.oil * quantity;

    }

    public void removePaneerTikkaIngredients(int quantity)
    {
        StockInventory.Instance.currentIngredientStocks.flour = StockInventory.Instance.currentIngredientStocks.flour - conditions.forPaneerTikka.flour * quantity;
        StockInventory.Instance.currentIngredientStocks.besan = StockInventory.Instance.currentIngredientStocks.besan - conditions.forPaneerTikka.besan * quantity;
        StockInventory.Instance.currentIngredientStocks.spice = StockInventory.Instance.currentIngredientStocks.spice - conditions.forPaneerTikka.spice * quantity;
        StockInventory.Instance.currentIngredientStocks.milk = StockInventory.Instance.currentIngredientStocks.milk - conditions.forPaneerTikka.milk * quantity;
        StockInventory.Instance.currentIngredientStocks.potato = StockInventory.Instance.currentIngredientStocks.potato - conditions.forPaneerTikka.potato * quantity;
        StockInventory.Instance.currentIngredientStocks.sugar = StockInventory.Instance.currentIngredientStocks.sugar - conditions.forPaneerTikka.sugar * quantity;
        StockInventory.Instance.currentIngredientStocks.tealeaves = StockInventory.Instance.currentIngredientStocks.tealeaves - conditions.forPaneerTikka.tea_leaves * quantity;
        StockInventory.Instance.currentIngredientStocks.oil = StockInventory.Instance.currentIngredientStocks.oil - conditions.forPaneerTikka.oil * quantity;

    }
    bool checkConditionForPakora(int quantity)
    {
        if (StockInventory.Instance.currentIngredientStocks.flour >= conditions.forPakora.flour * quantity)
        {
            
        }
        else
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan >= conditions.forPakora.besan * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.spice >= conditions.forPakora.spice * quantity)
        {
         
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.milk >= conditions.forPakora.milk * quantity)
        {
         
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.potato >= conditions.forPakora.potato * quantity)
        {
          
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.sugar >= conditions.forPakora.sugar * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.tealeaves >= conditions.forPakora.tea_leaves * quantity)
        {
        
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.oil >= conditions.forPakora.oil * quantity)
        {
          
        }
        else
        {
            return false;
        }

        return true;


    }

    bool checkConditionForPaneerTikka(int quantity)
    {
        if (StockInventory.Instance.currentIngredientStocks.flour >= conditions.forPaneerTikka.flour * quantity)
        {
           
        }
        else
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan >= conditions.forPaneerTikka.besan * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.spice >= conditions.forPaneerTikka.spice * quantity)
        {
         
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.milk >= conditions.forPaneerTikka.milk * quantity)
        {
          
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.potato >= conditions.forPaneerTikka.potato * quantity)
        {
            
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.sugar >= conditions.forPaneerTikka.sugar * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.tealeaves >= conditions.forPaneerTikka.tea_leaves * quantity)
        {
           
        }
        else
        {
            return false;
        }

        if (StockInventory.Instance.currentIngredientStocks.oil >= conditions.forPaneerTikka.oil * quantity)
        {
          
        }
        else
        {
            return false;
        }

        return true;


    }



    bool checkConditionForSamosa()
    {
        if( StockInventory.Instance.currentIngredientStocks.potato < conditions.forSamosa.potato)
        {
            return false;
        }
        else
        {
            StockInventory.Instance.currentIngredientStocks.potato -= conditions.forSamosa.potato;
        }
        if (StockInventory.Instance.currentIngredientStocks.flour< conditions.forSamosa.flour)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.spice < conditions.forSamosa.spice)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.oil < conditions.forSamosa.oil)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.besan < conditions.forSamosa.besan)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.tealeaves < conditions.forSamosa.tea_leaves)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.sugar < conditions.forSamosa.sugar)
        {
            return false;
        }
        if (StockInventory.Instance.currentIngredientStocks.milk < conditions.forSamosa.milk)
        {
            return false;
        }
        return true;
    }
}

    



