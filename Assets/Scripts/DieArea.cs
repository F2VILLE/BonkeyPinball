using UnityEngine;

public class DieArea : MonoBehaviour
{
    [SerializeField] private AudioClip gameOverSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Destroy(other);
            AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
        }
    }
}
