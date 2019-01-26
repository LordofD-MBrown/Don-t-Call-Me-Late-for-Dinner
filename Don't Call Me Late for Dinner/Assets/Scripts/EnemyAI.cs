using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    float moveX;
    public float speed = 0;
    void Start()
    {
        moveX = 1f;
    }

    void Update()
    {
        transform.position += (new Vector3(moveX, 0, 0) * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Waypoint")
        {
            moveX *= -1;
        }
    }
}