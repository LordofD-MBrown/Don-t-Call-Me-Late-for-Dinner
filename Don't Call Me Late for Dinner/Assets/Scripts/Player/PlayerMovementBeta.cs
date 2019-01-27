using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerMovementBeta : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private float _jumpForce = 10f;
    [SerializeField]
    private float _downRaycastDistance = 1.2f;

    public LayerMask GroundLayer;
    private bool _grounded = false;
    private Rigidbody2D _rigidBody2D;
	

    GameObject player;
    GameObject dad;
    GameObject momPlatform;
    GameObject momTopDown;
    GameObject son;

    // Use this for initialization
    void Start()
    {
        dad = GameObject.Find("Dad");
        momPlatform = GameObject.Find("Mom(Platform)");
        momTopDown = GameObject.Find("Mom(TopDown)");
        son = GameObject.Find("Son");
        player = GameObject.Find("Player");
    }

    void Awake()
    {
		
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        _rigidBody2D.isKinematic = false;

        // Grabbing the User input vectors
        var horizontalInput = Input.GetAxisRaw("Horizontal");

        // Move Player
        _rigidBody2D.velocity = new Vector2(horizontalInput * _speed, _rigidBody2D.velocity.y);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            Jump();

    }
    


    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        var direction = Vector2.down;
        var distance = 1.2f;
        var hit = Physics2D.Raycast(position, direction, _downRaycastDistance, GroundLayer);

        if (hit.collider != null)
        { 
            return true;
        }

        return false;

    }

    void Jump()
    {
        Debug.Log("Made it to jump();");
        if (!IsGrounded())
        {
            return;
        }

        else
        {
            _rigidBody2D.velocity = Vector2.up * _jumpForce;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Door to Overworld(Home)")
        {   
        
            SceneManager.LoadScene("Overworld");
			for (int i = 0; i < player.transform.childCount; i++)
				if(GameObject.Find("HomeSpawnOW") != null)
					player.transform.GetChild(i).position = GameObject.Find("HomeSpawnOW").transform.position;
				else
					Debug.Log("Didn't find home spawn point!");
        }
        if (other.gameObject.name == "Exit(To Overworld from Office)")
        {
			
            SceneManager.LoadScene("Overworld");
			for (int i = 0; i < player.transform.childCount; i++)
				if(GameObject.Find("OfficeSpawnOW") != null)
					player.transform.GetChild(i).position = GameObject.Find("OfficeSpawnOW").transform.position;
				else
					Debug.Log("Didn't find office spawn point!");
        }

    }
}