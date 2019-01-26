using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    public float speed = 20f;
    public Vector2 move = Vector2.zero;
	public Rigidbody2D rb2D;

    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            move = new Vector2(0f, speed);
			rb2D.velocity += move;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            move = new Vector2(0f, -speed);
            rb2D.velocity += move;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            move= new Vector2(-speed, 0f);
            rb2D.velocity += move;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            move = new Vector2(speed, 0f);
            rb2D.velocity += move;
        }
		if(rb2D.velocity != Vector2.zero)
		{
			if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
				rb2D.velocity += new Vector2(0f, -rb2D.velocity.y);
			if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
				rb2D.velocity += new Vector2(-rb2D.velocity.x, 0f);
			
		}
		
		
    }
}