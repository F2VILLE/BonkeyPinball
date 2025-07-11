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
                Vector3 bounceDirection = (collision.transform.position - transform.position).normalized;
                ballRigidbody.AddForce(bounceDirection * 500f, ForceMode.Impulse);
            }
        }
    }
}
