using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource player;
    public AudioClip TapSound;
    public AudioClip SuccessSound;
    public AudioClip FailSound;
    public AudioClip TingSound;
    public AudioClip ErrorSound;
    public AudioClip HornSound;
	[Header("Male Sound Collections")]
	public SoundCollection maleYoungCollection,maleKidCollection;
	[Space(5)]
	[Header("Female Sound Collection")]
	public SoundCollection femaleYoungCollection,femaleKidCollection;
    public static SoundManager Instance { get; set; }
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
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(string name)
    {
        if (name == "tap")
        {
            player.clip = TapSound;
        }
        if (name == "success")
        {
            player.clip = SuccessSound;
        }
        if (name == "fail")
        {
            player.clip = FailSound;
        }
        if (name == "ting")
        {
            player.clip = TingSound;
        }
        if (name == "error")
        {
            player.clip = ErrorSound;
        }
        if (name == "horn")
        {
            player.clip = HornSound;
        }
        player.Play();
    }

    public void PlayAISound(string Gender,bool isKid)
    {
        if (Gender == "Male")
        {
            if (isKid == true)
            {
                player.clip=maleKidCollection.
            }
            else
            { 
            
            }
        }
        if(Gender == "Female")
        {
            if (isKid == true)
            {

            }
            else
            {

            }
        }
    }
}
