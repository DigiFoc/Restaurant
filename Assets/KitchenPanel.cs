using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPanel : MonoBehaviour
{
    public GameObject KPanel;
    void Start()
    {
        KPanel.SetActive(false);

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            KPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            KPanel.SetActive(false);
        }
    }
}
