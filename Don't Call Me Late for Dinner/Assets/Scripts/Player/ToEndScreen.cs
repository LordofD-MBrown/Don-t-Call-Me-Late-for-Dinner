using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEndScreen : MonoBehaviour
{
    GameTimer clock;

	// Use this for initialization
	void Start ()
    {
        clock = GameObject.Find("Player").GetComponent<GameTimer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //End Timer
		if(clock.getHours() == 0 && clock.getMinutes() == 0 && SceneManager.GetActiveScene().name != "HomeWorld")
        {
           
        }
	}
}
