using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExtShopManager : MonoBehaviour
{
    [System.Serializable]
    public class TVUpgrade
    {
        public GameObject[] prefabs;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]
   

    [System.Serializable]
    public class decorationUpgrade
    {
        public GameObject[] prefabs;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]
   

    [System.Serializable]
    public class SoundSystemUpdate
    {
        public GameObject[] prefab;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]

    [System.Serializable]
    public class VegetationUpdate
    {
        public GameObject[] prefab;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public Sprite updateCompleteDot, updateNotCompletedDot;

    }
    [SerializeField]

    [System.Serializable]
    public class WallArtUpdate
    {
        public Material[] prefab;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]

    [System.Serializable]
    public class VehicleUpdate
    {
        public Sprite[] prefabs;
        public Image imageObjectToUpdate;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]

    [System.Serializable]
    public class FoodMachineUpdate
    {
        public int[] speed;
        public int[] levelsReq;
        public int currentUpgradeNo = 0;
        public int totalUpdates;
        public int[] coinsRequired;
        public Image upgradeImageField;
        public Sprite[] upgradeSprites;
        public Image allUpdatesDone;
        public GameObject priceShowingObject;
        public TMP_Text priceText;
        public Image[] updateDots;
        public Sprite updateCompleteDot, updateNotCompletedDot;
    }
    [SerializeField]

    [Header("TV UPDATE SETTINGS")]
    public TVUpgrade tv;
    [Space(5)]
    [Header("DECORATIOn UPDATE SETTINGS")]
    public decorationUpgrade decoration;
    [Space(5)]
    [Header("Sound System Update")]
    public SoundSystemUpdate soundSystem;
    [Space(5)]
    [Header("Vegetation Update")]
    public SoundSystemUpdate vegetation;
    [Space(5)]
    [Header("WallArt Update")]
    public WallArtUpdate wallArt;
    [Space(5)]
    [Header("Vehicle Update")]
    public VehicleUpdate vehicle;
    [Space(5)]
    [Header("Food Machine Update")]
    public FoodMachineUpdate foodMachine;





    public void Awake()
    {
        
    }


    #region TVUpdate
    public void UpdateTV()
    {
     
        if (tv.currentUpgradeNo >= tv.totalUpdates)
        {
            Debug.Log("CHAL GYAA TV");
            ShowMessage("All Updates Done", 2);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= tv.levelsReq[tv.currentUpgradeNo])
        {

            if (totalCoins >= tv.coinsRequired[tv.currentUpgradeNo])
            {

                UpdateTVVisuals(tv.currentUpgradeNo);
                tv.currentUpgradeNo++;
            }
            else
            {
                Debug.Log("Coins not sufficinet");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
            Debug.Log("Levels not Sufficient");
            ShowMessage("Levels Required :" + tv.levelsReq[0], 2);
        }
    }

    void UpdateTVVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for(int i=0;i<tv.prefabs.Length;i++)
        {
            if (i == upgradeNo) tv.prefabs[i].SetActive(true);
            else tv.prefabs[i].SetActive(false);
        }

        if (upgradeNo + 1 < tv.totalUpdates)
        {
            tv.upgradeImageField.sprite = tv.upgradeSprites[upgradeNo];

            tv.priceText.text = tv.coinsRequired[tv.currentUpgradeNo].ToString();
        }
        for(int i=0;i<tv.updateDots.Length;i++)
        {
            if(i<=upgradeNo)
            {
                tv.updateDots[i].sprite = tv.updateCompleteDot;
            }
        }

        if(tv.currentUpgradeNo+1 == tv.totalUpdates)
        {
            tv.priceShowingObject.SetActive(false);
            tv.allUpdatesDone.gameObject.SetActive(true);
            
        }


    }
    #endregion

    #region DecorationUpdate
    public void Updatedecoration()
    {
        if (decoration.currentUpgradeNo >= decoration.totalUpdates)
        {
            ShowMessage("All Updates Done", 2);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= decoration.levelsReq[decoration.currentUpgradeNo])
        {
            if (totalCoins >= decoration.coinsRequired[decoration.currentUpgradeNo])
            {

                UpdatedecorationVisuals(decoration.currentUpgradeNo);
                decoration.currentUpgradeNo++;
            }
            else
            {
                Debug.Log("Coins Not Sufficient");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
            Debug.Log("Levels Not Sufficient");
            ShowMessage("Levels Required :" + decoration.levelsReq[0], 2);
        }
    }

    void UpdatedecorationVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < decoration.prefabs.Length; i++)
        {
            if (i == upgradeNo) decoration.prefabs[i].SetActive(true);
           
        }

        if (upgradeNo + 1 < decoration.totalUpdates)
        {
            decoration.upgradeImageField.sprite = decoration.upgradeSprites[upgradeNo];

            decoration.priceText.text = decoration.coinsRequired[decoration.currentUpgradeNo+1].ToString();
        }
        for (int i = 0; i < decoration.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                decoration.updateDots[i].sprite = decoration.updateCompleteDot;
            }
        }
        if (decoration.currentUpgradeNo+1 == decoration.totalUpdates)
        {
            decoration.priceShowingObject.SetActive(false);
            decoration.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    #endregion

    #region SoundSystemUpdate
    public void UpdateSoundSystem()
    {
        if (soundSystem.currentUpgradeNo >= soundSystem.totalUpdates)
        {
            ShowMessage("All Updates Done", 2);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= soundSystem.levelsReq[soundSystem.currentUpgradeNo])
        {
            if (totalCoins >= soundSystem.coinsRequired[soundSystem.currentUpgradeNo])
            {

                UpdateSoundSystemVisuals(soundSystem.currentUpgradeNo);
                soundSystem.currentUpgradeNo++;
            }
            else
            {
                Debug.Log("Coins are not sufficient");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
            Debug.Log("Levels are not sufficient");
            ShowMessage("Levels Required :" + decoration.levelsReq[0], 2);
        }
    }

    void UpdateSoundSystemVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < soundSystem.prefab.Length; i++)
        {
            if (i == upgradeNo) soundSystem.prefab[i].SetActive(true);
            else soundSystem.prefab[i].SetActive(false);
        }

        if (upgradeNo + 1 < soundSystem.totalUpdates)
        {
            soundSystem.upgradeImageField.sprite = soundSystem.upgradeSprites[upgradeNo];
            soundSystem.priceText.text = (soundSystem.coinsRequired[soundSystem.currentUpgradeNo+1]).ToString();
        }
        for (int i = 0; i < soundSystem.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                soundSystem.updateDots[i].sprite = soundSystem.updateCompleteDot;
            }
        }

        if (soundSystem.currentUpgradeNo+1 == soundSystem.totalUpdates)
        {
            soundSystem.priceShowingObject.SetActive(false);
            soundSystem.allUpdatesDone.gameObject.SetActive(true);

        }

    }
    #endregion

    #region VegetationUpdate
    public void UpdateVegetation()
    {
        if (vegetation.currentUpgradeNo >= vegetation.totalUpdates)
        {
            ShowMessage("All Updates Done", 2);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= vegetation.levelsReq[vegetation.currentUpgradeNo])
        {
            if (totalCoins >= vegetation.coinsRequired[vegetation.currentUpgradeNo])
            {

                UpdateVegetationVisuals(vegetation.currentUpgradeNo);
                vegetation.currentUpgradeNo++;
            }
            else
            {
                Debug.Log("Coins are not sufficient");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
            Debug.Log("Levels are not sufficient");
            ShowMessage("Levels Required :" + decoration.levelsReq[0], 2);
        }
    }

    void UpdateVegetationVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < vegetation.prefab.Length; i++)
        {
            if (i == upgradeNo) vegetation.prefab[i].SetActive(true);
            else vegetation.prefab[i].SetActive(false);
        }

        if (upgradeNo + 1 < vegetation.totalUpdates)
        {
            vegetation.upgradeImageField.sprite = vegetation.upgradeSprites[upgradeNo+1];
            vegetation.priceText.text = (vegetation.coinsRequired[vegetation.currentUpgradeNo+1]).ToString();
        }
        for (int i = 0; i < vegetation.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                vegetation.updateDots[i].sprite = vegetation.updateCompleteDot;
            }
        }

        if (vegetation.currentUpgradeNo+1 == vegetation.totalUpdates)
        {
            vegetation.priceShowingObject.SetActive(false);
            vegetation.allUpdatesDone.gameObject.SetActive(true);

        }

    }
    #endregion

    #region WallArtUpdate
    public void UpdateWallArt()
    {
        if (wallArt.currentUpgradeNo >= wallArt.totalUpdates)
        {
            ShowMessage("All Updates Done", 2);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= wallArt.levelsReq[wallArt.currentUpgradeNo])
        {
            if (totalCoins >= wallArt.coinsRequired[wallArt.currentUpgradeNo])
            {

                UpdateWallArtVisuals(wallArt.currentUpgradeNo);
                wallArt.currentUpgradeNo++;
            }
            else
            {
                Debug.Log("Coins are not sufficient");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
            Debug.Log("Levels are not sufficient");
            ShowMessage("Levels Required :" + decoration.levelsReq[0], 2);
        }
    }

    void UpdateWallArtVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < wallArt.prefab.Length; i++)
        {
           if(i<upgradeNo)
            {
                Color temp = wallArt.prefab[i].color;
                temp.a = 1;
                wallArt.prefab[i].color = temp;
            }
        }
        if (upgradeNo + 1 < wallArt.totalUpdates)
        {
            wallArt.upgradeImageField.sprite = wallArt.upgradeSprites[upgradeNo];

            wallArt.priceText.text = (wallArt.coinsRequired[wallArt.currentUpgradeNo]).ToString();
        }
        for (int i = 0; i < wallArt.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                wallArt.updateDots[i].sprite = wallArt.updateCompleteDot;
            }
        }

        if (wallArt.currentUpgradeNo+1 == wallArt.totalUpdates)
        {
            wallArt.priceShowingObject.SetActive(false);
            wallArt.allUpdatesDone.gameObject.SetActive(true);

        }

    }
    #endregion

    #region VehicleUpdate
    public void UpdateVehicle()
    {
        if (vehicle.currentUpgradeNo >= vehicle.totalUpdates)
        {
            ShowMessage("All Updates Done", 2);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= vehicle.levelsReq[vehicle.currentUpgradeNo])
        {
            if (totalCoins >= vehicle.coinsRequired[vehicle.currentUpgradeNo])
            {

                UpdateVehicleVisuals(vehicle.currentUpgradeNo);
                vehicle.currentUpgradeNo++;
            }
            else
            {
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
            ShowMessage("Levels Required :" + decoration.levelsReq[0], 2);

    }

    void UpdateVehicleVisuals(int upgradeNo)
    {
        //Changing Image Of Vehicle
        for (int i = 0; i < vehicle.prefabs.Length; i++)
        {
            if (i == upgradeNo) vehicle.imageObjectToUpdate.sprite = vehicle.prefabs[upgradeNo];
        }

        if (upgradeNo + 1 < vehicle.totalUpdates)
        {
            vehicle.upgradeImageField.sprite = vehicle.upgradeSprites[upgradeNo+1];

            vehicle.priceText.text = (vehicle.coinsRequired[vehicle.currentUpgradeNo+1]).ToString();
        }
        for (int i = 0; i < vehicle.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
               vehicle.updateDots[i].sprite =vehicle.updateCompleteDot;
            }
        }
        if (vehicle.currentUpgradeNo+1 == vehicle.totalUpdates)
        {
            vehicle.priceShowingObject.SetActive(false);
            vehicle.allUpdatesDone.gameObject.SetActive(true);

        }

    }
    #endregion

    #region FoodMachineUpdate
    public void UpdateFoodMachine()
    {
        if (foodMachine.currentUpgradeNo >= foodMachine.totalUpdates)
        {
            ShowMessage("All Updates Done", 2);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= foodMachine.levelsReq[foodMachine.currentUpgradeNo])
        {
            if (totalCoins >= foodMachine.coinsRequired[foodMachine.currentUpgradeNo])
            {

                UpdateFoodMachineVisuals(foodMachine.currentUpgradeNo);
                foodMachine.currentUpgradeNo++;
            }
            else
            {
                Debug.Log("Coins are not sufficient");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
            Debug.Log("Levels are not sufficient");
            ShowMessage("Levels Required :" + decoration.levelsReq[0], 2);
        }
    }

    void UpdateFoodMachineVisuals(int upgradeNo)
    {
        //Changing Speed Of Food Machine
        SetFoodSpeed(foodMachine.speed[upgradeNo]);  //Not completed

        if (upgradeNo + 1 < foodMachine.totalUpdates)
        {
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo+1];

            foodMachine.priceText.text = (foodMachine.coinsRequired[foodMachine.currentUpgradeNo+1]).ToString();
        }

        for (int i = 0; i < foodMachine.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                foodMachine.updateDots[i].sprite = foodMachine.updateCompleteDot;
            }
        }
        if (foodMachine.currentUpgradeNo+1 == foodMachine.totalUpdates)
        {
            foodMachine.priceShowingObject.SetActive(false);
            foodMachine.allUpdatesDone.gameObject.SetActive(true);

        }

    }
    #endregion
   
    #region BasicFunction
    public int GetTotalCoins()
    {
        return StockInventory.Instance.coins;
    }
    public int GetCurrentLevel()
    {
        return 500;
    }
    public void SetFoodSpeed(int speed)
    {
       
    }

    public void ShowMessage(string message,int time)
    {
        TextManager.Instance.ShowToast(message, time);
    }

#endregion
}



