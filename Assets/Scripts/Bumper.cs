using UnityEngine;

public class Bumper : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                Vector3 incomingDirection = (collision.transform.position - transform.position).normalized;
                Vector3 bounceDirection = new Vector3(incomingDirection.x, incomingDirection.y, -incomingDirection.z).normalized;
                ballRigidbody.AddForce(bounceDirection * 500f, ForceMode.Impulse);
            }
        }
    }
}
