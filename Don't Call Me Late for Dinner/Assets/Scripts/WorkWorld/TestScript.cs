using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 10f;
    public float gravity = 30f;
    public Vector3 move = Vector3.zero;
    CharacterController controller;
    // Use this for initialization
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();

    }

    void movePlayer()
    {
        if (controller.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            move = transform.TransformDirection(move);
            move *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                move.y = jumpForce;
            }
        }

        move.y -= gravity * Time.deltaTime;

        controller.Move(move * Time.deltaTime);
    }
}