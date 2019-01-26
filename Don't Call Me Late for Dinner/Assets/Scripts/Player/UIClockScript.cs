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
            hour = (5 - playerClass.getHours()) + "";
       }
       hourText.SetText(hour);
       if (playerClass.getMinutes()>= 60f)
       {
           hour = "00";
       }
       else if (playerClass.getMinutes() < 60f)
       {
           hour = (5 - playerClass.getMinutes()) + "";
       }
       hourText.SetText(hour);
    }
}
