using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public string tempText= string.Empty;
        public int tempTime=0;
    public static TextManager Instance { get; set; }
    
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
    
    }
    public void ShowToast(string incomingText, int time)
    {
        if (transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text == string.Empty)
        {
            transform.GetComponent<Animator>().Play("FadeIn");
            transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = incomingText;
            //Debug.Log(incomingText);
            Invoke("FadeOut", time);
        }
        else
        {
            //Debug.Log(incomingText);
            tempText = incomingText;
            tempTime = time;
            Invoke("ChangePriority", 1f);
        }
    }
    void ChangePriority()
    {
        ShowToast(tempText, tempTime);
       
}

    void FadeOut()
    {
        transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = string.Empty;
        transform.GetComponent<Animator>().Play("FadeOut");
            Invoke("RemoveTextInstance", 2f);
    }
    void RemoveTextInstance()
    { 
        tempText = string.Empty;
        tempTime = 0;
    
    }
}
