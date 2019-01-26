using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		carUpdate();
	}
	
	void carUpdate()
	{
		if(this.gameObject.tag == "VerticalCar")
			transform.position += (new Vector3 (0, 1f, 0) * speed);
		if(this.gameObject.tag == "HorizontalCar")
			transform.position += (new Vector3 (1f, 0, 0) * speed);
	}
	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "VerticalCarReset")
		{
			Debug.Log(col.gameObject.tag);
			transform.position = new Vector3(14.54f, -33.86f, 0f);
		}
		if(col.gameObject.tag == "HorizontalCarReset")
		{
			transform.position = new Vector3(-16.34f, -6.46f, 0f);
		}
	}
	
}
