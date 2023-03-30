using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VehicleStarter : MonoBehaviour
{
    // Start is called before the first frame update
    public VehiclesPrefabs prefabs;
    public GameObject destination;

    // Update is called once per frame

    public void Awake()
    {
        GenerateNextVehicle();
    }
    void Update()
    {
        
    }

   public void GenerateNextVehicle()
    {
      
        int RandomVehicle = Random.Range(0, prefabs.vehicleArray.Length);
        GameObject newVehicle = GameObject.Instantiate(prefabs.vehicleArray[RandomVehicle], this.transform.position,Quaternion.identity);
        newVehicle.GetComponent<Vehicle>().starter = this.gameObject;
        newVehicle.GetComponent<NavMeshAgent>().SetDestination(destination.transform.position);
       
    }
}
