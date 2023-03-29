using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Clicked on the UI");
         
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Clicked on the UI");

        }
    }
}
