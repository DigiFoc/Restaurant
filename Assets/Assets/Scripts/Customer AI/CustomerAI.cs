using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]

public class CustomerAI : MonoBehaviour
{

    Rigidbody rb;
    NavMeshAgent theAgent;
    CapsuleCollider theCollider;
    Animator anim;

    [System.Serializable]
    public class Information
    {
        public string Gender;
        public string name;
        public int hutNo;
        public string emotion;
        public string foodOrder;
        public int quantity;
        public int amountToPay;
     
    }
    [SerializeField]


    [System.Serializable]
    public class DestinationsInfo
    {
        [Header("The places AI can visit Randomly")]
        public Transform[] RandomPlaces;
    }
    [SerializeField]

    public Information AI_Information;
    public DestinationsInfo destinations;
    public HutsManager hutManager;


    public int amount;
  bool countTime = false;
    public float WaitingTime;
    public int ratingStar;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        theAgent = GetComponent<NavMeshAgent>();
        this.gameObject.tag = "Customer";
        if (hutManager == null)
            hutManager = GameObject.Find("Huts Manager").GetComponent<HutsManager>();
    }
    void Start()
    {

        //SetDestination(destinations.RandomPlaces[0]);
        FindHut();

    }


    void Update()
    {
        HandleAnimations();

        if (countTime)
        {
            WaitingTime += Time.deltaTime;
        }

    }

    public void SetDestination(Transform destination)
    {
        theAgent.SetDestination(destination.position);
    }

    public void HandleAnimations()
    {
        if (theAgent.velocity != Vector3.zero)
        {
            anim.SetBool("Move", true);
        }
        else
            anim.SetBool("Move", false);
    }

    public void FindHut()
    {
        int hutNo = 0;
        hutNo = FindEmptyHut();
        if (hutNo == 0)
            Debug.Log("No Hut Is Empty");
        AI_Information.hutNo = hutNo;
    }
    public int FindEmptyHut()
    {
        if (!hutManager.hut1.isOccupied)
        {
            SetDestination(hutManager.hut1.locationOfHut);
            hutManager.hut1.isOccupied = true;
            hutManager.hut1.customerName = AI_Information.name;

            return 1;
        }
        if (!hutManager.hut2.isOccupied)
        {
            SetDestination(hutManager.hut2.locationOfHut);
            hutManager.hut2.isOccupied = true;
            hutManager.hut2.customerName = AI_Information.name;
            return 2;
        }
        if (!hutManager.hut3.isOccupied)
        {
            SetDestination(hutManager.hut3.locationOfHut);
            hutManager.hut3.isOccupied = true;
            hutManager.hut3.customerName = AI_Information.name;
            return 3;
        }
        if (!hutManager.hut4.isOccupied)
        {
            SetDestination(hutManager.hut4.locationOfHut);
            hutManager.hut4.isOccupied = true;
            hutManager.hut4.customerName = AI_Information.name;
            return 4;
        }

        return 0;

    }

    public void SetEmotion(string Emotion)
    {
        string emotionString = "";
        if (Emotion == "Thinking")  //Index ID = 12
        {
            emotionString = "<sprite=12>";
        }
        if (Emotion == "Happy")   //Index ID = 04
        {
            emotionString = "<sprite=4>";
        }
        if (Emotion == "Sad")     //IndexID = 15
        {
            emotionString = "<sprite=15>";
        }
        if (Emotion == "Frustrated") //IndexID = 10
        {
            emotionString = "<sprite=10>";
        }

        hutManager.SetEmotionStatus(AI_Information.hutNo, emotionString);
    }

    public void OrderFood()
    {
        
        AI_Information.foodOrder = StockInventory.Instance.GenerateRandomFood();
        AI_Information.quantity = Random.Range(1, 5);
        AI_Information.amountToPay = StockInventory.Instance.CalculateAmount(AI_Information.foodOrder, AI_Information.quantity);


        SetFoodOrderDisplay(AI_Information.foodOrder, AI_Information.quantity);

        if (AI_Information.hutNo == 1)
        {
            hutManager.hut1.hutMarker.SetActive(true);


            hutManager.hut1.hutMarker.GetComponent<MarkerTrigger>().foodName = AI_Information.foodOrder;
            hutManager.hut1.hutMarker.GetComponent<MarkerTrigger>().quntity = AI_Information.quantity;
            hutManager.hut1.hutMarker.GetComponent<MarkerTrigger>().customer = this;

        }
        if (AI_Information.hutNo == 2)
        {
            hutManager.hut2.hutMarker.SetActive(true);
            hutManager.hut2.hutMarker.GetComponent<MarkerTrigger>().foodName = AI_Information.foodOrder;
            hutManager.hut2.hutMarker.GetComponent<MarkerTrigger>().quntity = AI_Information.quantity;
            hutManager.hut2.hutMarker.GetComponent<MarkerTrigger>().customer = this;
        }
        if (AI_Information.hutNo == 3)
        {
            hutManager.hut3.hutMarker.SetActive(true);
            hutManager.hut3.hutMarker.GetComponent<MarkerTrigger>().foodName = AI_Information.foodOrder;
            hutManager.hut3.hutMarker.GetComponent<MarkerTrigger>().quntity = AI_Information.quantity;
            hutManager.hut3.hutMarker.GetComponent<MarkerTrigger>().customer = this;
        }
    }



    public void SetFoodOrderDisplay(string food, int quantity)
    {

        TextManager.Instance.ShowToast("New Customer", 5);
        TextManager.Instance.ShowToast("Please Check", 2);
        string foodString = "";
        if (food == "samosa")
        {
            foodString = "<sprite=8>";
        }
        if (food == "paneerTikka")
        {
            foodString = "<sprite=9>";
        }
        if (food == "pakori")
        {
            foodString = "<sprite=10>";
        }
        if (food == "tea")
        {
            foodString = "<sprite=11>";
        }

        hutManager.SetHutStatus(AI_Information.hutNo, foodString, AI_Information.quantity);
        countTime = true;
    }


    public void ServeFood()
    {
        int newCoins = StockInventory.Instance.coins;
     
        countTime = false;
        if (WaitingTime <= 15.0f)
        {
            ratingStar = 1;
            newCoins += (int)(AI_Information.amountToPay * (100 / 100));
            TextManager.Instance.ShowToast("Order Served,100%", 3);
        }
        if (WaitingTime > 15.0f && WaitingTime <= 20.0f)
        {

            ratingStar = 2;
            newCoins += (int)(AI_Information.amountToPay * (75 / 100));
            TextManager.Instance.ShowToast("Order Served,75%", 3);
        }

        if (WaitingTime > 30.0f)
        {
            ratingStar = 3;
            newCoins += (int)(AI_Information.amountToPay * (50 / 100));
            TextManager.Instance.ShowToast("Order Served,50%",3);
        }


        StockInventory.Instance.ChangeCoinsTo(newCoins);



    }
}
