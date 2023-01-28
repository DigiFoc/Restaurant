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

        GetInput();
    }

    public void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (Destinations.Length > 0 && Destinations[0] != null)
            {
                SetDestination(Destinations[0]);
                Debug.Log("Destination Set To :" + Destinations[0].gameObject.name);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Destinations.Length > 1 && Destinations[1] != null)
            {
                SetDestination(Destinations[1]);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Destinations.Length > 2 && Destinations[2] != null)
            {
                SetDestination(Destinations[2]);
            }
        }
    }

    public void SetDestination(Transform destination)
    {
        theAgent.SetDestination(destination.position);
    }

    
}