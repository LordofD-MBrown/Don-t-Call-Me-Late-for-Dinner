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
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
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
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Door to Overworld")
        {
            Debug.Log(other.gameObject.name);
            DontDestroyOnLoad(player);            
            SceneManager.LoadScene("Overworld");
            player.transform.Translate(5f, 1.1f, 0f);
        }
        
    }
}