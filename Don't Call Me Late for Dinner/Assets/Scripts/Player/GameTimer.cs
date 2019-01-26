using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {

	public PlayerClass pc;
	public float hours;
	public float mins;
	public bool timerStart = false;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timerStart)
			timer();
	}
	void timer()
	{
		if(pc.time > 1f)
			pc.time -= Time.deltaTime;
		hours = Mathf.Floor(Mathf.Round(pc.time)/60f);
		mins = Mathf.Round(pc.time)%60f; //
		Debug.Log(hours);
		Debug.Log(mins);
	}

    public float getHours()
    {
        return hours;
    }

    public float getMinutes()
    {
        return mins;
    }
}
