using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonMovement : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float jumpForce;
    private float input;
    private bool grounded = false;
    public float gravity;
    private bool ropeClimb = false;
    private int jumpCount = 0;
    private Vector2 spawnPoint;

    private Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.FindGameObjectWithTag("fhjn").transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        moveLateral();
        jump();
        moveVertical();
        if (grounded)
        {
            jumpCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walkables"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walkables"))
        {
            grounded = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            ropeClimb = true;
            //}
        }

        else if (other.gameObject.CompareTag("Lego"))
        {
            Debug.Log("DEATH");
            transform.position = spawnPoint;
        }
        if (other.gameObject.name == "You win school")
        {
            Debug.Log("Attempting to leave the school");
            SceneManager.LoadScene("Overworld");
            for (int i = 0; i < player.transform.childCount; i++)
                if (GameObject.Find("SchoolSpawnOW") != null)
                    player.transform.GetChild(i).position = GameObject.Find("SchoolSpawnOW").transform.position;
                else
                    Debug.Log("Didn't find the School Spawn Point");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            ropeClimb = false;
            rb.gravityScale = 3f;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            //rb.gravityScale = 0.0f;
        }

    }

    private void moveLateral()
    {
        input = Input.GetAxisRaw("Horizontal");
        //if ((grounded || jumpCount > 0) && !ropeClimb)
        //{
        //    rb.velocity = new Vector2(input * speed, rb.velocity.y);
        //}
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        if (input > 0)
        {
            FlipSprite(this.gameObject, false);
        }
        else if (input < 0)
        {
            FlipSprite(this.gameObject, true);
        }
    }

    //used to climb rope
    private void moveVertical()
    {
        if (ropeClimb)
        {
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
        //if (jumpCount < 1 && Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Jumped");
        //    rb.velocity = Vector2.up * jumpForce;
        //    jumpCount++;
        //}

        //if (jumpCount == 2)
        //{
        //    jumpCount = 0;
        //}

        if (Input.GetKeyDown(KeyCode.Space) && (grounded || ropeClimb))
        {
            rb.velocity = Vector2.up * jumpForce;
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