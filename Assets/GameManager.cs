using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public int currentTVUpgrade;
    public int currentHeartUpgrade;
    public int currentSpeakerUpgrade;
    public int currentVaseUpgrade;
    public int currentWallArtUpgrade;
    public int currentVehicleUpgrade;
    public int currentMachineUpgrade;
    public int globalCoins;
    public int lastUnlockedLevel;

    public GameObject ExtShopManager;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    

    void Start()
    {
        LoadUpgrades();
        
    }
    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("Level", level);
    }

    public void SaveTVUpgrade(int level)
    {
        PlayerPrefs.SetInt("TVUpgrade", level);
    }
    public void SaveHeartUpgrade(int level)
    {
        PlayerPrefs.SetInt("HeartUpgrade", level);
    }
    public void SaveSpeakerUpgrade(int level)
    {
        PlayerPrefs.SetInt("SpeakerUpgrade", level);
    }
    public void SaveVaseUpgrade(int level)
    {
        PlayerPrefs.SetInt("VaseUpgrade", level);
    }
    public void SaveWallArtUpgrade(int level)
    {
        PlayerPrefs.SetInt("WallArtUpgrade", level);
    }
    public void SaveVehicleUpgrade(int level)
    {
        PlayerPrefs.SetInt("VehicleUpgrade", level);
    }
    public void SaveMachineUpgrade(int level)
    {
        PlayerPrefs.SetInt("MachineUpgrade", level);
    }
    public void SaveGlobalCoins(int amount)
    {
        PlayerPrefs.SetInt("globalCoins", amount);

    }
    public bool CheckLevel(int levelNo)
    {
        if (levelNo <= lastUnlockedLevel)
        {
            return true;
        }
        else
            return false;
    }
    public void LoadUpgrades()
    {
        currentHeartUpgrade = PlayerPrefs.GetInt("HeartUpgrade");
        currentTVUpgrade = PlayerPrefs.GetInt("TVUpgrade");
        currentMachineUpgrade = PlayerPrefs.GetInt("MachineUpgrade");
        currentSpeakerUpgrade = PlayerPrefs.GetInt("SpeakerUpgrade");
        currentVaseUpgrade = PlayerPrefs.GetInt("VaseUpgrade");
        currentVehicleUpgrade = PlayerPrefs.GetInt("VehicleUpgrade");
        currentWallArtUpgrade = PlayerPrefs.GetInt("WallArtUpgrade");
        globalCoins = PlayerPrefs.GetInt("globalCoins");
        lastUnlockedLevel = PlayerPrefs.GetInt("Level");
    }
}


