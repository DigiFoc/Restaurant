using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReceiptGenerator : MonoBehaviour
{
    int MaxSlots = 2;
    public int CurrSlots = 0;
    public Transform TextHolder;
    public Transform FoodTextHolder;
    public GameObject ItemPrefab;
    public TMP_Text GrandTotal;
    public int amount = 0;
    public GameObject limitWarning;
    public GameObject limitWarning2;
    public GameObject cannotCookWarning;
    public GameObject buildBtn;

    public static ReceiptGenerator Instance { get; set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            //Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        GrandTotal.text = "Total Rs. 0";
		buildBtn.SetActive(false);
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
		CheckBtn();
		
    }

	public void CheckBtn()
	{
		int childrenCount = FoodTextHolder.transform.childCount;
		if(childrenCount>0)
		{
			buildBtn.SetActive(true);	
		}
		else
		{
			buildBtn.SetActive(false);
		}
	
	
	}


    

    public void AddPotato(int count)
    {
		
        string Objname = "potato";
		Debug.Log("Yo");
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
			
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
                return;
            }
        }
		Debug.Log("Yoo");
		CurrSlots = childrenCount;
        if (CurrSlots < MaxSlots)
        {
			Debug.Log("Yooo");
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=0>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(2);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
			MakeAmount();
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddFlour(int count)
    {
        string Objname = "flour";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
                return;
            }
        }
		CurrSlots = childrenCount;
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=1>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(1);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
			MakeAmount();
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddSpice(int count)
    {
        string Objname = "spice";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);MakeAmount();
                return;
            }
        }CurrSlots = childrenCount;
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=2>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(1);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);MakeAmount();
			MakeAmount();
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddOil(int count)
    {
        string Objname = "oil";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
				MakeAmount();
                return;
            }
        }
		CurrSlots = childrenCount;
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=3>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(2);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count);
			MakeAmount();
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddBesan(int count)
    {
        string Objname = "besan";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
                return;
            }
        }
		CurrSlots = childrenCount;
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=4>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(1);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }

    public void AddSugar(int count)
    {
        string Objname = "sugar";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
                return;
            }
        }
		CurrSlots = childrenCount;
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=5>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(2);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
        }
        else
        {
            StartCoroutine(ShowWarning());
        }
    }

    public void AddTeaLeaves(int count)
    {
        string Objname = "tea_leaves";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
                return;
            }
        }
		CurrSlots = childrenCount;
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=6>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(3);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
        }
        else
        {
            StartCoroutine(ShowWarning());
        }
    }

    public void AddMilk(int count)
    {
        string Objname = "milk";
        int childrenCount = TextHolder.transform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            if (TextHolder.transform.GetChild(i).name == Objname)
            {
                TextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
                return;
            }
        }
		CurrSlots = childrenCount;
        if (CurrSlots < MaxSlots)
        {
            GameObject ItemManager = Instantiate(ItemPrefab, TextHolder.transform);
            ItemManager.name = Objname;
            ItemManager.GetComponent<ItemHandler>().name = Objname;
            ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=7>");
            ItemManager.GetComponent<ItemHandler>().AssignPrice(5);
            ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); MakeAmount();
        }
        else
        {
            StartCoroutine(ShowWarning());
        }

    }


    public void AddTea(int count)
    {
       
       
        DisableCookWarning();
        string Objname = "Tea";
        int childrenCount = FoodTextHolder.transform.childCount;
		if(childrenCount==0)
		{
			 if (!FoodEngine.Instance.buildFood("Tea", count))
                {

                    StartCoroutine("ShowCookWarning");
                    return;
                }
				GameObject ItemManager = Instantiate(ItemPrefab, FoodTextHolder.transform);
				ItemManager.name = Objname;
				ItemManager.GetComponent<ItemHandler>().name = Objname;
				ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=11>");
				ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
				ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); 
		}
		else
		{
			for (int i = 0; i < childrenCount; i++)
			{
				
				if (FoodTextHolder.transform.GetChild(i).name == Objname)
				{
					
					if (!FoodEngine.Instance.buildFood("Tea", FoodTextHolder.transform.GetChild(i).GetComponent<ItemHandler>().quantity + count ))
					{

						StartCoroutine("ShowCookWarning");
						return;
					}
					FoodTextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
					DisableCookWarning();
					return;
				}
			}
				
			if (!FoodEngine.Instance.buildFood("Tea", count)) ///Applied when Slot is more then 1
			{

				StartCoroutine("ShowCookWarning");
				return;
			}
		
			CurrSlots = childrenCount;
			if (CurrSlots < MaxSlots)
			{
				GameObject ItemManager = Instantiate(ItemPrefab, FoodTextHolder.transform);
				ItemManager.name = Objname;
				ItemManager.GetComponent<ItemHandler>().name = Objname;
				ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=11>");
				ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
				ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); 
			}
			else
			{
				StartCoroutine(ShowFoodWarning());
			}

		}

    }

    public void AddSamosa(int count)
    {
       
        DisableCookWarning();
        string Objname = "Samosa";
        int childrenCount = FoodTextHolder.transform.childCount;
		if(childrenCount==0)
		{
			 if (!FoodEngine.Instance.buildFood("Samosa", count))
                {

                    StartCoroutine("ShowCookWarning");
                    return;
                }
				GameObject ItemManager = Instantiate(ItemPrefab, FoodTextHolder.transform);
				ItemManager.name = Objname;
				ItemManager.GetComponent<ItemHandler>().name = Objname;
				ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=08>");
				ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
				ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); 
		}
		else
		{
			for (int i = 0; i < childrenCount; i++)
			{
				
				if (FoodTextHolder.transform.GetChild(i).name == Objname)
				{
					
					if (!FoodEngine.Instance.buildFood("Samosa", FoodTextHolder.transform.GetChild(i).GetComponent<ItemHandler>().quantity + count ))
					{

						StartCoroutine("ShowCookWarning");
						return;
					}
					FoodTextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
					DisableCookWarning();
					return;
				}
			}
				
			if (!FoodEngine.Instance.buildFood("Samosa", count)) ///Applied when Slot is more then 1
			{

				StartCoroutine("ShowCookWarning");
				return;
			}
		
			CurrSlots = childrenCount;
			if (CurrSlots < MaxSlots)
			{
				GameObject ItemManager = Instantiate(ItemPrefab, FoodTextHolder.transform);
				ItemManager.name = Objname;
				ItemManager.GetComponent<ItemHandler>().name = Objname;
				ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=08>");
				ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
				ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); 
			}
			else
			{
				StartCoroutine(ShowFoodWarning());
			}

		}
    }

    public void AddPakori(int count)
    {
       
        DisableCookWarning();
        string Objname = "Pakori";
        int childrenCount = FoodTextHolder.transform.childCount;
		if(childrenCount==0)
		{
			 if (!FoodEngine.Instance.buildFood("Pakori", count))
                {

                    StartCoroutine("ShowCookWarning");
                    return;
                }
				GameObject ItemManager = Instantiate(ItemPrefab, FoodTextHolder.transform);
				ItemManager.name = Objname;
				ItemManager.GetComponent<ItemHandler>().name = Objname;
				ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=10>");
				ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
				ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); 
		}
		else
		{
			for (int i = 0; i < childrenCount; i++)
			{
				
				if (FoodTextHolder.transform.GetChild(i).name == Objname)
				{
					
					if (!FoodEngine.Instance.buildFood("Pakori", FoodTextHolder.transform.GetChild(i).GetComponent<ItemHandler>().quantity + count ))
					{

						StartCoroutine("ShowCookWarning");
						return;
					}
					FoodTextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
					DisableCookWarning();
					return;
				}
			}
				
			if (!FoodEngine.Instance.buildFood("Pakori", count)) ///Applied when Slot is more then 1
			{

				StartCoroutine("ShowCookWarning");
				return;
			}
		
			CurrSlots = childrenCount;
			if (CurrSlots < MaxSlots)
			{
				GameObject ItemManager = Instantiate(ItemPrefab, FoodTextHolder.transform);
				ItemManager.name = Objname;
				ItemManager.GetComponent<ItemHandler>().name = Objname;
				ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=10>");
				ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
				ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); 
			}
			else
			{
				StartCoroutine(ShowFoodWarning());
			}

		}
    }

    public void AddPaneerTikka(int count)
    {
        
        DisableCookWarning();
        string Objname = "PaneerTikka";
        int childrenCount = FoodTextHolder.transform.childCount;
		if(childrenCount==0)
		{
			 if (!FoodEngine.Instance.buildFood("PaneerTikka", count))
                {

                    StartCoroutine("ShowCookWarning");
                    return;
                }
				GameObject ItemManager = Instantiate(ItemPrefab, FoodTextHolder.transform);
				ItemManager.name = Objname;
				ItemManager.GetComponent<ItemHandler>().name = Objname;
				ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=09>");
				ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
				ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); 
		}
		else
		{
			for (int i = 0; i < childrenCount; i++)
			{
				
				if (FoodTextHolder.transform.GetChild(i).name == Objname)
				{
					
					if (!FoodEngine.Instance.buildFood("PaneerTikka", FoodTextHolder.transform.GetChild(i).GetComponent<ItemHandler>().quantity + count ))
					{

						StartCoroutine("ShowCookWarning");
						return;
					}
					FoodTextHolder.transform.GetChild(i).GetComponent<ItemHandler>().IncreaseQuantity(count);
					DisableCookWarning();
					return;
				}
			}
				
			if (!FoodEngine.Instance.buildFood("PaneerTikka", count)) ///Applied when Slot is more then 1
			{

				StartCoroutine("ShowCookWarning");
				return;
			}
		
			CurrSlots = childrenCount;
			if (CurrSlots < MaxSlots)
			{
				GameObject ItemManager = Instantiate(ItemPrefab, FoodTextHolder.transform);
				ItemManager.name = Objname;
				ItemManager.GetComponent<ItemHandler>().name = Objname;
				ItemManager.GetComponent<ItemHandler>().AssignIcon("<sprite=09>");
				ItemManager.GetComponent<ItemHandler>().AssignPrice(10);
				ItemManager.GetComponent<ItemHandler>().IncreaseQuantity(count); 
			}
			else
			{
				StartCoroutine(ShowFoodWarning());
			}

		}

    }
    
    IEnumerator ShowWarning()
    {
        limitWarning.SetActive(true);
        yield return new WaitForSeconds(4);
        limitWarning.SetActive(false);

    }
	public void DisableWarning()
	{
		limitWarning.SetActive(false);
	}
	
	IEnumerator ShowFoodWarning()
    {
        limitWarning2.SetActive(true);
        yield return new WaitForSeconds(4);
        limitWarning2.SetActive(false);

    }
	public void DisableFoodWarning()
	{
		limitWarning2.SetActive(false);
	}

    public IEnumerator ShowCookWarning()
    {
        cannotCookWarning.SetActive(true);
        yield return new WaitForSeconds(4);
        cannotCookWarning.SetActive(false);
    }

    public void DisableCookWarning()
    {
        cannotCookWarning.SetActive(false);
    }


}
