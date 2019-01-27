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
    GameObject momTopDown;
    // Use this for initialization 
    void Start () 
	{
        player = GameObject.Find("Player");
        momTopDown = GameObject.Find("Mom(TopDown)");
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

        // flip player
        if (input > 0)
        {
            FlipSprite(momTopDown, false);
        }
        else if (input < 0)
        {
            FlipSprite(momTopDown, true);
        }
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
    private void FlipSprite(GameObject gameObject, bool flipX)
    {
        if (null != gameObject)
        {
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.flipX = flipX;
        }
    }
}