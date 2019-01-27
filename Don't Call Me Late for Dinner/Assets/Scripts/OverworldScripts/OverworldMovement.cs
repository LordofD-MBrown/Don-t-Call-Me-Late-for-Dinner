using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldMovement : MonoBehaviour
{ 
	public float speed; 
	private float input; 
	public float gravity; 
	private Rigidbody2D rb;
    GameObject player;
    private Vector2 spawnPoint;
	// Use this for initialization 
	void Start () 
	{
        player = GameObject.Find("Player");
		rb = GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.FindGameObjectWithTag("fhjn").transform.position;
        
	}
// Update is called once per frame 
	void LateUpdate () 
	{ 
		moveLateral(); 
		moveVertical(); 
	} 
	private void moveLateral() 
	{ 
		input = Input.GetAxisRaw("Horizontal"); 
		rb.velocity = new Vector2(input * speed, rb.velocity.y); 
	} 
	private void moveVertical() 
	{ 
		input = Input.GetAxisRaw("Vertical");
		rb.velocity = new Vector2(rb.velocity.x, input * speed); 
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("WorkWorld");
        if (other.gameObject.tag == "Work")
        {
            for (int i = 0; i < player.transform.childCount; i++)
				if(GameObject.Find("InOfficeSpawn") != null)
					player.transform.GetChild(i).position = GameObject.Find("InOfficeSpawn").transform.position;
				else
					Debug.Log("Didn't find office spawn point!");
        }
        else if(other.gameObject.tag == "School")
        {
            SceneManager.LoadScene("School");
			for (int i = 0; i < player.transform.childCount; i++)
				if(GameObject.Find("InSchoolSpawn") != null)
					player.transform.GetChild(i).position = GameObject.Find("InSchoolSpawn").transform.position;
				else
					Debug.Log("Didn't find office spawn point!");
        }
		else if(other.gameObject.tag == "Puddle")
		{
			player.GetComponent<PlayerClass>().time -= 5f;
			other.gameObject.SetActive(false);
		}
    }
}