using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
	public GameObject GoodsBuyButton;
	public GameObject VehicleSlider;
	public GameObject foodSlider;
	[Range(1,5)]
	public int timeSpeed;
	public int Part=0;
    void Start()
    {
		Time.timeScale=timeSpeed;
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
			for(int i=0;i<7;i++)
			{
				if(i==5)
					ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=false;
				else
										ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=true;

			}
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
			
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Sorry, But Right Now You dont have Stock to Make Samosa. Tap on Shop to Purchase Goods " ;	
			
			ButtonObjects[9].SetActive(true);
			yield return new WaitForSeconds(5f);
			ButtonObjects[10].SetActive(true);
			ShowHandle(ArrowPlaceHolder[5]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
		}
		if(Part==13)
		{
			
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="This is your Shop Menu, You can Purchase Raw Goods from Here! " ;	
			
			ButtonObjects[11].SetActive(true);
			yield return new WaitForSeconds(5f);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Order Ingredients that is used to make Samosa " ;	
			
			ArrowHandler.transform.position=new Vector2(ArrowPlaceHolder[6].transform.GetChild(0).position.x-175,ArrowPlaceHolder[6].transform.GetChild(0).position.y);
			ArrowHandler.SetActive(true);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
			//ButtonObjects[10].SetActive(true);
			//ShowHandle(ArrowPlaceHolder[6]);
			//ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
		}
		if(Part==14)
		{
			
			ArrowHandler.SetActive(true);
			ButtonObjects[11].SetActive(true);
						ArrowHandler.transform.position=new Vector2(ArrowPlaceHolder[6].transform.GetChild(0).position.x-175,ArrowPlaceHolder[6].transform.GetChild(0).position.y-80);

		}
		if(Part==15)
		{
			ArrowHandler.SetActive(true);
			ButtonObjects[11].SetActive(true);
						ArrowHandler.transform.position=new Vector2(ArrowPlaceHolder[6].transform.GetChild(0).position.x-175,ArrowPlaceHolder[6].transform.GetChild(0).position.y-160);

		}
		if(Part==16)
		{
			ArrowHandler.SetActive(true);
			ButtonObjects[11].SetActive(true);
						ArrowHandler.transform.position=new Vector2(ArrowPlaceHolder[6].transform.GetChild(0).position.x-175,ArrowPlaceHolder[6].transform.GetChild(0).position.y-240);

		}
		if(Part==17)
		{
			ArrowHandler.SetActive(true);
			ButtonObjects[11].SetActive(true);
			GoodsBuyButton.SetActive(true);
			ShowHandle(ArrowPlaceHolder[7]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 0,28));

		}
		if(Part==18)
		{
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="You can see our Vehicle is out to Purchase Goods! Till then You can wait or Do other things! " ;	
			ButtonObjects[12].SetActive(true);
			ButtonObjects[12].transform.GetChild(0).GetComponent<GetVehicle>().StartRide();
			float reachTime=50f;
			VehicleSlider.SetActive(true);
			VehicleSlider.GetComponent<Slider>().maxValue=(int)reachTime;
			for(int i=0;i<(int)reachTime;i++)
				{
					yield return new WaitForSeconds(1);
					VehicleSlider.GetComponent<Slider>().value=i+1;
				}
			VehicleSlider.SetActive(false);
			NextBtn();

		}
		if(Part==19)
		{
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Items Reached, you can them in Stock Menu " ;
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			ButtonObjects[13].SetActive(true);
			ShowHandle(ArrowPlaceHolder[8]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
		}
		if(Part==20)
		{
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="You Can See all the Stock We Have! " ;
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			ButtonObjects[14].SetActive(true);
			yield return new WaitForSeconds(5f);
			NextBtn();
		}
		if(Part==21)
		{
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Again, As You can See Customer wants One Samosa. Tap On Food Engine Menu, Because Customers are waiting!" ;	
			ButtonObjects[8].SetActive(true);
			ShowHandle(ArrowPlaceHolder[3]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,180,0));
			yield return new WaitForSeconds(5f);
		}
		if(Part==22)
		{
			ShowHandle(ArrowPlaceHolder[4]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0, 180,0));
			ButtonObjects[9].SetActive(true);
			TextHolder.transform.position=PlaceHolder[0].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Tap on One Samosa";
			ButtonObjects[9].transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Button>().interactable=true;
	
		}
		if(Part==23)
		{
		ButtonObjects[9].SetActive(true);
		ShowHandle(ArrowPlaceHolder[7]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,0,28));
		}
		if(Part==24)
		{
			foodSlider.SetActive(true);
			foodSlider.GetComponent<Slider>().maxValue=(int)5;
		
			for(int i=0;i<5;i++)
			{
			yield return new WaitForSeconds(1);
			foodSlider.GetComponent<Slider>().value=i+1;
			}
		ButtonObjects[15].SetActive(true);
		foodSlider.SetActive(false);
		ShowHandle(ArrowPlaceHolder[9]);
			ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,0,-90));
			NextBtnGO.SetActive(true);
		}
		if(Part==25)
		{
						ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,0,30));

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Now, Tap on \"Move To\" Button" ;
			ButtonObjects[4].SetActive(true);
			ShowHandle(ArrowPlaceHolder[1]);
		}
		if(Part==26)
		{
			
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Here are the places you can walk to serve or make Food. Tap On Any Button to see your Player moving!" ;
			
			ButtonObjects[5].SetActive(true);
			for(int i=0;i<7;i++)
			{
				if(i!=5)
					ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=false;
			}
			RemoveHandle();
			
			
		}
		if(Part==27)
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
			
			NextBtn();
			
		}
		if(Part==28)
		{
			ButtonObjects[16].SetActive(true);
			ButtonObjects[17].SetActive(true);
		}
		if(Part==29)
		{
			
			PlayerFoodHandling.Instance.PickFood("UniversalFood");
		
						ArrowHandler.transform.rotation=Quaternion.Euler(new Vector3(0,0,30));

			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Now, Tap on \"Move To\" Button" ;
			ButtonObjects[4].SetActive(true);
			ShowHandle(ArrowPlaceHolder[1]);
		}
		if(Part==30)
		{
			
			TextHolder.transform.position=PlaceHolder[2].transform.position;
			TextHolder.SetActive(true);
			TextHolder.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text="Here are the places you can walk to serve or make Food. Tap On Any Button to see your Player moving!" ;
			
			ButtonObjects[5].SetActive(true);
			for(int i=0;i<7;i++)
			{
				if(i==0)
					ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=true;
				else
										ButtonObjects[5].transform.GetChild(2).GetChild(i).GetComponent<UnityEngine.UI.Button>().interactable=false;

			}
			RemoveHandle();
			
			
		}
		if(Part==31)
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
			PlayerFoodHandling.Instance.RemoveFood("UniversalFood");
			NextBtn();
			
		}
		if(Part==32)
		{
			ButtonObjects[18].SetActive(true);
						NextBtnGO.SetActive(true);

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
	public void finalString(string streeng)
	{
		if(streeng=="restart")
		{
			GameManager.Instance.Reset();
		}
		if(streeng=="next")
		{
			GameManager.Instance.SaveLearnt();
			GameManager.Instance.Reset();
		}
	}

}
