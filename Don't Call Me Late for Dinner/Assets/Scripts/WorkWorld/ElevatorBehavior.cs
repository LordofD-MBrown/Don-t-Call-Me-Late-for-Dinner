using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    private Rigidbody2D _leftElevator;
    private Rigidbody2D _rightElevator;

    [SerializeField] private float _speed = 10;

    [SerializeField] private const float _elevatorSpeed = 10f;

    // Right Elevator Floors
    private Vector2 _rightElevatorFloor0 = new Vector2(-6.1f, -0.5f);
    private Vector2 _rightElevatorFloor3 = new Vector2(-6.1f, -59.4f);

    // Left Elevator Floors
    private Vector2 _leftElevatorFloor0;
    private Vector2 _leftElevatorFloor3;

    private Vector2 _rightCurrentFloor;
    private Vector2 _leftCurrentFloor;

    //private readonly Vector2 _testVector2 = new Vector2(0, 0.44f);

    private float _elevatorFloor1 = -18.47f;


    // Start is called before the first frame update
    private void Start()
    {
        // Grab Elevator Game Objects
        var leftElevatorGameObject = GameObject.FindGameObjectWithTag("Work_ElevatorLeft");
        var rightElevatorGameObject = GameObject.FindGameObjectWithTag("Work_ElevatorRight");

        // Create right Elevator Floors 
        _rightCurrentFloor = _rightElevatorFloor0;
        _leftCurrentFloor = _leftElevatorFloor3;
        // Create Left Elevator Floors
        const float leftElevatorX = -37.3f;
        _leftElevatorFloor0 = new Vector2(leftElevatorX, -0.5f);
        _leftElevatorFloor3 = new Vector2(leftElevatorX, -54.5f);

        // Grab Elevator Rigid bodies
        _leftElevator = leftElevatorGameObject.GetComponent<Rigidbody2D>();
        _rightElevator = rightElevatorGameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        var leftElevatorGameObject = GameObject.FindGameObjectWithTag("Work_ElevatorLeft");
        var leftElevatorCollider = leftElevatorGameObject.GetComponent<Collider2D>();

        var rightElevatorGameObject = GameObject.FindGameObjectWithTag("Work_ElevatorRight");
        var rightElevatorCollider = rightElevatorGameObject.GetComponent<Collider2D>();

        var rightCurrentFloor = _rightElevatorFloor0;

        if (Vector2.Distance(_rightElevatorFloor3, _rightElevator.position) > .00000001f) //(-37.3, -19.4, 0.0)
        {
            var newPosition = Vector2.MoveTowards(_rightElevator.position, _rightElevatorFloor3,
                _elevatorSpeed * Time.deltaTime);

            _rightElevator.MovePosition(newPosition);
        }

    }
}
