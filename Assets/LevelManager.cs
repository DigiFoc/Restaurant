using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }
    public CustomerGenerator customerGenerator;
    public PlayerController PC;
    public List<Level> levels;
    public Level currentLevel;
    public int currentRating;
    public int currentCustomers;
    public int currentTime;
    public int currentReached;
    public int LevelNo;
    public TMP_Text timeRequired;
    public TMP_Text levelNumbertext;
    public TMP_Text totalCustomerstext;
    public TMP_Text ratingRequired;
    public string levelStatusText;
    public string reason;
    public bool levelStarted;
    public TMP_Text ObjtimeRequired;
    public TMP_Text ObjtimeCurrent;
    public TMP_Text ObjRatingRequired;
    public TMP_Text ObjRatingCurrent;
    public TMP_Text ObjCustRequired;
    public TMP_Text ObjCustCurrent;
    public TMP_Text EndScreentimeRequired;
    public TMP_Text EndScreentimeCurrent;
    public TMP_Text EndScreenRatingRequired;
    public TMP_Text EndScreenRatingCurrent;
    public TMP_Text EndScreenCustRequired;
    public TMP_Text EndScreenCustCurrent;
    public TMP_Text TimeOutScreenRatingRequired;
    public TMP_Text TimeOutScreenRatingCurrent;
    public TMP_Text TimeOutScreenCustRequired;
    public TMP_Text TimeOutScreenCustCurrent;
    float timecurrent = 0;
    float min = 0;
    float sec = 0;
    float currMin = 0;
    float currSec = 0;
    public GameObject EndScreen;
    public GameObject TimeOutScreen;
    public GameObject[] statusesEndScreen,statusesTimeOutScreen;
	public int CustNeedToSpawn;

    public Sprite passTextures;
    public Sprite failTextures;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        
    }
    public void CustomerReached(int opinion)
    {
        currentReached++;
        currentRating += opinion;
        CheckLevel();
        Debug.Log(currentRating);
    }

    

    void Start()
    {
		CustNeedToSpawn=0;
        levelStarted = false;
        //SetLevel(LevelNo);
        //customerGenerator.GenerateCustomer(currentLevel.totalCustomers);
    }
    private void Update()
    {
        if(levelStarted)
            {
            timecurrent += Time.deltaTime;
            currMin = Mathf.Floor(timecurrent / 60);
            currSec = timecurrent % 60;
            ObjtimeCurrent.text = currMin.ToString("00") + ":" + currSec.ToString("00");
            ObjRatingCurrent.text = currentRating.ToString();
            ObjCustCurrent.text = currentReached.ToString();
			
            if (timecurrent >= currentLevel.totalLevelTime)
            {
                levelStarted = false; }
			}
    }
    // Update is called once per frame
	public void ShuruKrvaao()
	{
		StartCoroutine(SpawnCust());
	}
	public IEnumerator SpawnCust()
	{
		if(customerGenerator.currentData.totalCustomersPresent < 6)
		{
		for(int i=0;i<currentLevel.consecCustomers;i++)
		{
			if(CustNeedToSpawn>0)
			{
			customerGenerator.GenerateCustomer();
			}
			//Debug.Log("Total Customers:"+currentLevel.totalCustomers + "Total Needed " +CustNeedToSpawn);
			CustNeedToSpawn--;
			Debug.Log("Total Customers:"+currentLevel.totalCustomers + "Total Needed " +CustNeedToSpawn);


			yield return new WaitForSeconds(Random.Range(3,7));
		}
		}
	}
    public void SetLevel(int levelNumber)
    {
        SoundManager.Instance.PlaySound("tap");
        int currentNumber = levelNumber - 1;
        currentLevel = levels[currentNumber];
        Debug.Log(currentLevel);
        min = Mathf.Floor(currentLevel.totalLevelTime / 60);
        sec = currentLevel.totalLevelTime % 60;
        timeRequired.text = min.ToString("00")+":"+ sec.ToString("00");
        totalCustomerstext.text = currentLevel.totalCustomers.ToString();
        ratingRequired.text = currentLevel.avgRatingReq.ToString();
        levelNumbertext.text = currentLevel.levelNum.ToString();
		CustNeedToSpawn=currentLevel.totalCustomers;
        AdmobController.Instance.ShowInterstitialAd();
    }
    public void StartLevel()
    {
        PC.GetComponent<PlayerController>().enabled = true;
        MenuManager.Instance.ChangeMenu("side");
        StartCoroutine(SpawnCust());
        levelStarted = true;
        StartCoroutine(CountTime());
    }
    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1); //To Remove the Glitch of Divide by Zero\
        Debug.Log(currentLevel.totalLevelTime);
        ObjtimeRequired.text = min.ToString("00") + ":" + sec.ToString("00");
        ObjRatingRequired.text = currentLevel.avgRatingReq.ToString();
        ObjCustRequired.text= currentLevel.totalCustomers.ToString();
        yield return new WaitForSeconds(currentLevel.totalLevelTime);
        string levelStatus = ((isLevelCompleted()) ? "Level Passes" : "Level Failed");
        if (levelStatus.Equals("Level Failed"))
            ShowTimeOutScreen();
    }





    public bool isLevelCompleted()
    {
        int avgRating = currentRating / currentLevel.totalCustomers;

        if(avgRating >= currentLevel.avgRatingReq)
        {
            return true;
        }
        return false;
    }

    void CheckLevel()
    {
        if (currentReached == currentLevel.totalCustomers)
        {
            string levelStatus = ((isLevelCompleted()) ? "Level Passes" : "Level Failed");
            Debug.Log(levelStatus);
            ShowEndScreen();
        } 
    }


    void ShowEndScreen()
    {
        SoundManager.Instance.PlaySound("success");
        EndScreen.SetActive(true);
        EndScreentimeCurrent.text = currMin.ToString("00") + ":" + currSec.ToString("00");
        EndScreentimeRequired.text = min.ToString("00") + ":" + sec.ToString("00");

        EndScreenRatingRequired.text = currentLevel.avgRatingReq.ToString();
        EndScreenRatingCurrent.text = currentRating.ToString();
        EndScreenCustRequired.text= currentLevel.totalCustomers.ToString();
        EndScreenCustCurrent.text= currentReached.ToString();

        if(currentTime < currentLevel.totalLevelTime)
        {

            statusesEndScreen[0].GetComponent<Image>().sprite = passTextures;

        }
        else
        {
            statusesEndScreen[0].GetComponent<Image>().sprite = failTextures;
        }


        if (currentReached >= currentLevel.totalCustomers)
        {
            statusesEndScreen[1].GetComponent<Image>().sprite = passTextures;
        }
        else
        {
            statusesEndScreen[1].GetComponent<Image>().sprite = failTextures;
        }


        if (currentRating >= currentLevel.avgRatingReq)
        {
            statusesEndScreen[2].GetComponent<Image>().sprite = passTextures;
        }
        else
        {
            statusesEndScreen[2].GetComponent<Image>().sprite = failTextures;
        }
        PC.GetComponent<PlayerController>().enabled = false;
        MenuManager.Instance.ResetAll();
        GameManager.Instance.SaveLevel(currentLevel.levelNum++);
    }


    void ShowTimeOutScreen()
    {
        SoundManager.Instance.PlaySound("fail");
        TimeOutScreen.SetActive(true);
       
        TimeOutScreenRatingRequired.text = currentLevel.avgRatingReq.ToString();
        TimeOutScreenRatingCurrent.text = currentRating.ToString();
        TimeOutScreenCustRequired.text = currentLevel.totalCustomers.ToString();
        TimeOutScreenCustCurrent.text = currentReached.ToString();

     


        if (currentReached >= currentLevel.totalCustomers)
        {
            statusesTimeOutScreen[0].GetComponent<Image>().sprite = passTextures;
        }
        else
        {
            statusesTimeOutScreen[0].GetComponent<Image>().sprite = failTextures;
        }


        if (currentRating >= currentLevel.avgRatingReq)
        {
            statusesTimeOutScreen[1].GetComponent<Image>().sprite = passTextures;
        }
        else
        {
            statusesTimeOutScreen[1].GetComponent<Image>().sprite = failTextures;
        }
        PC.GetComponent<PlayerController>().enabled = false;
        MenuManager.Instance.ResetAll();
    }

}
