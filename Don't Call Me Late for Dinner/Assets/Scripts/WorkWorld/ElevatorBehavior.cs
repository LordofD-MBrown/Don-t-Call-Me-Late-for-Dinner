using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    private Rigidbody2D _leftElevator;
    private Rigidbody2D _rightElevator;

    [SerializeField] private float _speed = 10;

    [SerializeField] private const float _elevatorSpeed = 10f;

    // Right Elevator Floors
    private Vector2 _rightElevatorFloor0 = new Vector2(-6.1f, -0.5f);
    private Vector2 _rightElevatorFloor1 = new Vector2(-6.1f, -59.4f);
    private Vector2 _rightElevatorFloor2 = new Vector2(-6.1f, -59.4f);
    private Vector2 _rightElevatorFloor3 = new Vector2(-6.1f, -59.4f);

    // Left Elevator Floors
    private Vector2 _leftElevatorFloor0 = new Vector2(-37.3f, -0.5f);
    private Vector2 _leftElevatorFloor3 = new Vector2(-37.3f, -54.5f);

    private Vector2 _rightCurrentFloor;
    private Vector2 _leftCurrentFloor;
    private bool _rightElevatorGoingUp;
    private bool _leftElevatorGoingUp;

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
        _rightElevatorGoingUp = true;
        _leftCurrentFloor = _rightElevatorFloor3;
        _leftElevatorGoingUp = true;

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
        Debug.Log("PositionX: " + rightElevatorGameObject.transform.position.x);

        handleRightElevator2();
    }

    void handleRightElevator2()
    {
        if (_rightElevatorGoingUp && Vector2.Distance(_rightElevatorFloor0, _rightElevator.position) > .00000001f)
        {
            var newPosition = Vector2.MoveTowards(_rightElevator.position, _rightElevatorFloor0,
                _elevatorSpeed * Time.deltaTime);

            _rightElevator.MovePosition(newPosition);
        }
        else
        {
            _rightElevatorGoingUp = false;
        }

        if (!_rightElevatorGoingUp && Vector2.Distance(_rightElevatorFloor3, _rightElevator.position) > .00000001f)
        {
            var newPosition = Vector2.MoveTowards(_rightElevator.position, _rightElevatorFloor3,
                _elevatorSpeed * Time.deltaTime);

            _rightElevator.MovePosition(newPosition);
        } else
        {
            _rightElevatorGoingUp = true;
        }
    }
}
