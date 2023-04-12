using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstTimeManager : MonoBehaviour
{
	public GameObject Player;
    public GameObject ArrowHandler;
	public GameObject[] ButtonObjects;
	public GameObject TextHolder;
	public Transform[] PlaceHolder;
	public Transform[] ArrowPlaceHolder;
	public GameObject NextBtnGO;
	public GameObject CameraScript;
	int Part=0;
    void Start()
    {
       ArrowHandler.SetActive(false);
	   NextBtnGO.SetActive(true);
	   StartCoroutine(StartTutorial());
    }

    // Update is called once per frame
    void Update()
    {
       		   
    }
	public void NextBtn()
	{
		StartCoroutine(StartTutorial());
	}
	public IEnumerator StartTutorial()
	{
		Part++;
		ResetButtons();
		ArrowHandler.SetActive(false);
		TextHolder.SetActive(false);
		RemoveHandle();
		if(Part==1)	
		{
			ButtonObjects[0].SetActive(true);
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="This is Level Selection Menu where you can Select any Unlocked Level. Tap on Next Button to Continue!";
			NextBtnGO.SetActive(true);
		}
		if(Part==2)	
		{
			TextHolder.transform.position=PlaceHolder[1].transform.position;
			TextHolder.SetActive(true);
			ButtonObjects[1].SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="This is Shop Where You can Upgrade Items After Collecting Coins by Playing Levels. Tap on Next Button to Continue!";
			NextBtnGO.SetActive(true);
		}
		if(Part==3)	
		{
			NextBtnGO.SetActive(false);
			ShowHandle(ArrowPlaceHolder[0]);
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			ButtonObjects[2].SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Tap on Level 1 to Start your first Level of Game! Let's Go!";
		}
		if(Part==4)	
		{
			ButtonObjects[3].SetActive(true);
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
		
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="These are Your Objectives. Read it Carefully and then Tap on Start Button to Start Level";
		}
		if(Part==5)	
		{
			
				NextBtn();
				yield return null;///REMOVE WHEN BUILD
			
			/*yield return new WaitForSeconds(3f);
			
			//Time.timeScale=0f;
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Rotate Player's Camera by Swiping on Screen!";
			bool done = false;
			int temp = 0;
			while(!done) // essentially a "while true", but with a bool to break out naturally
			{
				if(Input.GetAxis("Mouse X") !=0 ||Input.GetAxis("Mouse Y")!=0)
					{
						temp++;
						if(temp>50)
						done = true; // breaks the loop
					}
						yield return null; // wait until next frame, then continue execution from here (loop continues)
			}
			NextBtnGO.SetActive(true);*/
		}
		if(Part==6)
		{
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Now, Tap on \"Move To\" Button" ;
			ButtonObjects[4].SetActive(true);
			ShowHandle(ArrowPlaceHolder[1]);
		}
		if(Part==7)
		{
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Here are the places you can walk to serve or make Food. Tap On Any Button to see your Player moving!" ;
			
			ButtonObjects[5].SetActive(true);
			RemoveHandle();
			
			
		}
		if(Part==8)
		{
			yield return new WaitForSeconds(2f);
			bool done = false;
			while(!done) 
			{
				if(Player.GetComponent<PlayerController>().isMoving==false)
					{
						done = true; 
					}
						yield return null; 
			}
			 
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="That's Amazing! You Know how to move! Tap on Next Button to Continue!" ;
			
			NextBtnGO.SetActive(true);
			
		}
		if(Part==9)
		{
			
			LevelManager.Instance.CustSpawnforFirstTime();
			yield return new WaitForSeconds(2f);
			CameraScript.GetComponent<CameraController>().target=GameObject.Find("AICustomer").transform.GetChild(0);
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="A Customer is Coming, Make Sure to Fulfill thier Demands!" ;
			yield return new WaitForSeconds(8f);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Customer will Sit in any Vacant Hut and will Order thier desired food! " ;
			yield return new WaitForSeconds(8f);
			TextHolder.SetActive(false);
			CameraScript.GetComponent<CameraController>().target=GameObject.Find("Player").transform.GetChild(0);
			yield return new WaitForSeconds(5f);
			
		}
		if(Part==10)
		{
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="We have our First Customer in Hut 1" ;	
			yield return new WaitForSeconds(5f);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Tap on Status Menu to check what are their Requirements!" ;	
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			ShowHandle(ArrowPlaceHolder[2]);
			ButtonObjects[6].SetActive(true);
		}
		if(Part==11)
		{
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="As You can See, Customer wants One Samosa. Tap On Food Engine Menu, Because Customers are waiting!" ;	
			ButtonObjects[7].SetActive(true);
			ButtonObjects[8].SetActive(true);
			ShowHandle(ArrowPlaceHolder[3]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,180,0));
			yield return new WaitForSeconds(5f);
		}
		if(Part==12)
		{
		}
		
		}
	public void ShowHandle(Transform FocusPoint)
	{
		ArrowHandler.SetActive(true);
		ArrowHandler.transform.position=new Vector2(FocusPoint.transform.GetChild(0).position.x+75,FocusPoint.transform.GetChild(0).position.y+70);
	}
	public void RemoveHandle()
	{
		ArrowHandler.SetActive(false);
	}
	public void ResetButtons()
	{
		for(int i=0;i<ButtonObjects.Length;i++)
		{
			ButtonObjects[i].SetActive(false);		
		}
		NextBtnGO.SetActive(false);
	}

}
