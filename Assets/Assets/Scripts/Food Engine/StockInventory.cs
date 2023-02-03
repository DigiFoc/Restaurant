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
        public float potato = 1;
        public TMP_Text PotatoText;
        public float flour = 1;
        public TMP_Text FlourText;
        public float spice = 1;
        public TMP_Text SpiceText;
        public float oil = 1;
        public TMP_Text OilText;
        public float besan = 1;
        public TMP_Text BesanText;
        public float sugar = 1;
        public TMP_Text SugarText;
        public float milk = 1;
        public TMP_Text MilkText;
        public float tealeaves = 1;
        public TMP_Text TeaLeavesText;
    }


    [SerializeField]

    [System.Serializable]
    public class IngredientsPrice
    {
        public int potato = 10;
        public int flour = 30;
        public int spice = 1;
        public int oil = 180;
        public int besan = 80;
        public int tea_leaves = 10;
        public int sugar = 40;
        public int milk = 60;
    }
    [SerializeField]

    public IngredientStocks currentIngredientStocks;
    public IngredientsPrice ingredientsPrice;

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
