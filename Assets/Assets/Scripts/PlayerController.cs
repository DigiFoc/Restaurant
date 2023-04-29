using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
   
    public NavMeshAgent theAgent;
    [HideInInspector()]
    public Animator anim;
    public bool trackPath = false;
    int currentDestination = 0;
    public bool isMoving;
    [Header("Array Of Destinations")]
    public Transform[] Destinations;
    void Start()
    {
        theAgent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        SetDestination(Destinations[7]);
        transform.rotation = new Quaternion(0, 180, 0,1);

       theAgent.updateRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if(Vector3.Distance(Destinations[currentDestination].transform.position,transform.position)>0.1f)
            { 
            transform.LookAt(Destinations[currentDestination].transform.position);
             }
        }
        if (theAgent.velocity != Vector3.zero)
        {
            anim.SetBool("Move", true);
            isMoving = true;
        }
        else
        { anim.SetBool("Move", false);
            isMoving = false;
        }

       // if(trackPath)
       // GetPath();
    }

    public void GetPath()
    {
        if (theAgent.path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;

        for (int i = 0; i < theAgent.path.corners.Length; i++)
        {

            if (Vector3.Distance(theAgent.path.corners[i], transform.position) <= 0.1f && i < theAgent.path.corners.Length-1)
            {
                transform.LookAt(theAgent.path.corners[i+1]);
                Debug.Log("Reachde");
                continue;
            }
            if(Vector3.Distance(this.transform.position,theAgent.destination)<=0.1f)
            {
                trackPath = false;
            }
        }


    }

    public void MoveTo(string placeName)
    {
        if (placeName == "Hut1")
        {
            if (Destinations.Length > 0 && Destinations[0] != null)
            {
                SetDestination(Destinations[0]);
                currentDestination = 0;
                Debug.Log("Destination Set To :" + Destinations[0].gameObject.name);
            }
        }

        if (placeName == "Hut2")
        {
            if (Destinations.Length > 1 && Destinations[1] != null)
            {
                currentDestination = 1;
                SetDestination(Destinations[1]);
            }
        }

        if (placeName == "Hut3")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 2;
                SetDestination(Destinations[2]);
            }
        }

        if (placeName == "Hut4")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 3;
                SetDestination(Destinations[3]);
            }
        }

        if (placeName == "Hut5")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 4;
                SetDestination(Destinations[4]);
            }
        }

        if (placeName == "Toilet")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 5;
                SetDestination(Destinations[5]);
            }
        }

        if (placeName == "Kitchen")
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                currentDestination = 6;
                SetDestination(Destinations[6]);
            }
        }

       
    }

    public void SetDestination(Transform destination)
    {
        trackPath = true;
       transform.LookAt(destination.transform.position);
        Debug.Log("This", gameObject);
        theAgent.SetDestination(destination.position);
       
    }

   


}