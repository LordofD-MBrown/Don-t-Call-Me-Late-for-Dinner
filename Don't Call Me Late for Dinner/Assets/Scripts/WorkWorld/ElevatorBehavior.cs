using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    private Rigidbody2D elevatorRigidbody;

    [SerializeField] private const float _elevatorSpeed = 5f;

    // Elevator Targets
    public Vector2 topFloorTarget;
    public Vector2 bottomFloorTarget;

    // is elevator going up
    private bool elevatorGoingUp;
    private int elevatorWaitTimeRemaining;

    //private readonly Vector2 _testVector2 = new Vector2(0, 0.44f);

    private float _elevatorFloor1 = -18.47f;


    // Start is called before the first frame update
    private void Start()
    {
        // Grab Elevator Game Objects
        GameObject elevatorGameObject = this.gameObject;

        // Create right Elevator Floors 
        elevatorGoingUp = true;
        elevatorWaitTimeRemaining = 0;

        // Grab Elevator Rigid bodies
        elevatorRigidbody = elevatorGameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // handle elevator movement
        HandleElevatorMovement(elevatorRigidbody, topFloorTarget, bottomFloorTarget, ref elevatorGoingUp, ref elevatorWaitTimeRemaining);
    }

    void HandleElevatorMovement(Rigidbody2D elevatorRigidBody, Vector2 targetTopFloor, Vector2 targetBottomFloor, ref bool goingUp, ref int elevatorWaitTimeRemaining)
    {
        // if the elevator is moving
        if (elevatorWaitTimeRemaining == 0)
        {
            // flip elevator direction if elevator has reached the floor
            if (goingUp && Vector2.Distance(targetTopFloor, elevatorRigidBody.position) <= .00000001f)
            {
                goingUp = false;
                elevatorWaitTimeRemaining = 50;
            }
            else if (!goingUp && Vector2.Distance(targetBottomFloor, elevatorRigidBody.position) <= .00000001f)
            {
                goingUp = true;
                elevatorWaitTimeRemaining = 50;
            }


            // move elevator up
            if (goingUp && Vector2.Distance(targetTopFloor, elevatorRigidBody.position) > .00000001f)
            {
                var newPosition = Vector2.MoveTowards(elevatorRigidBody.position, targetTopFloor,
                    _elevatorSpeed * Time.deltaTime);

                elevatorRigidBody.MovePosition(newPosition);
            }

            // move elevator down
            if (!goingUp && Vector2.Distance(targetBottomFloor, elevatorRigidBody.position) > .00000001f)
            {
                var newPosition = Vector2.MoveTowards(elevatorRigidBody.position, targetBottomFloor,
                    _elevatorSpeed * Time.deltaTime);

                elevatorRigidBody.MovePosition(newPosition);
            }
        }
        // if the elevator is waiting
        else
        {
            // decrement wait time
            elevatorWaitTimeRemaining--;
        }
    }
}
