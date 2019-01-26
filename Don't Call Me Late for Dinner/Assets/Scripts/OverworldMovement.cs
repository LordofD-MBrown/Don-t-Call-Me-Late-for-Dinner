using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    public float speed = 20f;
    public Vector2 move = Vector2.zero;
	public Rigidbody2D rb2D;
    void Start()
    {
		
    }


    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("holding down 'W'");
            Vector2 moveInput = new Vector2(0f, 1f);
            move = moveInput.normalized * speed;
			rb2D.velocity = move;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("holding down 'S'");
            Vector2 moveInput = new Vector2(0f, -1f);
            move = moveInput.normalized * speed;
            rb2D.velocity = move;
        }
        if (Input.GetKey(KeyCode.A))
        {
			if (Input.GetKey(KeyCode.W)
            Debug.Log("holding down 'A'");
            Vector2 moveInput = new Vector2(-1f, 0f);
            move = moveInput.normalized * speed;
            rb2D.velocity = move;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("holding down 'D'");
            Vector2 moveInput = new Vector2(1f, 0f);
            move = moveInput.normalized * speed;
            rb2D.velocity = move;
        }
    }
}