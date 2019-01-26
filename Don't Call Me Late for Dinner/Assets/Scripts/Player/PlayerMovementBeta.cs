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
    


    bool IsGrounded()
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
            DontDestroyOnLoad(player);            
            SceneManager.LoadScene("Overworld");
            player.transform.Translate(5f, 1f, 0f);
        }
        if (other.gameObject.name == "Exit(To Overworld from Office)")
        {
            DontDestroyOnLoad(player);
            SceneManager.LoadScene("Overworld");
            player.transform.position = new Vector3(7.69f, -2.85f,-1f);
        }

    }
}