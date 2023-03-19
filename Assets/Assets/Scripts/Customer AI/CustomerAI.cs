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
        public GameObject currentDestination;

     
    }
    [SerializeField]


    [System.Serializable]
    public class DestinationsInfo
    {
        public Transform endPlace;
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
    GameObject currentdestination;
   

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
        this.currentdestination = destination.gameObject;
        theAgent.SetDestination(destination.position);
        AI_Information.currentDestination = destination.gameObject;
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
            hutManager.hut1.customer = this.gameObject;
            hutManager.hut1.customerName = AI_Information.name;

            return 1;
        }
        if (!hutManager.hut2.isOccupied)
        {
            SetDestination(hutManager.hut2.locationOfHut);
            hutManager.hut2.isOccupied = true;
            hutManager.hut2.customer = this.gameObject;
            hutManager.hut2.customerName = AI_Information.name;
            return 2;
        }
        if (!hutManager.hut3.isOccupied)
        {
            SetDestination(hutManager.hut3.locationOfHut);
            hutManager.hut3.isOccupied = true;
            hutManager.hut3.customer = this.gameObject;
            hutManager.hut3.customerName = AI_Information.name;
            return 3;
        }
        if (!hutManager.hut4.isOccupied)
        {
            SetDestination(hutManager.hut4.locationOfHut);
            hutManager.hut4.isOccupied = true;
            hutManager.hut4.customer = this.gameObject;
            hutManager.hut4.customerName = AI_Information.name;
            return 4;
        }
        if (!hutManager.hut5.isOccupied)
        {
            SetDestination(hutManager.hut5.locationOfHut);
            hutManager.hut5.isOccupied = true;
            hutManager.hut5.customer = this.gameObject;
            hutManager.hut5.customerName = AI_Information.name;
            return 5;
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
            ratingStar = 3;
         
            TextManager.Instance.ShowToast("Order Served,100%", 3);
        }
        if (WaitingTime > 15.0f && WaitingTime <= 30.0f)
        {

            ratingStar = 2;
          
            TextManager.Instance.ShowToast("Order Served,75%", 3);
        }

        if (WaitingTime > 30.0f)
        {
            ratingStar = 1;
          
            TextManager.Instance.ShowToast("Order Served,50%",3);
        }

        Debug.Log("New coins are" + newCoins);
        newCoins += AI_Information.amountToPay;
        StockInventory.Instance.ChangeCoinsTo(newCoins);

        Invoke("CurtainOut", 5);

    }

    public void CurtainOut()
    {
        anim.SetBool("Sit", false);
        currentdestination.GetComponent<BenchLocation>().curtainOff();
        Invoke("GetOut", 2);
     

    }
    public void GetOut()
    {
        theAgent.enabled = true;
        theAgent.SetDestination(destinations.endPlace.transform.position);
        Invoke("ResetValues", 2);
    }

    public void ResetValues()
    {
     

        if(AI_Information.hutNo == 1)
        {
            hutManager.hut1.cashToPay = 0;
            hutManager.hut1.customer = null;
            hutManager.hut1.customerName = null;
            hutManager.hut1.Gender = null;
            hutManager.hut1.isOccupied = false;
            hutManager.hut1.Statusorder.text = "Empty";
            hutManager.hut1.TimeLeft.text = "";
            hutManager.ResetHutStatus(1);

        }


        if (AI_Information.hutNo == 2)
        {
            hutManager.hut2.cashToPay = 0;
            hutManager.hut2.customer = null;
            hutManager.hut2.customerName = null;
            hutManager.hut2.Gender = null;
            hutManager.hut2.TimeLeft.text = "";
            hutManager.hut2.Statusorder.text = "Empty";

            hutManager.hut2.isOccupied = false;
            hutManager.ResetHutStatus(2);
        }

        if (AI_Information.hutNo == 3)
        {
            hutManager.hut3.cashToPay = 0;
            hutManager.hut3.customer = null;
            hutManager.hut3.customerName = null;
            hutManager.hut3.Gender = null;
            hutManager.hut3.TimeLeft.text = "";
            hutManager.hut3.Statusorder.text = "Empty";
            hutManager.hut3.isOccupied = false;
            hutManager.ResetHutStatus(3);
        }

        if (AI_Information.hutNo == 4)
        {
            hutManager.hut4.cashToPay = 0;
            hutManager.hut4.customer = null;
            hutManager.hut4.customerName = null;
            hutManager.hut4.Gender = null;
            hutManager.hut4.TimeLeft.text = "";
            hutManager.hut4.Statusorder.text = "Empty";
            hutManager.hut4.isOccupied = false;
            hutManager.ResetHutStatus(4);
        }

        if (AI_Information.hutNo == 5)
        {
            hutManager.hut5.cashToPay = 0;
            hutManager.hut5.customer = null;
            hutManager.hut5.customerName = null;
            hutManager.hut5.TimeLeft.text = "";
            hutManager.hut5.Statusorder.text = "Empty";
            hutManager.hut5.Gender = null;
            hutManager.hut5.isOccupied = false;
            hutManager.ResetHutStatus(5);
        }


    }

    public void SendReachSignal()
    {
        LevelManager.Instance.CustomerReached(ratingStar);
    }
   
}
