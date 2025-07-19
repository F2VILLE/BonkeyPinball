using UnityEngine;

public class FlipBouncing : MonoBehaviour
{
    [SerializeField] private float bounceForce = 100f;
    [SerializeField] private bool reverseBounceDirection = false;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing on " + gameObject.name);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (rb != null && rb.linearVelocity.magnitude > 0.1f)
            {
                Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                if (ballRigidbody != null)
                {
                    Vector3 bounceDirection = transform.forward;
                    if (reverseBounceDirection)
                    {
                        bounceDirection = -bounceDirection;
                    }
                    Debug.Log("Bounce direction: " + bounceDirection);
                    ballRigidbody.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
                }
            }
        }
    }
}
