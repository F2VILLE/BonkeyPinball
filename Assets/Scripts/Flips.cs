using UnityEngine;

public class Flips : MonoBehaviour
{
    // flips game objects
    [SerializeField] private GameObject flipLeft;
    [SerializeField] private GameObject flipRight;

    [SerializeField] private float flipSpeed = 5f; // Speed of the flip animation

    [SerializeField] private float flipDuration = 0.5f; // Duration of the flip animation

    [SerializeField] private float flipAngle = 45f; // Angle to flip the game objects

    private float flipLeftRotatedAngle = 0f; // Current angle of the left flip
    private float flipRightRotatedAngle = 0f; // Current angle of the right

    private float flipLeftTargetAngle = 0f; // Target angle for the left flip
    private float flipRightTargetAngle = 0f; // Target angle for the right flip

    private float lastFlipLeftTime = 0f; // Last time the left flip was rotated
    private float lastFlipRightTime = 0f; // Last time the right flip was

    void Start()
    {
        // Initialize any variables or settings if needed
        Debug.Log("Flips initialized.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && flipLeftRotatedAngle > -flipAngle)
        {
            Debug.Log("Left arrow key pressed.");
            FlipLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && flipRightRotatedAngle < flipAngle)
        {
            Debug.Log("Right arrow key pressed.");
            FlipRight();
        }

        if (flipLeftRotatedAngle != flipLeftTargetAngle)
        {
            // Rotate only the Y axis for the left flip towards the target angle much faster
            float step = flipSpeed * 100f * Time.deltaTime;
            flipLeftRotatedAngle = Mathf.MoveTowards(flipLeftRotatedAngle, flipLeftTargetAngle, step);
            Vector3 leftEuler = flipLeft.transform.localEulerAngles;
            leftEuler.y = -flipLeftRotatedAngle;
            flipLeft.transform.localEulerAngles = leftEuler + 180f * Vector3.up; // Adjusting the rotation to match the desired flip direction

            // Check if the left flip has reached the target angle
            if (Mathf.Approximately(flipLeftRotatedAngle, flipLeftTargetAngle))
            {
                lastFlipLeftTime = Time.time; // Update the last flip time
                Debug.Log("Left flip completed.");
                flipLeftTargetAngle = 0f; // Reset target angle after completion
            }
        }

        if (flipRightRotatedAngle != flipRightTargetAngle)
        {
            // Rotate only the Y axis for the right flip towards the target angle much faster
            float step = flipSpeed * 100f * Time.deltaTime;
            flipRightRotatedAngle = Mathf.MoveTowards(flipRightRotatedAngle, flipRightTargetAngle, step);
            Vector3 rightEuler = flipRight.transform.localEulerAngles;
            rightEuler.y = flipRightRotatedAngle;
            flipRight.transform.localEulerAngles = rightEuler;

            // Check if the right flip has reached the target angle
            if (Mathf.Approximately(flipRightRotatedAngle, flipRightTargetAngle))
            {
                lastFlipRightTime = Time.time; // Update the last flip time
                Debug.Log("Right flip completed.");
                flipRightTargetAngle = 0f; // Reset target angle after completion
            }
            
        }


        // // Check if the left flip has been rotated more than 180 degrees
        // if (flipLeftRotatedAngle <= -flipAngle)
        // {
        //     if (Time.time - lastFlipLeftTime >= flipDuration)
        //     {
        //         // Reset the left flip rotation
        //         flipLeft.transform.Rotate(Vector3.up, flipAngle, Space.World);
        //         flipLeftRotatedAngle = 0f; // Reset the angle
        //         Debug.Log("Left flip reset after exceeding angle.");
        //     }
        // }

        // if (flipRightRotatedAngle >= flipAngle)
        // {
        //     if (Time.time - lastFlipRightTime >= flipDuration)
        //     {
        //         // Reset the right flip rotation
        //         flipRight.transform.Rotate(Vector3.up, -flipAngle, Space.World);
        //         flipRightRotatedAngle = 0f; // Reset the angle
        //         Debug.Log("Right flip reset after exceeding angle.");
        //     }
        // }
    }

    void FlipLeft()
    {
        // Rotate the left flip object
        flipLeftTargetAngle = flipAngle; // Update the target angle for the left flip
        Debug.Log("Flipped left with angle: " + flipAngle);
    }

    void FlipRight()
    {
        // Rotate the right flip object
        flipRightTargetAngle = flipAngle; // Update the target angle for the right flip

        Debug.Log("Flipped right with angle: " + flipAngle);
    }
}
