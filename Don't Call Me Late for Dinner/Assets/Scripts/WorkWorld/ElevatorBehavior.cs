using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    private Rigidbody2D _leftElevator;
    private Rigidbody2D _rightElevator;
    [SerializeField] private float _speed = 10;

    private float _elevatorFloor0 = -18.47f;


    // Start is called before the first frame update
    void Start()
    {
        // Grab Elevator Game Objects
        var leftElevatorGameObject = GameObject.FindGameObjectWithTag("Work_ElevatorLeft");
        var rightElevatorGameObject = GameObject.FindGameObjectWithTag("Work_ElevatorRight");

        // Grab Elevator Rigid bodies
        _leftElevator = leftElevatorGameObject.GetComponent<Rigidbody2D>();
        _rightElevator = rightElevatorGameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_rightElevator.position.y >= _elevatorFloor0)
        {
            _rightElevator.velocity = new Vector2(0, 0);
            return;
        }
        
        _rightElevator.velocity = new Vector2(_rightElevator.velocity.x, _speed);

    }
}
