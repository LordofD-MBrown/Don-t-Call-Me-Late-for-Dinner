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
}
