using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovement : MonoBehaviour {

	public float speed;
	public GameObject player;
	public PlayerClass pc;

	// Use this for initialization
	void Awake () 
	{
		if(player == null)
			player = GameObject.Find("Player");
		if(SceneManager.GetActiveScene().name == "Overworld")
        {
            pc = GameObject.Find("Player").GetComponent<PlayerClass>();
        }
		
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
	public void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(this.gameObject.tag == "VerticalCar")
			{
				player.transform.Translate(-2.5f, 0f, 0f);
				pc.time -= 10;
				Debug.Log("Time subtracted");
			}
			if(this.gameObject.tag == "HorizontalCar")
			{
				player.transform.Translate(0f, 2.5f, 0f);
				pc.time -= 10;
				Debug.Log("Time subtracted");
			}
			
			
	
			
		}
	}

}
