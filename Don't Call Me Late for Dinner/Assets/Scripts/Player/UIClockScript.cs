using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            hour = (4 - playerClass.getHours()) + "";
       }
       hourText.SetText(hour);
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
            minuteText.SetText("00");
        }
        else
        {
            minuteText.SetText(mins);
        }     
    }
}
