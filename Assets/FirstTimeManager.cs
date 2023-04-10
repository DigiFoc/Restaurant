using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeManager : MonoBehaviour
{
    public GameObject ImageHandler;
    void Start()
    {
       ImageHandler.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       		   
    }
	
	public void ShowHandle(Transform FocusPoint)
	{
		ImageHandler.SetActive(true);
		ImageHandler.transform.position=new Vector2(FocusPoint.transform.position.x+75,FocusPoint.transform.position.y+70);
	}
	public void RemoveHandle()
	{
		ImageHandler.SetActive(false);
	}

}
