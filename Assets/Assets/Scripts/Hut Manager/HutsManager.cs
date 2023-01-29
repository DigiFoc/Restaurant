using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class HutsManager : MonoBehaviour
{

    [System.Serializable]
    public class HutsInfo
    {
        public Transform locationOfHut;
        public bool isOccupied = false;
        public string customerName;
        public int cashToPay;
        public string Gender;

    }
    [SerializeField]

    
    public  HutsInfo hut1, hut2, hut3, hut4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
