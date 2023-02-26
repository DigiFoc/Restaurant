using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCounter : MonoBehaviour
{

    public static FoodCounter Instance { get; set; }
    // Start is called before the first frame update
    [System.Serializable]
    public class foodSlots
    {
        public GameObject teaSlot,pakoraSlot,samosaSlot,paneerTikkaSlot;
        
    }
    [SerializeField]

    [System.Serializable]
    public class foodPrefabs
    {
        public GameObject teaPrefab, pakoraPrefab, samosaPrefab, paneerTikkaPrefab;

    }
    [SerializeField]

    public foodSlots FoodSlots;
    public foodPrefabs FoodPrefabs;


   
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

    

    // Update is called once per frame
    void Update()
    {
        
    }

   public void AddFood(string food)
    {
        if (food == "Tea")
        {
            GameObject.Instantiate(FoodPrefabs.teaPrefab, FoodSlots.teaSlot.transform.position, Quaternion.identity);
        }

        else if (food == "Pakori")
        {
            GameObject.Instantiate(FoodPrefabs.pakoraPrefab, FoodSlots.pakoraSlot.transform.position, Quaternion.identity);
        }

        else if (food == "PaneerTikka")
        {
            GameObject.Instantiate(FoodPrefabs.paneerTikkaPrefab, FoodSlots.paneerTikkaSlot.transform.position, Quaternion.identity);
        }
        else if (food == "Samosa")
        {
            GameObject.Instantiate(FoodPrefabs.samosaPrefab, FoodSlots.samosaSlot.transform.position, Quaternion.identity);
        }
        else {
            Debug.Log("Wrong Food Passed");
        }

        
        
    }
}
