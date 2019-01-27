using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkWorldObstacles : MonoBehaviour
{

    GameObject player;
    GameObject dad;

    public Vector3 startingPosition = new Vector3 (21.1f, 4.5f, -10.10769f);
    Vector3 dadStartingPosition = Vector3.zero;
    Rigidbody2D rigidBody;
    float FallingMaxVelocity = -30.0f;
    float LastFallingVelocity = 0.0f;

    // Use this for initialization
    void Awake()
    {

        // subscribe to new scene loaded event
        SceneManager.sceneLoaded += OnWorkWorldSceneLoaded;

        player = GameObject.Find("Player");
        dad = GameObject.Find("Dad");
        rigidBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        var playerMovement = GetComponent<PlayerMovementBeta>();


        if ( playerMovement.IsGrounded() && LastFallingVelocity < FallingMaxVelocity)
        {
            Die();
        }

        else
        {
            LastFallingVelocity = rigidBody.velocity.y;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Collides with Spilled Coffee
        if (other.gameObject.tag == "Coffee")
        {
            Die();
        }
    }

    void OnWorkWorldSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "WorkWorld")
        {
            // set the starting position
            ResetWorkWorldStartPosition();
            // get starting position of Dad
            dadStartingPosition = dad.transform.position;
        }
        else
        {
            // reset dad starting position to zero
            dadStartingPosition = Vector3.zero;
        }
    }

    private void ResetWorkWorldStartPosition()
    {
        // set player starting position
        player.transform.position = startingPosition;
        // if dad starting position has been set, reset dad position
        if(Vector3.zero != dadStartingPosition)
        {
            dad.transform.position = dadStartingPosition;
        }
    }

    void Die()
    {
        var playerClass = transform.parent.gameObject.GetComponent<PlayerClass>();
        // decrement health
        playerClass.SetDadHealth(playerClass.GetDadHealth() - 1);
        // reset position
        ResetWorkWorldStartPosition();
        LastFallingVelocity = 0.0f;
        rigidBody.velocity = new Vector2(0, 0);

    }
}
