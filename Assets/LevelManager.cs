using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }
    public CustomerGenerator customerGenerator;
    public List<Level> levels;
    public Level currentLevel;
    public int currentRating;
    public int currentCustomers;
    public int currentTime;
    public int currentReached;
    public int LevelNo;
    public TMP_Text timeRequired;
    public TMP_Text totalCustomerstext;
    public TMP_Text ratingRequired;

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
        //SetLevel(LevelNo);
        //customerGenerator.GenerateCustomer(currentLevel.totalCustomers);
    }

    // Update is called once per frame
   public void SetLevel(int levelNumber)
    {
        currentLevel = levels[levelNumber - 1];

        float min = 0;
        float sec=0;
        min = Mathf.Floor(currentLevel.totalLevelTime / 60);
        sec = currentLevel.totalLevelTime % 60;
        timeRequired.text = min.ToString("00")+":"+ sec.ToString("00");
        totalCustomerstext.text = currentLevel.totalCustomers.ToString();
        ratingRequired.text = currentLevel.avgRatingReq.ToString();

    }
    public void StartLevel()
    {
        customerGenerator.GenerateCustomer(currentLevel.totalCustomers);
        StartCoroutine(CountTime());
    }
    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1); //To Remove the Glitch of Divide by Zero\
        Debug.Log(currentLevel.totalLevelTime);
        yield return new WaitForSeconds(currentLevel.totalLevelTime);
        string levelStatus = ((isLevelCompleted()) ? "Level Passes" : "Level Failed");
        Debug.Log(levelStatus);
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
        } 
    }
}
