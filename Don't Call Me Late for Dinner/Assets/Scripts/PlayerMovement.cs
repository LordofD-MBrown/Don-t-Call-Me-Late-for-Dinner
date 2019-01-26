using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 10f;
    public float gravity = 30f;
    public Vector3 move = Vector3.zero;
    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("holding down 'W'");
            Vector3 moveInput = new Vector3(0f, 1f, 0f);
            move = moveInput.normalized * speed;
            transform.position += move * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("holding down 'S'");
            Vector3 moveInput = new Vector3(0f, -1f, 0f);
            move = moveInput.normalized * speed;
            transform.position += move * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("holding down 'A'");
            Vector3 moveInput = new Vector3(-1f, 0f, 0f);
            move = moveInput.normalized * speed;
            transform.position += move * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("holding down 'D'");
            Vector3 moveInput = new Vector3(1f, 0f, 0f);
            move = moveInput.normalized * speed;
            transform.position += move * Time.deltaTime;
        }
    }
}