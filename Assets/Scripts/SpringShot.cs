using UnityEngine;
// this is the Ball launcher for the Pinball game
// It will be used to launch the ball when the player presses the space bar
// When the ball is in the trigger area of the spring gameObject, if space is pressed, the ball will be launched
public class SpringShot : MonoBehaviour

{
    [SerializeField] private float launchForce = 10f; // Force applied to the ball when launched

    private bool isBallInTrigger = false; // Flag to check if the ball is in the trigger area

    void Start()
    {
        // Initialize any variables or settings if needed
        Debug.Log("SpringShot initialized.");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space key is pressed and the ball is in the trigger area
        if (Input.GetKeyDown(KeyCode.Space) && isBallInTrigger)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        // Find the ball GameObject in the scene
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            // Get the Rigidbody component of the ball
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                // Apply a force to the ball in the upward direction
                ballRigidbody.AddForce(Vector3.forward
                 * launchForce, ForceMode.Impulse);
                Debug.Log("Ball launched with force: " + launchForce);
            }
            else
            {
                Debug.LogWarning("No Rigidbody found on the ball.");
            }
        }
        else
        {
            Debug.LogWarning("No ball found in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the ball
        if (other.CompareTag("Ball"))
        {
            isBallInTrigger = true; // Set the flag to true when the ball enters the trigger
            Debug.Log("Ball entered the spring trigger area.");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the ball
        if (other.CompareTag("Ball"))
        {
            isBallInTrigger = false; // Set the flag to false when the ball exits the trigger
            Debug.Log("Ball exited the spring trigger area.");
        }
    }
}
