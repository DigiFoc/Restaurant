
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int currentStorageUpgrade;
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
        Debug.Log("Saved level"+level);

    }

    public void SaveStorageUpgrade(int level)
    {
        PlayerPrefs.SetInt("StorageUpgrade", level);
        LoadUpgrades();
    }

    public void SaveTVUpgrade(int level)
    {
        PlayerPrefs.SetInt("TVUpgrade", level);
		LoadUpgrades();
    }
    public void SaveHeartUpgrade(int level)
    {
        PlayerPrefs.SetInt("HeartUpgrade", level);
		LoadUpgrades();
    }
    public void SaveSpeakerUpgrade(int level)
    {
        PlayerPrefs.SetInt("SpeakerUpgrade", level);
		LoadUpgrades();
    }
    public void SaveVaseUpgrade(int level)
    {
        PlayerPrefs.SetInt("VaseUpgrade", level);
		LoadUpgrades();
    }
    public void SaveWallArtUpgrade(int level)
    {
        PlayerPrefs.SetInt("WallArtUpgrade", level);
		LoadUpgrades();
    }
    public void SaveVehicleUpgrade(int level)
    {
        PlayerPrefs.SetInt("VehicleUpgrade", level);
		LoadUpgrades();
    }
    public void SaveMachineUpgrade(int level)
    {
        PlayerPrefs.SetInt("MachineUpgrade", level);
		LoadUpgrades();
    }
    public void SaveGlobalCoins(int amount)
    {
        PlayerPrefs.SetInt("globalCoins", amount);
		LoadUpgrades();

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
        currentStorageUpgrade = PlayerPrefs.GetInt("StorageUpgrade", 0);
        currentHeartUpgrade = PlayerPrefs.GetInt("HeartUpgrade",0);
        currentTVUpgrade = PlayerPrefs.GetInt("TVUpgrade", 0);
        currentMachineUpgrade = PlayerPrefs.GetInt("MachineUpgrade", 0);
        currentSpeakerUpgrade = PlayerPrefs.GetInt("SpeakerUpgrade", 0);
        currentVaseUpgrade = PlayerPrefs.GetInt("VaseUpgrade", 0);
        currentVehicleUpgrade = PlayerPrefs.GetInt("VehicleUpgrade", 1);
        currentWallArtUpgrade = PlayerPrefs.GetInt("WallArtUpgrade", 0);
        globalCoins = PlayerPrefs.GetInt("globalCoins", 0);
        lastUnlockedLevel = PlayerPrefs.GetInt("Level",1);
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}


