using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVehicle : MonoBehaviour
{
   public int currentVehicle;
    public ExtShopManager shopManager;
    public int[] speeds;
    public int speed;
    public static GetVehicle Instance { get; set; }
    public GameObject[] CurrVehicle;

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
        currentVehicle = GameManager.Instance.currentVehicleUpgrade;
        Debug.Log(currentVehicle);
        CurrVehicle[currentVehicle - 1].SetActive(true);
        this.GetComponent<Animator>().speed = speeds[currentVehicle - 1];
    }

    public void StartRide()
    {
        this.GetComponent<Animator>().Play("VehicleAnim");
    }
}
