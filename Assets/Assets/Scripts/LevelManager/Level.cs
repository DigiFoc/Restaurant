using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager" , menuName = "Add Level")]
public class Level : ScriptableObject
{
    public int levelNum;
    public int totalCustomers;
    public int consecCustomers;
    public int totalLevelTime;
    public float avgRatingReq;
    public bool isCompleted;
    public int givenCoins;
	[Range(0,10)]
	public int maxTea,maxSamosa,maxPaneerTikka,maxPakori;
	
	
   
}
