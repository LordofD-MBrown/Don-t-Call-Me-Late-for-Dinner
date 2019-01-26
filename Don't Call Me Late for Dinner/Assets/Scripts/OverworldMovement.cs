using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
<<<<<<< HEAD:Don't Call Me Late for Dinner/Assets/Scripts/PlayerMovement.cs
    [SerializeField]
    private float _speed = 20f;

    [SerializeField] private float _jumpForce = 10f;

    [SerializeField] private float _downRaycastDistance = 1.2f;

    public LayerMask GroundLayer;

    private bool _grounded = false;

    private Rigidbody2D _rigidBody2D;

    // Use this for initialization
=======
    public float speed = 20f;
    public Vector2 move = Vector2.zero;
	public Rigidbody2D rb2D;
>>>>>>> master:Don't Call Me Late for Dinner/Assets/Scripts/OverworldMovement.cs
    void Start()
    {
		
    }

<<<<<<< HEAD:Don't Call Me Late for Dinner/Assets/Scripts/PlayerMovement.cs
    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
=======

>>>>>>> master:Don't Call Me Late for Dinner/Assets/Scripts/OverworldMovement.cs
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
<<<<<<< HEAD:Don't Call Me Late for Dinner/Assets/Scripts/PlayerMovement.cs
        _rigidBody2D.isKinematic = false;
        // Grabbing the User input vectors
        var horizontalInput = Input.GetAxisRaw("Horizontal");

        // Move Player
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);

        if(IsGrounded() && Input.GetKeyDown(KeyCode.W))
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
=======
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
>>>>>>> master:Don't Call Me Late for Dinner/Assets/Scripts/OverworldMovement.cs
        }

        return false;
    }

    void Jump()
    {
        Debug.Log("Made it to jump();");
        if (!IsGrounded())
        {
<<<<<<< HEAD:Don't Call Me Late for Dinner/Assets/Scripts/PlayerMovement.cs
            return;
=======
			if (Input.GetKey(KeyCode.W)
            Debug.Log("holding down 'A'");
            Vector2 moveInput = new Vector2(-1f, 0f);
            move = moveInput.normalized * speed;
            rb2D.velocity = move;
>>>>>>> master:Don't Call Me Late for Dinner/Assets/Scripts/OverworldMovement.cs
        }
        else
        {
<<<<<<< HEAD:Don't Call Me Late for Dinner/Assets/Scripts/PlayerMovement.cs
            _rigidBody2D.velocity = Vector2.up * _jumpForce;
=======
            Debug.Log("holding down 'D'");
            Vector2 moveInput = new Vector2(1f, 0f);
            move = moveInput.normalized * speed;
            rb2D.velocity = move;
>>>>>>> master:Don't Call Me Late for Dinner/Assets/Scripts/OverworldMovement.cs
        }
    }
}