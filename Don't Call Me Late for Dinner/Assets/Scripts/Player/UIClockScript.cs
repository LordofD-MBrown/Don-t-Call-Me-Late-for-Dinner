using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIClockScript : MonoBehaviour
{
    GameObject player;
    public GameObject hourObject;
    public GameObject minuteObject;
    TextMeshProUGUI hourText;
    TextMeshProUGUI minuteText;
    GameTimer playerClass;
    string hour;
    string mins;
  
	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        hourText = hourObject.GetComponent<TextMeshProUGUI>();
        minuteText = minuteObject.GetComponent<TextMeshProUGUI>();
        playerClass = player.GetComponent<GameTimer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       if(playerClass.getHours() >= 4f)
       {
            hour = "12";
       }
       else if(playerClass.getHours() < 4f)
       {
            hour = "0" + (4 - playerClass.getHours()) + "";
       }       
       if (playerClass.getMinutes() >= 60f)
       {
           mins = "00";
       }
       else if (playerClass.getMinutes() < 60f)
       {
            if (playerClass.getMinutes() > 50)
            {
                mins =  "0" + (60 - playerClass.getMinutes()) + "";
            }
            else
            {
                mins = (60 - playerClass.getMinutes()) + "";
            }   
       }      
       if(mins == "60")
        {
            mins = "00";
            minuteText.SetText(mins);
        }
        if (mins == "00")
        {
            hourText.SetText(((4 - playerClass.getHours()) + 1) + "");
        }
        else
        {
            hourText.SetText(hour);
            minuteText.SetText(mins);
        }
        
        if(hourText.text == "05")
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("End Screen");
        }
    }
}
