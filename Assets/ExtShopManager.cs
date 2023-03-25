using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtShopManager : MonoBehaviour
{
    [System.Serializable]
    public class Upgradable
    {
        public GameObject[] prefabs;
        public bool shouldChangeMats = false;
        public Material[] mats;
        public int[] levelsReq;
        public int upgradeNo = 0;
        public int[] coinsRequired;
        public Transform parentTransform;
    }
    [SerializeField]
    public Upgradable tv,painting,deco;
    
  
    public void UpgradeTV()      //Call This Function For Upgrade TV button in UI
    {
        int upgradeIndex = tv.upgradeNo++;
        if (!(tv.levelsReq[upgradeIndex - 1] <= LevelManager.Instance.LevelNo))
        {
            Debug.Log("Upgrade Not Possible Due To Less Levels Completed");
            return;
        }
        int currentcoins = StockInventory.Instance.coins;
        if(tv.upgradeNo ==0)
        {

            if (currentcoins >= tv.coinsRequired[0])
            {
                Debug.Log("Upgrade Possible");
                UpdateTVVisuals();
                tv.upgradeNo++;
            }
            else { Debug.Log("Upgrade Not Possible Due To Less Coins"); }
        }
        else
        {
            if (currentcoins >= tv.coinsRequired[tv.upgradeNo])
            {
                Debug.Log("Upgrade Possible");
            }
            else
            {
                Debug.Log("Upgrade Not Possible Due To Coins");
            }
        }
    }

    public void UpdateTVVisuals()
    {
       for(int i=0;i<tv.prefabs.Length;i++)
        {
            if (i == tv.upgradeNo - 1)
            {
                tv.prefabs[i].SetActive(true);
            }
            else
            {
                tv.prefabs[i].SetActive(false);
            }
        }

    }

}



