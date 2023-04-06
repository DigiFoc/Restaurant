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
    public class StorageUpgrade
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
        public Image[] prefabs;
        public Image imageObjectToUpdate;
        public int[] levelsReq;
        public int[] speeds;
        public int currentUpgradeNo = 0;
        public int currentSpeed;
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
    [Space(5)]
    [Header("Storage Update")]
    public StorageUpgrade storage;





    public void Awake()
    {
        StartCoroutine(loadUpgrades());
    }
    IEnumerator loadUpgrades()
    {
        yield return new WaitForSeconds(1);
        tv.currentUpgradeNo = GameManager.Instance.currentTVUpgrade;
        decoration.currentUpgradeNo = GameManager.Instance.currentHeartUpgrade;
        soundSystem.currentUpgradeNo = GameManager.Instance.currentSpeakerUpgrade;
        vegetation.currentUpgradeNo = GameManager.Instance.currentVaseUpgrade;
        wallArt.currentUpgradeNo = GameManager.Instance.currentWallArtUpgrade;
        vehicle.currentUpgradeNo = GameManager.Instance.currentVehicleUpgrade;
        foodMachine.currentUpgradeNo = GameManager.Instance.currentMachineUpgrade;
        storage.currentUpgradeNo = GameManager.Instance.currentStorageUpgrade;

        WriteTVVisuals(tv.currentUpgradeNo);
        WriteDecorationVisuals(decoration.currentUpgradeNo);
        WriteSoundSystemVisuals(soundSystem.currentUpgradeNo);
        WriteVegetationVisuals(vegetation.currentUpgradeNo);
        WriteWallArtVisuals(wallArt.currentUpgradeNo);
        WriteVehicleVisuals(vehicle.currentUpgradeNo);
        WriteFoodMachineVisuals(foodMachine.currentUpgradeNo);
        WriteStorageVisuals(storage.currentUpgradeNo);
        /* UpdatedecorationVisuals(decoration.currentUpgradeNo - 1);
         UpdateSoundSystemVisuals(soundSystem.currentUpgradeNo - 1);
         UpdateVegetationVisuals(vegetation.currentUpgradeNo - 1);
         UpdateWallArtVisuals(wallArt.currentUpgradeNo - 1);
         UpdateVehicleVisuals(vehicle.currentUpgradeNo - 1);
         UpdateFoodMachineVisuals(foodMachine.currentUpgradeNo - 1)*/
        ;
    }


    #region TVUpdate
    public void UpdateTV()
    {

        if (tv.currentUpgradeNo >= tv.totalUpdates)
        {
           // Debug.Log("CHAL GYAA TV");
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
                GameManager.Instance.SaveTVUpgrade(tv.currentUpgradeNo);
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
                //Debug.Log("Coins not sufficinet");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
           // Debug.Log("Levels not Sufficient");
            ShowMessage("Levels Required :" + tv.levelsReq[0], 2);
        }
    }

    void UpdateTVVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < tv.prefabs.Length; i++)
        {
            if (i == upgradeNo) tv.prefabs[i].SetActive(true);
            else tv.prefabs[i].SetActive(false);
        }

        if (upgradeNo + 1 < tv.totalUpdates)
        {
            tv.upgradeImageField.sprite = tv.upgradeSprites[upgradeNo + 1];

            tv.priceText.text = tv.coinsRequired[tv.currentUpgradeNo + 1].ToString();
        }
        for (int i = 0; i < tv.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                tv.updateDots[i].sprite = tv.updateCompleteDot;
            }
        }

        if (tv.currentUpgradeNo + 1 == tv.totalUpdates)
        {
            tv.priceShowingObject.SetActive(false);
            tv.allUpdatesDone.gameObject.SetActive(true);

        }


    }

    void WriteTVVisuals(int upgradeNo)
    {
      //  Debug.Log(tv.totalUpdates);
        //Changing Model Of TV
        for (int i = 1; i <= tv.prefabs.Length; i++)
        {

            if (i == upgradeNo) tv.prefabs[i - 1].SetActive(true);
            else tv.prefabs[i - 1].SetActive(false);
        }

        if (upgradeNo < tv.totalUpdates)
        {
            tv.priceText.text = tv.coinsRequired[tv.currentUpgradeNo].ToString();
            tv.upgradeImageField.sprite = tv.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == tv.totalUpdates)
        {
            tv.upgradeImageField.sprite = tv.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < tv.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                tv.updateDots[i].sprite = tv.updateCompleteDot;
            }
        }

        if (tv.currentUpgradeNo == tv.totalUpdates)
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
                GameManager.Instance.SaveHeartUpgrade(decoration.currentUpgradeNo);
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
              //  Debug.Log("Coins Not Sufficient");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
          //  Debug.Log("Levels Not Sufficient");
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

            decoration.priceText.text = decoration.coinsRequired[decoration.currentUpgradeNo + 1].ToString();
        }
        for (int i = 0; i < decoration.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                decoration.updateDots[i].sprite = decoration.updateCompleteDot;
            }
        }
        if (decoration.currentUpgradeNo + 1 == decoration.totalUpdates)
        {
            decoration.priceShowingObject.SetActive(false);
            decoration.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteDecorationVisuals(int upgradeNo)
    {
      //  Debug.Log(decoration.totalUpdates);
        //Changing Model Of TV
        for (int i = 1; i <= decoration.prefabs.Length; i++)
        {

            if (i == upgradeNo) decoration.prefabs[i - 1].SetActive(true);
            else decoration.prefabs[i - 1].SetActive(false);
        }

        if (upgradeNo < decoration.totalUpdates)
        {
            decoration.priceText.text = decoration.coinsRequired[decoration.currentUpgradeNo].ToString();
            decoration.upgradeImageField.sprite = decoration.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == decoration.totalUpdates)
        {
            decoration.upgradeImageField.sprite = decoration.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < decoration.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                decoration.updateDots[i].sprite = decoration.updateCompleteDot;
            }
        }

        if (decoration.currentUpgradeNo == decoration.totalUpdates)
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
                GameManager.Instance.SaveSpeakerUpgrade(soundSystem.currentUpgradeNo);
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
              //  Debug.Log("Coins are not sufficient");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
           // Debug.Log("Levels are not sufficient");
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
            soundSystem.priceText.text = (soundSystem.coinsRequired[soundSystem.currentUpgradeNo + 1]).ToString();
        }
        for (int i = 0; i < soundSystem.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                soundSystem.updateDots[i].sprite = soundSystem.updateCompleteDot;
            }
        }

        if (soundSystem.currentUpgradeNo + 1 == soundSystem.totalUpdates)
        {
            soundSystem.priceShowingObject.SetActive(false);
            soundSystem.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteSoundSystemVisuals(int upgradeNo)
    {
     //   Debug.Log(soundSystem.totalUpdates);
        //Changing Model Of TV
        for (int i = 1; i <= soundSystem.prefab.Length; i++)
        {

            if (i == upgradeNo) soundSystem.prefab[i - 1].SetActive(true);
            else soundSystem.prefab[i - 1].SetActive(false);
        }

        if (upgradeNo < soundSystem.totalUpdates)
        {
            soundSystem.priceText.text = soundSystem.coinsRequired[soundSystem.currentUpgradeNo].ToString();
            soundSystem.upgradeImageField.sprite = soundSystem.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == soundSystem.totalUpdates)
        {
            soundSystem.upgradeImageField.sprite = soundSystem.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < soundSystem.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                soundSystem.updateDots[i].sprite = soundSystem.updateCompleteDot;
            }
        }

        if (soundSystem.currentUpgradeNo == soundSystem.totalUpdates)
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
                GameManager.Instance.SaveVaseUpgrade(vegetation.currentUpgradeNo);
                AdmobController.Instance.ShowInterstitialAd();
            }
            else
            {
                Debug.Log("Coins are not sufficient");
                ShowMessage("Coins Are Not Suffiecient", 2);
            }
        }
        else
        {
          //  Debug.Log("Levels are not sufficient");
            ShowMessage("Levels Required :" + decoration.levelsReq[0], 2);
        }
    }

    void UpdateVegetationVisuals(int upgradeNo)
    {
        //Changing Model Of TV
        for (int i = 0; i < vegetation.prefab.Length; i++)
        {
            if (i == upgradeNo) vegetation.prefab[i].SetActive(true);
            //else vegetation.prefab[i].SetActive(false);
        }

        if (upgradeNo + 1 < vegetation.totalUpdates)
        {
            vegetation.upgradeImageField.sprite = vegetation.upgradeSprites[upgradeNo + 1];
            vegetation.priceText.text = (vegetation.coinsRequired[vegetation.currentUpgradeNo + 1]).ToString();
        }
        for (int i = 0; i < vegetation.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                vegetation.updateDots[i].sprite = vegetation.updateCompleteDot;
            }
        }

        if (vegetation.currentUpgradeNo + 1 == vegetation.totalUpdates)
        {
            vegetation.priceShowingObject.SetActive(false);
            vegetation.allUpdatesDone.gameObject.SetActive(true);

        }

    }
    void WriteVegetationVisuals(int upgradeNo)
    {
       // Debug.Log(vegetation.totalUpdates);
        //Changing Model Of TV
        for (int i = 1; i <= vegetation.prefab.Length; i++)
        {

            if (i == upgradeNo) vegetation.prefab[i - 1].SetActive(true);
            else vegetation.prefab[i - 1].SetActive(false);
        }

        if (upgradeNo < vegetation.totalUpdates)
        {
            vegetation.priceText.text = vegetation.coinsRequired[vegetation.currentUpgradeNo].ToString();
            vegetation.upgradeImageField.sprite = vegetation.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == vegetation.totalUpdates)
        {
            vegetation.upgradeImageField.sprite = vegetation.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < vegetation.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                vegetation.updateDots[i].sprite = vegetation.updateCompleteDot;
            }
        }

        if (vegetation.currentUpgradeNo == vegetation.totalUpdates)
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
                GameManager.Instance.SaveWallArtUpgrade(wallArt.currentUpgradeNo);
                AdmobController.Instance.ShowInterstitialAd();
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
            if (i < upgradeNo)
            {
                Color temp = wallArt.prefab[i].color;
                temp.a = 1;
                wallArt.prefab[i].color = temp;
            }
        }
        if (upgradeNo + 1 < wallArt.totalUpdates)
        {
            wallArt.upgradeImageField.sprite = wallArt.upgradeSprites[upgradeNo + 1];

            wallArt.priceText.text = (wallArt.coinsRequired[wallArt.currentUpgradeNo + 1]).ToString();
        }
        for (int i = 0; i < wallArt.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                wallArt.updateDots[i].sprite = wallArt.updateCompleteDot;
            }
        }

        if (wallArt.currentUpgradeNo + 1 == wallArt.totalUpdates)
        {
            wallArt.priceShowingObject.SetActive(false);
            wallArt.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteWallArtVisuals(int upgradeNo)
    {
     //   Debug.Log(wallArt.totalUpdates);
        //Changing Model Of TV
        //for (int i = 0; i < wallArt.prefab.Length; i++)
        //{
        // if (i < upgradeNo)
        // {
        //     Color temp = wallArt.prefab[i].color;
        //    temp.a = 1;
        //   wallArt.prefab[i].color = temp;
        //  }
        // }
        for (int i = 1; i <= wallArt.prefab.Length; i++)
        {
            if (i < upgradeNo)
            {
                Color temp = wallArt.prefab[i].color;
                temp.a = 1;
                wallArt.prefab[i].color = temp;
            }

            //if (i == upgradeNo) wallArt.prefab[i - 1].SetActive(true);
            // else wallArt.prefab[i - 1].SetActive(false);
        }

        if (upgradeNo < wallArt.totalUpdates)
        {
            wallArt.priceText.text = wallArt.coinsRequired[wallArt.currentUpgradeNo].ToString();
            wallArt.upgradeImageField.sprite = wallArt.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == wallArt.totalUpdates)
        {
            wallArt.upgradeImageField.sprite = wallArt.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < wallArt.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                wallArt.updateDots[i].sprite = wallArt.updateCompleteDot;
            }
        }

        if (wallArt.currentUpgradeNo == wallArt.totalUpdates)
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
                GameManager.Instance.SaveVehicleUpgrade(vehicle.currentUpgradeNo);
                AdmobController.Instance.ShowInterstitialAd();
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
            if (i == upgradeNo)
            {
                vehicle.prefabs[i].transform.gameObject.SetActive(true);
                vehicle.currentSpeed = vehicle.speeds[i];
            }
            else vehicle.prefabs[i].transform.gameObject.SetActive(false);
        }

        if (upgradeNo + 1 < vehicle.totalUpdates)
        {
            vehicle.upgradeImageField.sprite = vehicle.upgradeSprites[upgradeNo + 1];

            vehicle.priceText.text = (vehicle.coinsRequired[vehicle.currentUpgradeNo + 1]).ToString();
        }
        for (int i = 0; i < vehicle.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                vehicle.updateDots[i].sprite = vehicle.updateCompleteDot;
            }
        }
        if (vehicle.currentUpgradeNo + 1 == vehicle.totalUpdates)
        {
            vehicle.priceShowingObject.SetActive(false);
            vehicle.allUpdatesDone.gameObject.SetActive(true);

        }
		

    }

    void WriteVehicleVisuals(int upgradeNo)
    {
        for (int i = 1; i <= vehicle.prefabs.Length; i++)
        {
            if (i == upgradeNo)
            {
               // Debug.Log("Vehcile pic changed");
                vehicle.prefabs[i - 1].transform.gameObject.SetActive(true);
                vehicle.currentSpeed = vehicle.speeds[i - 1];
            }
            else vehicle.prefabs[i - 1].transform.gameObject.SetActive(false);
        }
       // Debug.Log(vehicle.totalUpdates);
        //Changing Model Of TV

       // Debug.Log("Current Speed is" + vehicle.speeds[vehicle.currentUpgradeNo - 1]);

        vehicle.currentSpeed = vehicle.speeds[vehicle.currentUpgradeNo-1];

        if (upgradeNo < vehicle.totalUpdates)
        {
            vehicle.priceText.text = vehicle.coinsRequired[vehicle.currentUpgradeNo - 1].ToString();
            vehicle.upgradeImageField.sprite = vehicle.upgradeSprites[upgradeNo - 1];
        }
        else if (upgradeNo == vehicle.totalUpdates)
        {
            vehicle.upgradeImageField.sprite = vehicle.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < vehicle.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                vehicle.updateDots[i].sprite = vehicle.updateCompleteDot;
            }
        }

        if (vehicle.currentUpgradeNo == vehicle.totalUpdates)
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
                GameManager.Instance.SaveMachineUpgrade(foodMachine.currentUpgradeNo);
                AdmobController.Instance.ShowInterstitialAd();
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
        //SetFoodSpeed(foodMachine.speed[upgradeNo]);  //Not completed

        if (upgradeNo + 1 < foodMachine.totalUpdates)
        {
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo + 1];

            foodMachine.priceText.text = (foodMachine.coinsRequired[foodMachine.currentUpgradeNo + 1]).ToString();
        }

        for (int i = 0; i < foodMachine.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                foodMachine.updateDots[i].sprite = foodMachine.updateCompleteDot;
            }
        }
        if (foodMachine.currentUpgradeNo + 1 == foodMachine.totalUpdates)
        {
            foodMachine.priceShowingObject.SetActive(false);
            foodMachine.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteFoodMachineVisuals(int upgradeNo)
    {

        if (upgradeNo < foodMachine.totalUpdates)
        {
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo];

            foodMachine.priceText.text = (foodMachine.coinsRequired[foodMachine.currentUpgradeNo]).ToString();
        }




        if (upgradeNo < foodMachine.totalUpdates)
        {
            foodMachine.priceText.text = foodMachine.coinsRequired[foodMachine.currentUpgradeNo].ToString();
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == foodMachine.totalUpdates)
        {
            foodMachine.upgradeImageField.sprite = foodMachine.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < foodMachine.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                foodMachine.updateDots[i].sprite = foodMachine.updateCompleteDot;
            }
        }

        if (foodMachine.currentUpgradeNo == foodMachine.totalUpdates)
        {
            foodMachine.priceShowingObject.SetActive(false);
            foodMachine.allUpdatesDone.gameObject.SetActive(true);

        }


    }


    #endregion

    #region StorageUpdate
    public void UpdateStorageMachine()
    {
        if (storage.currentUpgradeNo >= storage.totalUpdates)
        {
            ShowMessage("All Updates Done", 2);
            return;
        }

        int totalCoins = GetTotalCoins();

        if (GetCurrentLevel() >= storage.levelsReq[storage.currentUpgradeNo])
        {
            if (totalCoins >= storage.coinsRequired[storage.currentUpgradeNo])
            {

                UpdateStorageVisuals(storage.currentUpgradeNo);
                storage.currentUpgradeNo++;
                GameManager.Instance.SaveStorageUpgrade(storage.currentUpgradeNo);
                AdmobController.Instance.ShowInterstitialAd();
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
            ShowMessage("Levels Required :" + storage.levelsReq[0], 2);
        }
    }

    void UpdateStorageVisuals(int upgradeNo)
    {
        //Changing Speed Of Food Machine
        //SetFoodSpeed(foodMachine.speed[upgradeNo]);  //Not completed

        if (upgradeNo + 1 < storage.totalUpdates)
        {
            storage.upgradeImageField.sprite = storage.upgradeSprites[upgradeNo + 1];

            storage.priceText.text = (storage.coinsRequired[storage.currentUpgradeNo + 1]).ToString();
        }

        for (int i = 0; i < storage.updateDots.Length; i++)
        {
            if (i <= upgradeNo)
            {
                storage.updateDots[i].sprite = storage.updateCompleteDot;
            }
        }
        if (storage.currentUpgradeNo + 1 == storage.totalUpdates)
        {
            storage.priceShowingObject.SetActive(false);
            storage.allUpdatesDone.gameObject.SetActive(true);

        }

    }

    void WriteStorageVisuals(int upgradeNo)
    {

        if (upgradeNo < storage.totalUpdates)
        {
            storage.upgradeImageField.sprite = storage.upgradeSprites[upgradeNo];

            storage.priceText.text = (storage.coinsRequired[storage.currentUpgradeNo]).ToString();
        }




        if (upgradeNo < storage.totalUpdates)
        {
            storage.priceText.text = storage.coinsRequired[storage.currentUpgradeNo].ToString();
            storage.upgradeImageField.sprite = storage.upgradeSprites[upgradeNo];
        }
        else if (upgradeNo == storage.totalUpdates)
        {
            storage.upgradeImageField.sprite = storage.upgradeSprites[upgradeNo - 1];
        }
        for (int i = 0; i < storage.updateDots.Length; i++)
        {
            if (i < upgradeNo)
            {
                storage.updateDots[i].sprite = storage.updateCompleteDot;
            }
        }

        if (storage.currentUpgradeNo == storage.totalUpdates)
        {
            storage.priceShowingObject.SetActive(false);
            storage.allUpdatesDone.gameObject.SetActive(true);

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

    public void ShowMessage(string message, int time)
    {
        TextManager.Instance.ShowToast(message, time);
    }

    #endregion
}



