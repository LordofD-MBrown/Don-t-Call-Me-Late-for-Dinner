﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStarter : MonoBehaviour {

	public GameTimer gt;
    GameObject clock;
    GameObject doorToOutside;
    BoxCollider2D door;
    private void Start()
    {
        clock = GameObject.Find("Clock");
        clock.SetActive(false);
        doorToOutside = GameObject.Find("Door to Overworld(Home)");
        door = doorToOutside.GetComponent<BoxCollider2D>();
        door.isTrigger = false;
    }
    void Awake()
	{
		gt = GameObject.Find("Player").GetComponent<GameTimer>();       
	}
	
	public void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log(col.gameObject.name);
		if(col.gameObject.tag == "Player")
		{
			//prompt player, take confirmation from UI:
			//if player says yes:
				gt.timerStart = true;
            clock.SetActive(true);
            door.isTrigger = true;
        }
	}
}
