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

    private void Awake()
    {
        anim = GetComponent<Animator>();
        theAgent = GetComponent<NavMeshAgent>();
        this.gameObject.tag = "Customer";
        if(hutManager == null)
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
    

    
}
