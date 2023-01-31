using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockInventory : MonoBehaviour
{

    [System.Serializable]
    public class IngredientStocks
    {
        public int potato = 1;
        
        public int flour = 1;
        public int spice = 1;
        public int oil = 1;
        public int besan = 1;
        public int sugar = 1;
        public int milk = 1;
    }
    [SerializeField]

    public IngredientStocks currentIngredientStocks;

    [System.Serializable]
    public class FoodStock
    {
        public int samosa = 1;
        public GameObject samosaUI;
        public int paneerTikka = 1;
        public GameObject pannerTikkaUI;
        public int tea = 1;
        public GameObject teaUI;
        public int pakora = 1;
        public GameObject pakoraUI;
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

        UpdateUI();
    }


    void Update()
    {
        
    }

    public void UpdateUI()
    {
        currentFoodStocks.samosaUI.GetComponent<Text>().text = currentFoodStocks.samosa.ToString();
        currentFoodStocks.pakoraUI.GetComponent<Text>().text = currentFoodStocks.pakora.ToString();
        currentFoodStocks.teaUI.GetComponent<Text>().text = currentFoodStocks.tea.ToString();
        currentFoodStocks.pannerTikkaUI.GetComponent<Text>().text = currentFoodStocks.paneerTikka.ToString();

    }
}
