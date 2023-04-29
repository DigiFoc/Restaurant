using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCleaner : MonoBehaviour
{
    public UnityEngine.Playables.PlayableDirector garbageWala;
    bool isRecentlyUsed;
    public GameObject GarbageObj;
    public GameObject Player;
    void Start()
    {
        GarbageObj.SetActive(false);
    }

    // Update is called once per frame
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player")
        {
            if (!isRecentlyUsed)
            {
                Player = other.gameObject;
                other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;
                other.gameObject.GetComponent<PlayerFoodHandling>().broomIk = true;
                GarbageObj.SetActive(true);
                garbageWala.Play();
                StartCoroutine(StartGarbage());
            }
            else
            {
                TextManager.Instance.ShowToast("You Recently Use Garbage Cleaner, Come back Later!", 5);
            }
        }

    }

    IEnumerator StartGarbage()
    {
        isRecentlyUsed = true;
        yield return new WaitForSeconds(30f);
        isRecentlyUsed = false;

    }

    public void EndTimeline()
    {

        Player.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        Player.gameObject.GetComponent<PlayerFoodHandling>().broomIk = false;
        garbageWala.Stop();
        GarbageObj.SetActive(false);
      

    }
}
