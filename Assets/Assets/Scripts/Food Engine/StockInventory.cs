using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StockInventory : MonoBehaviour
{

    [System.Serializable]
    public class IngredientStocks
    {
        public int potato = 1;
        public TMP_Text PotatoText;
        public int flour = 1;
        public TMP_Text FlourText;
        public int spice = 1;
        public TMP_Text SpiceText;
        public int oil = 1;
        public TMP_Text OilText;
        public int besan = 1;
        public TMP_Text BesanText;
        public int sugar = 1;
        public TMP_Text SugarText;
        public int milk = 1;
        public TMP_Text MilkText;
        public int tealeaves = 1;
        public TMP_Text TeaLeavesText;
    }
    [SerializeField]

    public IngredientStocks currentIngredientStocks;

    [System.Serializable]
    public class FoodStock
    {
        public int samosa = 1;
        public int paneerTikka = 1;
        public int tea = 1;
        public int pakora = 1;
        public TMP_Text FoodItemsText;
    }
    [SerializeField]

    public FoodStock currentFoodStocks;

    public static StockInventory Instance { get; set; }
    void Start()
    {
        
    }

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

        UpdateFoodStockUI();
        UpdateIngredientStockUI();
    }


    void Update()
    {
        
    }

    public void UpdateFoodStockUI()
    {
        currentFoodStocks.FoodItemsText.text = "<sprite=8>" + currentFoodStocks.samosa.ToString() + "  <sprite=10>" + currentFoodStocks.pakora.ToString() + "  <sprite=11>" + currentFoodStocks.tea.ToString() + "  <sprite=9>" + currentFoodStocks.paneerTikka.ToString();
    }
    public void UpdateIngredientStockUI()
    {
        currentIngredientStocks.PotatoText.text = "<sprite=0>" + currentIngredientStocks.potato.ToString();
        currentIngredientStocks.FlourText.text = "<sprite=1>" + currentIngredientStocks.flour.ToString();
        currentIngredientStocks.SpiceText.text = "<sprite=2>" + currentIngredientStocks.spice.ToString();
        currentIngredientStocks.OilText.text = "<sprite=3>" + currentIngredientStocks.oil.ToString();
        currentIngredientStocks.BesanText.text = "<sprite=4>" + currentIngredientStocks.besan.ToString();
        currentIngredientStocks.SugarText.text = "<sprite=5>" + currentIngredientStocks.sugar.ToString();
        currentIngredientStocks.MilkText.text = "<sprite=6>" + currentIngredientStocks.milk.ToString();
        currentIngredientStocks.TeaLeavesText.text = "<sprite=7>" + currentIngredientStocks.tealeaves.ToString();
    }

}
