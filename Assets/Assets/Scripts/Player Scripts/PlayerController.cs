using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector()]
    public NavMeshAgent theAgent;
    [HideInInspector()]
    public Animator anim;

    [Header("Array Of Destinations")]
    public Transform[] Destinations;
    void Start()
    {
        theAgent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theAgent.velocity != Vector3.zero)
        {
            anim.SetBool("Move", true);
        }
        else
            anim.SetBool("Move", false);

      //  GetInput();
    }

    public void MoveTo(string placeName)
    {
        if(placeName=="Hut1")
        {
            if (Destinations.Length > 0 && Destinations[0] != null)
            {
                SetDestination(Destinations[0]);
                Debug.Log("Destination Set To :" + Destinations[0].gameObject.name);
            }
        }

        if(placeName=="Hut2")
        {
            if (Destinations.Length > 1 && Destinations[1] != null)
            {
                SetDestination(Destinations[1]);
            }
        }

       if(placeName=="Hut3")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                SetDestination(Destinations[2]);
            }
        }

       if(placeName=="Hut4")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                SetDestination(Destinations[3]);
            }
        }

        if(placeName=="Hut5")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                SetDestination(Destinations[4]);
            }
        }

        if(placeName=="Toilet")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                SetDestination(Destinations[5]);
            }
        }

        if (placeName=="Kitchen")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                SetDestination(Destinations[6]);
            }
        }

        //For Reaching the nearest Customer
        if (Input.GetKeyDown(KeyCode.C))
        {
            GoToCustomer();
        }
    }

    public void SetDestination(Transform destination)
    {
        transform.LookAt(destination.transform.position);
        theAgent.SetDestination(destination.position);
    }

    public void GoToCustomer()
    {
        GameObject[] allCustomers = GameObject.FindGameObjectsWithTag("Customer");
        float minDistance = 100000;
        int customerNo = 0;
        for (int i = 0; i < allCustomers.Length; i++)
        {
            float distance = Vector3.Distance(allCustomers[i].transform.position, this.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                customerNo = i;
            }
        }

        SetDestination(allCustomers[customerNo].transform);
    }

    
}
