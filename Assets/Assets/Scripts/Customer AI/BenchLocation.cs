using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BenchLocation : MonoBehaviour
{
     Animator anim;
    NavMeshAgent theAgent;
    public Transform lookAtPoint;
    bool lookAt;
    GameObject other;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lookAt)
        {
            other.transform.LookAt(lookAtPoint.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Customer")
        {
            theAgent = other.GetComponent<NavMeshAgent>();
            anim = other.GetComponent<Animator>();
            theAgent.enabled = false;
            lookAt = true;
            this.other = other.gameObject;
            anim.SetBool("Sit", true);

        }
    }
}
