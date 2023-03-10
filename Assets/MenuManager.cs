using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
	private static MenuManager _instance;
	public static MenuManager Instance { get { return _instance; } }
	public GameObject SideMenu;
	public GameObject ShopMenu;
	public GameObject StorageMenu;
	public GameObject FoodEngineMenu;
	public GameObject PickupMenu;
	public GameObject TransformMenu;
	
	

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
		ChangeMenu("side");
	}

	public void ChangeMenu(string name)
	{
		ResetAll();

		if (name == "shop")
		{
			ShopMenu.SetActive(true);
		}

		if (name == "storage")
		{
			StorageMenu.SetActive(true);
		}
		if (name == "foodengine")
		{
			FoodEngineMenu.SetActive(true);
		}
		if (name == "side")
		{
			SideMenu.SetActive(true);
			
		}
		if (name == "pickup")
		{
			PickupMenu.SetActive(true);

		}
		if (name == "transform")
		{
			TransformMenu.SetActive(true);

		}


	}

	void ResetAll()
	{
		SideMenu.SetActive(false);
		ShopMenu.SetActive(false);
		StorageMenu.SetActive(false);
		FoodEngineMenu.SetActive(false);
		PickupMenu.SetActive(false);
		TransformMenu.SetActive(false);
	}

}