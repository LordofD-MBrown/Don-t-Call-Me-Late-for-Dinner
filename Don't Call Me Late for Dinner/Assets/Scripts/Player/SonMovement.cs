using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonMovement : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float input;
    private bool grounded = false;
    public float gravity;
    private bool ropeClimb = false;
    private int jumpCount = 0;

    private Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        moveLateral();
        jump();
        moveVertical();
        if (grounded)
        {
            Debug.Log("Grounded");
            jumpCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Rope")
        {
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            ropeClimb = true;
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Rope")
        {
            ropeClimb = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Rope")
        {
            //rb.gravityScale = 0.0f;
        }
    }

    private void moveLateral()
    {
        input = Input.GetAxisRaw("Horizontal");
        if ((grounded || jumpCount > 0) && !ropeClimb)
        {
            rb.velocity = new Vector2(input * speed, rb.velocity.y);
        }
    }

    //used to climb rope
    private void moveVertical()
    {
        if (ropeClimb)
        {
            Debug.Log("Here");
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector2.up * speed;
                rb.gravityScale = 0.0f;

            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = Vector2.down * speed;
                rb.gravityScale = 0.0f;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                rb.velocity = Vector2.up * 0;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                rb.velocity = Vector2.up * 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCount = 0;
                ropeClimb = false;
                rb.gravityScale = 1.0f;
            }
        }
        //if(!ropeClimb || Input.GetKeyUp(KeyCode.W))
        //{
        //rb.gravityScale = 1.0f;
        //}


    }

    //used to jump
    private void jump()
    {
        Debug.Log("jumpCount: " + jumpCount);
        if (jumpCount < 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumped");
            rb.velocity = Vector2.up * jumpForce;
            jumpCount++;
        }

        if (jumpCount == 2)
        {
            jumpCount = 0;
        }
    }
}
