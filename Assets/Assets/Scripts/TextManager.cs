using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public string tempText= string.Empty;
        public int tempTime=0;
    public RectTransform rt;
    public TMPro.TMP_Text txt;
    public int OffSet;
    public TMPro.TMP_Text Heading;
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

    public void Show2SecondNotification(string incomingText)
    {
        if (transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text == string.Empty)
        {
            transform.GetComponent<Animator>().Play("FadeIn");
            transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = incomingText;
            //Debug.Log(incomingText);
            Invoke("FadeOut", 2);
        }
        else
        {
            //Debug.Log(incomingText);
            tempText = incomingText;
            tempTime = 2;
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

    public void CaptionTextHandler(string headingText,string incomingText,Color shadee)
    {
        StartCoroutine(RevealText(headingText,incomingText, shadee));
    }

    IEnumerator RevealText(string headeen,string texty,Color shade)
    {
        Heading.text = headeen;
        Heading.color = shade;
        var originalString = texty.ToString();
        txt.text = "";
        string rand;
        var numCharsRevealed = 0;
        while (numCharsRevealed < originalString.Length)
        {
            int j = Random.Range(0, 6);
            switch (j)
            {
                case 5:
                    rand = "@";
                    break;
                case 4:
                    rand = "#";
                    break;
                case 3:
                    rand = "$";
                    break;
                case 2:
                    rand = "%";
                    break;
                case 1:
                    rand = "^";
                    break;
                default:
                    rand = "&";
                    break;
            }
            ++numCharsRevealed;
            txt.text = originalString.Substring(0, numCharsRevealed)+rand+"|";
            CaptionsCheck();
            yield return new WaitForSeconds(0.03f);
        }
        txt.text= texty.ToString();
    }
    void CaptionsCheck()
    {
        rt.sizeDelta = new Vector2(rt.rect.width, txt.preferredHeight + Heading.preferredHeight+OffSet);
    }
}
