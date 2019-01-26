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
        hourText.SetText((5 - playerClass.getHours()) + "");
        minuteText.SetText((60 - playerClass.getMinutes()) + "");
	}
}
