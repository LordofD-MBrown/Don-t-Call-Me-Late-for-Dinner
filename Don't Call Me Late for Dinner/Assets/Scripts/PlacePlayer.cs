using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlayer : MonoBehaviour {
	
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		if (player != null)
		{
			for (int i = 0; i < player.transform.childCount; i++)
				player.transform.GetChild(i).position = transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
