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
	bool isOnRoad;
	 public GameObject button;
	 public ReceiptGenerator currSlots;
	public UnityEngine.UI.Slider VehicleSlider;
        private void Start()
    {
        VehicleSlider.value=0;

    }
    public void OrderGooods()
    {
        items = ItemHolder.GetComponentsInChildren<ItemHandler>();
		if(ItemHolder.transform.childCount==0)
		{
			return;
		}
        StartCoroutine(OrderGoooods());
		
    }

    public void CloseShop()
    {
        foreach (Transform child in ItemHolder.transform)
        {
            child.gameObject.GetComponent<ItemHandler>().RemoveMe();

        }
		
    }

    IEnumerator OrderGoooods()
    {
        MenuManager.Instance.ChangeMenu("side");
        yield return new WaitForSeconds(0.5f);
        bool temp = BuildFoood();
		currSlots.CurrSlots = 0;
       
        if (!temp)
        {
            TextManager.Instance.ShowToast("Coins are not enough", 2);
            yield return new WaitForSeconds(0.1f);
            foreach (Transform child in ItemHolder.transform)
            {
                child.gameObject.GetComponent<ItemHandler>().RemoveMe();

            }
        }
        else
        {
            TextManager.Instance.ShowToast("Ordered", 2);
            int newCoins = StockInventory.Instance.coins - totalPrice;

            StockInventory.Instance.ChangeCoinsTo(newCoins);
            GetVehicle.Instance.StartRide();
			SetButtonStatus(true);
           
            foreach (Transform child in ItemHolder.transform)
            {
                child.gameObject.GetComponent<ItemHandler>().RemoveMe();

            }
			float reachTime=50 / (GetVehicle.Instance.speeds[GetVehicle.Instance.currentVehicle - 1]);
			VehicleSlider.maxValue=(int)reachTime;
			for(int i=0;i<(int)reachTime;i++)
				{
					yield return new WaitForSeconds(1);
					VehicleSlider.value=i+1;
				}
            TextManager.Instance.ShowToast("Recieved", 2);
			SetButtonStatus(false);
            SoundManager.Instance.PlaySound("horn");
            for (int i = 0; i < items.Length; i++)
        {
            StockInventory.Instance.AddStocks(itemNames[i], quantities[i]);
			Debug.Log(itemNames[i]);
			Debug.Log(quantities[i]);
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
	
	void SetButtonStatus(bool value)
	{
		button.SetActive(!value);
	}
}
