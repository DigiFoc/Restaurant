using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReceiptGenerator : MonoBehaviour
{
    int MaxSlots = 2;
    int CurrSlots = 0;
    public Transform TextHolder;
    public GameObject ItemPrefab;
    public TMP_Text GrandTotal;
    int amount = 0;
    public GameObject limitWarning;
    

    public static ReceiptGenerator Instance { get; set; }
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

    void Start()
    {
        GrandTotal.text = "Total Rs. 0";
    }

    public void MakeAmount()
    {
        StartCoroutine(FetchAmount());
    }

    public IEnumerator FetchAmount()
    {
        yield return new WaitForSeconds(0.2f);
        int childrenCount = TextHolder.transform.childCount;
        amount = 0;
        for (int i = 0; i < childrenCount; i++)
        {
            amount = amount + TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().amount;
            //Debug.Log(amount);
        }
        GrandTotal.text = "Total Rs. " + amount.ToString();
        CurrSlots = childrenCount;


    }

    public void AddPotato(int count)
    {
        string Objname = "Potato";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=0>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddFlour(int count)
    {
        string Objname = "Flour";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=1>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(30);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddSpice(int count)
    {
        string Objname = "Spice";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=2>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(1);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddOil(int count)
    {
        string Objname = "Oil";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=3>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(180);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddBesan(int count)
    {
        string Objname = "Besan";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=4>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(80);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddSugar(int count)
    {
        string Objname = "Sugar";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=5>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(40);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }
    }

    public void AddTeaLeaves(int count)
    {
        string Objname = "TeaLeaves";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=6>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }
    }

    public void AddMilk(int count)
    {
        string Objname = "Milk";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=7>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(80);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }


    public void AddTea(int count)
    {
       
        string Objname = "Tea";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                if (!FoodEngine.Instance.buildFood("Tea", TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().quantity + count ))
                {
                    Debug.Log("cannot build food");
                    return;
                }
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=11>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(10); //Price to be changed
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddSamosa(int count)
    {
       
        
        string Objname = "Samosa";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                
                if (!FoodEngine.Instance.buildFood("Samosa", TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().quantity + count ))
                {
                    Debug.Log("cannot build food");
                    return;
                }
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=08>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddPakori(int count)
    {
        string Objname = "Pakori";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                if (!FoodEngine.Instance.buildFood("Pakori", TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().quantity + count  ))
                {
                    Debug.Log("cannot build food");
                    return;
                }
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=10>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddPaneerTikka(int count)
    {
        string Objname = "Paneer Tikka";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                if (!FoodEngine.Instance.buildFood("PaneerTikka", TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().quantity + count ))
                {
                    Debug.Log("cannot build food");
                    return;
                }
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=09>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }
    
    IEnumerator ShowWarning()
    {
        limitWarning.SetActive(true);
        yield return new WaitForSeconds(4);
        limitWarning.SetActive(false);

    }
}
