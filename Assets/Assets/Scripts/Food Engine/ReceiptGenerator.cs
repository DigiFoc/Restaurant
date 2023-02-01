using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ReceiptGenerator : MonoBehaviour
{
    [Header("Connect it to level Manager")]
    public int maxSlots = 2; 
    [System.Serializable]
    public class Slot
    {
        public bool isOccupied = false;
        public string name = "";
        public int quantity = 0;
        public int amount = 0;
    }
    [SerializeField]

    public TMP_Text[] slotsText = new TMP_Text[4] ;

    public Slot[] slots = new Slot[4];

    public GameObject limitWarning;
    public GameObject totalAmount;
    public int total; //This is total Amount
    int i = 0;
    
    
     

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void GetPotato(int quantity)
    {
         i = 0;

        //Find If Any Is Already Present
        foreach (Slot  slot in slots)
        {
            i += 1;
            if (slot.name.Equals("Potato    "))
            {
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.potato;
             
                UpdateUI(i);
                DoTotal();
                return;
            }
           
        }
        i = 0;

        foreach (Slot slot in slots)
        {
            i = i + 1;
            if (!slot.isOccupied)
            {
                if (i > maxSlots)
                {
                    StartCoroutine(ShowWarning());
                    return;
                }
                slot.isOccupied = true;
                slot.name = "Potato    ";
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.potato;
                UpdateUI(i);
                DoTotal();
                return;
            }
        }
    }

    public void GetFlour(int quantity)
    {
         i = 0;

        //Find If Any Is Already Present
        foreach (Slot slot in slots)
        {
            i += 1;
            if (slot.name.Equals("Flour     "))
            {
                slot.isOccupied = true;
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.flour;
                UpdateUI(i);
                DoTotal();
                return;
            }

        }
        i = 0;

        foreach (Slot slot in slots)
        {
            i = i + 1;
            if (!slot.isOccupied)
            {
                if(i > maxSlots)
                {
                    
                    StartCoroutine(ShowWarning());
                    return;
                }
                slot.isOccupied = true;
                slot.name = "Flour     ";
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.flour;
                UpdateUI(i);
                DoTotal();
                return;
            }
        }
    }

    public void GetSpice(int quantity)
    {
         i = 0;

        //Find If Any Is Already Present
        foreach (Slot slot in slots)
        {
            i += 1;
            if (slot.name.Equals("Spice     "))
            {
                slot.isOccupied = true;
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.spice;
                UpdateUI(i);
                DoTotal();
                return;
            }

        }
        i = 0;

        foreach (Slot slot in slots)
        {
            i = i + 1;
            if (!slot.isOccupied)
            {
                if (i > maxSlots)
                {
                    StartCoroutine(ShowWarning());
                    return;
                }
                slot.isOccupied = true;
                slot.name = "Spice     ";
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.spice;
                UpdateUI(i);
                DoTotal();
                return;
            }
        }
    }

    public void GetOil(int quantity)
    {
        i = 0;

        //Find If Any Is Already Present
        foreach (Slot slot in slots)
        {
            i += 1;
            if (slot.name.Equals("Oil       "))
            {
                slot.isOccupied = true;
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.oil;
                UpdateUI(i);
                DoTotal();
                return;
            }

        }
        i = 0;

        foreach (Slot slot in slots)
        {
            i = i + 1;
            if (!slot.isOccupied)
            {
                if (i > maxSlots)
                {
                    StartCoroutine(ShowWarning());
                    return;
                }
                slot.isOccupied = true;
                slot.name = "Oil       ";
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.oil;
                UpdateUI(i);
                DoTotal();
                return;
            }
        }
    }

    public void GetBesan(int quantity)
    {
        i = 0;

        //Find If Any Is Already Present
        foreach (Slot slot in slots)
        {
            i += 1;
            if (slot.name.Equals("Besan     "))
            {
                slot.isOccupied = true;
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.besan;
                UpdateUI(i);
                DoTotal();
                return;
            }

        }
        i = 0;

        foreach (Slot slot in slots)
        {
            i = i + 1;
            if (!slot.isOccupied)
            {
                if (i > maxSlots)
                {
                    StartCoroutine(ShowWarning());
                    return;
                }
                slot.isOccupied = true;
                slot.name = "Besan     ";
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.besan;
                UpdateUI(i);
                DoTotal();
                return;
            }
        }
    }

    public void GetSugar(int quantity)
    {
        i = 0;

        //Find If Any Is Already Present
        foreach (Slot slot in slots)
        {
            i += 1;
            if (slot.name.Equals("Sugar     "))
            {
                slot.isOccupied = true;
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.sugar;
                UpdateUI(i);
                DoTotal();
                return;
            }

        }
        i = 0;

        foreach (Slot slot in slots)
        {
            i = i + 1;
            if (!slot.isOccupied)
            {
                if (i > maxSlots)
                {
                    StartCoroutine(ShowWarning());
                    return;
                }
                slot.isOccupied = true;
                slot.name = "Sugar     ";
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.sugar;
                UpdateUI(i);
                DoTotal();
                return;
            }
        }
    }

    public void GetTeaLeaves(int quantity)
    {
        i = 0;

        //Find If Any Is Already Present
        foreach (Slot slot in slots)
        {
            i += 1;
            if (slot.name.Equals("Tea Leaves"))
            {
                slot.isOccupied = true;
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.tea_leaves;
                UpdateUI(i);
                DoTotal();
                return;
            }

        }
        i = 0;

        foreach (Slot slot in slots)
        {
            i = i + 1;
            if (!slot.isOccupied)
            {
                if (i > maxSlots)
                {
                    StartCoroutine(ShowWarning());
                    return;
                }
                slot.isOccupied = true;
                slot.name = "Tea Leaves";
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.tea_leaves;
                slot.quantity += quantity;
                UpdateUI(i);
                DoTotal();
                return;
            }
        }
    }

    public void GetMilk(int quantity)
    {
        i = 0;

        //Find If Any Is Already Present
        foreach (Slot slot in slots)
        {
            i += 1;
            if (slot.name.Equals("Milk      "))
            {
                slot.isOccupied = true;
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.milk;
                UpdateUI(i);
                DoTotal();
                return;
            }

        }
        i = 0;

        foreach (Slot slot in slots)
        {
            i = i + 1;
            if (!slot.isOccupied)
            {
                if (i > maxSlots)
                {
                    StartCoroutine(ShowWarning());
                    return;
                }
                slot.isOccupied = true;
                slot.name = "Milk      ";
                slot.quantity += quantity;
                slot.amount = slot.quantity * StockInventory.Instance.ingredientsPrice.milk;
                UpdateUI(i);
                DoTotal();
                return;
            }
        }
    }


    void UpdateUI(int slotNo)
    {

       
        slotsText[slotNo-1].text =   slots[slotNo-1].name.ToString() + " \t" + slots[slotNo-1].quantity.ToString() +"\t \t"+ slots[slotNo-1].amount.ToString();

        
    }

    void DoTotal()
    {
        total = 0;
        foreach (Slot slot in slots)
        {
            total += slot.amount;

        }
        totalAmount.GetComponent<Text>().text = "Total :- " + total.ToString();
    }

    public void RemoveAll()
    {
        i = 0;
        foreach (Slot slot in slots)
        {
            i++;
            slot.isOccupied = false;
            slot.name = string.Empty;
            slot.quantity = 0;
            slot.amount = 0;
            UpdateUI(i);
            total = 0;
            DoTotal();
        }
    }


    IEnumerator ShowWarning()
    {
        limitWarning.SetActive(true);
        Debug.Log("Hello");
        yield return new WaitForSeconds(4);
        limitWarning.SetActive(false);

    }
}
