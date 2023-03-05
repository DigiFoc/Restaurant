using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCounter : MonoBehaviour
{
		bool samosaReady;
		bool pTikkaReady;
		bool teaReady;
		bool pakoriReady;
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
        if (food == "Tea"&&samosaReady==false)
        {
            GameObject g=Instantiate(FoodPrefabs.teaPrefab, FoodSlots.teaSlot.transform.position, Quaternion.identity);
			g.name="TeaModel";
			samosaReady=true;
        }

        else if (food == "Pakori"&&pakoriReady==false)
        {
            GameObject g=Instantiate(FoodPrefabs.pakoraPrefab, FoodSlots.pakoraSlot.transform.position, Quaternion.identity);
			g.name="PakoriModel";
			pakoriReady=true;
        }

        else if (food == "PaneerTikka"&&pTikkaReady==false)
        {
            GameObject g=Instantiate(FoodPrefabs.paneerTikkaPrefab, FoodSlots.paneerTikkaSlot.transform.position, Quaternion.identity);
			g.name="PTikkaModel";
			pTikkaReady=true;
        }
        else if (food == "Samosa"&&samosaReady==false)
        {
            GameObject g=Instantiate(FoodPrefabs.samosaPrefab, FoodSlots.samosaSlot.transform.position, Quaternion.identity);
			g.name="SamosaModel";
			samosaReady=true;
        }
        else {
            Debug.Log("Wrong Food Passed");
        }

        
        
    }
	
	public void RemoveFood(string food)
	{
		 if (food == "Tea"&&teaReady==true)
        {
            
			Destroy(GameObject.Find("TeaModel"),1);
			teaReady=false;
        }

        else if (food == "Pakori"&&pakoriReady==false)
        {
            Destroy(GameObject.Find("PakoriModel"),1);
			pakoriReady=false;
        }

        else if (food == "PaneerTikka"&&pTikkaReady==false)
        {
            Destroy(GameObject.Find("pTikkaModel"),1);
			pTikkaReady=false;
        }
        else if (food == "Samosa"&&samosaReady==false)
        {
            Destroy(GameObject.Find("SamosaModel"),1);
			samosaReady=false;
        }
        else {
            Debug.Log("Wrong Food Passed");
        }
	}
}
