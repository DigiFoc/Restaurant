using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HutsManager : MonoBehaviour
{

    [System.Serializable]
    public class HutsInfo
    {
        public Transform locationOfHut;
        public bool isOccupied = false;
        public string customerName;
        public int cashToPay;
        public string Gender;
        public TMP_Text emotion;
        public TMP_Text order;
        public GameObject hutMarker;


    }
    [SerializeField]


    public HutsInfo hut1, hut2, hut3, hut4;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetEmotionStatus(int hutNo,string Emotion)
    {
        if(hutNo == 1)
        {
            hut1.emotion.text = Emotion;
        }
        if (hutNo == 2)
        {
            hut2.emotion.text = Emotion;
        }
        if (hutNo == 3)
        {
            hut2.emotion.text = Emotion;
        }

    }

    public void SetHutStatus(int hutNo, string food, int quantity)
    {
        if (hutNo == 1)
        {
            hut1.order.text = food + quantity;
            Debug.Log("Camed Here");
            hut1.hutMarker.SetActive(true);
            hut1.hutMarker.GetComponent<MarkerTrigger>().foodName = food;
            hut1.hutMarker.GetComponent<MarkerTrigger>().quntity = quantity;
        }
        if (hutNo == 2)
        {
            hut2.order.text = food + quantity;
        }
        if (hutNo == 3)
        {
            hut3.order.text = food + quantity;
        }

    }

}
