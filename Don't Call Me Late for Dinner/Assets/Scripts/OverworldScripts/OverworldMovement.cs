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
	// Use this for initialization 
	void Start () 
	{
        player = GameObject.Find("Player");
		rb = GetComponent<Rigidbody2D>(); 
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
        
        if (other.gameObject.tag == "Work")
			SceneManager.LoadScene("WorkWorld");
        if(other.gameObject.tag == "School")
			SceneManager.LoadScene("School");
		if(other.gameObject.tag == "Puddle")
		{
			player.GetComponent<PlayerClass>().time -= 5f;
			other.gameObject.SetActive(false);
		}
    }
}