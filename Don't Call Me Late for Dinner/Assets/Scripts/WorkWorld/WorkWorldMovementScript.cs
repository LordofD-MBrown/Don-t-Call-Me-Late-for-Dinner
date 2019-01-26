using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkWorldMovementScript : MonoBehaviour {

    public float speed = 20f;
    public float jumpForce = 10f;
    public float gravity = 30f;
    public Vector2 move = Vector2.zero;
    Rigidbody2D player;
    Collider2D jumpMap;
    Collider2D collisionMap;
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        collisionMap = GameObject.FindGameObjectWithTag("Collision Map").GetComponent<Collider2D>();
        jumpMap = GameObject.FindGameObjectWithTag("Jump Map").GetComponent<Collider2D>();
    }
    void Update()
    {
        movePlayer();
    }
    void movePlayer()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && player.IsTouching(jumpMap))
        {
            Vector2 moveInput = new Vector2(0f, 1f);
            move = moveInput.normalized * jumpForce;
            player.MovePosition(player.position + move * Time.fixedDeltaTime);
        }
        //Move Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector2 moveInput = new Vector2(-1f, 0f);
            move = moveInput.normalized * speed;
            player.MovePosition(player.position + move * Time.fixedDeltaTime);
        }
        //Move Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector2 moveInput = new Vector2(1f, 0f);
            move = moveInput.normalized * speed;
            player.MovePosition(player.position + move * Time.fixedDeltaTime);
        }
    }


}
